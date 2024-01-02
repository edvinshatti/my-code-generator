Declare	@TypeName		nVarchar(200)
--Set	@TypeName		= N'EstateProperty'
Declare @TablePrefix		nVarchar(200)
Set	@TablePrefix		= N'TBLPRFX'
Declare	@TableName		nVarchar(200)
--Set	@TableName		= @TablePrefix	+ @TypeName

Declare	@ProcedureType		nVarchar(100)
Set	@ProcedureType		= N'PROCTYPE'

Declare	@Result		Varchar(Max)
Declare	@PrimaryKey	nVarchar(100)

Create	Table	#tables(idx int identity primary key, tableName nvarchar(200))

SET NOCOUNT ON;

Insert	#tables
	Select	TABLE_NAME
		From	INFORMATION_SCHEMA.TABLES
		Where	TABLE_NAME	Like	@TablePrefix + N'%'
		Order	By	TABLE_NAME
--Select	tableName
--	From	#tables

SET NOCOUNT OFF;

Declare	@count	Int,
	@i	Int

Select	@count	= Max(idx)
	From	#tables

Select	@i	= Min(Idx)
	From	#tables

Create	Table	#items(val nvarchar(4000))

While	(@i <= @count)
Begin

Select	@TableName	= tableName
	From	#tables
	Where	idx	= @i

Set	@PrimaryKey	= Stuff((Select	N' ' + ccu.COLUMN_NAME
					From	INFORMATION_SCHEMA.TABLE_CONSTRAINTS		tc
							Inner	Join
						INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE	ccu
							On	tc.CONSTRAINT_NAME	= ccu.CONSTRAINT_NAME	And
								tc.TABLE_NAME	= @TableName	And
								tc.CONSTRAINT_TYPE	= 'PRIMARY KEY'
					For Xml Path('')), 1, 1, '')

Declare	@PrimaryKeyDataType	nVarchar(100)
Select	@PrimaryKeyDataType	= 	Data_Type
					From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_NAME	= @TableName	And
						COLUMN_NAME	= @PrimaryKey


Set	@Result	= N'/*************************************************
 *
 * Generated By xCode code generator
 *
 * Table: ' + @TableName + N'
 *
 *************************************************/

'
 Print @Result
 Insert #items	(val)
	values	(@Result)
/********************************
 *
 * Create
 *
 ********************************/

Select @Result = 	
@ProcedureType + N'	Procedure	dbo.' + @TableName + N'_Save'

If	@ProcedureType	<> 'Drop'
Begin

Select	@Result = @Result 
+
Replace(Stuff((Select	--N'@' 
	+ N',.@'
	+ Column_Name
	+ N'		'
	+ DATA_TYPE
	+
	Case
		When CHARACTER_MAXIMUM_LENGTH Is Null	Then	N''
		When CHARACTER_MAXIMUM_LENGTH = -1	Then	N'(Max)'
		Else						N'(' + Convert(nVarchar, CHARACTER_MAXIMUM_LENGTH) + N')'
	End
	From	INFORMATION_SCHEMA.COLUMNS
	Where	TABLE_NAME	= @TableName
	For	Xml	Path('')), 1, 1, ''), '.', CHAR(13))
