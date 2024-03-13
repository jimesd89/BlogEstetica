CREATE TABLE [dbo].[Publicacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[Subtitulo] [varchar](100) NOT NULL,
	[Cuerpo] [varchar](max) NOT NULL,
	[Creacion] [date] NULL,
	[Imagen1] [varchar](200) NULL,
	[Imagen2] [varchar](200) NULL,
	[Imagen3] [varchar](200) NULL,
	[Imagen4] [varchar](200) NULL,
	[Imagen5] [varchar](200) NULL,
 CONSTRAINT [PK_Publicacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
