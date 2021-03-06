USE [DB_1380A_reserva]
GO
/****** Object:  StoredProcedure [dbo].[M08_AgregarAutomovil]    Script Date: 18/01/2017 3:40:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- Procedure structure for M08_AgregarAutomovil
-- ----------------------------
CREATE PROCEDURE [dbo].[M08_AgregarAutomovil]
  @aut_matricula AS VARCHAR(50),
  @aut_modelo AS VARCHAR(50),
  @aut_fabricante AS VARCHAR(50),
  @aut_anio AS INT,
  @aut_kilometraje AS DECIMAL(20,2),  
  @aut_cantpasajeros AS INT,
  @aut_tipovehiculo AS VARCHAR(50),
  @aut_preciocompra AS DECIMAL(20,2),
  @aut_precioalquiler AS DECIMAL(20,2),
  @aut_penalidaddiaria AS DECIMAL(20,2),
  @aut_color AS VARCHAR(20),
  @aut_disponibilidad AS INT,
  @aut_transmision AS VARCHAR(20),  
  @fk_lugar AS INT 
AS
BEGIN
	INSERT INTO Automovil (aut_matricula,aut_modelo,aut_fabricante,aut_anio,aut_kilometraje,aut_cantpasajeros,aut_tipovehiculo,aut_preciocompra,aut_precioalquiler,aut_penalidaddiaria,aut_fecharegistro,aut_color,aut_disponibilidad,aut_transmision,aut_fk_ciudad)
	VALUES (@aut_matricula,@aut_modelo,@aut_fabricante,@aut_anio,@aut_kilometraje,@aut_cantpasajeros,@aut_tipovehiculo,@aut_preciocompra,@aut_precioalquiler,@aut_penalidaddiaria,CURRENT_TIMESTAMP,@aut_color,@aut_disponibilidad,@aut_transmision,@fk_lugar);
END

GO

/****** Object:  StoredProcedure [dbo].[M08_ModificarAutomovil]    Script Date: 18/01/2017 3:40:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- Procedure structure for M08_ModificarAutomovil
-- ----------------------------
CREATE PROCEDURE [dbo].[M08_ModificarAutomovil]

	@aut_matricula AS VARCHAR(50),
	@aut_kilometraje AS DECIMAL(20,2),
	@aut_tipovehiculo AS VARCHAR(50),
	@aut_precioalquiler AS DECIMAL(20,2),
	@aut_penalidaddiaria AS DECIMAL(20,2),
	@aut_color AS VARCHAR(20),
	@fk_lugar AS INT	

 AS
BEGIN
SET NOCOUNT ON 
	-- SET NOCOUNT ON added to prevent extra result sets from
	UPDATE Automovil 
	SET aut_kilometraje = @aut_kilometraje, aut_tipovehiculo = @aut_tipovehiculo, aut_precioalquiler = @aut_precioalquiler, aut_penalidaddiaria = @aut_penalidaddiaria, aut_color = @aut_color,aut_fk_ciudad = @fk_lugar
	WHERE aut_matricula =   @aut_matricula; 
END

GO

/****** Object:  StoredProcedure [dbo].[M08_Consultar_Lugar]    Script Date: 18/01/2017 3:40:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- Procedure structure for M08_Consultar_Lugar
-- ----------------------------
CREATE PROCEDURE [dbo].[M08_Consultar_Lugar]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON
	SELECT c.lug_id,c.lug_nombre, p.lug_nombre FROM lugar p, lugar c
	WHERE c.lug_tipo_lugar = 'Ciudad' AND c.lug_FK_lugar_id = p.lug_id
END

GO

/****** Object:  StoredProcedure [dbo].[M08_ConsultarAutomoviles]    Script Date: 18/01/2017 3:40:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- Procedure structure for M08_ConsultarAutomoviles
-- ----------------------------
CREATE PROCEDURE  [dbo].[M08_ConsultarAutomoviles]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	SELECT a.*, c.lug_nombre AS aut_pais, p.lug_nombre AS aut_ciudad 
					 FROM automovil a, lugar p, lugar c
					WHERE a.aut_fk_ciudad = c.lug_id 
					  AND c.lug_FK_lugar_id = p.lug_id;

	END

GO

/****** Object:  StoredProcedure [dbo].[M08_ConsultarAutomovilMatricula]    Script Date: 18/01/2017 3:40:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- Procedure structure for M08_ConsultarAutomovilMatricula
-- ----------------------------
CREATE PROCEDURE [dbo].[M08_ConsultarAutomovilMatricula]
	-- Add the parameters for the stored procedure here
	 @aut_matricula AS VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	SELECT a.*, c.lug_nombre AS aut_pais, p.lug_nombre AS aut_ciudad 
					 FROM automovil a, lugar p, lugar c
					WHERE a.aut_matricula = @aut_matricula
					  AND a.aut_fk_ciudad = c.lug_id 
					  AND c.lug_FK_lugar_id = p.lug_id;

END

GO

/****** Object:  StoredProcedure [dbo].[M08_EliminarAutomovil]    Script Date: 18/01/2017 3:40:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- Procedure structure for M08_EliminarAutomovil
-- ----------------------------
CREATE PROCEDURE [dbo].[M08_EliminarAutomovil]

	@aut_matricula AS VARCHAR(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	DELETE FROM Automovil WHERE aut_matricula =  @aut_matricula;
END

GO

/****** Object:  StoredProcedure [dbo].[M08_CambiarDisponibilidadAutomovil]    Script Date: 18/01/2017 3:40:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- Procedure structure for M08_CambiarDisponibilidadAutomovil
-- ----------------------------
CREATE PROCEDURE [dbo].[M08_CambiarDisponibilidadAutomovil]

	@aut_matricula AS VARCHAR(50)

 AS
BEGIN

DECLARE @aut_disponibilidad AS INT

SELECT @aut_disponibilidad = aut_disponibilidad FROM Automovil WHERE aut_matricula = @aut_matricula

SET NOCOUNT ON 
	-- SET NOCOUNT ON added to prevent extra result sets from
	IF (@aut_disponibilidad = 1)
		SET @aut_disponibilidad = 0;
	ELSE
		SET @aut_disponibilidad = 1; 

	UPDATE Automovil 
	SET aut_disponibilidad = @aut_disponibilidad
	WHERE aut_matricula =   @aut_matricula; 
END

GO

/****** Object:  StoredProcedure [dbo].[M08_ConsulExisteMatriculaAutomovil]    Script Date: 18/01/2017 3:40:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ----------------------------
-- Procedure structure for M08_ConsulExisteMatriculaAutomovil
-- ----------------------------
CREATE PROCEDURE [dbo].[M08_ConsulExisteMatriculaAutomovil]
	-- Add the parameters for the stored procedure here
	 @aut_matricula AS VARCHAR(50)

AS
BEGIN
	DECLARE @aut_matricula2 AS VARCHAR(50)

	SET NOCOUNT ON 
	-- SET NOCOUNT ON added to prevent extra result sets from

	SET @aut_matricula2 = (SELECT aut_matricula FROM Automovil WHERE aut_matricula = @aut_matricula)

		IF (@aut_matricula2 <> @aut_matricula)
			SET @aut_matricula = ''; 
		PRINT @aut_matricula;
END

GO

