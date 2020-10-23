SELECT 
    Codigo AS cod,
    Descripcion AS razons,
    NIT AS nif,
    'COP' AS codmoneda
    FROM empresas
WHERE 
    CODIGO IN(01,02);