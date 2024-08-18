--tblUser.sql
GO

/****** Object:  Table [dbo].[tblUser]    Script Date: 8.03.2019 08:28:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserFirstname] [nvarchar](50) NULL,
	[UserLastname] [nvarchar](50) NULL,
	[UserName] [nvarchar](20) NULL,
	[UserPassword] [nvarchar](24) NULL,
	[UserRoleID] [int] NULL,
	[UserEmail] [nvarchar](50) NULL,
	[UserIsDeleted] [bit] NOT NULL,
	[UserCreatedUserID] [int] NOT NULL,
	[UserCreatedDateTime] [datetime] NOT NULL,
	[UserUpdatedUserID] [int] NULL,
	[UserUpdatedDateTime] [datetime] NULL,
	[UserIsAdmin] [bit] NULL,
	[UserIsActive] [bit] NULL,
	[UserPasswordLastUpdateDateTime] [datetime] NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_UserIsDeleted]  DEFAULT ((0)) FOR [UserIsDeleted]
GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_UserCreatedDateTime]  DEFAULT (getdate()) FOR [UserCreatedDateTime]
GO

ALTER TABLE [dbo].[tblUser] ADD  CONSTRAINT [DF_tblUser_UserIsActive]  DEFAULT ((1)) FOR [UserIsActive]
GO

--ALTER TABLE [dbo].[tblUser]  WITH CHECK ADD  CONSTRAINT [FK_tblUser_tblRole] FOREIGN KEY([UserRoleID])
--REFERENCES [dbo].[tblRole] ([RoleID])
--GO

--ALTER TABLE [dbo].[tblUser] CHECK CONSTRAINT [FK_tblUser_tblRole]
--GO

SET IDENTITY_INSERT tblUser ON;


Insert Into tblUser ([UserID],[UserFirstname],[UserLastname],[UserName],[UserPassword],[UserRoleID],[UserEmail],[UserIsDeleted],[UserCreatedUserID],[UserCreatedDateTime],[UserUpdatedUserID],[UserUpdatedDateTime],[UserIsAdmin],[UserIsActive],[UserPasswordLastUpdateDateTime])
Values (1,N'admin',N'admin',N'admin',N'NAam3lK5fRaF9XROcJm/jg==',1,N'admin@admin.com                                   ',1,1,'2010-03-28 00:00:00.000',1,'2018-06-18 09:00:00.520',NULL,1,'2018-06-18 09:00:00.520')

SET IDENTITY_INSERT tblUser OFF;
