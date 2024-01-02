Declare	@TableName	nVarchar(200)
Set	@TableName	= N'TBLNAME'

Declare	@TypeName	nVarchar(200)
Set	@TypeName	= N'TYPENAME'

Declare	@ClassName	nVarchar(200)
Set	@ClassName	= N'CLASSNAME'

Declare	@ParentNamespace	nVarchar(200)
Set	@ParentNamespace	= N'PARENTNAMESPC'

Declare	@Result			Varchar(Max)
Declare	@Properties		Varchar(Max)
Declare	@Method			Varchar(Max)
Declare	@Parameters		Varchar(Max)
Declare	@MethodParameters	Varchar(Max)
Declare	@PrimaryKey		Varchar(100)
Declare	@PrimaryKeyProp		Varchar(100)

SET NOCOUNT ON;

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

Create	Table	#items(id int identity, val nvarchar(2000))

Set	@Result	= N'#region ' + @TableName + N'

'
Print @Result

Insert #items	(val)
	values	(@Result)

Set	@Result	= N'	/*************************************************
	 *
	 * ' + @TableName + N'
	 *
	 *************************************************/
'
Print @Result

Insert #items	(val)
	values	(@Result)
------------------------------------------------------------------------------------------------------
Select	@Method	=
N'
	[WebMethod, SoapHeader("Authentication")]
	public Result ' + @TypeName + N'_Save('
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
	+ N')
	{
		Result authResult = this.IsAuthenticated(Authentication);
		if (authResult.Type != ResultType.Success)
		{
			return new Result()
			{
				Type = ResultType.Failed,
				Message = authResult.Message,
				Code = -1000
			};
		}

		' + @ParentNamespace + N'.Result result = new ' + @TypeName + N'().Save(' + @Parameters + N');
			
		return new Result()
		{
			Type = result.Type == ' + @ParentNamespace + N'.ResultType.Success ? ResultType.Success : ResultType.Failed,
			Code = result.Code,
			Message = result.Message,
			ResultObj = result.ResultObj
		};
	}
	'

Print @Method

Insert #items	(val)
	values	(@Method)
-------------------------------------------------------------------------------------------------------------------------------------------------
Select	@Method	=
N'
	[WebMethod, SoapHeader("Authentication")]
	public Result<List<' + @TypeName + N'>> ' + @TypeName + N'_SelectAll()
	{
		Result authResult = this.IsAuthenticated(Authentication);
		if (authResult.Type != ResultType.Success)
		{
			return new Result<List<' + @TypeName + N'>>()
			{
				Type = ResultType.Failed,
				Message = authResult.Message,
				Code = -1000
			};
		}

		return new Result<List<' + @TypeName + N'>>()
		{
		    Type = ResultType.Success,
		    Code = 0,
		    ResultObj = new ' + @TypeName + N'().SelectAll()
		};
	}
	'

Print @Method

Insert #items	(val)
	values	(@Method)
-------------------------------------------------------------------------------------------------------------------------------------------------
Select	@Method	=
N'
	[WebMethod, SoapHeader("Authentication")]
	public Result<' + @TypeName + N'> ' + @TypeName + N'_SelectBy' + @PrimaryKey + N'(' + @PrimaryKeyDataType + N' ' + @PrimaryKeyProp + N')
	{
		Result authResult = this.IsAuthenticated(Authentication);
		
		if (authResult.Type != ResultType.Success)
		{
			return new Result<' + @TypeName + N'>()
			{
				Type = ResultType.Failed,
				Message = authResult.Message,
				Code = -1000
			};
		}

		return new Result<' + @TypeName + N'>()
		{
		    Type = ResultType.Success,
		    Code = 0,
		    ResultObj = new ' + @TypeName + N'().SelectBy' + @PrimaryKey + N'(' + @PrimaryKeyProp + N')
		};
	}
	'

Print @Method

Insert #items	(val)
	values	(@Method)
-------------------------------------------------------------------------------------------------------------------------------------------------
Select	@Method	=
N'
	[WebMethod, SoapHeader("Authentication")]
	public Result<List<' + @TypeName + N'>> ' + @TypeName + N'_Search('
	+ STUFF(
			(Select	N', object ' + LOWER(Substring(Column_Name, 1, 1)) + Substring(Column_Name, 2, LEN(Column_Name))
				From	INFORMATION_SCHEMA.COLUMNS
				Where	TABLE_NAME	= @TableName
				For	Xml	Path(''))
		, 1, 2, '')
	+ N')
	{
		Result authResult = this.IsAuthenticated(Authentication);
		if (authResult.Type != ResultType.Success)
		{
			return new Result<List<' + @TypeName + N'>>()
			{
				Type = ResultType.Failed,
				Message = authResult.Message,
				Code = -1000
			};
		}

		return new Result<List<' + @TypeName + N'>>()
		{
		    Type = ResultType.Success,
		    Code = 0,
		    ResultObj = new ' + @TypeName + N'().Search(' + @Parameters + N')
		};
	}
	'

Print @Method

Insert #items	(val)
	values	(@Method)
-------------------------------------------------------------------------------------------------------------------------------------------------
Select	@Method	=
N'
	[WebMethod, SoapHeader("Authentication")]
	public Result ' + @TypeName + N'_DeleteBy' + @PrimaryKey + N'(' + @PrimaryKeyDataType + N' ' + @PrimaryKeyProp + N')
	{
		Result authResult = this.IsAuthenticated(Authentication);
		if (authResult.Type != ResultType.Success)
		{
			return new Result()
			{
				Type = ResultType.Failed,
				Message = authResult.Message,
				Code = -1000
			};
		}

		' + @ParentNamespace + N'.Result result = new ' + @TypeName + N'().DeleteBy' + @PrimaryKey + N'(' + @PrimaryKeyProp + N');

		return new Result()
		{
			Type = result.Type == ' + @ParentNamespace + N'.ResultType.Success ? ResultType.Success : ResultType.Failed,
			Code = result.Code,
			Message = result.Message,
			ResultObj = result.ResultObj
		};
	}
	'

Print @Method

Insert #items	(val)
	values	(@Method)
-------------------------------------------------------------------------------------------------------------------------------------------------
Set	@Result	= N'
#endregion'
Print @Result

Insert #items	(val)
	values	(@Result)
-------------------------------------------------------------------------------------------------------------------------------------------------
Select	val
	From	#items
	order by id

Drop	Table	#items

SET NOCOUNT OFF;
