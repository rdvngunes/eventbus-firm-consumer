--tblFirmSummary.sql
GO

/****** Object:  Table [dbo].[tblFirmSummary]    Script Date: 8.03.2019 08:24:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFirmSummary](
	[FirmSummaryID] [int] IDENTITY(1,1) NOT NULL,
	[FirmSummaryFirmID] [int] NULL,
	[FirmSummaryFirmPackageID] [int] NULL,
	[FirmSummaryStartDate] [datetime] NULL,
	[FirmSummaryEndDate] [datetime] NULL,
	[FirmSummaryRealtyQty] [int] NULL,
	[FirmSummaryAdvisorQty] [int] NULL,
	[FirmSummaryIsExtraTime] [bit] NULL,
	[FirmSummaryIsDeleted] [bit] NOT NULL,
	[FirmSummaryCreatedUserID] [int] NOT NULL,
	[FirmSummaryCreatedDateTime] [datetime] NOT NULL,
	[FirmSummaryUpdatedUserID] [int] NULL,
	[FirmSummaryUpdatedDateTime] [datetime] NULL,
	[FirmSummaryRealtyImageQty] [int] NULL,
	[FirmSummaryRealtyProductDiscount] [decimal](5, 2) NULL,
	[FirmSummaryHasWebsiteService] [bit] NULL,
	[FirmSummaryIsVipPackage] [bit] NULL,
	[FirmSummaryExtraTimeCount] [int] NULL,
	[FirmSummaryPackageIsCommitment] [bit] NULL,
	[FirmSummaryPackagePaymentIsAwaiting] [bit] NULL,
	[FirmSummaryOriginalEndDate] [datetime] NULL,
	[FirmSummaryPackageCategoryTypeID] [int] NULL,
	[FirmSummaryFirmChamberID] [nvarchar](20) NULL,
	[FirmSummaryPackageIsFirmChamberPackage] [bit] NULL,
	[FirmSummaryExtraDay] [int] NULL,
 CONSTRAINT [PK_tblFirmSummary] PRIMARY KEY CLUSTERED 
(
	[FirmSummaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblFirmSummary] ADD  CONSTRAINT [DF_tblFirmSummary_FirmSummaryIsDeleted]  DEFAULT ((0)) FOR [FirmSummaryIsDeleted]
GO

ALTER TABLE [dbo].[tblFirmSummary] ADD  CONSTRAINT [DF_tblFirmSummary_FirmSummaryCreatedDateTime]  DEFAULT (getdate()) FOR [FirmSummaryCreatedDateTime]
GO

ALTER TABLE [dbo].[tblFirmSummary]  WITH CHECK ADD  CONSTRAINT [FK_tblFirmSummary_tblFirm] FOREIGN KEY([FirmSummaryFirmID])
REFERENCES [dbo].[tblFirm] ([FirmID])
GO

ALTER TABLE [dbo].[tblFirmSummary] CHECK CONSTRAINT [FK_tblFirmSummary_tblFirm]
GO

SET IDENTITY_INSERT tblFirmSummary ON;

Insert Into tblFirmSummary ([FirmSummaryID],[FirmSummaryFirmID],[FirmSummaryFirmPackageID],[FirmSummaryStartDate],[FirmSummaryEndDate],[FirmSummaryRealtyQty],[FirmSummaryAdvisorQty],[FirmSummaryIsExtraTime],[FirmSummaryIsDeleted],[FirmSummaryCreatedUserID],[FirmSummaryCreatedDateTime],[FirmSummaryUpdatedUserID],[FirmSummaryUpdatedDateTime],[FirmSummaryRealtyImageQty],[FirmSummaryRealtyProductDiscount],[FirmSummaryHasWebsiteService],[FirmSummaryIsVipPackage],[FirmSummaryExtraTimeCount],[FirmSummaryPackageIsCommitment],[FirmSummaryPackagePaymentIsAwaiting],[FirmSummaryOriginalEndDate],[FirmSummaryPackageCategoryTypeID],[FirmSummaryFirmChamberID],[FirmSummaryPackageIsFirmChamberPackage],[FirmSummaryExtraDay])
Values (698615,54026,755786,'2014-01-27 17:32:55.397','2015-01-27 17:32:55.397',200,15,NULL,0,1016577,'2014-01-27 17:32:55.400',NULL,NULL,15,10.00,NULL,0,NULL,NULL,NULL,NULL,181304,NULL,NULL,NULL)
,(698616,54027,818429,'2014-01-27 17:44:20.430','2019-06-27 17:58:45.357',400,30,NULL,0,1016578,'2014-01-27 17:44:20.437',1016578,'2019-02-01 12:00:55.797',30,NULL,1,1,NULL,1,0,NULL,181313,NULL,0,NULL)
,(698665,54037,781829,'2014-02-04 19:16:39.900','2017-03-21 15:05:31.430',250,10,NULL,0,1016684,'2014-02-04 19:16:39.903',1016684,'2016-07-12 10:02:27.107',20,10.00,1,0,3,1,0,NULL,181303,NULL,NULL,NULL)
,(698627,54039,755846,'2014-01-30 11:29:50.333','2016-05-10 11:29:50.333',450,20,NULL,0,1016724,'2014-01-30 11:29:50.340',NULL,'2016-04-30 12:00:01.050',20,20.00,1,0,NULL,NULL,NULL,'2016-04-30 11:29:50.333',181303,NULL,NULL,NULL)
,(698632,54040,755864,'2014-01-30 15:41:08.730','2016-04-09 15:41:08.730',200,15,NULL,0,1016729,'2014-01-30 15:41:08.743',NULL,'2016-03-30 16:00:00.613',15,10.00,NULL,0,NULL,NULL,NULL,'2016-03-30 15:41:08.730',181304,NULL,NULL,NULL)
,(698641,54043,755885,'2014-01-31 12:59:41.610','2016-05-10 12:59:41.610',450,20,NULL,0,1016739,'2014-01-31 12:59:41.617',NULL,'2016-04-30 14:00:00.757',20,20.00,1,0,NULL,NULL,NULL,'2016-04-30 12:59:41.610',181303,NULL,NULL,NULL)

SET IDENTITY_INSERT tblFirmSummary OFF;
