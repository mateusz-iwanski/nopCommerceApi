USE [nopCommerce]
GO
/****** Object:  Table [dbo].[AclRecord]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AclRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EntityName] [nvarchar](400) NOT NULL,
	[CustomerRoleId] [int] NOT NULL,
	[EntityId] [int] NOT NULL,
 CONSTRAINT [PK_AclRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityLog]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[IpAddress] [nvarchar](100) NULL,
	[EntityName] [nvarchar](400) NULL,
	[ActivityLogTypeId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[EntityId] [int] NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_ActivityLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityLogType]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityLogType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemKeyword] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_ActivityLogType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NULL,
	[StateProvinceId] [int] NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Company] [nvarchar](max) NULL,
	[County] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Address1] [nvarchar](max) NULL,
	[Address2] [nvarchar](max) NULL,
	[ZipPostalCode] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[FaxNumber] [nvarchar](max) NULL,
	[CustomAttributes] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressAttribute]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressAttribute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[AttributeControlTypeId] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_AddressAttribute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressAttributeValue]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressAttributeValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[AddressAttributeId] [int] NOT NULL,
	[IsPreSelected] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_AddressAttributeValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Affiliate]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Affiliate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressId] [int] NOT NULL,
	[AdminComment] [nvarchar](max) NULL,
	[FriendlyUrlName] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Affiliate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvalaraItemClassification]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvalaraItemClassification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[HSClassificationRequestId] [nvarchar](max) NULL,
	[CountryId] [int] NOT NULL,
	[HSCode] [nvarchar](max) NULL,
	[UpdatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_AvalaraItemClassification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BackInStockSubscription]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BackInStockSubscription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_BackInStockSubscription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogComment]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[BlogPostId] [int] NOT NULL,
	[CommentText] [nvarchar](max) NULL,
	[IsApproved] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_BlogComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogPost]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[MetaKeywords] [nvarchar](400) NULL,
	[MetaTitle] [nvarchar](400) NULL,
	[LanguageId] [int] NOT NULL,
	[IncludeInSitemap] [bit] NOT NULL,
	[BodyOverview] [nvarchar](max) NULL,
	[AllowComments] [bit] NOT NULL,
	[Tags] [nvarchar](max) NULL,
	[StartDateUtc] [datetime2](6) NULL,
	[EndDateUtc] [datetime2](6) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[LimitedToStores] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_BlogPost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Campaign]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campaign](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Subject] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[StoreId] [int] NOT NULL,
	[CustomerRoleId] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[DontSendBeforeDateUtc] [datetime2](6) NULL,
 CONSTRAINT [PK_Campaign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[MetaKeywords] [nvarchar](400) NULL,
	[MetaTitle] [nvarchar](400) NULL,
	[PageSizeOptions] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[CategoryTemplateId] [int] NOT NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[ParentCategoryId] [int] NOT NULL,
	[PictureId] [int] NOT NULL,
	[PageSize] [int] NOT NULL,
	[AllowCustomersToSelectPageSize] [bit] NOT NULL,
	[ShowOnHomepage] [bit] NOT NULL,
	[IncludeInTopMenu] [bit] NOT NULL,
	[SubjectToAcl] [bit] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
	[Published] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[UpdatedOnUtc] [datetime2](6) NOT NULL,
	[PriceRangeFiltering] [bit] NOT NULL,
	[PriceFrom] [decimal](18, 4) NOT NULL,
	[PriceTo] [decimal](18, 4) NOT NULL,
	[ManuallyPriceRange] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryTemplate]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[ViewPath] [nvarchar](400) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_CategoryTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckoutAttribute]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckoutAttribute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[TextPrompt] [nvarchar](max) NULL,
	[ShippableProductRequired] [bit] NOT NULL,
	[IsTaxExempt] [bit] NOT NULL,
	[TaxCategoryId] [int] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
	[ValidationMinLength] [int] NULL,
	[ValidationMaxLength] [int] NULL,
	[ValidationFileAllowedExtensions] [nvarchar](max) NULL,
	[ValidationFileMaximumSize] [int] NULL,
	[DefaultValue] [nvarchar](max) NULL,
	[ConditionAttributeXml] [nvarchar](max) NULL,
	[IsRequired] [bit] NOT NULL,
	[AttributeControlTypeId] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_CheckoutAttribute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckoutAttributeValue]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckoutAttributeValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[ColorSquaresRgb] [nvarchar](100) NULL,
	[CheckoutAttributeId] [int] NOT NULL,
	[PriceAdjustment] [decimal](18, 4) NOT NULL,
	[WeightAdjustment] [decimal](18, 4) NOT NULL,
	[IsPreSelected] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_CheckoutAttributeValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[TwoLetterIsoCode] [nvarchar](2) NULL,
	[ThreeLetterIsoCode] [nvarchar](3) NULL,
	[AllowsBilling] [bit] NOT NULL,
	[AllowsShipping] [bit] NOT NULL,
	[NumericIsoCode] [int] NOT NULL,
	[SubjectToVat] [bit] NOT NULL,
	[Published] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CrossSellProduct]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CrossSellProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId1] [int] NOT NULL,
	[ProductId2] [int] NOT NULL,
 CONSTRAINT [PK_CrossSellProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CurrencyCode] [nvarchar](5) NOT NULL,
	[DisplayLocale] [nvarchar](50) NULL,
	[CustomFormatting] [nvarchar](50) NULL,
	[Rate] [decimal](18, 4) NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
	[Published] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[UpdatedOnUtc] [datetime2](6) NOT NULL,
	[RoundingTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](1000) NULL,
	[Email] [nvarchar](1000) NULL,
	[EmailToRevalidate] [nvarchar](1000) NULL,
	[FirstName] [nvarchar](1000) NULL,
	[LastName] [nvarchar](1000) NULL,
	[Gender] [nvarchar](1000) NULL,
	[Company] [nvarchar](1000) NULL,
	[StreetAddress] [nvarchar](1000) NULL,
	[StreetAddress2] [nvarchar](1000) NULL,
	[ZipPostalCode] [nvarchar](1000) NULL,
	[City] [nvarchar](1000) NULL,
	[County] [nvarchar](1000) NULL,
	[Phone] [nvarchar](1000) NULL,
	[Fax] [nvarchar](1000) NULL,
	[VatNumber] [nvarchar](1000) NULL,
	[TimeZoneId] [nvarchar](1000) NULL,
	[CustomCustomerAttributesXML] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[SystemName] [nvarchar](400) NULL,
	[LastIpAddress] [nvarchar](100) NULL,
	[CurrencyId] [int] NULL,
	[LanguageId] [int] NULL,
	[BillingAddress_Id] [int] NULL,
	[ShippingAddress_Id] [int] NULL,
	[CustomerGuid] [uniqueidentifier] NOT NULL,
	[CountryId] [int] NOT NULL,
	[StateProvinceId] [int] NOT NULL,
	[VatNumberStatusId] [int] NOT NULL,
	[TaxDisplayTypeId] [int] NULL,
	[AdminComment] [nvarchar](max) NULL,
	[IsTaxExempt] [bit] NOT NULL,
	[AffiliateId] [int] NOT NULL,
	[VendorId] [int] NOT NULL,
	[HasShoppingCartItems] [bit] NOT NULL,
	[RequireReLogin] [bit] NOT NULL,
	[FailedLoginAttempts] [int] NOT NULL,
	[CannotLoginUntilDateUtc] [datetime2](6) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[IsSystemAccount] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[LastLoginDateUtc] [datetime2](6) NULL,
	[LastActivityDateUtc] [datetime2](6) NOT NULL,
	[RegisteredInStoreId] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_CustomerRole_Mapping]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_CustomerRole_Mapping](
	[Customer_Id] [int] NOT NULL,
	[CustomerRole_Id] [int] NOT NULL,
 CONSTRAINT [PK_Customer_CustomerRole_Mapping] PRIMARY KEY CLUSTERED 
(
	[Customer_Id] ASC,
	[CustomerRole_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerAddresses]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerAddresses](
	[Address_Id] [int] NOT NULL,
	[Customer_Id] [int] NOT NULL,
 CONSTRAINT [PK_CustomerAddresses] PRIMARY KEY CLUSTERED 
(
	[Address_Id] ASC,
	[Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerAttribute]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerAttribute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[AttributeControlTypeId] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_CustomerAttribute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerAttributeValue]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerAttributeValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[CustomerAttributeId] [int] NOT NULL,
	[IsPreSelected] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_CustomerAttributeValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerPassword]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerPassword](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Password] [nvarchar](max) NULL,
	[PasswordFormatId] [int] NOT NULL,
	[PasswordSalt] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_CustomerPassword] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerRole]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[SystemName] [nvarchar](255) NULL,
	[FreeShipping] [bit] NOT NULL,
	[TaxExempt] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[IsSystemRole] [bit] NOT NULL,
	[EnablePasswordLifetime] [bit] NOT NULL,
	[OverrideTaxDisplayType] [bit] NOT NULL,
	[DefaultTaxDisplayTypeId] [int] NOT NULL,
	[PurchasedWithProductId] [int] NOT NULL,
 CONSTRAINT [PK_CustomerRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryDate]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryDate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_DeliveryDate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CouponCode] [nvarchar](100) NULL,
	[AdminComment] [nvarchar](max) NULL,
	[DiscountTypeId] [int] NOT NULL,
	[UsePercentage] [bit] NOT NULL,
	[DiscountPercentage] [decimal](18, 4) NOT NULL,
	[DiscountAmount] [decimal](18, 4) NOT NULL,
	[MaximumDiscountAmount] [decimal](18, 4) NULL,
	[StartDateUtc] [datetime2](6) NULL,
	[EndDateUtc] [datetime2](6) NULL,
	[RequiresCouponCode] [bit] NOT NULL,
	[IsCumulative] [bit] NOT NULL,
	[DiscountLimitationId] [int] NOT NULL,
	[LimitationTimes] [int] NOT NULL,
	[MaximumDiscountedQuantity] [int] NULL,
	[AppliedToSubCategories] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount_AppliedToCategories]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount_AppliedToCategories](
	[Discount_Id] [int] NOT NULL,
	[Category_Id] [int] NOT NULL,
 CONSTRAINT [PK_Discount_AppliedToCategories] PRIMARY KEY CLUSTERED 
(
	[Discount_Id] ASC,
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount_AppliedToManufacturers]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount_AppliedToManufacturers](
	[Discount_Id] [int] NOT NULL,
	[Manufacturer_Id] [int] NOT NULL,
 CONSTRAINT [PK_Discount_AppliedToManufacturers] PRIMARY KEY CLUSTERED 
(
	[Discount_Id] ASC,
	[Manufacturer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount_AppliedToProducts]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount_AppliedToProducts](
	[Discount_Id] [int] NOT NULL,
	[Product_Id] [int] NOT NULL,
 CONSTRAINT [PK_Discount_AppliedToProducts] PRIMARY KEY CLUSTERED 
(
	[Discount_Id] ASC,
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscountRequirement]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscountRequirement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiscountId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[DiscountRequirementRuleSystemName] [nvarchar](max) NULL,
	[InteractionTypeId] [int] NULL,
	[IsGroup] [bit] NOT NULL,
 CONSTRAINT [PK_DiscountRequirement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscountUsageHistory]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscountUsageHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiscountId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_DiscountUsageHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Download]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Download](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DownloadGuid] [uniqueidentifier] NOT NULL,
	[UseDownloadUrl] [bit] NOT NULL,
	[DownloadUrl] [nvarchar](max) NULL,
	[DownloadBinary] [varbinary](max) NULL,
	[ContentType] [nvarchar](max) NULL,
	[Filename] [nvarchar](max) NULL,
	[Extension] [nvarchar](max) NULL,
	[IsNew] [bit] NOT NULL,
 CONSTRAINT [PK_Download] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailAccount]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Host] [nvarchar](255) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Port] [int] NOT NULL,
	[EnableSsl] [bit] NOT NULL,
	[MaxNumberOfEmails] [int] NOT NULL,
	[EmailAuthenticationMethodId] [int] NOT NULL,
	[ClientId] [nvarchar](max) NULL,
	[ClientSecret] [nvarchar](max) NULL,
	[TenantId] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmailAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExternalAuthenticationRecord]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalAuthenticationRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[ExternalIdentifier] [nvarchar](max) NULL,
	[ExternalDisplayIdentifier] [nvarchar](max) NULL,
	[OAuthToken] [nvarchar](max) NULL,
	[OAuthAccessToken] [nvarchar](max) NULL,
	[ProviderSystemName] [nvarchar](max) NULL,
 CONSTRAINT [PK_ExternalAuthenticationRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacebookPixelConfiguration]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacebookPixelConfiguration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PixelId] [nvarchar](max) NULL,
	[AccessToken] [nvarchar](max) NULL,
	[PixelScriptEnabled] [bit] NOT NULL,
	[ConversionsApiEnabled] [bit] NOT NULL,
	[DisableForUsersNotAcceptingCookieConsent] [bit] NOT NULL,
	[StoreId] [int] NOT NULL,
	[PassUserProperties] [bit] NOT NULL,
	[UseAdvancedMatching] [bit] NOT NULL,
	[TrackPageView] [bit] NOT NULL,
	[TrackAddToCart] [bit] NOT NULL,
	[TrackPurchase] [bit] NOT NULL,
	[TrackViewContent] [bit] NOT NULL,
	[TrackAddToWishlist] [bit] NOT NULL,
	[TrackInitiateCheckout] [bit] NOT NULL,
	[TrackSearch] [bit] NOT NULL,
	[TrackContact] [bit] NOT NULL,
	[TrackCompleteRegistration] [bit] NOT NULL,
	[CustomEvents] [nvarchar](max) NULL,
 CONSTRAINT [PK_FacebookPixelConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forums_Forum]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forums_Forum](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ForumGroupId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[NumTopics] [int] NOT NULL,
	[NumPosts] [int] NOT NULL,
	[LastTopicId] [int] NOT NULL,
	[LastPostId] [int] NOT NULL,
	[LastPostCustomerId] [int] NOT NULL,
	[LastPostTime] [datetime2](6) NULL,
	[DisplayOrder] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[UpdatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_Forums_Forum] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forums_Group]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forums_Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[UpdatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_Forums_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forums_Post]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forums_Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[IPAddress] [nvarchar](100) NULL,
	[CustomerId] [int] NOT NULL,
	[TopicId] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[UpdatedOnUtc] [datetime2](6) NOT NULL,
	[VoteCount] [int] NOT NULL,
 CONSTRAINT [PK_Forums_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forums_PostVote]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forums_PostVote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ForumPostId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[IsUp] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_Forums_PostVote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forums_PrivateMessage]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forums_PrivateMessage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](450) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[FromCustomerId] [int] NOT NULL,
	[ToCustomerId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[IsRead] [bit] NOT NULL,
	[IsDeletedByAuthor] [bit] NOT NULL,
	[IsDeletedByRecipient] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_Forums_PrivateMessage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forums_Subscription]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forums_Subscription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[SubscriptionGuid] [uniqueidentifier] NOT NULL,
	[ForumId] [int] NOT NULL,
	[TopicId] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_Forums_Subscription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forums_Topic]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forums_Topic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](450) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ForumId] [int] NOT NULL,
	[TopicTypeId] [int] NOT NULL,
	[NumPosts] [int] NOT NULL,
	[Views] [int] NOT NULL,
	[LastPostId] [int] NOT NULL,
	[LastPostCustomerId] [int] NOT NULL,
	[LastPostTime] [datetime2](6) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[UpdatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_Forums_Topic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GdprConsent]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GdprConsent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[RequiredMessage] [nvarchar](max) NULL,
	[DisplayDuringRegistration] [bit] NOT NULL,
	[DisplayOnCustomerInfoPage] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_GdprConsent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GdprLog]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GdprLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ConsentId] [int] NOT NULL,
	[CustomerInfo] [nvarchar](max) NULL,
	[RequestTypeId] [int] NOT NULL,
	[RequestDetails] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_GdprLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GenericAttribute]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenericAttribute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KeyGroup] [nvarchar](400) NOT NULL,
	[Key] [nvarchar](400) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[EntityId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[CreatedOrUpdatedDateUTC] [datetime2](6) NULL,
 CONSTRAINT [PK_GenericAttribute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiftCard]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiftCard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchasedWithOrderItemId] [int] NULL,
	[GiftCardTypeId] [int] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[IsGiftCardActivated] [bit] NOT NULL,
	[GiftCardCouponCode] [nvarchar](max) NULL,
	[RecipientName] [nvarchar](max) NULL,
	[RecipientEmail] [nvarchar](max) NULL,
	[SenderName] [nvarchar](max) NULL,
	[SenderEmail] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[IsRecipientNotified] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_GiftCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiftCardUsageHistory]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiftCardUsageHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GiftCardId] [int] NOT NULL,
	[UsedWithOrderId] [int] NOT NULL,
	[UsedValue] [decimal](18, 4) NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_GiftCardUsageHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoogleAuthenticatorRecord]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoogleAuthenticatorRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer] [nvarchar](max) NULL,
	[SecretKey] [nvarchar](max) NULL,
 CONSTRAINT [PK_GoogleAuthenticatorRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LanguageCulture] [nvarchar](20) NOT NULL,
	[UniqueSeoCode] [nvarchar](2) NULL,
	[FlagImageFileName] [nvarchar](50) NULL,
	[Rtl] [bit] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
	[DefaultCurrencyId] [int] NOT NULL,
	[Published] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocaleStringResource]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocaleStringResource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResourceName] [nvarchar](200) NOT NULL,
	[ResourceValue] [nvarchar](max) NOT NULL,
	[LanguageId] [int] NOT NULL,
 CONSTRAINT [PK_LocaleStringResource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalizedProperty]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalizedProperty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocaleKeyGroup] [nvarchar](400) NOT NULL,
	[LocaleKey] [nvarchar](400) NOT NULL,
	[LocaleValue] [nvarchar](max) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[EntityId] [int] NOT NULL,
 CONSTRAINT [PK_LocalizedProperty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortMessage] [nvarchar](max) NOT NULL,
	[IpAddress] [nvarchar](100) NULL,
	[CustomerId] [int] NULL,
	[LogLevelId] [int] NOT NULL,
	[FullMessage] [nvarchar](max) NULL,
	[PageUrl] [nvarchar](max) NULL,
	[ReferrerUrl] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[MetaKeywords] [nvarchar](400) NULL,
	[MetaTitle] [nvarchar](400) NULL,
	[PageSizeOptions] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[ManufacturerTemplateId] [int] NOT NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[PictureId] [int] NOT NULL,
	[PageSize] [int] NOT NULL,
	[AllowCustomersToSelectPageSize] [bit] NOT NULL,
	[SubjectToAcl] [bit] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
	[Published] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[UpdatedOnUtc] [datetime2](6) NOT NULL,
	[PriceRangeFiltering] [bit] NOT NULL,
	[PriceFrom] [decimal](18, 4) NOT NULL,
	[PriceTo] [decimal](18, 4) NOT NULL,
	[ManuallyPriceRange] [bit] NOT NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManufacturerTemplate]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManufacturerTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[ViewPath] [nvarchar](400) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_ManufacturerTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasureDimension]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasureDimension](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SystemKeyword] [nvarchar](100) NOT NULL,
	[Ratio] [decimal](18, 8) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_MeasureDimension] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasureWeight]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasureWeight](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SystemKeyword] [nvarchar](100) NOT NULL,
	[Ratio] [decimal](18, 8) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_MeasureWeight] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageTemplate]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[BccEmailAddresses] [nvarchar](200) NULL,
	[Subject] [nvarchar](1000) NULL,
	[EmailAccountId] [int] NOT NULL,
	[Body] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[DelayBeforeSend] [int] NULL,
	[DelayPeriodId] [int] NOT NULL,
	[AttachedDownloadId] [int] NOT NULL,
	[AllowDirectReply] [bit] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
 CONSTRAINT [PK_MessageTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MigrationVersionInfo]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MigrationVersionInfo](
	[Version] [bigint] NOT NULL,
	[AppliedOn] [datetime] NULL,
	[Description] [nvarchar](1024) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Short] [nvarchar](max) NOT NULL,
	[Full] [nvarchar](max) NOT NULL,
	[MetaKeywords] [nvarchar](400) NULL,
	[MetaTitle] [nvarchar](400) NULL,
	[LanguageId] [int] NOT NULL,
	[Published] [bit] NOT NULL,
	[StartDateUtc] [datetime2](6) NULL,
	[EndDateUtc] [datetime2](6) NULL,
	[AllowComments] [bit] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewsComment]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[NewsItemId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[CommentTitle] [nvarchar](max) NULL,
	[CommentText] [nvarchar](max) NULL,
	[IsApproved] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_NewsComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewsLetterSubscription]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsLetterSubscription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[NewsLetterSubscriptionGuid] [uniqueidentifier] NOT NULL,
	[Active] [bit] NOT NULL,
	[StoreId] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[LanguageId] [int] NOT NULL,
 CONSTRAINT [PK_NewsLetterSubscription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomOrderNumber] [nvarchar](max) NOT NULL,
	[BillingAddressId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PickupAddressId] [int] NULL,
	[ShippingAddressId] [int] NULL,
	[CustomerIp] [nvarchar](100) NULL,
	[OrderGuid] [uniqueidentifier] NOT NULL,
	[StoreId] [int] NOT NULL,
	[PickupInStore] [bit] NOT NULL,
	[OrderStatusId] [int] NOT NULL,
	[ShippingStatusId] [int] NOT NULL,
	[PaymentStatusId] [int] NOT NULL,
	[PaymentMethodSystemName] [nvarchar](max) NULL,
	[CustomerCurrencyCode] [nvarchar](max) NULL,
	[CurrencyRate] [decimal](18, 4) NOT NULL,
	[CustomerTaxDisplayTypeId] [int] NOT NULL,
	[VatNumber] [nvarchar](max) NULL,
	[OrderSubtotalInclTax] [decimal](18, 4) NOT NULL,
	[OrderSubtotalExclTax] [decimal](18, 4) NOT NULL,
	[OrderSubTotalDiscountInclTax] [decimal](18, 4) NOT NULL,
	[OrderSubTotalDiscountExclTax] [decimal](18, 4) NOT NULL,
	[OrderShippingInclTax] [decimal](18, 4) NOT NULL,
	[OrderShippingExclTax] [decimal](18, 4) NOT NULL,
	[PaymentMethodAdditionalFeeInclTax] [decimal](18, 4) NOT NULL,
	[PaymentMethodAdditionalFeeExclTax] [decimal](18, 4) NOT NULL,
	[TaxRates] [nvarchar](max) NULL,
	[OrderTax] [decimal](18, 4) NOT NULL,
	[OrderDiscount] [decimal](18, 4) NOT NULL,
	[OrderTotal] [decimal](18, 4) NOT NULL,
	[RefundedAmount] [decimal](18, 4) NOT NULL,
	[RewardPointsHistoryEntryId] [int] NULL,
	[CheckoutAttributeDescription] [nvarchar](max) NULL,
	[CheckoutAttributesXml] [nvarchar](max) NULL,
	[CustomerLanguageId] [int] NOT NULL,
	[AffiliateId] [int] NOT NULL,
	[AllowStoringCreditCardNumber] [bit] NOT NULL,
	[CardType] [nvarchar](max) NULL,
	[CardName] [nvarchar](max) NULL,
	[CardNumber] [nvarchar](max) NULL,
	[MaskedCreditCardNumber] [nvarchar](max) NULL,
	[CardCvv2] [nvarchar](max) NULL,
	[CardExpirationMonth] [nvarchar](max) NULL,
	[CardExpirationYear] [nvarchar](max) NULL,
	[AuthorizationTransactionId] [nvarchar](max) NULL,
	[AuthorizationTransactionCode] [nvarchar](max) NULL,
	[AuthorizationTransactionResult] [nvarchar](max) NULL,
	[CaptureTransactionId] [nvarchar](max) NULL,
	[CaptureTransactionResult] [nvarchar](max) NULL,
	[SubscriptionTransactionId] [nvarchar](max) NULL,
	[PaidDateUtc] [datetime2](6) NULL,
	[ShippingMethod] [nvarchar](max) NULL,
	[ShippingRateComputationMethodSystemName] [nvarchar](max) NULL,
	[CustomValuesXml] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[RedeemedRewardPointsEntryId] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderItemGuid] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPriceInclTax] [decimal](18, 4) NOT NULL,
	[UnitPriceExclTax] [decimal](18, 4) NOT NULL,
	[PriceInclTax] [decimal](18, 4) NOT NULL,
	[PriceExclTax] [decimal](18, 4) NOT NULL,
	[DiscountAmountInclTax] [decimal](18, 4) NOT NULL,
	[DiscountAmountExclTax] [decimal](18, 4) NOT NULL,
	[OriginalProductCost] [decimal](18, 4) NOT NULL,
	[AttributeDescription] [nvarchar](max) NULL,
	[AttributesXml] [nvarchar](max) NULL,
	[DownloadCount] [int] NOT NULL,
	[IsDownloadActivated] [bit] NOT NULL,
	[LicenseDownloadId] [int] NULL,
	[ItemWeight] [decimal](18, 4) NULL,
	[RentalStartDateUtc] [datetime2](6) NULL,
	[RentalEndDateUtc] [datetime2](6) NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderNote]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderNote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[OrderId] [int] NOT NULL,
	[DownloadId] [int] NOT NULL,
	[DisplayToCustomer] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_OrderNote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionRecord]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[SystemName] [nvarchar](255) NOT NULL,
	[Category] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_PermissionRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionRecord_Role_Mapping]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionRecord_Role_Mapping](
	[PermissionRecord_Id] [int] NOT NULL,
	[CustomerRole_Id] [int] NOT NULL,
 CONSTRAINT [PK_PermissionRecord_Role_Mapping] PRIMARY KEY CLUSTERED 
(
	[PermissionRecord_Id] ASC,
	[CustomerRole_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Picture]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Picture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MimeType] [nvarchar](40) NOT NULL,
	[SeoFilename] [nvarchar](300) NULL,
	[AltAttribute] [nvarchar](max) NULL,
	[TitleAttribute] [nvarchar](max) NULL,
	[IsNew] [bit] NOT NULL,
	[VirtualPath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PictureBinary]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PictureBinary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PictureId] [int] NOT NULL,
	[BinaryData] [varbinary](max) NULL,
 CONSTRAINT [PK_PictureBinary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Poll]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poll](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[SystemKeyword] [nvarchar](max) NULL,
	[Published] [bit] NOT NULL,
	[ShowOnHomepage] [bit] NOT NULL,
	[AllowGuestsToVote] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
	[StartDateUtc] [datetime2](6) NULL,
	[EndDateUtc] [datetime2](6) NULL,
 CONSTRAINT [PK_Poll] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PollAnswer]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PollAnswer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[PollId] [int] NOT NULL,
	[NumberOfVotes] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_PollAnswer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PollVotingRecord]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PollVotingRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PollAnswerId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_PollVotingRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PredefinedProductAttributeValue]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PredefinedProductAttributeValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[ProductAttributeId] [int] NOT NULL,
	[PriceAdjustment] [decimal](18, 4) NOT NULL,
	[PriceAdjustmentUsePercentage] [bit] NOT NULL,
	[WeightAdjustment] [decimal](18, 4) NOT NULL,
	[Cost] [decimal](18, 4) NOT NULL,
	[IsPreSelected] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_PredefinedProductAttributeValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[MetaKeywords] [nvarchar](400) NULL,
	[MetaTitle] [nvarchar](400) NULL,
	[Sku] [nvarchar](400) NULL,
	[ManufacturerPartNumber] [nvarchar](400) NULL,
	[Gtin] [nvarchar](400) NULL,
	[RequiredProductIds] [nvarchar](1000) NULL,
	[AllowedQuantities] [nvarchar](1000) NULL,
	[ProductTypeId] [int] NOT NULL,
	[ParentGroupedProductId] [int] NOT NULL,
	[VisibleIndividually] [bit] NOT NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[FullDescription] [nvarchar](max) NULL,
	[AdminComment] [nvarchar](max) NULL,
	[ProductTemplateId] [int] NOT NULL,
	[VendorId] [int] NOT NULL,
	[ShowOnHomepage] [bit] NOT NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[AllowCustomerReviews] [bit] NOT NULL,
	[ApprovedRatingSum] [int] NOT NULL,
	[NotApprovedRatingSum] [int] NOT NULL,
	[ApprovedTotalReviews] [int] NOT NULL,
	[NotApprovedTotalReviews] [int] NOT NULL,
	[SubjectToAcl] [bit] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
	[IsGiftCard] [bit] NOT NULL,
	[GiftCardTypeId] [int] NOT NULL,
	[OverriddenGiftCardAmount] [decimal](18, 4) NULL,
	[RequireOtherProducts] [bit] NOT NULL,
	[AutomaticallyAddRequiredProducts] [bit] NOT NULL,
	[IsDownload] [bit] NOT NULL,
	[DownloadId] [int] NOT NULL,
	[UnlimitedDownloads] [bit] NOT NULL,
	[MaxNumberOfDownloads] [int] NOT NULL,
	[DownloadExpirationDays] [int] NULL,
	[DownloadActivationTypeId] [int] NOT NULL,
	[HasSampleDownload] [bit] NOT NULL,
	[SampleDownloadId] [int] NOT NULL,
	[HasUserAgreement] [bit] NOT NULL,
	[UserAgreementText] [nvarchar](max) NULL,
	[IsRecurring] [bit] NOT NULL,
	[RecurringCycleLength] [int] NOT NULL,
	[RecurringCyclePeriodId] [int] NOT NULL,
	[RecurringTotalCycles] [int] NOT NULL,
	[IsRental] [bit] NOT NULL,
	[RentalPriceLength] [int] NOT NULL,
	[RentalPricePeriodId] [int] NOT NULL,
	[IsShipEnabled] [bit] NOT NULL,
	[IsFreeShipping] [bit] NOT NULL,
	[ShipSeparately] [bit] NOT NULL,
	[AdditionalShippingCharge] [decimal](18, 4) NOT NULL,
	[DeliveryDateId] [int] NOT NULL,
	[IsTaxExempt] [bit] NOT NULL,
	[TaxCategoryId] [int] NOT NULL,
	[ManageInventoryMethodId] [int] NOT NULL,
	[ProductAvailabilityRangeId] [int] NOT NULL,
	[UseMultipleWarehouses] [bit] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[DisplayStockAvailability] [bit] NOT NULL,
	[DisplayStockQuantity] [bit] NOT NULL,
	[MinStockQuantity] [int] NOT NULL,
	[LowStockActivityId] [int] NOT NULL,
	[NotifyAdminForQuantityBelow] [int] NOT NULL,
	[BackorderModeId] [int] NOT NULL,
	[AllowBackInStockSubscriptions] [bit] NOT NULL,
	[OrderMinimumQuantity] [int] NOT NULL,
	[OrderMaximumQuantity] [int] NOT NULL,
	[AllowAddingOnlyExistingAttributeCombinations] [bit] NOT NULL,
	[DisplayAttributeCombinationImagesOnly] [bit] NOT NULL,
	[NotReturnable] [bit] NOT NULL,
	[DisableBuyButton] [bit] NOT NULL,
	[DisableWishlistButton] [bit] NOT NULL,
	[AvailableForPreOrder] [bit] NOT NULL,
	[PreOrderAvailabilityStartDateTimeUtc] [datetime2](6) NULL,
	[CallForPrice] [bit] NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[OldPrice] [decimal](18, 4) NOT NULL,
	[ProductCost] [decimal](18, 4) NOT NULL,
	[CustomerEntersPrice] [bit] NOT NULL,
	[MinimumCustomerEnteredPrice] [decimal](18, 4) NOT NULL,
	[MaximumCustomerEnteredPrice] [decimal](18, 4) NOT NULL,
	[BasepriceEnabled] [bit] NOT NULL,
	[BasepriceAmount] [decimal](18, 4) NOT NULL,
	[BasepriceUnitId] [int] NOT NULL,
	[BasepriceBaseAmount] [decimal](18, 4) NOT NULL,
	[BasepriceBaseUnitId] [int] NOT NULL,
	[MarkAsNew] [bit] NOT NULL,
	[MarkAsNewStartDateTimeUtc] [datetime2](6) NULL,
	[MarkAsNewEndDateTimeUtc] [datetime2](6) NULL,
	[HasTierPrices] [bit] NOT NULL,
	[HasDiscountsApplied] [bit] NOT NULL,
	[Weight] [decimal](18, 4) NOT NULL,
	[Length] [decimal](18, 4) NOT NULL,
	[Width] [decimal](18, 4) NOT NULL,
	[Height] [decimal](18, 4) NOT NULL,
	[AvailableStartDateTimeUtc] [datetime2](6) NULL,
	[AvailableEndDateTimeUtc] [datetime2](6) NULL,
	[DisplayOrder] [int] NOT NULL,
	[Published] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[UpdatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Category_Mapping]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Category_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[IsFeaturedProduct] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_Product_Category_Mapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Manufacturer_Mapping]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Manufacturer_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ManufacturerId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[IsFeaturedProduct] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_Product_Manufacturer_Mapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Picture_Mapping]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Picture_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PictureId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_Product_Picture_Mapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_ProductAttribute_Mapping]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_ProductAttribute_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductAttributeId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[TextPrompt] [nvarchar](max) NULL,
	[IsRequired] [bit] NOT NULL,
	[AttributeControlTypeId] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[ValidationMinLength] [int] NULL,
	[ValidationMaxLength] [int] NULL,
	[ValidationFileAllowedExtensions] [nvarchar](max) NULL,
	[ValidationFileMaximumSize] [int] NULL,
	[DefaultValue] [nvarchar](max) NULL,
	[ConditionAttributeXml] [nvarchar](max) NULL,
 CONSTRAINT [PK_Product_ProductAttribute_Mapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_ProductTag_Mapping]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_ProductTag_Mapping](
	[Product_Id] [int] NOT NULL,
	[ProductTag_Id] [int] NOT NULL,
 CONSTRAINT [PK_Product_ProductTag_Mapping] PRIMARY KEY CLUSTERED 
(
	[Product_Id] ASC,
	[ProductTag_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_SpecificationAttribute_Mapping]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_SpecificationAttribute_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomValue] [nvarchar](4000) NULL,
	[ProductId] [int] NOT NULL,
	[SpecificationAttributeOptionId] [int] NOT NULL,
	[AttributeTypeId] [int] NOT NULL,
	[AllowFiltering] [bit] NOT NULL,
	[ShowOnProductPage] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_Product_SpecificationAttribute_Mapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttribute]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttribute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductAttribute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttributeCombination]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttributeCombination](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sku] [nvarchar](400) NULL,
	[ManufacturerPartNumber] [nvarchar](400) NULL,
	[Gtin] [nvarchar](400) NULL,
	[ProductId] [int] NOT NULL,
	[AttributesXml] [nvarchar](max) NULL,
	[StockQuantity] [int] NOT NULL,
	[AllowOutOfStockOrders] [bit] NOT NULL,
	[OverriddenPrice] [decimal](18, 4) NULL,
	[NotifyAdminForQuantityBelow] [int] NOT NULL,
	[MinStockQuantity] [int] NOT NULL,
	[PictureId] [int] NULL,
 CONSTRAINT [PK_ProductAttributeCombination] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttributeCombinationPicture]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttributeCombinationPicture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductAttributeCombinationId] [int] NOT NULL,
	[PictureId] [int] NOT NULL,
 CONSTRAINT [PK_ProductAttributeCombinationPicture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttributeValue]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttributeValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[ColorSquaresRgb] [nvarchar](100) NULL,
	[ProductAttributeMappingId] [int] NOT NULL,
	[AttributeValueTypeId] [int] NOT NULL,
	[AssociatedProductId] [int] NOT NULL,
	[ImageSquaresPictureId] [int] NOT NULL,
	[PriceAdjustment] [decimal](18, 4) NOT NULL,
	[PriceAdjustmentUsePercentage] [bit] NOT NULL,
	[WeightAdjustment] [decimal](18, 4) NOT NULL,
	[Cost] [decimal](18, 4) NOT NULL,
	[CustomerEntersQty] [bit] NOT NULL,
	[Quantity] [int] NOT NULL,
	[IsPreSelected] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[PictureId] [int] NULL,
 CONSTRAINT [PK_ProductAttributeValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttributeValuePicture]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttributeValuePicture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductAttributeValueId] [int] NOT NULL,
	[PictureId] [int] NOT NULL,
 CONSTRAINT [PK_ProductAttributeValuePicture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAvailabilityRange]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAvailabilityRange](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_ProductAvailabilityRange] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReview]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReview](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[ReviewText] [nvarchar](max) NULL,
	[ReplyText] [nvarchar](max) NULL,
	[CustomerNotifiedOfReply] [bit] NOT NULL,
	[Rating] [int] NOT NULL,
	[HelpfulYesTotal] [int] NOT NULL,
	[HelpfulNoTotal] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_ProductReview] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReview_ReviewType_Mapping]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReview_ReviewType_Mapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductReviewId] [int] NOT NULL,
	[ReviewTypeId] [int] NOT NULL,
	[Rating] [int] NOT NULL,
 CONSTRAINT [PK_ProductReview_ReviewType_Mapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReviewHelpfulness]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReviewHelpfulness](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductReviewId] [int] NOT NULL,
	[WasHelpful] [bit] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_ProductReviewHelpfulness] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTag]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
 CONSTRAINT [PK_ProductTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTemplate]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[ViewPath] [nvarchar](400) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[IgnoredProductTypes] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductVideo]    Script Date: 2024-06-20 13:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductVideo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VideoId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_ProductVideo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductWarehouseInventory]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductWarehouseInventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[ReservedQuantity] [int] NOT NULL,
 CONSTRAINT [PK_ProductWarehouseInventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QueuedEmail]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QueuedEmail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[From] [nvarchar](500) NOT NULL,
	[FromName] [nvarchar](500) NULL,
	[To] [nvarchar](500) NOT NULL,
	[ToName] [nvarchar](500) NULL,
	[ReplyTo] [nvarchar](500) NULL,
	[ReplyToName] [nvarchar](500) NULL,
	[CC] [nvarchar](500) NULL,
	[Bcc] [nvarchar](500) NULL,
	[Subject] [nvarchar](1000) NULL,
	[EmailAccountId] [int] NOT NULL,
	[PriorityId] [int] NOT NULL,
	[Body] [nvarchar](max) NULL,
	[AttachmentFilePath] [nvarchar](max) NULL,
	[AttachmentFileName] [nvarchar](max) NULL,
	[AttachedDownloadId] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[DontSendBeforeDateUtc] [datetime2](6) NULL,
	[SentTries] [int] NOT NULL,
	[SentOnUtc] [datetime2](6) NULL,
 CONSTRAINT [PK_QueuedEmail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecurringPayment]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecurringPayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InitialOrderId] [int] NOT NULL,
	[CycleLength] [int] NOT NULL,
	[CyclePeriodId] [int] NOT NULL,
	[TotalCycles] [int] NOT NULL,
	[StartDateUtc] [datetime2](6) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastPaymentFailed] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_RecurringPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecurringPaymentHistory]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecurringPaymentHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecurringPaymentId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_RecurringPaymentHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelatedProduct]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelatedProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId1] [int] NOT NULL,
	[ProductId2] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_RelatedProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnRequest]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnRequest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReasonForReturn] [nvarchar](max) NOT NULL,
	[RequestedAction] [nvarchar](max) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CustomNumber] [nvarchar](max) NULL,
	[StoreId] [int] NOT NULL,
	[OrderItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ReturnedQuantity] [int] NOT NULL,
	[CustomerComments] [nvarchar](max) NULL,
	[UploadedFileId] [int] NOT NULL,
	[StaffNotes] [nvarchar](max) NULL,
	[ReturnRequestStatusId] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[UpdatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_ReturnRequest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnRequestAction]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnRequestAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_ReturnRequestAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnRequestReason]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnRequestReason](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_ReturnRequestReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReviewType]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReviewType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[Description] [nvarchar](400) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[VisibleToAllCustomers] [bit] NOT NULL,
	[IsRequired] [bit] NOT NULL,
 CONSTRAINT [PK_ReviewType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RewardPointsHistory]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RewardPointsHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[Points] [int] NOT NULL,
	[PointsBalance] [int] NULL,
	[UsedAmount] [decimal](18, 4) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[EndDateUtc] [datetime2](6) NULL,
	[ValidPoints] [int] NULL,
	[UsedWithOrder] [uniqueidentifier] NULL,
 CONSTRAINT [PK_RewardPointsHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleTask]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleTask](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Seconds] [int] NOT NULL,
	[LastEnabledUtc] [datetime2](6) NULL,
	[Enabled] [bit] NOT NULL,
	[StopOnError] [bit] NOT NULL,
	[LastStartUtc] [datetime2](6) NULL,
	[LastEndUtc] [datetime2](6) NULL,
	[LastSuccessUtc] [datetime2](6) NULL,
 CONSTRAINT [PK_ScheduleTask] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchTerm]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchTerm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Keyword] [nvarchar](max) NULL,
	[StoreId] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_SearchTerm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[StoreId] [int] NOT NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipment]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[TrackingNumber] [nvarchar](max) NULL,
	[TotalWeight] [decimal](18, 4) NULL,
	[ShippedDateUtc] [datetime2](6) NULL,
	[DeliveryDateUtc] [datetime2](6) NULL,
	[ReadyForPickupDateUtc] [datetime2](6) NULL,
	[AdminComment] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_Shipment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShipmentItem]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShipmentItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShipmentId] [int] NOT NULL,
	[OrderItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
 CONSTRAINT [PK_ShipmentItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShippingByWeightByTotalRecord]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingByWeightByTotalRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WeightFrom] [decimal](18, 4) NOT NULL,
	[WeightTo] [decimal](18, 4) NOT NULL,
	[OrderSubtotalFrom] [decimal](18, 4) NOT NULL,
	[OrderSubtotalTo] [decimal](18, 4) NOT NULL,
	[AdditionalFixedCost] [decimal](18, 4) NOT NULL,
	[PercentageRateOfSubtotal] [decimal](18, 4) NOT NULL,
	[RatePerWeightUnit] [decimal](18, 4) NOT NULL,
	[LowerWeightLimit] [decimal](18, 4) NOT NULL,
	[Zip] [nvarchar](400) NULL,
	[StoreId] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[StateProvinceId] [int] NOT NULL,
	[ShippingMethodId] [int] NOT NULL,
	[TransitDays] [int] NULL,
 CONSTRAINT [PK_ShippingByWeightByTotalRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShippingMethod]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingMethod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_ShippingMethod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShippingMethodRestrictions]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingMethodRestrictions](
	[ShippingMethod_Id] [int] NOT NULL,
	[Country_Id] [int] NOT NULL,
 CONSTRAINT [PK_ShippingMethodRestrictions] PRIMARY KEY CLUSTERED 
(
	[ShippingMethod_Id] ASC,
	[Country_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCartItem]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCartItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[ShoppingCartTypeId] [int] NOT NULL,
	[AttributesXml] [nvarchar](max) NULL,
	[CustomerEnteredPrice] [decimal](18, 4) NOT NULL,
	[Quantity] [int] NOT NULL,
	[RentalStartDateUtc] [datetime2](6) NULL,
	[RentalEndDateUtc] [datetime2](6) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[UpdatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_ShoppingCartItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpecificationAttribute]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpecificationAttribute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[SpecificationAttributeGroupId] [int] NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_SpecificationAttribute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpecificationAttributeGroup]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpecificationAttributeGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_SpecificationAttributeGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpecificationAttributeOption]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpecificationAttributeOption](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ColorSquaresRgb] [nvarchar](100) NULL,
	[SpecificationAttributeId] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_SpecificationAttributeOption] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StateProvince]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StateProvince](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Abbreviation] [nvarchar](100) NULL,
	[CountryId] [int] NOT NULL,
	[Published] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_StateProvince] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockQuantityHistory]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockQuantityHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[QuantityAdjustment] [int] NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[Message] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[CombinationId] [int] NULL,
	[WarehouseId] [int] NULL,
 CONSTRAINT [PK_StockQuantityHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[Url] [nvarchar](400) NOT NULL,
	[Hosts] [nvarchar](1000) NULL,
	[CompanyName] [nvarchar](1000) NULL,
	[CompanyAddress] [nvarchar](1000) NULL,
	[CompanyPhoneNumber] [nvarchar](1000) NULL,
	[CompanyVat] [nvarchar](1000) NULL,
	[DefaultMetaKeywords] [nvarchar](max) NULL,
	[DefaultMetaDescription] [nvarchar](max) NULL,
	[DefaultTitle] [nvarchar](max) NULL,
	[HomepageTitle] [nvarchar](max) NULL,
	[HomepageDescription] [nvarchar](max) NULL,
	[SslEnabled] [bit] NOT NULL,
	[DefaultLanguageId] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreMapping]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EntityName] [nvarchar](400) NOT NULL,
	[StoreId] [int] NOT NULL,
	[EntityId] [int] NOT NULL,
 CONSTRAINT [PK_StoreMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StorePickupPoint]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorePickupPoint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Latitude] [decimal](18, 8) NULL,
	[Longitude] [decimal](18, 8) NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[AddressId] [int] NOT NULL,
	[PickupFee] [decimal](18, 4) NOT NULL,
	[OpeningHours] [nvarchar](max) NULL,
	[DisplayOrder] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[TransitDays] [int] NULL,
 CONSTRAINT [PK_StorePickupPoint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxCategory]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_TaxCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxRate]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxRate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [int] NOT NULL,
	[TaxCategoryId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[StateProvinceId] [int] NOT NULL,
	[Zip] [nvarchar](max) NULL,
	[Percentage] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_TaxRate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxTransactionLog]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxTransactionLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusCode] [int] NOT NULL,
	[Url] [nvarchar](max) NULL,
	[RequestMessage] [nvarchar](max) NULL,
	[ResponseMessage] [nvarchar](max) NULL,
	[CustomerId] [int] NOT NULL,
	[CreatedDateUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_TaxTransactionLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TierPrice]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TierPrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerRoleId] [int] NULL,
	[ProductId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[StartDateTimeUtc] [datetime2](6) NULL,
	[EndDateTimeUtc] [datetime2](6) NULL,
 CONSTRAINT [PK_TierPrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemName] [nvarchar](max) NULL,
	[IncludeInSitemap] [bit] NOT NULL,
	[IncludeInTopMenu] [bit] NOT NULL,
	[IncludeInFooterColumn1] [bit] NOT NULL,
	[IncludeInFooterColumn2] [bit] NOT NULL,
	[IncludeInFooterColumn3] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[AccessibleWhenStoreClosed] [bit] NOT NULL,
	[IsPasswordProtected] [bit] NOT NULL,
	[Password] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[Published] [bit] NOT NULL,
	[TopicTemplateId] [int] NOT NULL,
	[MetaKeywords] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[MetaTitle] [nvarchar](max) NULL,
	[SubjectToAcl] [bit] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TopicTemplate]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TopicTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[ViewPath] [nvarchar](400) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_TopicTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UrlRecord]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrlRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EntityName] [nvarchar](400) NOT NULL,
	[Slug] [nvarchar](400) NOT NULL,
	[EntityId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LanguageId] [int] NOT NULL,
 CONSTRAINT [PK_UrlRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[Email] [nvarchar](400) NULL,
	[MetaKeywords] [nvarchar](400) NULL,
	[MetaTitle] [nvarchar](400) NULL,
	[PageSizeOptions] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[PictureId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
	[AdminComment] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[PageSize] [int] NOT NULL,
	[AllowCustomersToSelectPageSize] [bit] NOT NULL,
	[PriceRangeFiltering] [bit] NOT NULL,
	[PriceFrom] [decimal](18, 4) NOT NULL,
	[PriceTo] [decimal](18, 4) NOT NULL,
	[ManuallyPriceRange] [bit] NOT NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorAttribute]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorAttribute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[AttributeControlTypeId] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_VendorAttribute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorAttributeValue]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorAttributeValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[VendorAttributeId] [int] NOT NULL,
	[IsPreSelected] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_VendorAttributeValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorNote]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorNote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[VendorId] [int] NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
 CONSTRAINT [PK_VendorNote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Video]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Video](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VideoUrl] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[AdminComment] [nvarchar](max) NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZettleRecord]    Script Date: 2024-06-20 13:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZettleRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Active] [bit] NOT NULL,
	[Uuid] [nvarchar](max) NULL,
	[ProductId] [int] NOT NULL,
	[VariantUuid] [nvarchar](max) NULL,
	[CombinationId] [int] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[OperationTypeId] [int] NOT NULL,
	[PriceSyncEnabled] [bit] NOT NULL,
	[ImageSyncEnabled] [bit] NOT NULL,
	[InventoryTrackingEnabled] [bit] NOT NULL,
	[ExternalUuid] [nvarchar](max) NULL,
	[UpdatedOnUtc] [datetime2](6) NULL,
 CONSTRAINT [PK_ZettleRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AclRecord]  WITH CHECK ADD  CONSTRAINT [FK_AclRecord_CustomerRoleId_CustomerRole_Id] FOREIGN KEY([CustomerRoleId])
REFERENCES [dbo].[CustomerRole] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AclRecord] CHECK CONSTRAINT [FK_AclRecord_CustomerRoleId_CustomerRole_Id]
GO
ALTER TABLE [dbo].[ActivityLog]  WITH CHECK ADD  CONSTRAINT [FK_ActivityLog_ActivityLogTypeId_ActivityLogType_Id] FOREIGN KEY([ActivityLogTypeId])
REFERENCES [dbo].[ActivityLogType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActivityLog] CHECK CONSTRAINT [FK_ActivityLog_ActivityLogTypeId_ActivityLogType_Id]
GO
ALTER TABLE [dbo].[ActivityLog]  WITH CHECK ADD  CONSTRAINT [FK_ActivityLog_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActivityLog] CHECK CONSTRAINT [FK_ActivityLog_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_CountryId_Country_Id] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_CountryId_Country_Id]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_StateProvinceId_StateProvince_Id] FOREIGN KEY([StateProvinceId])
REFERENCES [dbo].[StateProvince] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_StateProvinceId_StateProvince_Id]
GO
ALTER TABLE [dbo].[AddressAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_AddressAttributeValue_AddressAttributeId_AddressAttribute_Id] FOREIGN KEY([AddressAttributeId])
REFERENCES [dbo].[AddressAttribute] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AddressAttributeValue] CHECK CONSTRAINT [FK_AddressAttributeValue_AddressAttributeId_AddressAttribute_Id]
GO
ALTER TABLE [dbo].[Affiliate]  WITH CHECK ADD  CONSTRAINT [FK_Affiliate_AddressId_Address_Id] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Affiliate] CHECK CONSTRAINT [FK_Affiliate_AddressId_Address_Id]
GO
ALTER TABLE [dbo].[BackInStockSubscription]  WITH CHECK ADD  CONSTRAINT [FK_BackInStockSubscription_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BackInStockSubscription] CHECK CONSTRAINT [FK_BackInStockSubscription_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[BackInStockSubscription]  WITH CHECK ADD  CONSTRAINT [FK_BackInStockSubscription_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BackInStockSubscription] CHECK CONSTRAINT [FK_BackInStockSubscription_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[BlogComment]  WITH CHECK ADD  CONSTRAINT [FK_BlogComment_BlogPostId_BlogPost_Id] FOREIGN KEY([BlogPostId])
REFERENCES [dbo].[BlogPost] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogComment] CHECK CONSTRAINT [FK_BlogComment_BlogPostId_BlogPost_Id]
GO
ALTER TABLE [dbo].[BlogComment]  WITH CHECK ADD  CONSTRAINT [FK_BlogComment_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogComment] CHECK CONSTRAINT [FK_BlogComment_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[BlogComment]  WITH CHECK ADD  CONSTRAINT [FK_BlogComment_StoreId_Store_Id] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogComment] CHECK CONSTRAINT [FK_BlogComment_StoreId_Store_Id]
GO
ALTER TABLE [dbo].[BlogPost]  WITH CHECK ADD  CONSTRAINT [FK_BlogPost_LanguageId_Language_Id] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogPost] CHECK CONSTRAINT [FK_BlogPost_LanguageId_Language_Id]
GO
ALTER TABLE [dbo].[CheckoutAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_CheckoutAttributeValue_CheckoutAttributeId_CheckoutAttribute_Id] FOREIGN KEY([CheckoutAttributeId])
REFERENCES [dbo].[CheckoutAttribute] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CheckoutAttributeValue] CHECK CONSTRAINT [FK_CheckoutAttributeValue_CheckoutAttributeId_CheckoutAttribute_Id]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_BillingAddress_Id_Address_Id] FOREIGN KEY([BillingAddress_Id])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_BillingAddress_Id_Address_Id]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_CurrencyId_Currency_Id] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_CurrencyId_Currency_Id]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_LanguageId_Language_Id] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_LanguageId_Language_Id]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_ShippingAddress_Id_Address_Id] FOREIGN KEY([ShippingAddress_Id])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_ShippingAddress_Id_Address_Id]
GO
ALTER TABLE [dbo].[Customer_CustomerRole_Mapping]  WITH NOCHECK ADD  CONSTRAINT [FK_Customer_CustomerRole_Mapping_Customer_Id_Customer_Id] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customer_CustomerRole_Mapping] CHECK CONSTRAINT [FK_Customer_CustomerRole_Mapping_Customer_Id_Customer_Id]
GO
ALTER TABLE [dbo].[Customer_CustomerRole_Mapping]  WITH NOCHECK ADD  CONSTRAINT [FK_Customer_CustomerRole_Mapping_CustomerRole_Id_CustomerRole_Id] FOREIGN KEY([CustomerRole_Id])
REFERENCES [dbo].[CustomerRole] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customer_CustomerRole_Mapping] CHECK CONSTRAINT [FK_Customer_CustomerRole_Mapping_CustomerRole_Id_CustomerRole_Id]
GO
ALTER TABLE [dbo].[CustomerAddresses]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAddresses_Address_Id_Address_Id] FOREIGN KEY([Address_Id])
REFERENCES [dbo].[Address] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerAddresses] CHECK CONSTRAINT [FK_CustomerAddresses_Address_Id_Address_Id]
GO
ALTER TABLE [dbo].[CustomerAddresses]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAddresses_Customer_Id_Customer_Id] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerAddresses] CHECK CONSTRAINT [FK_CustomerAddresses_Customer_Id_Customer_Id]
GO
ALTER TABLE [dbo].[CustomerAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAttributeValue_CustomerAttributeId_CustomerAttribute_Id] FOREIGN KEY([CustomerAttributeId])
REFERENCES [dbo].[CustomerAttribute] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerAttributeValue] CHECK CONSTRAINT [FK_CustomerAttributeValue_CustomerAttributeId_CustomerAttribute_Id]
GO
ALTER TABLE [dbo].[CustomerPassword]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPassword_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerPassword] CHECK CONSTRAINT [FK_CustomerPassword_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[Discount_AppliedToCategories]  WITH CHECK ADD  CONSTRAINT [FK_Discount_AppliedToCategories_Category_Id_Category_Id] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Discount_AppliedToCategories] CHECK CONSTRAINT [FK_Discount_AppliedToCategories_Category_Id_Category_Id]
GO
ALTER TABLE [dbo].[Discount_AppliedToCategories]  WITH CHECK ADD  CONSTRAINT [FK_Discount_AppliedToCategories_Discount_Id_Discount_Id] FOREIGN KEY([Discount_Id])
REFERENCES [dbo].[Discount] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Discount_AppliedToCategories] CHECK CONSTRAINT [FK_Discount_AppliedToCategories_Discount_Id_Discount_Id]
GO
ALTER TABLE [dbo].[Discount_AppliedToManufacturers]  WITH CHECK ADD  CONSTRAINT [FK_Discount_AppliedToManufacturers_Discount_Id_Discount_Id] FOREIGN KEY([Discount_Id])
REFERENCES [dbo].[Discount] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Discount_AppliedToManufacturers] CHECK CONSTRAINT [FK_Discount_AppliedToManufacturers_Discount_Id_Discount_Id]
GO
ALTER TABLE [dbo].[Discount_AppliedToManufacturers]  WITH CHECK ADD  CONSTRAINT [FK_Discount_AppliedToManufacturers_Manufacturer_Id_Manufacturer_Id] FOREIGN KEY([Manufacturer_Id])
REFERENCES [dbo].[Manufacturer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Discount_AppliedToManufacturers] CHECK CONSTRAINT [FK_Discount_AppliedToManufacturers_Manufacturer_Id_Manufacturer_Id]
GO
ALTER TABLE [dbo].[Discount_AppliedToProducts]  WITH CHECK ADD  CONSTRAINT [FK_Discount_AppliedToProducts_Discount_Id_Discount_Id] FOREIGN KEY([Discount_Id])
REFERENCES [dbo].[Discount] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Discount_AppliedToProducts] CHECK CONSTRAINT [FK_Discount_AppliedToProducts_Discount_Id_Discount_Id]
GO
ALTER TABLE [dbo].[Discount_AppliedToProducts]  WITH CHECK ADD  CONSTRAINT [FK_Discount_AppliedToProducts_Product_Id_Product_Id] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Discount_AppliedToProducts] CHECK CONSTRAINT [FK_Discount_AppliedToProducts_Product_Id_Product_Id]
GO
ALTER TABLE [dbo].[DiscountRequirement]  WITH CHECK ADD  CONSTRAINT [FK_DiscountRequirement_DiscountId_Discount_Id] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discount] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiscountRequirement] CHECK CONSTRAINT [FK_DiscountRequirement_DiscountId_Discount_Id]
GO
ALTER TABLE [dbo].[DiscountRequirement]  WITH CHECK ADD  CONSTRAINT [FK_DiscountRequirement_ParentId_DiscountRequirement_Id] FOREIGN KEY([ParentId])
REFERENCES [dbo].[DiscountRequirement] ([Id])
GO
ALTER TABLE [dbo].[DiscountRequirement] CHECK CONSTRAINT [FK_DiscountRequirement_ParentId_DiscountRequirement_Id]
GO
ALTER TABLE [dbo].[DiscountUsageHistory]  WITH CHECK ADD  CONSTRAINT [FK_DiscountUsageHistory_DiscountId_Discount_Id] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discount] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiscountUsageHistory] CHECK CONSTRAINT [FK_DiscountUsageHistory_DiscountId_Discount_Id]
GO
ALTER TABLE [dbo].[DiscountUsageHistory]  WITH CHECK ADD  CONSTRAINT [FK_DiscountUsageHistory_OrderId_Order_Id] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiscountUsageHistory] CHECK CONSTRAINT [FK_DiscountUsageHistory_OrderId_Order_Id]
GO
ALTER TABLE [dbo].[ExternalAuthenticationRecord]  WITH CHECK ADD  CONSTRAINT [FK_ExternalAuthenticationRecord_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExternalAuthenticationRecord] CHECK CONSTRAINT [FK_ExternalAuthenticationRecord_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[Forums_Forum]  WITH CHECK ADD  CONSTRAINT [FK_Forums_Forum_ForumGroupId_Forums_Group_Id] FOREIGN KEY([ForumGroupId])
REFERENCES [dbo].[Forums_Group] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Forums_Forum] CHECK CONSTRAINT [FK_Forums_Forum_ForumGroupId_Forums_Group_Id]
GO
ALTER TABLE [dbo].[Forums_Post]  WITH CHECK ADD  CONSTRAINT [FK_Forums_Post_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Forums_Post] CHECK CONSTRAINT [FK_Forums_Post_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[Forums_Post]  WITH CHECK ADD  CONSTRAINT [FK_Forums_Post_TopicId_Forums_Topic_Id] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Forums_Topic] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Forums_Post] CHECK CONSTRAINT [FK_Forums_Post_TopicId_Forums_Topic_Id]
GO
ALTER TABLE [dbo].[Forums_PostVote]  WITH CHECK ADD  CONSTRAINT [FK_Forums_PostVote_ForumPostId_Forums_Post_Id] FOREIGN KEY([ForumPostId])
REFERENCES [dbo].[Forums_Post] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Forums_PostVote] CHECK CONSTRAINT [FK_Forums_PostVote_ForumPostId_Forums_Post_Id]
GO
ALTER TABLE [dbo].[Forums_PrivateMessage]  WITH CHECK ADD  CONSTRAINT [FK_Forums_PrivateMessage_FromCustomerId_Customer_Id] FOREIGN KEY([FromCustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Forums_PrivateMessage] CHECK CONSTRAINT [FK_Forums_PrivateMessage_FromCustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[Forums_PrivateMessage]  WITH CHECK ADD  CONSTRAINT [FK_Forums_PrivateMessage_ToCustomerId_Customer_Id] FOREIGN KEY([ToCustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Forums_PrivateMessage] CHECK CONSTRAINT [FK_Forums_PrivateMessage_ToCustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[Forums_Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Forums_Subscription_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Forums_Subscription] CHECK CONSTRAINT [FK_Forums_Subscription_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[Forums_Topic]  WITH CHECK ADD  CONSTRAINT [FK_Forums_Topic_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Forums_Topic] CHECK CONSTRAINT [FK_Forums_Topic_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[Forums_Topic]  WITH CHECK ADD  CONSTRAINT [FK_Forums_Topic_ForumId_Forums_Forum_Id] FOREIGN KEY([ForumId])
REFERENCES [dbo].[Forums_Forum] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Forums_Topic] CHECK CONSTRAINT [FK_Forums_Topic_ForumId_Forums_Forum_Id]
GO
ALTER TABLE [dbo].[GiftCard]  WITH CHECK ADD  CONSTRAINT [FK_GiftCard_PurchasedWithOrderItemId_OrderItem_Id] FOREIGN KEY([PurchasedWithOrderItemId])
REFERENCES [dbo].[OrderItem] ([Id])
GO
ALTER TABLE [dbo].[GiftCard] CHECK CONSTRAINT [FK_GiftCard_PurchasedWithOrderItemId_OrderItem_Id]
GO
ALTER TABLE [dbo].[GiftCardUsageHistory]  WITH CHECK ADD  CONSTRAINT [FK_GiftCardUsageHistory_GiftCardId_GiftCard_Id] FOREIGN KEY([GiftCardId])
REFERENCES [dbo].[GiftCard] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GiftCardUsageHistory] CHECK CONSTRAINT [FK_GiftCardUsageHistory_GiftCardId_GiftCard_Id]
GO
ALTER TABLE [dbo].[GiftCardUsageHistory]  WITH CHECK ADD  CONSTRAINT [FK_GiftCardUsageHistory_UsedWithOrderId_Order_Id] FOREIGN KEY([UsedWithOrderId])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GiftCardUsageHistory] CHECK CONSTRAINT [FK_GiftCardUsageHistory_UsedWithOrderId_Order_Id]
GO
ALTER TABLE [dbo].[LocaleStringResource]  WITH NOCHECK ADD  CONSTRAINT [FK_LocaleStringResource_LanguageId_Language_Id] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LocaleStringResource] CHECK CONSTRAINT [FK_LocaleStringResource_LanguageId_Language_Id]
GO
ALTER TABLE [dbo].[LocalizedProperty]  WITH CHECK ADD  CONSTRAINT [FK_LocalizedProperty_LanguageId_Language_Id] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LocalizedProperty] CHECK CONSTRAINT [FK_LocalizedProperty_LanguageId_Language_Id]
GO
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_LanguageId_Language_Id] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_LanguageId_Language_Id]
GO
ALTER TABLE [dbo].[NewsComment]  WITH CHECK ADD  CONSTRAINT [FK_NewsComment_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NewsComment] CHECK CONSTRAINT [FK_NewsComment_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[NewsComment]  WITH CHECK ADD  CONSTRAINT [FK_NewsComment_NewsItemId_News_Id] FOREIGN KEY([NewsItemId])
REFERENCES [dbo].[News] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NewsComment] CHECK CONSTRAINT [FK_NewsComment_NewsItemId_News_Id]
GO
ALTER TABLE [dbo].[NewsComment]  WITH CHECK ADD  CONSTRAINT [FK_NewsComment_StoreId_Store_Id] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NewsComment] CHECK CONSTRAINT [FK_NewsComment_StoreId_Store_Id]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_BillingAddressId_Address_Id] FOREIGN KEY([BillingAddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_BillingAddressId_Address_Id]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_PickupAddressId_Address_Id] FOREIGN KEY([PickupAddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_PickupAddressId_Address_Id]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_RewardPointsHistoryEntryId_RewardPointsHistory_Id] FOREIGN KEY([RewardPointsHistoryEntryId])
REFERENCES [dbo].[RewardPointsHistory] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_RewardPointsHistoryEntryId_RewardPointsHistory_Id]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_ShippingAddressId_Address_Id] FOREIGN KEY([ShippingAddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_ShippingAddressId_Address_Id]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_OrderId_Order_Id] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_OrderId_Order_Id]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[OrderNote]  WITH CHECK ADD  CONSTRAINT [FK_OrderNote_OrderId_Order_Id] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderNote] CHECK CONSTRAINT [FK_OrderNote_OrderId_Order_Id]
GO
ALTER TABLE [dbo].[PermissionRecord_Role_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_PermissionRecord_Role_Mapping_CustomerRole_Id_CustomerRole_Id] FOREIGN KEY([CustomerRole_Id])
REFERENCES [dbo].[CustomerRole] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PermissionRecord_Role_Mapping] CHECK CONSTRAINT [FK_PermissionRecord_Role_Mapping_CustomerRole_Id_CustomerRole_Id]
GO
ALTER TABLE [dbo].[PermissionRecord_Role_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_PermissionRecord_Role_Mapping_PermissionRecord_Id_PermissionRecord_Id] FOREIGN KEY([PermissionRecord_Id])
REFERENCES [dbo].[PermissionRecord] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PermissionRecord_Role_Mapping] CHECK CONSTRAINT [FK_PermissionRecord_Role_Mapping_PermissionRecord_Id_PermissionRecord_Id]
GO
ALTER TABLE [dbo].[PictureBinary]  WITH CHECK ADD  CONSTRAINT [FK_PictureBinary_PictureId_Picture_Id] FOREIGN KEY([PictureId])
REFERENCES [dbo].[Picture] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PictureBinary] CHECK CONSTRAINT [FK_PictureBinary_PictureId_Picture_Id]
GO
ALTER TABLE [dbo].[Poll]  WITH CHECK ADD  CONSTRAINT [FK_Poll_LanguageId_Language_Id] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Poll] CHECK CONSTRAINT [FK_Poll_LanguageId_Language_Id]
GO
ALTER TABLE [dbo].[PollAnswer]  WITH CHECK ADD  CONSTRAINT [FK_PollAnswer_PollId_Poll_Id] FOREIGN KEY([PollId])
REFERENCES [dbo].[Poll] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PollAnswer] CHECK CONSTRAINT [FK_PollAnswer_PollId_Poll_Id]
GO
ALTER TABLE [dbo].[PollVotingRecord]  WITH CHECK ADD  CONSTRAINT [FK_PollVotingRecord_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PollVotingRecord] CHECK CONSTRAINT [FK_PollVotingRecord_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[PollVotingRecord]  WITH CHECK ADD  CONSTRAINT [FK_PollVotingRecord_PollAnswerId_PollAnswer_Id] FOREIGN KEY([PollAnswerId])
REFERENCES [dbo].[PollAnswer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PollVotingRecord] CHECK CONSTRAINT [FK_PollVotingRecord_PollAnswerId_PollAnswer_Id]
GO
ALTER TABLE [dbo].[PredefinedProductAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_PredefinedProductAttributeValue_ProductAttributeId_ProductAttribute_Id] FOREIGN KEY([ProductAttributeId])
REFERENCES [dbo].[ProductAttribute] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PredefinedProductAttributeValue] CHECK CONSTRAINT [FK_PredefinedProductAttributeValue_ProductAttributeId_ProductAttribute_Id]
GO
ALTER TABLE [dbo].[Product_Category_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_Mapping_CategoryId_Category_Id] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_Category_Mapping] CHECK CONSTRAINT [FK_Product_Category_Mapping_CategoryId_Category_Id]
GO
ALTER TABLE [dbo].[Product_Category_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_Mapping_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_Category_Mapping] CHECK CONSTRAINT [FK_Product_Category_Mapping_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[Product_Manufacturer_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_Manufacturer_Mapping_ManufacturerId_Manufacturer_Id] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_Manufacturer_Mapping] CHECK CONSTRAINT [FK_Product_Manufacturer_Mapping_ManufacturerId_Manufacturer_Id]
GO
ALTER TABLE [dbo].[Product_Manufacturer_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_Manufacturer_Mapping_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_Manufacturer_Mapping] CHECK CONSTRAINT [FK_Product_Manufacturer_Mapping_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[Product_Picture_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_Picture_Mapping_PictureId_Picture_Id] FOREIGN KEY([PictureId])
REFERENCES [dbo].[Picture] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_Picture_Mapping] CHECK CONSTRAINT [FK_Product_Picture_Mapping_PictureId_Picture_Id]
GO
ALTER TABLE [dbo].[Product_Picture_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_Picture_Mapping_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_Picture_Mapping] CHECK CONSTRAINT [FK_Product_Picture_Mapping_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[Product_ProductAttribute_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductAttribute_Mapping_ProductAttributeId_ProductAttribute_Id] FOREIGN KEY([ProductAttributeId])
REFERENCES [dbo].[ProductAttribute] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_ProductAttribute_Mapping] CHECK CONSTRAINT [FK_Product_ProductAttribute_Mapping_ProductAttributeId_ProductAttribute_Id]
GO
ALTER TABLE [dbo].[Product_ProductAttribute_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductAttribute_Mapping_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_ProductAttribute_Mapping] CHECK CONSTRAINT [FK_Product_ProductAttribute_Mapping_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[Product_ProductTag_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductTag_Mapping_Product_Id_Product_Id] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_ProductTag_Mapping] CHECK CONSTRAINT [FK_Product_ProductTag_Mapping_Product_Id_Product_Id]
GO
ALTER TABLE [dbo].[Product_ProductTag_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductTag_Mapping_ProductTag_Id_ProductTag_Id] FOREIGN KEY([ProductTag_Id])
REFERENCES [dbo].[ProductTag] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_ProductTag_Mapping] CHECK CONSTRAINT [FK_Product_ProductTag_Mapping_ProductTag_Id_ProductTag_Id]
GO
ALTER TABLE [dbo].[Product_SpecificationAttribute_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_SpecificationAttribute_Mapping_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_SpecificationAttribute_Mapping] CHECK CONSTRAINT [FK_Product_SpecificationAttribute_Mapping_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[Product_SpecificationAttribute_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Product_SpecificationAttribute_Mapping_SpecificationAttributeOptionId_SpecificationAttributeOption_Id] FOREIGN KEY([SpecificationAttributeOptionId])
REFERENCES [dbo].[SpecificationAttributeOption] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_SpecificationAttribute_Mapping] CHECK CONSTRAINT [FK_Product_SpecificationAttribute_Mapping_SpecificationAttributeOptionId_SpecificationAttributeOption_Id]
GO
ALTER TABLE [dbo].[ProductAttributeCombination]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributeCombination_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductAttributeCombination] CHECK CONSTRAINT [FK_ProductAttributeCombination_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[ProductAttributeCombinationPicture]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributeCombinationPicture_ProductAttributeCombinationId_ProductAttributeCombination_Id] FOREIGN KEY([ProductAttributeCombinationId])
REFERENCES [dbo].[ProductAttributeCombination] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductAttributeCombinationPicture] CHECK CONSTRAINT [FK_ProductAttributeCombinationPicture_ProductAttributeCombinationId_ProductAttributeCombination_Id]
GO
ALTER TABLE [dbo].[ProductAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributeValue_ProductAttributeMappingId_Product_ProductAttribute_Mapping_Id] FOREIGN KEY([ProductAttributeMappingId])
REFERENCES [dbo].[Product_ProductAttribute_Mapping] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductAttributeValue] CHECK CONSTRAINT [FK_ProductAttributeValue_ProductAttributeMappingId_Product_ProductAttribute_Mapping_Id]
GO
ALTER TABLE [dbo].[ProductAttributeValuePicture]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributeValuePicture_ProductAttributeValueId_ProductAttributeValue_Id] FOREIGN KEY([ProductAttributeValueId])
REFERENCES [dbo].[ProductAttributeValue] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductAttributeValuePicture] CHECK CONSTRAINT [FK_ProductAttributeValuePicture_ProductAttributeValueId_ProductAttributeValue_Id]
GO
ALTER TABLE [dbo].[ProductReview]  WITH CHECK ADD  CONSTRAINT [FK_ProductReview_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReview] CHECK CONSTRAINT [FK_ProductReview_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[ProductReview]  WITH CHECK ADD  CONSTRAINT [FK_ProductReview_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReview] CHECK CONSTRAINT [FK_ProductReview_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[ProductReview]  WITH CHECK ADD  CONSTRAINT [FK_ProductReview_StoreId_Store_Id] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReview] CHECK CONSTRAINT [FK_ProductReview_StoreId_Store_Id]
GO
ALTER TABLE [dbo].[ProductReview_ReviewType_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_ProductReview_ReviewType_Mapping_ProductReviewId_ProductReview_Id] FOREIGN KEY([ProductReviewId])
REFERENCES [dbo].[ProductReview] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReview_ReviewType_Mapping] CHECK CONSTRAINT [FK_ProductReview_ReviewType_Mapping_ProductReviewId_ProductReview_Id]
GO
ALTER TABLE [dbo].[ProductReview_ReviewType_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_ProductReview_ReviewType_Mapping_ReviewTypeId_ReviewType_Id] FOREIGN KEY([ReviewTypeId])
REFERENCES [dbo].[ReviewType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReview_ReviewType_Mapping] CHECK CONSTRAINT [FK_ProductReview_ReviewType_Mapping_ReviewTypeId_ReviewType_Id]
GO
ALTER TABLE [dbo].[ProductReviewHelpfulness]  WITH CHECK ADD  CONSTRAINT [FK_ProductReviewHelpfulness_ProductReviewId_ProductReview_Id] FOREIGN KEY([ProductReviewId])
REFERENCES [dbo].[ProductReview] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReviewHelpfulness] CHECK CONSTRAINT [FK_ProductReviewHelpfulness_ProductReviewId_ProductReview_Id]
GO
ALTER TABLE [dbo].[ProductVideo]  WITH CHECK ADD  CONSTRAINT [FK_ProductVideo_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductVideo] CHECK CONSTRAINT [FK_ProductVideo_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[ProductVideo]  WITH CHECK ADD  CONSTRAINT [FK_ProductVideo_VideoId_Video_Id] FOREIGN KEY([VideoId])
REFERENCES [dbo].[Video] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductVideo] CHECK CONSTRAINT [FK_ProductVideo_VideoId_Video_Id]
GO
ALTER TABLE [dbo].[ProductWarehouseInventory]  WITH CHECK ADD  CONSTRAINT [FK_ProductWarehouseInventory_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductWarehouseInventory] CHECK CONSTRAINT [FK_ProductWarehouseInventory_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[ProductWarehouseInventory]  WITH CHECK ADD  CONSTRAINT [FK_ProductWarehouseInventory_WarehouseId_Warehouse_Id] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductWarehouseInventory] CHECK CONSTRAINT [FK_ProductWarehouseInventory_WarehouseId_Warehouse_Id]
GO
ALTER TABLE [dbo].[QueuedEmail]  WITH CHECK ADD  CONSTRAINT [FK_QueuedEmail_EmailAccountId_EmailAccount_Id] FOREIGN KEY([EmailAccountId])
REFERENCES [dbo].[EmailAccount] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QueuedEmail] CHECK CONSTRAINT [FK_QueuedEmail_EmailAccountId_EmailAccount_Id]
GO
ALTER TABLE [dbo].[RecurringPayment]  WITH CHECK ADD  CONSTRAINT [FK_RecurringPayment_InitialOrderId_Order_Id] FOREIGN KEY([InitialOrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[RecurringPayment] CHECK CONSTRAINT [FK_RecurringPayment_InitialOrderId_Order_Id]
GO
ALTER TABLE [dbo].[RecurringPaymentHistory]  WITH CHECK ADD  CONSTRAINT [FK_RecurringPaymentHistory_RecurringPaymentId_RecurringPayment_Id] FOREIGN KEY([RecurringPaymentId])
REFERENCES [dbo].[RecurringPayment] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RecurringPaymentHistory] CHECK CONSTRAINT [FK_RecurringPaymentHistory_RecurringPaymentId_RecurringPayment_Id]
GO
ALTER TABLE [dbo].[ReturnRequest]  WITH CHECK ADD  CONSTRAINT [FK_ReturnRequest_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReturnRequest] CHECK CONSTRAINT [FK_ReturnRequest_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[RewardPointsHistory]  WITH CHECK ADD  CONSTRAINT [FK_RewardPointsHistory_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RewardPointsHistory] CHECK CONSTRAINT [FK_RewardPointsHistory_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[Shipment]  WITH CHECK ADD  CONSTRAINT [FK_Shipment_OrderId_Order_Id] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shipment] CHECK CONSTRAINT [FK_Shipment_OrderId_Order_Id]
GO
ALTER TABLE [dbo].[ShipmentItem]  WITH CHECK ADD  CONSTRAINT [FK_ShipmentItem_ShipmentId_Shipment_Id] FOREIGN KEY([ShipmentId])
REFERENCES [dbo].[Shipment] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShipmentItem] CHECK CONSTRAINT [FK_ShipmentItem_ShipmentId_Shipment_Id]
GO
ALTER TABLE [dbo].[ShippingMethodRestrictions]  WITH CHECK ADD  CONSTRAINT [FK_ShippingMethodRestrictions_Country_Id_Country_Id] FOREIGN KEY([Country_Id])
REFERENCES [dbo].[Country] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShippingMethodRestrictions] CHECK CONSTRAINT [FK_ShippingMethodRestrictions_Country_Id_Country_Id]
GO
ALTER TABLE [dbo].[ShippingMethodRestrictions]  WITH CHECK ADD  CONSTRAINT [FK_ShippingMethodRestrictions_ShippingMethod_Id_ShippingMethod_Id] FOREIGN KEY([ShippingMethod_Id])
REFERENCES [dbo].[ShippingMethod] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShippingMethodRestrictions] CHECK CONSTRAINT [FK_ShippingMethodRestrictions_ShippingMethod_Id_ShippingMethod_Id]
GO
ALTER TABLE [dbo].[ShoppingCartItem]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartItem_CustomerId_Customer_Id] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShoppingCartItem] CHECK CONSTRAINT [FK_ShoppingCartItem_CustomerId_Customer_Id]
GO
ALTER TABLE [dbo].[ShoppingCartItem]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartItem_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShoppingCartItem] CHECK CONSTRAINT [FK_ShoppingCartItem_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[SpecificationAttribute]  WITH CHECK ADD  CONSTRAINT [FK_SpecificationAttribute_SpecificationAttributeGroupId_SpecificationAttributeGroup_Id] FOREIGN KEY([SpecificationAttributeGroupId])
REFERENCES [dbo].[SpecificationAttributeGroup] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpecificationAttribute] CHECK CONSTRAINT [FK_SpecificationAttribute_SpecificationAttributeGroupId_SpecificationAttributeGroup_Id]
GO
ALTER TABLE [dbo].[SpecificationAttributeOption]  WITH CHECK ADD  CONSTRAINT [FK_SpecificationAttributeOption_SpecificationAttributeId_SpecificationAttribute_Id] FOREIGN KEY([SpecificationAttributeId])
REFERENCES [dbo].[SpecificationAttribute] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpecificationAttributeOption] CHECK CONSTRAINT [FK_SpecificationAttributeOption_SpecificationAttributeId_SpecificationAttribute_Id]
GO
ALTER TABLE [dbo].[StateProvince]  WITH CHECK ADD  CONSTRAINT [FK_StateProvince_CountryId_Country_Id] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StateProvince] CHECK CONSTRAINT [FK_StateProvince_CountryId_Country_Id]
GO
ALTER TABLE [dbo].[StockQuantityHistory]  WITH CHECK ADD  CONSTRAINT [FK_StockQuantityHistory_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StockQuantityHistory] CHECK CONSTRAINT [FK_StockQuantityHistory_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[StoreMapping]  WITH CHECK ADD  CONSTRAINT [FK_StoreMapping_StoreId_Store_Id] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StoreMapping] CHECK CONSTRAINT [FK_StoreMapping_StoreId_Store_Id]
GO
ALTER TABLE [dbo].[TierPrice]  WITH CHECK ADD  CONSTRAINT [FK_TierPrice_CustomerRoleId_CustomerRole_Id] FOREIGN KEY([CustomerRoleId])
REFERENCES [dbo].[CustomerRole] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TierPrice] CHECK CONSTRAINT [FK_TierPrice_CustomerRoleId_CustomerRole_Id]
GO
ALTER TABLE [dbo].[TierPrice]  WITH CHECK ADD  CONSTRAINT [FK_TierPrice_ProductId_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TierPrice] CHECK CONSTRAINT [FK_TierPrice_ProductId_Product_Id]
GO
ALTER TABLE [dbo].[VendorAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_VendorAttributeValue_VendorAttributeId_VendorAttribute_Id] FOREIGN KEY([VendorAttributeId])
REFERENCES [dbo].[VendorAttribute] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VendorAttributeValue] CHECK CONSTRAINT [FK_VendorAttributeValue_VendorAttributeId_VendorAttribute_Id]
GO
ALTER TABLE [dbo].[VendorNote]  WITH CHECK ADD  CONSTRAINT [FK_VendorNote_VendorId_Vendor_Id] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendor] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VendorNote] CHECK CONSTRAINT [FK_VendorNote_VendorId_Vendor_Id]
GO
