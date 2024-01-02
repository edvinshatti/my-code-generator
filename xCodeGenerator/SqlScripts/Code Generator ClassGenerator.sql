Declare	@Schema		nVarchar(200)
Set	@Schema		= N'SCHMNAME'

Declare	@TableName	nVarchar(200)
Set	@TableName	= N'TBLNAME'

Declare	@TypeName	nVarchar(200)
Set	@TypeName	= N'TYPENAME'

Declare	@Namespace		nVarchar(200)
Set	@Namespace		= N'NAMESPACE'

Declare	@NamespaceDataPart		nVarchar(200)
Set	@NamespaceDataPart		= N'.NSPACEDATAPART'

Declare	@ClassProps		nVarchar(200)
Set	@ClassProps		= N'CLASSATTR'

Declare	@ParentNamespace	nVarchar(200)
Set	@ParentNamespace = N'PARENTNAMESPC'

Declare	@ParentClass	nVarchar(200)
Set	@ParentClass	= N'PARENTCLASS'

Declare	@Class			nVarchar(Max)

Declare	@Result			Varchar(Max)
Declare	@Properties		Varchar(Max)
Declare	@Method			Varchar(Max)
Declare	@Parameters		Varchar(Max)
Declare	@MethodParameters	Varchar(Max)
Declare	@PrimaryKey		Varchar(100)
Declare	@PrimaryKeyProp		Varchar(100)

Set	@PrimaryKey	= Stuff((Select	N' ' + ccu.COLUMN_NAME
					From	INFORMATION_SCHEMA.TABLE_CONSTRAINTS		tc
							Inner	Join
						INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE	ccu
							On	tc.CONSTRAINT_NAME	= ccu.CONSTRAINT_NAME	And
								tc.TABLE_NAME	= @TableName	And
								tc.CONSTRAINT_TYPE	= 'PRIMARY KEY'
					For Xml Path('')), 1, 1, '')


Set	@PrimaryKeyProp	= LOWER(Substring(@PrimaryKey, 1, 1)) + Substring(@PrimaryKey, 2, LEN(@PrimaryKey))

Declare	@PrimaryKeyDataType	nVarchar(100)
--Select	@PrimaryKeyDataType	= 	Data_Type
--					From	INFORMATION_SCHEMA.COLUMNS
--					Where	TABLE_NAME	= @TableName	And
--						COLUMN_NAME	= @PrimaryKey

Select	@PrimaryKeyDataType	= Case DATA_TYPE
					When 'bigint'		Then	N'long'
					When 'int'		Then	N'int'
					When 'varchar'		Then	N'string'
					When 'nvarchar'		Then	N'string'
					When 'bit'		Then	N'bool'
					When 'DateTime'		Then	N'DateTime'
					When 'varbinary'	Then	N'byte[]'
					When 'image'		Then	N'byte[]'
					When 'UniqueIdentifier'	Then	N'Guid'
					When 'decimal'		Then	N'decimal'
					When 'float'		Then	N'float'
					Else				N'Unknown'
				  End
				  From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_SCHEMA	= @Schema	And
						TABLE_NAME	= @TableName	And
						COLUMN_NAME	= @PrimaryKey

Select	@Parameters	= 
STUFF(
		(Select	N', '
			+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
			From	INFORMATION_SCHEMA.COLUMNS
			Where	TABLE_SCHEMA	= @Schema	And
				TABLE_NAME	= @TableName
			For	Xml	Path('')
		)
		, 1, 1, '')

Select	@MethodParameters	= 
STUFF(
		(Select	N', this.'
			+ Column_Name
			From	INFORMATION_SCHEMA.COLUMNS
			Where	TABLE_SCHEMA	= @Schema	And
				TABLE_NAME	= @TableName
			For	Xml	Path('')
		)
		, 1, 1, '')


Create	Table	#items(id int identity, val nvarchar(Max))

/********************************
 *
 * Class
 *
 ********************************/
 

