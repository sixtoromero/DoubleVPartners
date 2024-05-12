USE [DoubleVPartnersDB]
GO
CREATE TABLE [dbo].[Personas](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](150) NOT NULL,
	[Apellidos] [nvarchar](150) NOT NULL,
	[TipoIdentificacion] [int] NOT NULL,
	[NumeroIdentificacion] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](80) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 12/05/2024 6:33:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](80) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[uspDelPersonas]    Script Date: 12/05/2024 6:33:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDelPersonas]
	@Identificador INT	
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		DELETE FROM [dbo].[Personas]
		WHERE Identificador = @Identificador

		SELECT 'success'
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE();
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[uspDelUsuarios]    Script Date: 12/05/2024 6:33:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDelUsuarios]
	@Identificador INT	
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		DELETE FROM [dbo].[Usuarios]
		WHERE Identificador = @Identificador

		SELECT 'success'
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE();
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[UspgetPersonas]    Script Date: 12/05/2024 6:33:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetPersonas]
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		SELECT Identificador
			,Nombres
			,Apellidos
			,TipoIdentificacion
			,NumeroIdentificacion
			,Email
			,FechaCreacion FROM [dbo].[Personas]
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE();
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[UspgetPersonasByID]    Script Date: 12/05/2024 6:33:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetPersonasByID]
	@Identificador INT	
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		SELECT Identificador
			,Nombres
			,Apellidos
			,TipoIdentificacion
			,NumeroIdentificacion
			,Email
			,FechaCreacion FROM [dbo].[Personas]
		WHERE Identificador = @Identificador		
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE();
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[UspgetUsuarios]    Script Date: 12/05/2024 6:33:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetUsuarios]
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		SELECT Identificador
			,NombreUsuario
			,FechaCreacion FROM [dbo].[Usuarios]
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE();
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[UspgetUsuariosByID]    Script Date: 12/05/2024 6:33:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetUsuariosByID]
	@Identificador INT	
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		SELECT Identificador
			,NombreUsuario
			,FechaCreacion FROM [dbo].[Usuarios]
		WHERE Identificador = @Identificador		
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE();
	END CATCH;
END

GO
/****** Object:  StoredProcedure [dbo].[UspgetUsuariosPorNombreUsuario]    Script Date: 12/05/2024 6:33:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetUsuariosPorNombreUsuario]
	@NombreUsuario NVARCHAR(80)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		SELECT Identificador
			,NombreUsuario
			,Password
			,FechaCreacion FROM [dbo].[Usuarios]
		WHERE NombreUsuario = @NombreUsuario
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE();
	END CATCH;
END

GO
/****** Object:  StoredProcedure [dbo].[uspPersonasInsert]    Script Date: 12/05/2024 6:33:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspPersonasInsert]
	@Nombres NVARCHAR(150),
	@Apellidos NVARCHAR(150),
	@TipoIdentificacion INT,
	@NumeroIdentificacion NVARCHAR(20),
	@Email NVARCHAR(80)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		INSERT INTO [dbo].[Personas] (Nombres
			,Apellidos
			,TipoIdentificacion
			,NumeroIdentificacion
			,Email
			,FechaCreacion)
		VALUES (
		@Nombres
		,@Apellidos
		,@TipoIdentificacion
		,@NumeroIdentificacion
		,@Email
		,GETDATE()
		);

		SELECT 'success'
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE();
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[uspPersonasUpdate]    Script Date: 12/05/2024 6:33:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspPersonasUpdate]
	@Identificador INT,
	@Nombres NVARCHAR(150),
	@Apellidos NVARCHAR(150),
	@TipoIdentificacion INT,
	@NumeroIdentificacion NVARCHAR(20),
	@Email NVARCHAR(80)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[Personas] SET Nombres = @Nombres
			,Apellidos = @Apellidos
			,TipoIdentificacion = @TipoIdentificacion
			,NumeroIdentificacion = @NumeroIdentificacion
			,Email = @Email
		WHERE Identificador = @Identificador

		SELECT 'success'
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE();
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[uspUsuariosInsert]    Script Date: 12/05/2024 6:33:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUsuariosInsert]
	@NombreUsuario NVARCHAR(150),
	@Password NVARCHAR(250)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		INSERT INTO [dbo].[Usuarios] (NombreUsuario
			,Password
			,FechaCreacion)
		VALUES (
		@NombreUsuario
		,@Password
		,GETDATE()
		);

		SELECT 'success'
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE();
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[uspUsuariosUpdate]    Script Date: 12/05/2024 6:33:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUsuariosUpdate]
	@Identificador INT,
	@Password NVARCHAR(250)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[Usuarios] SET Password = @Password			
		WHERE Identificador = @Identificador

		SELECT 'success'
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE();
	END CATCH;
END
GO