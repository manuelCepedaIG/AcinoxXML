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
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlDataReader rdr = sql.getQueryData("sociedades", conn);
                xml.generateEntity("sociedades", rdr);

                MySqlDataReader rdr2 = sql.getQueryData("clientes", conn);
                xml.generateEntity("clientes", rdr2);

                //MySqlDataReader rdr3 = sql.getQueryData("formasPago", conn);
                xml.generateEntity("formasPago", null);

                MySqlDataReader rdr4 = sql.getQueryData("contactos", conn);
                xml.generateEntity("contactos", rdr4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
            conn.Close();
        }

        

        

    }


}
