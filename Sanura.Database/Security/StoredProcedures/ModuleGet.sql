CREATE PROCEDURE [Security].[ModuleGet]
	@idModule int = null,
	@Code nvarchar(50)=null,
	@active bit = null,
	@pageNumber int= 1,
	@pageSize int= 100,
	@orderByColumn VARCHAR(80) = null,   
	@sortType TINYINT = 0
 AS
BEGIN
	SET @orderByColumn = UPPER(@orderByColumn);	

	DECLARE @table table(rowNumber int not null,
						 idModule int not null,
						 idModuleParent int null,
						 Code nvarchar(50) not null,
						 Description nvarchar(100) not null,
						 SortOrder float null,
						 Icon nvarchar(50) null,
						 Active bit not null,
						 CreationDateTime datetimeoffset not null,
						 CreatedByIdUser int not null,
						 UpdateDateTime datetimeoffset null,
						 UpdateByIdUser int null
						)
	insert into @table
	SELECT ROW_NUMBER() OVER
				   (
					ORDER BY    
						CASE when @sortType = 1 then ''					WHEN @orderByColumn is NULL					then idModule				end asc   
					   ,CASE when @sortType = 0 then ''					WHEN @orderByColumn IS NULL					then idModule				end desc
					   ,CASE when @sortType = 1 then ''					WHEN @orderByColumn = 'CODE'				then Code					end asc   
					   ,CASE when @sortType = 0 then ''					WHEN @orderByColumn = 'CODE'				then Code					end desc    
				   ), 
				   * 
			  from [Security].[Module]
	where 
			(@idModule is null or idModule = @idModule)
		and (@Code is null or Code = @Code)
		and (@active is  null or [Active] = @active)

	declare @initialId int = ((@pageNumber-1) * @pageSize) +1
	declare @finalId int = (@pageNumber) * @pageSize

	if(@pageNumber = 0)
		select @finalId =count(rowNumber) from @table

	select *
		from @table
		where rowNumber >= @initialId and rowNumber<= @finalId

	select distinct * from
	(
		select u.* from [Security].[User] u
		inner join @table t on t.CreatedByIdUser = u.idUser
		where rowNumber >= @initialId and rowNumber<= @finalId
		union
		select u.* from [Security].[User] u
		inner join @table t on t.UpdateByIdUser = u.idUser
		where rowNumber >= @initialId and rowNumber<= @finalId
	) users

	select count(rowNumber) [count] from @table
END