Select	@Properties =	
Replace(
		STUFF(
			(Select
N'[NEWLINE][NEWLINE][TAB][TAB][DataMember]
[TAB][TAB][TableField]
[TAB][TAB]public '
			+ Case DATA_TYPE
				When 'bigint'		Then	N'long'
				When 'int'		Then	N'int'
				When 'varchar'		Then	N'string'
				When 'nvarchar'		Then	N'string'
				When 'bit'		Then	N'bool'
				When 'DateTime'		Then	N'DateTime'
				When 'varbinary'	Then	N'byte[]'
				When 'image'		Then	N'byte[]'
				When 'UniqueIdentifier'	Then	N'Guid'
				When 'decimal'		Then	N'decimal'
				When 'float'		Then	N'float'
				Else				N'Unknown'
			End
			+ Case 
				When	IS_NULLABLE = 'YES' And DATA_TYPE	 In ('varchar', 'nvarchar', 'varbinary')		Then	N''
				When	IS_NULLABLE = 'YES'																	Then	N'?'
				Else																								N''
				End
			+ N' '
			+ Column_Name
			+ N' { get; set; }'
			From	INFORMATION_SCHEMA.COLUMNS
			Where	TABLE_SCHEMA	= @Schema	And
				TABLE_NAME	= @TableName
			For	Xml Path('')
), 1, 9, '')
, '&#x0D;', N'')


--Print @Properties
-------------------------------------------------------------------------------------------------------------------------------------------------

--Set	@Class	= N'using ' + @ParentNamespace + N';
Set	@Class	= N'namespace ' + @Namespace + @NamespaceDataPart + N'
{
[TAB]using System;
[TAB]using System.Collections.Generic;
[TAB]using System.Runtime.Serialization;

[TAB]using CommonObject;

[TAB]using ' + @Namespace + N'.Attributes;

' + @ClassProps + N'
[TAB]public partial class ' + @TypeName + N' : ' + @ParentClass + N'
[TAB]{'
--Set	@Class	= @Class + @Properties
Print @Class

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Class)

SET NOCOUNT OFF;

Print @Properties

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Properties)

SET NOCOUNT OFF;



Select	@Method	=
N'[NEWLINE][NEWLINE][TAB][TAB]public Result Save('
		+ STUFF(
				(Select	N', '
					+ Case DATA_TYPE
						When 'bigint'		Then	N'long'
						When 'int'		Then	N'int'
						When 'varchar'		Then	N'string'
						When 'nvarchar'		Then	N'string'
						When 'bit'		Then	N'bool'
						When 'DateTime'		Then	N'DateTime'
						When 'varbinary'	Then	N'byte[]'
						When 'image'		Then	N'byte[]'
						When 'UniqueIdentifier'	Then	N'Guid'
						When 'decimal'		Then	N'decimal'
						When 'float'		Then	N'float'
						Else				N'Unknown'
						End
					+ Case 
						When	IS_NULLABLE = 'YES' And DATA_TYPE In ('varchar', 'nvarchar', 'varbinary')			Then	N''
						When	IS_NULLABLE = 'YES'																	Then	N'?'
						Else																								N''
						End
					+ N' '
					+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
					From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_SCHEMA	= @Schema	And
						TABLE_NAME	= @TableName
					For	Xml	Path(''))
			, 1, 2, '')
		+ N')
