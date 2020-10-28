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
using System.Diagnostics;
using System.Threading;

namespace AcinoxXML2
{
    #region comentarios de proyecto

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
    // Para efectos de validación de XSD del proyecto debe copiarse la carpeta XSD en la misma ubicación 
    // en donde se esta usando el ejecutable .exe, los archivos XSD deben tener los nombres en minusculas
    // y deben estar todos los ficheros necesarios para validación.
    //
    // Creado: Manuel Cepeda
    // Fecha de creación: 5-oct-2020
    // Descripción: Fase inicial de desarrollo de proyecto
    //
    // Modificación: Manuel Cepeda
    // Fecha de modificación: 14-oct-2020
    // Añadidas validaciones XSD y mejoras de desarrollo para XML y carpetas
    //
    //##***********************************************************************************************###

    #endregion


    class Program
    {

        public static void Main(string[] args)
        {
            SQLBussiness sql = new SQLBussiness();
            MySqlConnection conn = sql.connect();
            generateFiles(sql, conn);
            validateXMLFiles(string.Empty);

            Console.WriteLine("\nDone. Press any key to close.");
            Console.ReadLine();
        }

        public static void generateFiles(SQLBussiness sql, MySqlConnection conn)
        {
            XMLBussiness xml = new XMLBussiness();
            try
            {
                Console.WriteLine("Connecting to MySQL and generating XML files...");
                conn.Open();
                MySqlDataReader rdr = sql.getQueryData("sociedades", conn, string.Empty);
                List<Sociedad> listSociedades = xml.generateEntitySociedad(rdr);
                foreach (Sociedad item in listSociedades)
                {
                    generateFilesBySociety(item, conn, xml, sql);
                    Console.WriteLine("\nXML files generated entity " + item.Cod);
                    validateXMLFiles(item.Cod);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }

            //Console.ReadLine();
            conn.Close();
        }

        private static void generateFilesBySociety(Sociedad sociedad, MySqlConnection conn, XMLBussiness xml, SQLBussiness sql)
        {

            MySqlDataReader rdr2 = sql.getQueryData("clientes", conn,sociedad.Cod);
            xml.generateEntity("clientes", rdr2, sociedad.Cod);

            //MySqlDataReader rdr3 = sql.getQueryData("formasPago", conn);
            xml.generateEntity("formasPago", null, sociedad.Cod);

            MySqlDataReader rdr4 = sql.getQueryData("contactos", conn, sociedad.Cod);
            xml.generateEntity("contactos", rdr4, sociedad.Cod);

            MySqlDataReader rdr5 = sql.getQueryData("clasifcriterios", conn, sociedad.Cod);
            xml.generateEntity("clasifcriterios", rdr5, sociedad.Cod);

            MySqlDataReader rdr6 = sql.getQueryData("direcciones", conn, sociedad.Cod);
            xml.generateEntity("direcciones", rdr6, sociedad.Cod);

            //MySqlDataReader rdr7 = sql.getQueryData("condicionesPago", conn);
            xml.generateEntity("condicionesPago", null, sociedad.Cod);

            MySqlDataReader rdr8 = sql.getQueryData("partabiertas", conn, sociedad.Cod);
            xml.generateEntity("partabiertas", rdr8, sociedad.Cod);

            MySqlDataReader rdr9 = sql.getQueryData("ventas", conn, sociedad.Cod);
            xml.generateEntity("ventas", rdr9, sociedad.Cod);
        }

        public static void validateXMLFiles(string codeEntity)
        {
            //Thread.Sleep(5000);
            XSDBussiness xsd = new XSDBussiness();
            if (string.IsNullOrEmpty(codeEntity))
            {
                xsd.ValidationXSD("sociedades",string.Empty);
            }
            else
            {
                xsd.ValidationXSD("clientes", codeEntity);
                xsd.ValidationXSD("viaspago", codeEntity);
                xsd.ValidationXSD("contactos", codeEntity);
                xsd.ValidationXSD("direcciones", codeEntity);
                xsd.ValidationXSD("clasifcriterios", codeEntity);
                xsd.ValidationXSD("cndpago", codeEntity);
                xsd.ValidationXSD("partabiertas", codeEntity);
                xsd.ValidationXSD("ventas", codeEntity);
            }

        }


    }


}