+N'
As
	If	Exists	(Select	Id
				From	' + @TableName + N'
				Where	Id	= @Id)
	Begin
		Update	' + @TableName + N'
			Set	'+
				Replace(Stuff(
				(Select	N',.' + COLUMN_NAME + N'		= @' + COLUMN_NAME
					From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_NAME	= @TableName
						And	COLUMNPROPERTY(OBJECT_ID(@TableName), COLUMN_NAME, 'IsIdentity') != 1
					For Xml Path(''))
				, 1, 2, N''), '.', CHAR(13)+ N'				' )
			+'
			Where	' + 	--Id	= @Id
			@PrimaryKey + N'	= @' + @PrimaryKey
			+ N'
			
			Select	@' + @PrimaryKey + N'
			Return	0
	End
	Else
	Begin
		Insert	' + @TableName + N'	('
		+ 
			Stuff(
				(Select	N', ' + COLUMN_NAME
					From	INFORMATION_SCHEMA.COLUMNS
					Where	TABLE_NAME	= @TableName
						And	COLUMNPROPERTY(OBJECT_ID(@TableName), COLUMN_NAME, 'IsIdentity') != 1
					For Xml Path(''))
				, 1, 2, N'')
		+')
			Values			('
			+
				Stuff(
					(Select	N', @' + COLUMN_NAME
						From	INFORMATION_SCHEMA.COLUMNS
						Where	TABLE_NAME	= @TableName
							And	COLUMNPROPERTY(OBJECT_ID(@TableName), COLUMN_NAME, 'IsIdentity') != 1
						For Xml Path(''))
					, 1, 2, N'')
			
			+')
		
		Select	SCOPE_IDENTITY()
		Return	0
	End
'

End
Set	@Result = @Result + N'
GO
'

Print @Result

Insert #items	(val)
	values	(@Result)

/********************************
 *
 * Read
 *
 ********************************/
Select	@Result	=	@ProcedureType	+ N'	Procedure	dbo.' + @TableName + N'_SelectAll'

If	@ProcedureType	<> 'Drop'
Begin

Select	@Result = @Result +
N'
As
	Select	'
	+ Stuff(
		Replace(
			(Select	N',.			'
				+ Column_Name
				From	INFORMATION_SCHEMA.COLUMNS
				Where	TABLE_NAME	= @TableName
				For	Xml	Path(''))
			, '.', Char(13))
		,1, 1, '')
	+ N'
	From	'
	+ @TableName
	+ N'
'
End

Set	@Result = @Result + N'
GO
'

Print @Result

Insert #items	(val)
	values	(@Result)

---------------------------------------------------------------------------------------------------------------
Select	@Result	=	@ProcedureType	+ N'	Procedure	dbo.' + @TableName + N'_SelectById'
If	@ProcedureType	<> 'Drop'
Begin

Select	@Result = @Result +
N'
@' + @PrimaryKey	+ N'		' + @PrimaryKeyDataType
+ N'
As
	Select	'
	+ Stuff(
		Replace(
			(Select	N',.			'
				+ Column_Name
				From	INFORMATION_SCHEMA.COLUMNS
				Where	TABLE_NAME	= @TableName
				For	Xml	Path(''))
			, '.', Char(13))
		,1, 1, '')
	+ N'
	From	'
	+ @TableName
	+ N'
	Where	'
	+ @PrimaryKey
	+ N'	= @'
	+ @PrimaryKey
	+ N'
'
End

Set	@Result = @Result + N'
GO
'

Print @Result

Insert #items	(val)
	values	(@Result)

---------------------------------------------------------------------------------------------------------------------
Select	@Result	=	@ProcedureType	+ N'	Procedure	dbo.' + @TableName + N'_Search'

If	@ProcedureType	<> 'Drop'
Begin

Select	@Result = @Result +
+
Replace(Stuff((Select	--N'@' 
	+ N',.@'
	+ Column_Name
	+ N'		'
	+ DATA_TYPE
	+
	Case
		When CHARACTER_MAXIMUM_LENGTH Is Null	Then	N''
		When CHARACTER_MAXIMUM_LENGTH = -1	Then	N'(Max)'
		Else						N'(' + Convert(nVarchar, CHARACTER_MAXIMUM_LENGTH) + N')'
	End
	+ N' = NULL'
	From	INFORMATION_SCHEMA.COLUMNS
	Where	TABLE_NAME	= @TableName
	For	Xml	Path('')), 1, 1, ''), '.', CHAR(13))
+N'
As
	Select	'
	+ Stuff(
		Replace(
			(Select	N',.			'
				+ Column_Name
				From	INFORMATION_SCHEMA.COLUMNS
				Where	TABLE_NAME	= @TableName
				For	Xml	Path(''))
			, '.', Char(13))
		,1, 1, '')
	+ N'
	From	'
	+ @TableName
	+ N'
	Where
	'
	+ Replace(Stuff(Replace((Select	
				+ N'.;And		(@' + Column_Name + N' Is Null Or ' + COLUMN_NAME + N' = @' + COLUMN_NAME + N')	'
				From	INFORMATION_SCHEMA.COLUMNS
				Where	TABLE_NAME	= @TableName
				For	Xml	Path('')), '.', CHAR(13)), 1, 5, '	'), ';', N'		')
+N'

'
End

Set	@Result = @Result + N'
GO
'

Print @Result

Insert #items	(val)
	values	(@Result)

/********************************
 *
 * Delete
 *
 ********************************/
 Select	@Result	=	@ProcedureType + N'	Procedure	dbo.' + @TableName + N'_DeleteBy' + @PrimaryKey

If	@ProcedureType	<> 'Drop'
Begin

Select	@Result = @Result +
N'
@' + @PrimaryKey	+ N'		' + @PrimaryKeyDataType
+ N'
As
	Delete	From	'
	+ @TableName
	+ N'
	Where	'
	+ @PrimaryKey
	+ N'	= @'
	+ @PrimaryKey
	+ N'
'

End

Set	@Result = @Result + N'
GO
'


Print @Result

Insert #items	(val)
	values	(@Result)
----------------------------------------------------------------------------------------------
Set	@i = @i + 1

End

Drop	Table	#tables

Select	val
	From	#items

Drop	Table	#items