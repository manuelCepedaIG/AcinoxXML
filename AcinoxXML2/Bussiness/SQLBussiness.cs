using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcinoxXML2.Bussiness
{
    //##***********************************************************************************************###
    //
    //
    // Intergrupo 2020
    // Proyecto ACINOX
    // Descripción: Conexión y consulta a base de datos
    //
    // Creado: Manuel Cepeda
    // Fecha de creación: 5-oct-2020
    // 
    //
    //##***********************************************************************************************###

    public class SQLBussiness
    {
        public MySqlConnection connect()
        {
            //string connStr = "server=localhost;user=root;database=pruebaxesor;port=3306;password=IG82020.";
            string connStr = "server=localhost;user=root;database=acinox;port=3306;password=administrator";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }

        public MySqlDataReader getQueryData(string typeOfQuery, MySqlConnection conn)
        {
            string sql = string.Empty;
            switch (typeOfQuery)
            {
                case "sociedades":
                    sql = "SELECT Codigo AS cod, " +
                            "Descripcion AS razons, " +
                            "NIT AS nif, " +
                            "'COP' AS codmoneda " +
                            "FROM empresas" +
                            " WHERE CODIGO IN(01,02);";
                    break;
                case "clientes":
                    sql = "SELECT T1.CODIGO AS cod," +
                            "T1.NIT AS nif," +
                            "T1.DESCRIPCION AS razons," +
                            "IF( T1.CLI_COND_PAGO IS NULL or T1.CLI_COND_PAGO = '', ' ',  T1.CLI_COND_PAGO)  AS codcondp,	" +
                            "REPLACE(T1.CLI_CUPO_CRE, ',','.') AS limitrg," +
                            "T2.UNDPTO_DESCRIPCION AS prov," +
                            "T1.CLI_ZONA_1 as criterio1_ZONA," +
                            "T1.CLI_ZONA_2 as criterio2_SUBZONA," +
                            "'0' as lrcomp," +
                            "IF( T1.METODO_PAGO IS NULL or T1.METODO_PAGO = '', '',  T1.METODO_PAGO)  AS viasp," +
                            "T1.TIPO_TERCERO as clasifcontable," +
                            "'' as lsegcredito," +
                            "'' as fchcadsegcred," +
                            "'' as tipoentidad," +
                            "IF( T1.CODIGO_CIIU IS NULL or T1.CODIGO_CIIU = '', '',  T1.CODIGO_CIIU)  AS sector," +
                            "T1.FECHA_CREACION as fchaltaerp," +
                            "'' as fchinitact," +
                            "IF( T3.DESCRIPCION  IS NULL or T3.DESCRIPCION = '', '', T3.DESCRIPCION)  AS  ind1," +
                            "'' as ind2," +
                            "'' as ind3," +
                            "'' as ind4," +
                            "'' as ind5," +
                            "'' as ind6," +
                            "'' as ind7," +
                            "'' as ind8," +
                            "'' as ind9," +
                            "'' as tieneaval," +
                            "'' as tipoaval " +
                            "FROM TERCEROS AS T1 " +
                            "INNER JOIN DEPARTAMENTOS AS T2 ON T1.DPTO_CORRESP=T2.ID_DPTO " +
                            "INNER JOIN VENDEDORES AS T3 ON T1.CLI_VENDEDOR=T3.CODIGO " +
                            "INNER JOIN CONTRATOS AS C ON C.ID_TERC = T1.Codigo AND C.ID_EMP IN ('01','02')";
                    break;
                case "contactos":
                    sql = "SELECT Cl.CODIGO AS codcliente, " +
                            "Cl.CLI_CO AS codcontacto, " +
                            "Cl.DESCRIPCION AS Nombre, " +
                            "Cl.NIT AS nif, " +
                            "Cl.TIPO_TERCERO AS tcontacto,	" +
                            "Cl.DIRECCION_1 AS coddireccion, " +
                            "Cl.TELEFONO_1 AS tlfmovil, " +
                            "Cl.TELEFONO_2 AS tlffijo, " +
                            "IF( Cl.FAX IS NULL or  Cl.FAX = '', '',  Cl.FAX)  AS fax,	" +
                            "IF( Cl.EMAIL IS NULL or  Cl.EMAIL = '', '',  Cl.EMAIL)  AS email, " +
                            "'' AS ind1, " +
                            "'' AS ind2, " +
                            "'' AS ind3 " +
                            "FROM TERCEROS AS Cl " +
                            "INNER JOIN CONTRATOS AS Con ON Con.ID_TERC = Cl.Codigo AND Con.ID_EMP IN('01','02'); ";
                    break;
                case "clasifcriterios":
                    sql = "select " +
                        "'1001' as id, " +
                        "ZONAS_SUBZONA.ID_ZONA1 as cod, " +
                        "ZONAS_SUBZONA.UNZONAS_DESCRIPCION as 'desc' " +
                        "from ZONAS_SUBZONA " +
                        "where (ZONAS_SUBZONA.ID_ZONA1 = ZONAS_SUBZONA.ID_ZONA) " +
                        "UNION ALL " +
                        "select " +
                        "'1002' as id, " +
                        "ZONAS_SUBZONA.ID_ZONA1 as cod, " +
                        "ZONAS_SUBZONA.UNZONAS_DESCRIPCION as 'desc' " +
                        "from ZONAS_SUBZONA " +
                        "where (ZONAS_SUBZONA.ID_ZONA2 = ZONAS_SUBZONA.ID_ZONA); ";
                    break;
                case "direcciones":
                    sql = "select  " +
                        "T1.CODIGO AS cod, " +
                        "CASE " +
                        "WHEN T1.DIRECCION_1 != '' THEN T1.DIRECCION_1 " +
                        "WHEN T1.DIRECCION_2 != '' THEN T1.DIRECCION_1 " +
                        "WHEN T1.DIRECCION_3 != '' THEN T1.DIRECCION_2 " +
                        "END as coddireccion, " +
                        "CASE " +
                        "WHEN T1.DIRECCION_1 != '' THEN 2 " +
                        "WHEN T1.DIRECCION_2 != '' THEN 1 " +
                        "WHEN T1.DIRECCION_3 != '' THEN 0 " +
                        "END as tdireccion, " +
                        "CASE " +
                        "WHEN T1.DIRECCION_1 != '' THEN T1.DIRECCION_1 " +
                        "WHEN T1.DIRECCION_2 != '' THEN T1.DIRECCION_1 " +
                        "WHEN T1.DIRECCION_3 != '' THEN T1.DIRECCION_2 " +
                        "END as domicilio,  " +
                        "T2.UNCIUDAD_DESCRIPCION as ciudad, " +
                        "T3.UNDPTO_DESCRIPCION as prov, " +
                        "CASE " +
                        "WHEN T1.DIRECCION_1 != '' THEN T1.CLI_ZONA " +
                        "WHEN T1.DIRECCION_2 != '' THEN T1.CLI_ZONA_1 " +
                        "WHEN T1.DIRECCION_3 != '' THEN T1.CLI_ZONA_2 " +
                        "END as cp /*Verificar*/, " +
                        "T4.UNPAIS_DESCRIPCION as pais, " +
                        "'' as ind1, " +
                        "'' as ind2, " +
                        "'' as ind3 " +
                        "from  " +
                        "TERCEROS AS T1 " +
                        "inner join CIUDADES AS T2 on T1.CIUDAD_CORRESP = T2.ID_CIUDAD " +
                        "inner join DEPARTAMENTOS AS T3 on T1.DPTO_CORRESP = T3.ID_DPTO " +
                        "inner join PAISES AS T4 on T1.PAIS_CORRESP = T4.ID_PAIS " +
                        "inner join CONTRATOS AS T5 ON T5.ID_TERC = T1.Codigo AND T5.ID_EMP IN('01','02') " +
                        "where " +
                        "(T1.DIRECCION_1 != '' or  " +
                        "T1.DIRECCION_2 != '' or  " +
                        "T1.DIRECCION_3 != '' ); ";
                    break;
                case "partabiertas" :
                    sql = "SELECT " +
                            "T.CODIGO AS codcli, " +
                            "CXC.ID_TIPO_CRU AS tdoc, " +
                            "CXC.ID_NRO_CRU AS ndoc, " +
                            "CXC.ID_DIAS_VCTO AS nvcto, " +
                            "CXC.ID_FECHA_CONTAB AS fchemi, " +
                            "CXC.ID_FECHA_VCTO AS fcvcto, " +
                            "CXC.SALDOS_TOT_CARTERA AS importe, " +
                            "0 AS estado, " +
                            "0 AS dotada, " +
                            "CXC.FORMA_PAGO_DOC AS codvp, " +
                            "'' AS codcondp, " +
                            "'COP' AS codmondoc, " +
                            "'' AS impmondoc, " +
                            "'' AS ind1, " +
                            "'' AS ind2, " +
                            "'' AS ind3, " +
                            "'' AS ind4, " +
                            "'' AS ind5, " +
                            "'' AS ind6, " +
                            "'' AS ind7, " +
                            "'' AS ind8, " +
                            "'' AS ind9, " +
                            "CONCAT_WS('@#', CXC.ID_FECHA_CONTAB, CXC.ID_TIPO_CRU, CXC.ID_NRO_CRU) AS campoid, " +
                            "'' AS codejercicio, " +
                            "'' AS numdocorigen " +
                            "FROM " +
                            "cgresumen_cxc AS CXC " +
                            "INNER JOIN terceros AS T ON CXC.ID_TERC = T.CODIGO AND CXC.ID_SUC = T.SUCURSAL " +
                            "INNER JOIN cuentas_contab AS CC ON CXC.ID_CUENTA = CC.CODIGO " +
                            "WHERE " +
                            "CXC.ID_EMP IN('01','02') " +
                            "AND CXC.ID_FECHA_CANC = 0 " +
                            "AND ID_FECHA_CONTAB = (SELECT MAX(ID_FECHA_CONTAB) FROM acinox.CGRESUMEN_CXC WHERE ID_FECHA_CANC = 0) " +
                            "ORDER BY " +
                            "T.CODIGO," +
                            "CXC.ID_TIPO_CRU," +
                            "CXC.ID_NRO_CRU," +
                            "CXC.LAPSO_DOC" +
                            ";";
                    break;
                default:
                    sql = "SELECT Codigo AS cod, " +
                            "Descripcion AS razons, " +
                            "NIT AS nif, " +
                            "'COP' AS codmoneda " +
                            "FROM empresas WHERE CODIGO IN(01,02);";
                    break;
            }

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
    }
}
