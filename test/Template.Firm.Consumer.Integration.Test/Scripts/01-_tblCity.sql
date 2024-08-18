--_tblCity.sql
GO

/****** Object:  Table [dbo].[_tblCity]    Script Date: 8.03.2019 08:06:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[_tblCity](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[CityCountryID] [int] NOT NULL,
	[CityCode] [nvarchar](2) NOT NULL,
	[CityDescription] [nvarchar](50) NOT NULL,
	[CityOrderID] [int] NULL,
	[CityIsActive] [bit] NOT NULL,
	[CityIsDeleted] [bit] NOT NULL,
	[CityCreatedUserID] [int] NOT NULL,
	[CityCreatedDateTime] [smalldatetime] NOT NULL,
	[CityUpdatedUserID] [int] NULL,
	[CityUpdatedDateTime] [smalldatetime] NULL,
	[CitySearchCount] [int] NULL,
	[CityMigrationID] [bigint] NULL,
	[CityLatitude] [decimal](18, 15) NULL,
	[CityLongtitude] [decimal](18, 15) NULL,
	[CityOldID] [int] NULL,
	[CityBasarsoftID] [int] NULL,
	[CityBasarsoftParentID] [int] NULL,
	[CityMigrationKey] [uniqueidentifier] NULL,
	[CityDescriptionIsCustomized] [bit] NOT NULL,
	[CityTier] [int] NULL,
 CONSTRAINT [PK___tblCity__F2D21A96AC251B0D] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET IDENTITY_INSERT _tblCity ON;
GO

Insert Into _tblCity ([CityID],[CityCountryID],[CityCode],[CityDescription],[CityOrderID],[CityIsActive],[CityIsDeleted],[CityCreatedUserID],[CityCreatedDateTime],[CityUpdatedUserID],[CityUpdatedDateTime],[CitySearchCount],[CityMigrationID],[CityLatitude],[CityLongtitude],[CityOldID],[CityBasarsoftID],[CityBasarsoftParentID],[CityMigrationKey],[CityDescriptionIsCustomized],[CityTier])
Values (7,3,N'7',N'Antalya',999,1,0,1,'2010-01-14 17:09:00.000',1,'2017-06-08 19:51:00.000',541,110102000000,36.888023376464800,30.703699111938500,7,7,0,N'cf3b266d-50ae-4e39-9daa-acdf41fb2377',0,1)
,(10,3,N'10',N'Balıkesir',999,1,0,1,'2010-01-14 17:09:00.000',1,'2017-06-08 19:51:00.000',134,110801000000,39.650463104248000,27.888339996337900,10,10,0,N'cf3b266d-50ae-4e39-9daa-acdf41fb2377',0,1)
,(16,3,N'16',N'Bursa',999,1,0,1,'2010-01-14 17:09:00.000',1,'2017-06-08 19:51:00.000',150,110803000000,40.182846069335900,29.067083358764600,16,16,0,N'cf3b266d-50ae-4e39-9daa-acdf41fb2377',0,1)
,(34,3,N'34',N'İstanbul',1,1,0,1,'2010-01-14 17:09:00.000',1,'2017-06-08 19:51:00.000',3763,110806000000,41.008930206298800,28.967115402221700,34,34,0,N'cf3b266d-50ae-4e39-9daa-acdf41fb2377',0,1)
,(42,3,N'42',N'Konya',999,1,0,1,'2010-01-14 17:09:00.000',253,'2017-09-25 16:17:00.000',44,110509000000,37.874431610107400,32.492824554443400,42,42,0,N'cf3b266d-50ae-4e39-9daa-acdf41fb2377',0,1)
,(45,3,N'45',N'Manisa',999,1,0,1,'2010-01-14 17:09:00.000',253,'2018-04-11 09:39:00.000',22,110306000000,38.614070892334000,27.427600860595700,45,45,0,N'cf3b266d-50ae-4e39-9daa-acdf41fb2377',0,2)
,(59,3,N'59',N'Tekirdağ',999,1,0,1,'2010-01-14 17:09:00.000',253,'2018-04-11 10:53:00.000',73,110810000000,40.978092193603500,27.511674880981400,59,59,0,N'cf3b266d-50ae-4e39-9daa-acdf41fb2377',0,1)
,(60,3,N'60',N'Tokat',999,1,0,1,'2010-01-14 17:09:00.000',253,'2017-09-11 23:17:00.000',4,110616000000,40.315101623535200,36.551448822021500,60,60,0,N'cf3b266d-50ae-4e39-9daa-acdf41fb2377',0,2)

SET IDENTITY_INSERT _tblCity OFF;