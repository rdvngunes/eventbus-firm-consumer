--tblFirmUserInfo.sql
GO

/****** Object:  Table [dbo].[tblFirmUserInfo]    Script Date: 8.03.2019 08:31:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFirmUserInfo](
	[FirmUserInfoID] [int] IDENTITY(1,1) NOT NULL,
	[FirmUserInfoFirmUserID] [int] NULL,
	[FirmUserInfoRecordName] [nvarchar](50) NULL,
	[FirmUserInfoTypeID] [int] NULL,
	[FirmUserInfoInvoiceName] [nvarchar](255) NULL,
	[FirmUserInfoInvoiceAddress] [nvarchar](255) NULL,
	[FirmUserInfoInvoiceCityID] [int] NULL,
	[FirmUserInfoInvoicePhone] [nvarchar](20) NULL,
	[FirmUserInfoTaxOffice] [nvarchar](50) NULL,
	[FirmUserInfoTaxNo] [nvarchar](50) NULL,
	[FirmUserInfoIdentityNo] [nvarchar](15) NULL,
	[FirmUserInfoAddressName] [nvarchar](100) NULL,
	[FirmUserInfoAddressText] [nvarchar](255) NULL,
	[FirmUserInfoAddressCityID] [int] NULL,
	[FirmUserInfoAddressPhone] [nvarchar](20) NULL,
	[FirmUserInfoSapCustomerCode] [nvarchar](20) NULL,
	[FirmUserInfoIsDeleted] [bit] NOT NULL,
	[FirmUserInfoCreatedUserID] [int] NOT NULL,
	[FirmUserInfoCreatedDateTime] [datetime] NOT NULL,
	[FirmUserInfoUpdatedUserID] [int] NULL,
	[FirmUserInfoUpdatedDateTime] [datetime] NULL,
	[FirmUserInfoIsApproved] [bit] NOT NULL,
	[FirmUserInfoDataUpdatedDateTime] [datetime] NULL,
	[FirmUserInfoEInvoiceUserID] [int] NULL,
	[FirmUserInfoSapCustomerCreatedDateTime] [datetime] NULL,
	[FirmUserInfoIsActive] [bit] NOT NULL,
	[FirmUserInfoInvoiceDistrictID] [int] NULL,
 CONSTRAINT [PK_tblFirmUserInfo] PRIMARY KEY CLUSTERED 
(
	[FirmUserInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblFirmUserInfo] ADD  CONSTRAINT [DF_tblFirmUserInfo_FirmUserInfoIsDeleted]  DEFAULT ((0)) FOR [FirmUserInfoIsDeleted]
GO

ALTER TABLE [dbo].[tblFirmUserInfo] ADD  CONSTRAINT [DF_tblFirmUserInfo_FirmUserInfoCreatedDateTime]  DEFAULT (getdate()) FOR [FirmUserInfoCreatedDateTime]
GO

ALTER TABLE [dbo].[tblFirmUserInfo] ADD  CONSTRAINT [DF_tblFirmUserInfo_FirmUserInfoIsApproved]  DEFAULT ((0)) FOR [FirmUserInfoIsApproved]
GO

ALTER TABLE [dbo].[tblFirmUserInfo] ADD  DEFAULT ((1)) FOR [FirmUserInfoIsActive]
GO

ALTER TABLE [dbo].[tblFirmUserInfo]  WITH CHECK ADD  CONSTRAINT [FK_tblFirmUserInfo_tblFirmUser] FOREIGN KEY([FirmUserInfoFirmUserID])
REFERENCES [dbo].[tblFirmUser] ([FirmUserID])
GO

ALTER TABLE [dbo].[tblFirmUserInfo] CHECK CONSTRAINT [FK_tblFirmUserInfo_tblFirmUser]
GO

--ALTER TABLE [dbo].[tblFirmUserInfo]  WITH CHECK ADD  CONSTRAINT [FK_tblFirmUserInfo_tblType] FOREIGN KEY([FirmUserInfoTypeID])
--REFERENCES [dbo].[tblType] ([TypeID])
--GO

--ALTER TABLE [dbo].[tblFirmUserInfo] CHECK CONSTRAINT [FK_tblFirmUserInfo_tblType]
--GO

SET IDENTITY_INSERT tblFirmUserInfo ON;


Insert Into tblFirmUserInfo ([FirmUserInfoID],[FirmUserInfoFirmUserID],[FirmUserInfoRecordName],[FirmUserInfoTypeID],[FirmUserInfoInvoiceName],[FirmUserInfoInvoiceAddress],[FirmUserInfoInvoiceCityID],[FirmUserInfoInvoicePhone],[FirmUserInfoTaxOffice],[FirmUserInfoTaxNo],[FirmUserInfoIdentityNo],[FirmUserInfoAddressName],[FirmUserInfoAddressText],[FirmUserInfoAddressCityID],[FirmUserInfoAddressPhone],[FirmUserInfoSapCustomerCode],[FirmUserInfoIsDeleted],[FirmUserInfoCreatedUserID],[FirmUserInfoCreatedDateTime],[FirmUserInfoUpdatedUserID],[FirmUserInfoUpdatedDateTime],[FirmUserInfoIsApproved],[FirmUserInfoDataUpdatedDateTime],[FirmUserInfoEInvoiceUserID],[FirmUserInfoSapCustomerCreatedDateTime],[FirmUserInfoIsActive],[FirmUserInfoInvoiceDistrictID])
Values (42351,1016577,N'fatura',109602,N'abdulcelil gül',N'ERGENEKON CADDESİ TÜRKBEYİ SOKAK NO:4-6 PANGALTI ŞİŞLİ',34,N'212-2961896',NULL,NULL,N'46708152924',N'fatura',N'ERGENEKON CADDESİ TÜRKBEYİ SOKAK NO:4-6 PANGALTI ŞİŞLİ',34,N'212-2961896',NULL,0,75,'2014-01-27 17:31:01.793',1,'2017-09-26 09:53:40.047',0,NULL,0,NULL,0,NULL)
,(42352,1016578,N'fatura',109602,N'Dominique Marthe Louise Le Doare Atay',N'balmumcu bul 76/1 beşiktaş
vd beşiktaş 0990374863',34,N'541-7487610',NULL,NULL,N'99169209072',NULL,NULL,NULL,N'-',NULL,0,1016578,'2014-01-27 17:44:18.713',1,'2017-09-26 09:53:40.047',0,'2014-03-25 17:07:40.260',0,NULL,0,NULL)
,(52049,1016578,N'2',109602,N'Dominique Marthe Louise Le Doaré',N'Abbasağa Mah. Bekçi Sokak 7/1 Beşiktaş VD 0990374863',34,N'541-7487610',NULL,NULL,N'99169209072',NULL,NULL,NULL,N'-',NULL,0,1016578,'2015-03-27 17:58:42.990',1,'2017-09-26 09:53:40.047',0,NULL,0,NULL,0,NULL)
,(63698,1016578,N'Fatura',109602,N'Dominique Marthe Louise Le Doaré',N'Abbasağa Mah. Bekçi Sokak 7/1 Beşiktaş',34,N'541-7487610',NULL,NULL,N'99169209072',NULL,NULL,NULL,N'-',N'0009103792',0,65,'2016-03-26 11:45:52.483',1,'2017-09-26 09:53:40.047',1,'2017-03-27 14:34:21.907',0,'2017-11-07 15:39:02.123',1,1663)
,(89977,1016578,N'15.03.2018',109602,N'Dominique Marthe Louise Le Doaré',N'Abbasağa Mah. Bekçi Sokak 7/1 Beşiktaş',34,N'541-7487610',NULL,NULL,N'99169209072',N'Dominique Marthe Louise Le Doaré',N'Abbasağa Mah. Bekçi Sokak 7/1 BeşiktaşBeşiktaş',34,NULL,NULL,0,1016578,'2018-03-15 11:46:12.553',391,'2018-03-16 16:27:28.950',1,NULL,0,'2018-03-16 16:27:28.950',1,1183)
,(42505,1016684,N'FATURA',109602,N'HALİL CEM GÖKHAN AYTAÇ',N'ATAKÖY 5. KISIM A. 9 BLOK D:1 BAKIRKÖY / İSTANBUL',34,N'212-5601085',NULL,NULL,N'39169580078',NULL,NULL,NULL,N'-',NULL,0,77,'2014-02-04 19:05:10.017',1,'2017-09-26 09:53:40.047',0,'2015-03-13 15:02:26.913',0,NULL,0,NULL)
,(63356,1016684,N'Fatura',109602,N'HALİL CEM GÖKHAN AYTAÇ',N'ATAKÖY 5. KISIM A. 9 BLOK D:1 BAKIRKÖY / İSTANBUL',34,N'-',NULL,NULL,N'39169580078',NULL,NULL,NULL,N'-',N'0009103245',0,178,'2016-03-18 11:24:25.453',1,'2017-09-26 09:53:40.047',0,NULL,0,'2017-02-22 12:01:19.483',1,NULL)
,(42405,1016724,N'fatura',109602,N'Kartal Kilinç',N'Atatürk Cad.Şafak Apt.No:35/A
Nilüfer Bursa',16,N'224-4834645',NULL,NULL,N'29297419654',NULL,N'Atatürk Cad.Şafak Apt.No:35/A
Nilüfer Bursa',NULL,N'-',NULL,0,132,'2014-01-30 11:26:51.583',1,'2017-09-26 09:53:40.047',0,'2014-03-05 12:21:07.563',0,NULL,0,NULL)
,(42413,1016729,N'FATURA',109602,N'ERKAN KOÇ',N'FEVZİ ÇAKMAK MAH FEVZİ ÇAKMAK CAD. NO:35 ESENLER',34,N'212-6105663',NULL,NULL,N'16328967888',N'ERKAN KOÇ',N'FEVZİ ÇAKMAK MAH FEVZİ ÇAKMAK CAD. NO:35 ESENLER',34,N'212-6105663',NULL,0,49,'2014-01-30 15:27:31.613',1,'2017-09-26 09:53:40.047',0,NULL,0,NULL,0,NULL)
,(42429,1016739,N'görkem ercan',109602,N'görkem ercan',N'güzeloba mh 2132 sk antalya spor evleri',7,N'541-2852092',NULL,NULL,N'21076557878',N'mp emlak',N'güzzeloba mh 2132 sk antalya spor evleri muratpaşa/antalya',7,N'541-2852092',NULL,0,111,'2014-01-31 12:56:51.940',1,'2017-09-26 09:53:40.047',0,NULL,0,NULL,0,NULL)
SET IDENTITY_INSERT tblFirmUserInfo OFF;