using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }

        public MySqlDataReader getQueryData(string typeOfQuery, MySqlConnection conn, string codeEntity)
        {
            string sql = string.Empty;
            FileInfo file = new FileInfo(@"SQL\"+ typeOfQuery + ".sql");
            sql = file.OpenText().ReadToEnd();

            if (!string.IsNullOrEmpty(codeEntity) && !string.IsNullOrEmpty(sql))
            {
                sql = sql.Replace("{0}", codeEntity);
            }

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
    }
}
