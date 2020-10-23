SELECT 
    T1.CODIGO AS cod,
    T1.NIT AS nif,
    T1.DESCRIPCION AS razons,
    IF( T1.CLI_COND_PAGO IS NULL or T1.CLI_COND_PAGO = '', '',  T1.CLI_COND_PAGO)  AS codcondp,	
    REPLACE(T1.CLI_CUPO_CRE, ',','.') AS limitrg,
    T2.UNDPTO_DESCRIPCION AS prov,
    T1.CLI_ZONA_1 as criterio1_ZONA,
    T1.CLI_ZONA_2 as criterio2_SUBZONA,
    '0' as lrcomp,
    IF( T1.METODO_PAGO IS NULL or T1.METODO_PAGO = '', '',  T1.METODO_PAGO)  AS viasp,
    T1.TIPO_TERCERO as clasifcontable,
    '' as lsegcredito,
    '' as fchcadsegcred,
    '' as tipoentidad,
    IF( T1.CODIGO_CIIU IS NULL or T1.CODIGO_CIIU = '', '',  T1.CODIGO_CIIU)  AS sector,
    T1.FECHA_CREACION as fchaltaerp,
    '' as fchinitact,
    IF( T3.DESCRIPCION  IS NULL or T3.DESCRIPCION = '', '', T3.DESCRIPCION)  AS  ind1,
    '' as ind2,
    '' as ind3,
    '' as ind4,
    '' as ind5,
    '' as ind6,
    '' as ind7,
    '' as ind8,
    '' as ind9,
    '' as tieneaval,
    '' as tipoaval 
FROM TERCEROS AS T1 
    INNER JOIN DEPARTAMENTOS AS T2 ON T1.DPTO_CORRESP=T2.ID_DPTO 
    INNER JOIN VENDEDORES AS T3 ON T1.CLI_VENDEDOR=T3.CODIGO 
    INNER JOIN CONTRATOS AS C ON C.ID_TERC = T1.Codigo AND C.ID_EMP IN ('01','02');