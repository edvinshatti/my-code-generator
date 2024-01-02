Declare	@TableName	nVarchar(200)
Set	@TableName	= N'TBLNAME'

Declare	@TypeName	nVarchar(200)
Set	@TypeName	= N'TYPENAME'

Declare	@Namespace		nVarchar(200)
Set	@Namespace		= N'NAMESPACE'

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


Create	Table	#items(id int identity, val nvarchar(4000))

/********************************
 *
 * Class
 *
 ********************************/
 
Select	@Properties =
Replace(
		(Select	
    		N'.		PROPATTR.		public '
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
				+ Case 
					When	IS_NULLABLE = 'YES' And DATA_TYPE	 In ('varchar', 'nvarchar', 'varbinary')		Then	N''
					When	IS_NULLABLE = 'YES'																	Then	N'?'
					Else																								N''
					End
				+ N' '
				+ Column_Name
				+ N' { get; set; }'
				From	INFORMATION_SCHEMA.COLUMNS
				Where	TABLE_NAME	= @TableName
				For	Xml Path('')
		)
		, '.', Char(13) + Char(10))

--Print @Properties
-------------------------------------------------------------------------------------------------------------------------------------------------

--Set	@Class	= N'using ' + @ParentNamespace + N';
Set	@Class	= N'using CommonObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ' + @Namespace + N'
{
	' + @ClassProps + N'
	public partial class ' + @TypeName + N' : ' + @ParentClass + N'
	{'
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
N'
		
		public Result Save('
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
					+ Case 
						When	IS_NULLABLE = 'YES' And DATA_TYPE In ('varchar', 'nvarchar', 'varbinary')			Then	N''
						When	IS_NULLABLE = 'YES'																	Then	N'?'
						Else																								N''
						End
					+ N' '
					+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
					From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_NAME	= @TableName
					For	Xml	Path(''))
			, 1, 2, '')
		+ N')
		{
			return this.Execute("' + @TableName + N'_Save",' + @Parameters + N');
		}'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'
		public Result<object> SaveScalar('
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
					+ Case 
						When	IS_NULLABLE = 'YES' And DATA_TYPE In ('varchar', 'nvarchar', 'varbinary')			Then	N''
						When	IS_NULLABLE = 'YES'																	Then	N'?'
						Else																								N''
						End
					+ N' '
					+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
					From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_NAME	= @TableName
					For	Xml	Path(''))
			, 1, 2, '')
		+ N')
		{
			return this.ExecuteScalar<object>("' + @TableName + N'_Save",' + @Parameters + N');
		}'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'
		public Result Save()
		{
			return this.Execute("' + @TableName + N'_Save",' + @MethodParameters + N');
		}'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'
		public List<' + @TypeName + N'> SelectAll()
		{
			return this.SelectList<' + @TypeName + '>("' + @TableName + N'_SelectAll");
		}'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'
		public ' + @TypeName + N' SelectBy' + @PrimaryKey + N'(' + @PrimaryKeyDataType + N' ' + @PrimaryKeyProp + N')
		{
			return this.SelectSingle<' + @TypeName + '>("' + @TableName + N'_SelectBy' + @PrimaryKey + N'", ' + @PrimaryKeyProp + N');
		}'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'
		public List<' + @TypeName + N'> Search('
		+ STUFF(
				(Select	N', object ' + LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
					From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_NAME	= @TableName
					For	Xml	Path(''))
			, 1, 2, '')
		+ N')
		{'
		+	Replace((Select	N',			'	+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
					+ N' = '
					+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
					+ N' != null ? '
					+ LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
					+ N' : DBNull.Value;'
					From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_NAME	= @TableName
					For	Xml	Path('')), ',', Char(13) + CHAR(10))
		+	N'

			return this.SelectList<' + @TypeName + '>("' + @TableName + N'_Search",' + @Parameters + N');
		}'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Select	@Method	=
N'
		public Result DeleteBy' + @PrimaryKey + N'(' + @PrimaryKeyDataType + N' ' + @PrimaryKeyProp + N')
		{
			return this.Execute("' + @TableName + N'_DeleteBy' + @PrimaryKey + N'", ' + @PrimaryKeyProp + N');
		}'

Print @Method

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Method)

SET NOCOUNT OFF;

-------------------------------------------------------------------------------------------------------------------------------------------------

Set	@Class = N'
	}
}'

Print	@Class

SET NOCOUNT ON;

Insert #items	(val)
	values	(@Class)

SET NOCOUNT OFF;

Select	val
	From	#items
	order by id

Drop	Table	#items