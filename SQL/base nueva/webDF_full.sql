USE [master]
GO

CREATE DATABASE [ApiWeb]

GO
ALTER DATABASE [ApiWeb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApiWeb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApiWeb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApiWeb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApiWeb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApiWeb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApiWeb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApiWeb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ApiWeb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApiWeb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApiWeb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApiWeb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApiWeb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApiWeb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApiWeb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApiWeb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApiWeb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ApiWeb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApiWeb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApiWeb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApiWeb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApiWeb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApiWeb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ApiWeb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApiWeb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ApiWeb] SET  MULTI_USER 
GO
ALTER DATABASE [ApiWeb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApiWeb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApiWeb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApiWeb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ApiWeb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ApiWeb] SET QUERY_STORE = OFF
GO
USE [ApiWeb]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IDCategoria] [int] IDENTITY(1,1) NOT NULL,
	[NombreC] [nchar](200) NOT NULL,
	[DescripcionC] [nchar](400) NULL,
    Activo bit default 1,
	[IDMarca] [int] NOT NULL,
	FechaRegistro datetime default getdate()
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IDCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[IDMarca] [int] IDENTITY(1,1) NOT NULL,
	[NombreM] [nchar](250) NOT NULL,
	[DescripcionM] [nchar](200) NULL,
	Activo bit default 1,
    FechaRegistro datetime default getdate()
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[IDMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IDProducto] [int] IDENTITY(1,1) NOT NULL,
	[NombreP] [nchar](250) NOT NULL,
	[DescripcionP] [nchar] (250) NULL,
	[Precio] [smallint] NULL,
	[stock] [smallint] NULL,
	[IDCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IDProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([IDCategoria], [NombreC], [DescripcionC], [IDMarca]) VALUES (1, 'MCDONALD', 'Disfruta de tu hamburguesa del mejor restaurante', 1)
INSERT [dbo].[Categoria] ([IDCategoria], [NombreC], [DescripcionC], [IDMarca]) VALUES (2, 'BurguerKing', 'Disfruta de las hamburguesas del rey', 1)
INSERT [dbo].[Categoria] ([IDCategoria], [NombreC], [DescripcionC], [IDMarca]) VALUES (3, 'KFC', 'Para chuparte los dedos', 2)
INSERT [dbo].[Categoria] ([IDCategoria], [NombreC], [DescripcionC], [IDMarca]) VALUES (4, 'King Chicken', 'lo mejor', 2)
INSERT [dbo].[Categoria] ([IDCategoria], [NombreC], [DescripcionC], [IDMarca]) VALUES (5, 'Hornados maria', 'sabor como en casa', 3)
INSERT [dbo].[Categoria] ([IDCategoria], [NombreC], [DescripcionC], [IDMarca]) VALUES (6, 'rincon del sabor', 'slo mejor de lo mejor', 3)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 

INSERT [dbo].[Marca] ([IDMarca], [NombreM], [DescripcionM] ) VALUES (1, N'Hamburguesas', N'Disfruta de las ham,burguesas de tus restaurantes favoritos')
INSERT [dbo].[Marca] ([IDMarca], [NombreM], [DescripcionM] ) VALUES (2, N'Pollo Broster', N'El mejor pollo en el mejor lugar') 
INSERT [dbo].[Marca] ([IDMarca], [NombreM], [DescripcionM] ) VALUES (3, N'Nacional', N'El mejor pollo en el mejor lugar')
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([IDProducto], [NombreP], [DescripcionP], [Precio], [stock], [IDCategoria]) VALUES (1, N'Cuato de libra', N'Hamburguesa insignea de nuestro restaurante, contiene queso',7,100,1)
INSERT [dbo].[Producto] ([IDProducto], [NombreP], [DescripcionP], [Precio], [stock], [IDCategoria]) VALUES (2, N'wooper', N'La mejor de todas',5,100,2)
INSERT [dbo].[Producto] ([IDProducto], [NombreP], [DescripcionP], [Precio], [stock], [IDCategoria]) VALUES (3, N'Alitas Picantes', N'Las mas populares',12,150,3)
INSERT [dbo].[Producto] ([IDProducto], [NombreP], [DescripcionP], [Precio], [stock], [IDCategoria]) VALUES (4, N'Pollo broaster', N'Pollo frito muy bien preparado',9,150,4)
INSERT [dbo].[Producto] ([IDProducto], [NombreP], [DescripcionP], [Precio], [stock], [IDCategoria]) VALUES (5, N'Hornado completo', N'un sabor que no podras dejar',4,200,5)
INSERT [dbo].[Producto] ([IDProducto], [NombreP], [DescripcionP], [Precio], [stock], [IDCategoria]) VALUES (6, N'Locro de papa', N'Rico locro con bastante papa',3,200,6)

SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Marca] FOREIGN KEY([IDMarca])
REFERENCES [dbo].[Marca] ([IDMarca])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Marca]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IDCategoria])
REFERENCES [dbo].[Categoria] ([IDCategoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
USE [master]
GO
ALTER DATABASE [APIWEB] SET  READ_WRITE 
GO





