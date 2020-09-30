using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcinoxXML2.Bussiness
{
    public class SQLBussiness
    {
        public MySqlConnection connect()
        {
            string connStr = "server=localhost;user=BIABLE01;database=acinox;port=3306;password=acinox";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }

        public MySqlDataReader getQueryData(string typeOfQuery, MySqlConnection conn)
        {
            string sql = string.Empty;
            switch (typeOfQuery)
            {
                case "sociedades":
                    sql = "SELECT Codigo AS cod, Descripcion AS razons, NIT AS nif, 'COP' AS codmoneda FROM acinox.empresas WHERE CODIGO IN(01,02);";
                    break;
                case "clientes":
                    sql = "SELECT T1.CODIGO AS cod,T1.NIT AS nif,T1.DESCRIPCION AS razons,T1.CLI_COND_PAGO AS codcondp,T1.CLI_CUPO_CRE AS limitrg," +
                        "T2.UNDPTO_DESCRIPCION AS prov,T1.CLI_ZONA_1 as criterio1_ZONA,T1.CLI_ZONA_2 as criterio2_SUBZONA,'0' as lrcomp,' ' as viasp," +
                        "T1.TIPO_TERCERO as clasifcontable,' ' as lsegcredito,' ' as fchcadsegcred,' ' as tipoentidad,' ' as sector," +
                        "T1.FECHA_CREACION as fchaltaerp,' ' as fchinitact,T3.DESCRIPCION as ind1,' ' as ind2,' ' as ind3,' ' as ind4,' ' as ind5," +
                        "' ' as ind6,' ' as ind7,' ' as ind8,' ' as ind9,' ' as tieneaval,' ' as tipoaval " +
                        "FROM TERCEROS AS T1 " +
                        "INNER JOIN DEPARTAMENTOS AS T2 ON T1.DPTO_CORRESP=T2.ID_DPTO " +
                        "INNER JOIN VENDEDORES AS T3 ON T1.CLI_VENDEDOR=T3.CODIGO " +
                        "INNER JOIN CONTRATOS AS C ON C.ID_TERC = T1.Codigo AND C.ID_EMP IN ('01','02')";
                    break;
                case "formasPago":
                    sql = "SELECT CFC.ID_CPTONIV4 AS cod, CFC.CGCPTOFE_DESCRIPCION AS 'desc', '1' AS gencart, ' ' AS ind1, ' ' AS ind2, '15' AS numdias FROM acinox.cpto_flujo_caja CFC;";
                    break;
                default:
                    sql = "SELECT Codigo AS cod, Descripcion AS razons, NIT AS nif, 'COP' AS codmoneda FROM acinox.empresas WHERE CODIGO IN(01,02);";
                    break;
            }

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
    }
}
