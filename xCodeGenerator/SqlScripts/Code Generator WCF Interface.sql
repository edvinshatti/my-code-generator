Declare	@TableName	nVarchar(200)
Set	@TableName	= N'TBLNAME'

Declare	@TypeName	nVarchar(200)
Set	@TypeName	= N'TYPENAME'

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
					Else				N'Unknown'
				  End
				  From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_NAME	= @TableName	And
						COLUMN_NAME	= @PrimaryKey

Select	@Parameters	= 
STUFF(
		(Select	N', '
			+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
			From	INFORMATION_SCHEMA.COLUMNS
			Where	TABLE_NAME	= @TableName
			For	Xml	Path('')
		)
		, 1, 1, '')

Select	@MethodParameters	= 
STUFF(
		(Select	N', this.'
			+ Column_Name
			From	INFORMATION_SCHEMA.COLUMNS
			Where	TABLE_NAME	= @TableName
			For	Xml	Path('')
		)
		, 1, 1, '')

Create	Table	#items(id int identity, val nvarchar(2000))

Set	@Result	= N'#region ' + @TableName + N'

'
Print @Result

SET NOCOUNT ON;
Insert #items	(val)
	values	(@Result)
SET NOCOUNT OFF;

Set	@Result	= N'	/*************************************************
	 *
	 * ' + @TableName + N'
	 *
	 *************************************************/
'
 Print @Result

SET NOCOUNT ON;
Insert #items	(val)
	values	(@Result)
SET NOCOUNT OFF;


Select	@Method	=
N'
	[OperationContract]
	[XmlSerializerFormat]
	Result ' + @TypeName + N'_Save('
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
					Else				N'Unknown'
					End
				+ Case IS_NULLABLE
					When	'YES'		Then	N'?'
					Else				N''
					End
				+ N' '
				+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
				From	INFORMATION_SCHEMA.COLUMNS
				Where	TABLE_NAME	= @TableName
				For	Xml	Path(''))
		, 1, 2, '')
	+ N');
	'

Print @Method

SET NOCOUNT ON;
Insert #items	(val)
	values	(@Method)
SET NOCOUNT OFF;
-------------------------------------------------------------------------------------------------------------------------------------------------
Select	@Method	=
N'
	[OperationContract]
	[XmlSerializerFormat]
	List<' + @TypeName + N'> ' + @TypeName + N'_SelectAll();
	'

Print @Method
SET NOCOUNT ON;
Insert #items	(val)
	values	(@Method)
SET NOCOUNT OFF;
-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'
	[OperationContract]
	[XmlSerializerFormat]
	' + @TypeName + N' ' + @TypeName + N'_SelectBy' + @PrimaryKey + N'(' + @PrimaryKeyDataType + N' ' + @PrimaryKeyProp + N');
	'

Print @Method
SET NOCOUNT ON;
Insert #items	(val)
	values	(@Method)
SET NOCOUNT OFF;
-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'
	[OperationContract]
	[XmlSerializerFormat]
	List<' + @TypeName + N'> ' + @TypeName + N'_Search('
	+ STUFF(
			(Select	N', object ' + LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
				From	INFORMATION_SCHEMA.COLUMNS
				Where	TABLE_NAME	= @TableName
				For	Xml	Path(''))
		, 1, 2, '')
	+ N');
	'

Print @Method
SET NOCOUNT ON;
Insert #items	(val)
	values	(@Method)
SET NOCOUNT OFF;
-------------------------------------------------------------------------------------------------------------------------------------------------
Select	@Method	=
N'
	[OperationContract]
	[XmlSerializerFormat]
	Result ' + @TypeName + N'_DeleteBy' + @PrimaryKey + N'(' + @PrimaryKeyDataType + N' ' + @PrimaryKeyProp + N');
	'

Print @Method
SET NOCOUNT ON;
Insert #items	(val)
	values	(@Method)
SET NOCOUNT OFF;
-------------------------------------------------------------------------------------------------------------------------------------------------
Set	@Result	= N'
#endregion'
Print @Result

SET NOCOUNT ON;
Insert #items	(val)
	values	(@Result)
SET NOCOUNT OFF;
-------------------------------------------------------------------------------------------------------------------------------------------------
Select	val
	From	#items
	order by id

Drop	Table	#items