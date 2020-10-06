using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Xml;
using AcinoxXML2.Models;
using AcinoxXML2.Bussiness;

namespace AcinoxXML2
{
    //##***********************************************************************************************###
    //
    //
    // Intergrupo 2020
    // Proyecto ACINOX
    // Descripción: Proyecto de consola .NET para consulta y mapeado de consulta a mysql de clientes
    // y posterior generación a archivo XML
    // 
    // Versionamiento para tener en cuenta: .NET 4.7.2
    // Motor de Base de datos MySQL: 8.0
    // Driver para conexión MySQL: MySql.Data v8.0.21.0 - Runtime Version: v4.0.30319
    //
    // Creado: Manuel Cepeda
    // Fecha de creación: 5-oct-2020
    // 
    //
    //##***********************************************************************************************###


    class Program
    {

        public static void Main(string[] args)
        {
            SQLBussiness sql = new SQLBussiness();
            MySqlConnection conn = sql.connect();
            generateFiles(sql, conn);
        }

        public static void generateFiles(SQLBussiness sql, MySqlConnection conn)
        {
            XMLBussiness xml = new XMLBussiness();
            try
            {
                Console.WriteLine("Connecting to MySQL and generating XML files...");
                conn.Open();

                MySqlDataReader rdr = sql.getQueryData("sociedades", conn);
                xml.generateEntity("sociedades", rdr);

                MySqlDataReader rdr2 = sql.getQueryData("clientes", conn);
                xml.generateEntity("clientes", rdr2);

                //MySqlDataReader rdr3 = sql.getQueryData("formasPago", conn);
                xml.generateEntity("formasPago", null);

                MySqlDataReader rdr4 = sql.getQueryData("contactos", conn);
                xml.generateEntity("contactos", rdr4);

                MySqlDataReader rdr5 = sql.getQueryData("clasifcriterios", conn);
                xml.generateEntity("clasifcriterios", rdr4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Done. Press any key to close.");
            Console.ReadLine();
            conn.Close();
        }

        

        

    }


}
