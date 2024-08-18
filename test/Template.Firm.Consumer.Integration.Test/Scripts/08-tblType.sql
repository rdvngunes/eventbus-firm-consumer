--tblType.sql

/****** Object:  Table [dbo].[tblType]    Script Date: 8.03.2019 08:22:48 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[tblType](
	[TypeID] [int] NOT NULL,
	[TypeParentID] [int] NULL,
	[TypeOrder] [int] NULL,
	[TypeDescription] [nvarchar](100) NOT NULL,
	[TypeMigrationID] [bigint] NULL,
	[TypeIsActive] [bit] NOT NULL,
	[TypeCreatedUserID] [int] NOT NULL,
	[TypeCreatedDateTime] [datetime] NOT NULL,
	[TypeUpdatedUserID] [int] NULL,
	[TypeUpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_tblType] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[tblType] ADD  CONSTRAINT [DF_tblType_TypeIsActive]  DEFAULT ((1)) FOR [TypeIsActive]

ALTER TABLE [dbo].[tblType] ADD  CONSTRAINT [DF_tblType_TypeCreatedDateTime]  DEFAULT (getdate()) FOR [TypeCreatedDateTime]

--ALTER TABLE [dbo].[tblType]  WITH CHECK ADD  CONSTRAINT [FK_tblType_tblTypeParent] FOREIGN KEY([TypeParentID])
--REFERENCES [dbo].[tblType] ([TypeID])

Insert Into tblType ([TypeID],[TypeParentID],[TypeOrder],[TypeDescription],[TypeMigrationID],[TypeIsActive],[TypeCreatedUserID],[TypeCreatedDateTime],[TypeUpdatedUserID],[TypeUpdatedDateTime])
Values (105401,1054,1,N'Emlak Ofisi',1,1,1,'2011-01-01 00:00:00.000',NULL,NULL)
,(105403,1054,3,N'İnşaat Firması',20,1,1,'2011-01-01 00:00:00.000',NULL,NULL)
,(105408,1054,5,N'Emlakçılar Odası',NULL,0,1,'2011-01-01 00:00:00.000',NULL,NULL)
,(105409,1054,6,N'Ticaret Odası',NULL,0,1,'2011-01-01 00:00:00.000',NULL,NULL)
,(105410,1054,7,N'Emlak Organizasyonu',NULL,0,1,'2011-01-01 00:00:00.000',NULL,NULL)