SELECT 
    Cl.CODIGO AS codcliente,
    Cl.CLI_CO AS codcontacto,
    Cl.DESCRIPCION AS Nombre,
    Cl.NIT AS nif,
    Cl.TIPO_TERCERO AS tcontacto,
    Cl.DIRECCION_1 AS coddireccion,
    Cl.TELEFONO_1 AS tlfmovil,
    Cl.TELEFONO_2 AS tlffijo,
    IF( Cl.FAX IS NULL or  Cl.FAX = '', '',  Cl.FAX)  AS fax,
    IF( Cl.EMAIL IS NULL or  Cl.EMAIL = '', '',  Cl.EMAIL)  AS email,
    '' AS ind1,
    '' AS ind2,
    '' AS ind3
FROM TERCEROS AS Cl
    INNER JOIN CONTRATOS AS Con ON Con.ID_TERC = Cl.Codigo AND Con.ID_EMP = '{0}';