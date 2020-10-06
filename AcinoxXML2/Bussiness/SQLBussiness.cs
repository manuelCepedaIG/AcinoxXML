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
            string connStr = "server=localhost;user=root;database=pruebaxesor;port=3306;password=IG82020.";
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
                            "FROM pruebaxesor.empresas" +
                            " WHERE CODIGO IN(01,02);";
                    break;
                case "clientes":
                    sql = "SELECT T1.CODIGO AS cod," +
                            "T1.NIT AS nif," +
                            "T1.DESCRIPCION AS razons," +
                            "IF( T1.CLI_COND_PAGO IS NULL or T1.CLI_COND_PAGO = '', ' ',  T1.CLI_COND_PAGO)  AS codcondp,	" + 
                            "T1.CLI_CUPO_CRE AS limitrg," +
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
                        "from pruebaxesor.ZONAS_SUBZONA " +
                        "where (ZONAS_SUBZONA.ID_ZONA1 = ZONAS_SUBZONA.ID_ZONA) " +
                        "UNION ALL " +
                        "select " +
                        "'1002' as id, " +
                        "ZONAS_SUBZONA.ID_ZONA1 as cod, " +
                        "ZONAS_SUBZONA.UNZONAS_DESCRIPCION as 'desc' " +
                        "from " +
                        "pruebaxesor.ZONAS_SUBZONA " +
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
                        "END as domicilio, /*verificar si esta bien que se seleccione el mismo que coddireccion*/ " +
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
                        "pruebaxesor.TERCEROS AS T1 " +
                        "inner join pruebaxesor.CIUDADES AS T2 on T1.CIUDAD_CORRESP = T2.ID_CIUDAD " +
                        "inner join pruebaxesor.DEPARTAMENTOS AS T3 on T1.DPTO_CORRESP = T3.ID_DPTO " +
                        "inner join pruebaxesor.PAISES AS T4 on T1.PAIS_CORRESP = T4.ID_PAIS " +
                        "where " +
                        "(T1.DIRECCION_1 != '' or  " +
                        "T1.DIRECCION_2 != '' or  " +
                        "T1.DIRECCION_3 != '' ) " ;
                    break;
                default:
                    sql = "SELECT Codigo AS cod, " +
                            "Descripcion AS razons, " +
                            "NIT AS nif, " +
                            "'COP' AS codmoneda " +
                            "FROM pruebaxesor.empresas WHERE CODIGO IN(01,02);";
                    break;
            }

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
    }
}
