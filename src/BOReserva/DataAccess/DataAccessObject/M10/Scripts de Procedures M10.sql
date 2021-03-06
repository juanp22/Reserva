USE [DB_1380A_reserva]
GO
/****** Object:  StoredProcedure [dbo].[M10_ActualizarRestaurante]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[M10_ActualizarRestaurante]
	-- Add the parameters for the stored procedure here
	  
	  @rst_id AS int,
	  @rst_nombre AS varchar (100),
	  @rst_direccion AS varchar (100),
	  @rst_descripcion AS varchar (100),
	  @rst_hora_apertura AS varchar (100),
	  @rst_hora_cierre AS varchar (100) ,
	  @rst_telefono AS varchar (100),
	  @fk_lugar AS int 

 AS
BEGIN
SET NOCOUNT ON 
	-- SET NOCOUNT ON added to prevent extra result sets from
	update Restaurante 
	set rst_nombre = @rst_nombre, rst_direccion = @rst_direccion, rst_descripcion = @rst_descripcion, rst_hora_apertura = @rst_hora_apertura, rst_hora_cierre = @rst_hora_cierre,rst_telefono = @rst_telefono ,fk_lugar = @fk_lugar
	where rst_id =   @rst_id; 
END

GO
/****** Object:  StoredProcedure [dbo].[M10_AgregarRestaurante]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- Procedure structure for M10_AgregarRestaurante
-- ----------------------------
CREATE PROCEDURE [dbo].[M10_AgregarRestaurante]
  @rst_nombre AS varchar (100),
  @rst_direccion AS varchar (100),
  @rst_descripcion AS varchar (100),
  @rst_hora_apertura AS varchar (100),
  @rst_hora_cierre AS varchar (100) ,
  @rst_telefono AS varchar (100),
  @fk_lugar AS int 
AS
BEGIN
	insert into Restaurante (rst_nombre, rst_direccion, rst_descripcion, rst_hora_apertura, rst_hora_cierre,rst_telefono, fk_lugar)
	values (@rst_nombre, @rst_direccion, @rst_descripcion, @rst_hora_apertura, @rst_hora_cierre, @rst_telefono,@fk_lugar);
END

GO
/****** Object:  StoredProcedure [dbo].[M10_Consultar_Lugar]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[M10_Consultar_Lugar]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT c.lug_id,c.lug_nombre, p.lug_nombre from lugar p, lugar c
	where c.lug_tipo_lugar = 'Ciudad' and c.lug_FK_lugar_id = p.lug_id
END

GO
/****** Object:  StoredProcedure [dbo].[M10_ConsultarRestaurante]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[M10_ConsultarRestaurante]

@lug_id AS int -- Atributo de entrada, si tuviera despues del int output es de salida
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select r.rst_id,r.rst_nombre,r.rst_direccion,r.rst_descripcion,r.rst_hora_apertura,r.rst_hora_cierre,r.rst_telefono,l.lug_nombre
	from restaurante r, lugar l
	where l.lug_id = r.fk_lugar
	and l.lug_id = @lug_id
	END

GO
/****** Object:  StoredProcedure [dbo].[M10_ConsultarRestauranteId]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[M10_ConsultarRestauranteId]
	-- Add the parameters for the stored procedure here
	 @rst_id AS int -- Atributo de entrada, si tuviera despues del int output es de salida
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select *from Restaurante where rst_id = @rst_id;
END

GO
/****** Object:  StoredProcedure [dbo].[M10_EliminarRestaurante]    Script Date: 15/01/2017 6:45:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[M10_EliminarRestaurante]
	-- Add the parameters for the stored procedure here
 @rst_id AS int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Restaurante
	where rst_id =  @rst_id;
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[M10_ListarRestaurante]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select rst_id,rst_nombre from Restaurante;
END
GO