[TAB][TAB]{
[TAB][TAB][TAB]return this.Execute("' + @Schema + N'.' + @TableName + N'_Save",' + @Parameters + N');
[TAB][TAB]}[NEWLINE]'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'[NEWLINE][TAB][TAB]public Result<object> SaveScalar('
		+ STUFF(
				(Select	N', '
					+ Case DATA_TYPE
						When 'bigint'		Then	N'long'
						When 'int'		Then	N'int'
						When 'varchar'		Then	N'string'
						When 'nvarchar'		Then	N'string'
						When 'bit'		Then	N'bool'
						When 'DateTime'		Then	N'DateTime'
						When 'varbinary'	Then	N'byte[]'
						When 'image'		Then	N'byte[]'
						When 'UniqueIdentifier'	Then	N'Guid'
						When 'decimal'		Then	N'decimal'
						When 'float'		Then	N'float'
						Else				N'Unknown'
						End
					+ Case 
						When	IS_NULLABLE = 'YES' And DATA_TYPE In ('varchar', 'nvarchar', 'varbinary')			Then	N''
						When	IS_NULLABLE = 'YES'																	Then	N'?'
						Else																								N''
						End
					+ N' '
					+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
					From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_SCHEMA	= @Schema	And
						TABLE_NAME	= @TableName
					For	Xml	Path(''))
			, 1, 2, '')
		+ N')
[TAB][TAB]{
[TAB][TAB][TAB]return this.ExecuteScalar<object>("' + @Schema + N'.' + @TableName + N'_Save",' + @Parameters + N');
[TAB][TAB]}[NEWLINE]'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'[NEWLINE][TAB][TAB]public Result Save()
[TAB][TAB]{
[TAB][TAB][TAB]return this.Execute("' + @Schema + N'.' + @TableName + N'_Save",' + @MethodParameters + N');
[TAB][TAB]}[NEWLINE]'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'[NEWLINE][TAB][TAB]public Result<object> SaveScalar()
[TAB][TAB]{
[TAB][TAB][TAB]return this.ExecuteScalar<object>("' + @Schema + N'.' + @TableName + N'_Save",' + @MethodParameters + N');
[TAB][TAB]}[NEWLINE]'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'[NEWLINE][TAB][TAB]public List<' + @TypeName + N'> SelectAll()
[TAB][TAB]{
[TAB][TAB][TAB]return this.SelectList<' + @TypeName + '>("' + @Schema + N'.' + @TableName + N'_SelectAll");
[TAB][TAB]}[NEWLINE]'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'[NEWLINE][TAB][TAB]public ' + @TypeName + N' SelectBy' + @PrimaryKey + N'(' + @PrimaryKeyDataType + N' ' + @PrimaryKeyProp + N')
[TAB][TAB]{
[TAB][TAB][TAB]return this.SelectSingle<' + @TypeName + '>("' + @Schema + N'.' + @TableName + N'_SelectBy' + @PrimaryKey + N'", ' + @PrimaryKeyProp + N');
[TAB][TAB]}[NEWLINE]'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'[NEWLINE][TAB][TAB]public List<' + @TypeName + N'> Search('
		+ STUFF(
				(Select	N', object ' + LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name)) + N' = null'
					From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_SCHEMA	= @Schema	And
						TABLE_NAME	= @TableName
					For	Xml	Path(''))
			, 1, 2, '')
		+ N')[NEWLINE][TAB][TAB]{'
		+	Replace((Select	N',[TAB][TAB][TAB]'	+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
					+ N' = '
					+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
					+ N' ?? '
					--+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
					--+ N' : DBNull.Value;'
					+ N'DBNull.Value;'
					From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_SCHEMA	= @Schema	And
						TABLE_NAME	= @TableName
					For	Xml	Path('')), ',', Char(13) + CHAR(10))
		+	N'[NEWLINE][NEWLINE][TAB][TAB][TAB]return this.SelectList<' + @TypeName + '>("' + @Schema + N'.' + @TableName + N'_Search",' + @Parameters + N');[NEWLINE][TAB][TAB]}[NEWLINE]'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'[NEWLINE][TAB][TAB]public Result DeleteBy' + @PrimaryKey + N'(' + @PrimaryKeyDataType + N' ' + @PrimaryKeyProp + N')
[TAB][TAB]{
[TAB][TAB][TAB]return this.Execute("' + @Schema + N'.' + @TableName + N'_DeleteBy' + @PrimaryKey + N'", ' + @PrimaryKeyProp + N');
[TAB][TAB]}[NEWLINE]'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'[NEWLINE][TAB][TAB]public Result LogicalDeleteBy' + @PrimaryKey + N'(' + @PrimaryKeyDataType + N' ' + @PrimaryKeyProp + N')
[TAB][TAB]{
[TAB][TAB][TAB]return this.Execute("' + @Schema + N'.' + @TableName + N'_LogicalDeleteBy' + @PrimaryKey + N'", ' + @PrimaryKeyProp + N');
[TAB][TAB]}'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Set	@Class = N'[NEWLINE][TAB]}[NEWLINE]}[NEWLINE]'

Print	@Class

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Class)

SET NOCOUNT OFF;

Select	val
	From	#items
	order by id

Drop	Table	#items