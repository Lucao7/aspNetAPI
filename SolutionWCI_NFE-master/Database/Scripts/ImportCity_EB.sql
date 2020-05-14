IF OBJECT_ID('tempdb..#cidade') IS NOT NULL 	DROP TABLE  #cidade 

SELECT DISTINCT 
	c.nome, e.nome as Estado
INTO #cidade
FROM EstadosBrasileiros.dbo.cidade c
RIGHT JOIN EstadosBrasileiros.dbo.estado e ON (c.estado = e.id)

MERGE WorkingCode.dbo.COM_City	AS C1
USING #cidade		AS C2 ON (C1.Name = C2.nome)
WHEN NOT MATCHED BY TARGET
	THEN INSERT 
			   ([Name]
			   ,[ExternalCode]
			   ,[StateId]
			   ,[CreateDate]
			   ,[ModifieldDate])
		 VALUES
			   (C2.nome
			   ,null
			   ,(SELECT WorkingCode.dbo.COM_State.StateId from WorkingCode.dbo.COM_State WHERE Name = C2.Estado)
			   ,GETDATE()
			   ,GETDATE())
WHEN MATCHED 
    THEN UPDATE SET 				   
		Name = c2.nome;

DROP TABLE #cidade