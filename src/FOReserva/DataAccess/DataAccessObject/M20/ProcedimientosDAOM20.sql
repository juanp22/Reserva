USE [DB_A14EBC_reserva]
GO
/****** Object:  StoredProcedure [dbo].[M20_BorrarRevision]    Script Date: 22/01/2017 2:15:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:	
--    Permite borrar una revision si eres el 
-- propietario o hace referencia a un Hotel o 
-- Restaurante.
-- =============================================
CREATE PROCEDURE [dbo].[M20_BorrarRevision]
	@rev_id int = 0,
	@rev_tipo int,
	@rev_fk_propietario int = 0,
	@rev_fk_referencia int = 0
AS
BEGIN	
	DECLARE 
		@estatus int = -1, 
		@mensaje varchar(max) = 'Error desconocido...', 
		@referencia int = 0
	BEGIN TRY
		DECLARE @TableReference TABLE (id int)
		IF (@rev_id > 0)
		BEGIN
			DELETE FROM [dbo].[Revision]
			OUTPUT deleted.rev_id INTO @TableReference
			WHERE [rev_id] = @rev_id 
				AND ([rev_fk_propietario] = @rev_fk_propietario
				OR   ([rev_tipo] = @rev_tipo 
				  AND [rev_fk_referencia] = @rev_fk_referencia))

			SELECT 
				@estatus = 0, 
				@mensaje = 'Se guardaron los cambios correctamente...',
				@referencia = @rev_id
			FROM @TableReference
			IF @estatus = -1
				SELECT 
					@estatus = 1, 
					@mensaje = 'Registro no encontrados.',
					@referencia = @rev_id
		END
		ELSE
			THROW 60000, 'Debe indicar el ID de la revision.', 1
	END TRY
	BEGIN CATCH
		SELECT @estatus = ERROR_STATE(), @mensaje = ERROR_MESSAGE()
	END CATCH

	SELECT 
		@estatus as "Estatus",
		@mensaje as "Mensaje",
		@referencia as "Referencia"
		
END

GO
/****** Object:  StoredProcedure [dbo].[M20_GuardarRevision]    Script Date: 22/01/2017 2:15:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:	
--   Permite almacear los cambios de una Revision 
-- (Exista o no).
-- =============================================
CREATE PROCEDURE [dbo].[M20_GuardarRevision]
	@rev_id int = 0,	
	@rev_mensaje varchar(8000),
	@rev_tipo int,
	@rev_fk_propietario int,
	@rev_fk_referencia int,
	@rev_estrellas numeric(2,1)
AS
BEGIN	
	DECLARE 
		@estatus int = -1, 
		@mensaje varchar(max) = 'Error desconocido...', 
		@referencia int = 0
	BEGIN TRY
		DECLARE @TableReference TABLE (id int)
		IF (@rev_id > 0)
		BEGIN
			UPDATE [dbo].[Revision]			
			SET 
				[rev_mensaje] = @rev_mensaje,
				[rev_tipo] = @rev_tipo,				
				[rev_fk_propietario] = @rev_fk_propietario, 
				[rev_fk_referencia] = @rev_fk_referencia,
				[rev_estrellas] = @rev_estrellas
			OUTPUT inserted.rev_id INTO @TableReference
			WHERE 		
				[rev_id] = @rev_id			
		END
		ELSE
		BEGIN			
			INSERT INTO [dbo].[Revision] 
				([rev_fecha], [rev_mensaje], [rev_tipo], [rev_fk_propietario], [rev_fk_referencia])
			OUTPUT inserted.rev_id INTO @TableReference
			VALUES
				(GETDATE(), @rev_mensaje, @rev_tipo, @rev_fk_propietario, @rev_fk_referencia)
			SELECT @rev_id = id FROM @TableReference
		END
		SELECT 
				@estatus = 0, 
				@mensaje = 'Se guardaron los cambios correctamente...',
				@referencia = @rev_id
			FROM @TableReference
			
		IF @estatus = -1
			SELECT 
		  	@estatus = 1, 
				@mensaje = 'Registro no encontrados.',
				@referencia = @rev_id
	END TRY
	BEGIN CATCH
		SELECT @estatus = ERROR_STATE(), @mensaje = ERROR_MESSAGE()
	END CATCH

	SELECT 
		@estatus as "Estatus",
		@mensaje as "Mensaje",
		@referencia as "Referencia"
		
END

GO
/****** Object:  StoredProcedure [dbo].[M20_GuardarValoracion]    Script Date: 22/01/2017 2:15:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:	
--   Permite almacear los cambios de una 
-- Valoracion (Exista o no) de una Revision.
-- =============================================
CREATE PROCEDURE [dbo].[M20_GuardarValoracion]
	@val_id int = 0,
	@val_fk_revision int,
	@val_punto int,
	@val_fk_propietario int	
AS
BEGIN	
	DECLARE 
		@estatus int = -1, 
		@mensaje varchar(max) = 'Error desconocido...', 
		@referencia int = 0
	BEGIN TRY
		DECLARE @TableReference TABLE (id int)
		IF (@val_id > 0)
		BEGIN
			UPDATE [dbo].[Revision_Valoracion]
			SET 				
				[val_fecha] = GETDATE(),
				[val_punto] = @val_punto
			OUTPUT inserted.val_id INTO @TableReference
			WHERE 		
				[val_id] = @val_id
		END
		ELSE
		BEGIN			
			INSERT INTO [dbo].[Revision_Valoracion] 
				([val_fecha], [val_punto], [val_fk_revision], [val_fk_propietario])
			OUTPUT inserted.val_id INTO @TableReference
			VALUES
				(getdate(), @val_punto, @val_fk_revision, @val_fk_propietario)

			SELECT @val_id = id FROM @TableReference
		END
		SELECT 
				@estatus = 0, 
				@mensaje = 'Se guardaron los cambios correctamente...',
				@referencia = @val_id
			FROM @TableReference
			
		IF @estatus = -1
			SELECT 
		  	@estatus = 1, 
				@mensaje = 'Registro no encontrados.',
				@referencia = @val_id
	END TRY
	BEGIN CATCH
		SELECT @estatus = ERROR_STATE(), @mensaje = ERROR_MESSAGE()
	END CATCH

	SELECT 
		@estatus as "Estatus",
		@mensaje as "Mensaje",
		@referencia as "Referencia"
		
END

GO
/****** Object:  StoredProcedure [dbo].[M20_ObtenerRevisionesPorReferencia]    Script Date: 22/01/2017 2:15:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:	
--   Permite obtener las revisiones de una 
-- referencia (Hotel | Restaurante) con sus 
-- puntos y estrellas.
-- =============================================
CREATE PROCEDURE [dbo].[M20_ObtenerRevisionesPorReferencia]
	@rev_tipo int = 0,
	@rev_fk_referencia int = 0
AS
BEGIN
	SELECT 
		[DET].*, 
		COALESCE([LK].rev_positivos , 0) AS "rev_positivos", 
		COALESCE([NLK].rev_negativos , 0) AS "rev_negativos"
	FROM [dbo].[Revision] [DET]	
	LEFT JOIN(
		SELECT [REV].[rev_id], COUNT([VAL].[val_punto]) AS "rev_positivos"
		FROM [dbo].[Revision] [REV] 
		LEFT JOIN [dbo].[Revision_Valoracion] [VAL] ON [REV].[rev_id] = [VAL].[val_fk_revision]
		WHERE [REV].[rev_tipo] = @rev_tipo
			AND [REV].[rev_fk_referencia] = @rev_fk_referencia
			AND [VAL].[val_punto] = 1
		GROUP BY [REV].[rev_id]
	) [LK] ON [DET].[rev_id] = [LK].[rev_id]
	LEFT JOIN(
		SELECT [REV].[rev_id], COUNT([VAL].[val_punto]) AS "rev_negativos"
		FROM [dbo].[Revision] [REV] 
		LEFT JOIN [dbo].[Revision_Valoracion] [VAL] ON [REV].[rev_id] = [VAL].[val_fk_revision]
		WHERE [REV].[rev_tipo] = @rev_tipo
			AND [REV].[rev_fk_referencia] = @rev_fk_referencia
			AND [VAL].[val_punto] = -1
		GROUP BY [REV].[rev_id]
	) [NLK] ON [DET].[rev_id] = [NLK].[rev_id]
	WHERE [DET].[rev_tipo] = @rev_tipo
			AND [DET].[rev_fk_referencia] = @rev_fk_referencia

END

GO
/****** Object:  StoredProcedure [dbo].[M20_ObtenerValoracionPorReferencia]    Script Date: 22/01/2017 2:15:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Roysbert Salinas
-- Create date: 28/11/2016
-- Description:	
--   Permite obtener el promedio de estrellas de
-- una referencia (Hotel | Restaurante).
-- =============================================
CREATE PROCEDURE [dbo].[M20_ObtenerValoracionPorReferencia]
	@rev_tipo int = 0,
	@rev_fk_referencia int = 0
AS
BEGIN
	SELECT [REV].[rev_fk_referencia], AVG([REV].[rev_estrellas]) AS "ref_estrellas"
	FROM [dbo].[Revision] [REV]
	WHERE [REV].[rev_tipo] = @rev_tipo
		AND [REV].[rev_fk_referencia] = @rev_fk_referencia			
	GROUP BY [REV].[rev_fk_referencia]	
END

GO
