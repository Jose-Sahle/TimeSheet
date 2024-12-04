USE #DatabaseName#
DECLARE @LEVEL INT
DECLARE @COUNT INT

IF OBJECT_ID ('TEMPDB..#TABLES') IS NOT NULL
	DROP TABLE #TABLES 

SELECT
	 T.NAME  AS TABLENAME
	,T.OBJECT_ID            AS TABLEID
      ,	0                      AS ORDINAL   INTO #TABLES 
FROM SYS.TABLES T
JOIN SYS.SCHEMAS S
	ON T.SCHEMA_ID = S.SCHEMA_ID
WHERE NOT EXISTS
		(
			SELECT 1           
			FROM SYS.FOREIGN_KEYS F          
			WHERE F.PARENT_OBJECT_ID = T.OBJECT_ID
		)

SET @COUNT = @@ROWCOUNT							
SET @LEVEL = 0   

WHILE @COUNT > 0 
BEGIN      
	INSERT #TABLES 
	(            
		 TABLENAME           
		,TABLEID           
		,ORDINAL     
	)      
	SELECT 
		 T.NAME  AS TABLENAME           
		,T.OBJECT_ID            AS TABLEID           
		,@LEVEL + 1             AS ORDINAL       
	FROM SYS.TABLES T       
	JOIN SYS.SCHEMAS S         
		ON S.SCHEMA_ID = T.SCHEMA_ID      
	WHERE EXISTS            
		(
			SELECT 1
			FROM SYS.FOREIGN_KEYS F
			JOIN #TABLES TT
			ON F.REFERENCED_OBJECT_ID = TT.TABLEID
			AND TT.ORDINAL = @LEVEL
			AND F.PARENT_OBJECT_ID = T.OBJECT_ID
			AND F.PARENT_OBJECT_ID != F.REFERENCED_OBJECT_ID
		)

	SET @COUNT = @@ROWCOUNT    
	SET @LEVEL = @LEVEL + 1 
END  

SELECT  
	    T.TABLEID       
	   ,T.TABLENAME  AS TABLE_NAME
FROM #TABLES T   
JOIN 
	(
		SELECT   
			 TABLENAME     AS TABLENAME               
			,MAX (ORDINAL) AS ORDINAL           
		FROM #TABLES          
		GROUP BY TABLENAME
	) TT     
	  ON T.TABLENAME = TT.TABLENAME    
	  AND T.ORDINAL = TT.ORDINAL  
ORDER BY T.ORDINAL