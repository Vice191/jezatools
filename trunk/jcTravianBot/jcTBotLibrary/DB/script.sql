USE [jcTBot]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Priority]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Priority](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PriorityName] [nvarchar](50) NOT NULL,
	[PriorityLevel] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuildingGIDs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BuildingGIDs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuildingName] [nvarchar](50) NOT NULL,
	[BuildingGID] [int] NOT NULL,
 CONSTRAINT [PK_BuildingGIDs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Villages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Villages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageId] [int] NOT NULL,
	[VillageName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Villages_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TaskList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
	[BuildLevel] [int] NOT NULL,
	[BuildPriority] [int] NOT NULL,
	[NextCheck] [datetime] NOT NULL,
 CONSTRAINT [PK_TaskList_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Production]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Production](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[Warehouse] [int] NULL,
	[Granary] [int] NULL,
	[Wood] [int] NULL,
	[Clay] [int] NULL,
	[Iron] [int] NULL,
	[Crop] [int] NULL,
	[WoodPerHour] [int] NULL,
	[ClayPerHour] [int] NULL,
	[IronPerHour] [int] NULL,
	[CropPerHour] [int] NULL,
 CONSTRAINT [PK_Production_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Resources]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Resources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[ResourcesId] [int] NULL,
	[ResourcesName] [nvarchar](50) NULL,
	[ResourcesLevel] [int] NULL,
 CONSTRAINT [PK_Resources_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Buildings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[BuildingId] [int] NULL,
	[BuildingName] [nvarchar](50) NULL,
	[BuildingLevel] [int] NULL,
 CONSTRAINT [PK_Buildings_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductionForVillages]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 12.09.2008
-- Description:	Get production, warehouse and granary capacity
-- =============================================
CREATE PROCEDURE [dbo].[GetProductionForVillages] 
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [Id]
      ,(SELECT [VillageName] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[Id] = [jcTBot].[dbo].[Production].[VillageID]) AS VillageName
      ,(SELECT [VillageId] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[Id] = [jcTBot].[dbo].[Production].[VillageID]) AS VillageId
      ,[Warehouse]
      ,[Granary]
      ,[Wood]
      ,[Clay]
      ,[Iron]
      ,[Crop]
      ,[WoodPerHour]
      ,[ClayPerHour]
      ,[IronPerHour]
      ,[CropPerHour]
  FROM [jcTBot].[dbo].[Production]	
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertProduction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 14.09.2008
-- Description:	Inserts production values for village
-- =============================================
CREATE PROCEDURE [dbo].[InsertProduction] 
           (@VillageID int
           ,@Warehouse int
           ,@Granary int
           ,@Wood int
           ,@Clay int
           ,@Iron int
           ,@Crop int
           ,@WoodPerHour int
           ,@ClayPerHour int
           ,@IronPerHour int
           ,@CropPerHour int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @villID int;
	SET @villID = (SELECT [Id] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[VillageId] = @VillageID);
INSERT INTO [jcTBot].[dbo].[Production]
           ([VillageID]
           ,[Warehouse]
           ,[Granary]
           ,[Wood]
           ,[Clay]
           ,[Iron]
           ,[Crop]
           ,[WoodPerHour]
           ,[ClayPerHour]
           ,[IronPerHour]
           ,[CropPerHour])
     VALUES
           (@villID
           ,@Warehouse
           ,@Granary
           ,@Wood
           ,@Clay
           ,@Iron
           ,@Crop
           ,@WoodPerHour
           ,@ClayPerHour
           ,@IronPerHour
           ,@CropPerHour)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteAllFromProduction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 18.09.2008
-- Description:	Deletes everything in Production table
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAllFromProduction]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [jcTBot].[dbo].[Production]
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertResources]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 14.09.2008
-- Description:	Inserts resources values for village
-- =============================================
CREATE PROCEDURE [dbo].[InsertResources] 
           (@VillageID int
           ,@ResourcesId int
           ,@ResourcesName nvarchar(50)
           ,@ResourcesLevel int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @villID int;
	SET @villID = (SELECT [Id] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[VillageId] = @VillageID);

INSERT INTO [jcTBot].[dbo].[Resources]
           ([VillageID]
           ,[ResourcesId]
           ,[ResourcesName]
           ,[ResourcesLevel])
     VALUES
           (@villID
           ,@ResourcesId
           ,@ResourcesName
           ,@ResourcesLevel)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteAllFromResources]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 18.09.2008
-- Description:	Deletes everything from Resources
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAllFromResources] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [jcTBot].[dbo].[Resources]
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetResourcesForVillage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 18.09.2008
-- Description:	Get resources for village
-- =============================================
CREATE PROCEDURE [dbo].[GetResourcesForVillage] 
           (@VillageID int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [Id]
      ,(SELECT [VillageId] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[Id] = [jcTBot].[dbo].[Resources].[VillageID]) AS VillageId
      ,(SELECT [VillageName] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[Id] = [jcTBot].[dbo].[Resources].[VillageID]) AS VillageName
      ,[ResourcesId]
      ,[ResourcesName]
      ,[ResourcesLevel]
  FROM [jcTBot].[dbo].[Resources]
WHERE [VillageID] = @VillageID
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertTask]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Insert new task
-- =============================================
CREATE PROCEDURE [dbo].[InsertTask] 
	-- Add the parameters for the stored procedure here
	(@VillageId int
	,@TaskId int
	,@BuildLevel int 
	,@BuildPriority int 
	,@NextCheck datetime)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [jcTBot].[dbo].[TaskList]
           ([VillageID]
           ,[TaskId]
           ,[BuildLevel]
           ,[BuildPriority]
           ,[NextCheck])
     VALUES
           (@VillageId
           ,@TaskId
           ,@BuildLevel
           ,@BuildPriority
           ,@NextCheck)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBuildingsGIDsNamesAndIDs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 14.09.2008
-- Description:	Gets buildings GIDs andresources IDs
-- =============================================
CREATE PROCEDURE [dbo].[GetBuildingsGIDsNamesAndIDs] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id], [BuildingName] FROM [jcTBot].[dbo].[BuildingGIDs]
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaskNames]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 12.09.2008
-- Description:	Get available task names
-- =============================================
CREATE PROCEDURE [dbo].[GetTaskNames] 
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [TaskName] FROM [jcTBot].[dbo].[Tasks]
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaskNamesAndIDs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 14.09.2008
-- Description:	Get available task names and ids
-- =============================================
CREATE PROCEDURE [dbo].[GetTaskNamesAndIDs] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id], [TaskName] FROM [jcTBot].[dbo].[Tasks]
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaskList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Get current tasks list
-- =============================================
CREATE PROCEDURE [dbo].[GetTaskList]
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [Id]
      ,(SELECT [VillageName] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[Id] = [jcTBot].[dbo].[TaskList].[VillageID]) AS VillageName
      ,(SELECT [TaskName] FROM [jcTBot].[dbo].[Tasks] WHERE [jcTBot].[dbo].[Tasks].[Id] = [jcTBot].[dbo].[TaskList].[TaskId]) AS TaskName
      ,[BuildLevel]
      ,[NextCheck]
  FROM [jcTBot].[dbo].[TaskList]
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateVillageName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 16.09.2008
-- Description:	Insert new village
-- =============================================
CREATE PROCEDURE [dbo].[UpdateVillageName]
	(@VillageId int
	,@VillageName nvarchar(50))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

UPDATE [jcTBot].[dbo].[Villages]
   SET [VillageName] = @VillageName
 WHERE [VillageId] = @VillageId
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertVillage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Insert new village
-- =============================================
CREATE PROCEDURE [dbo].[InsertVillage] 
	-- Add the parameters for the stored procedure here
	(@VillageId int
	,@VillageName nvarchar(50))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF NOT EXISTS (SELECT [VillageId] FROM [jcTBot].[dbo].[Villages] WHERE @VillageId = [dbo].[Villages].[VillageId])
INSERT INTO [jcTBot].[dbo].[Villages]
           ([VillageId]
           ,[VillageName])
     VALUES
           (@VillageId
           ,@VillageName)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVillagesNamesAndIDs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Gets Villages (Names and IDs) list
-- =============================================
CREATE PROCEDURE [dbo].[GetVillagesNamesAndIDs] 
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [VillageId], [VillageName] FROM [dbo].[Villages]
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVillageNames]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 14.09.2008
-- Description:	Gets villages names
-- =============================================
CREATE PROCEDURE [dbo].[GetVillageNames] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [VillageName] FROM [jcTBot].[dbo].[Villages]
END
' 
END
GO
USE [jcTBot]
GO
USE [jcTBot]
GO
USE [jcTBot]
GO
USE [jcTBot]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TaskList_Tasks]') AND parent_object_id = OBJECT_ID(N'[dbo].[TaskList]'))
ALTER TABLE [dbo].[TaskList]  WITH CHECK ADD  CONSTRAINT [FK_TaskList_Tasks] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TaskList_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[TaskList]'))
ALTER TABLE [dbo].[TaskList]  WITH CHECK ADD  CONSTRAINT [FK_TaskList_Villages] FOREIGN KEY([VillageID])
REFERENCES [dbo].[Villages] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Production_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[Production]'))
ALTER TABLE [dbo].[Production]  WITH CHECK ADD  CONSTRAINT [FK_Production_Villages] FOREIGN KEY([VillageID])
REFERENCES [dbo].[Villages] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Resources_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[Resources]'))
ALTER TABLE [dbo].[Resources]  WITH CHECK ADD  CONSTRAINT [FK_Resources_Villages] FOREIGN KEY([VillageID])
REFERENCES [dbo].[Villages] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Buildings_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_Villages] FOREIGN KEY([VillageID])
REFERENCES [dbo].[Villages] ([Id])
