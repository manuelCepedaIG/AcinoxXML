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
            validateXMLFiles();
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

                MySqlDataReader rdr5 = sql.getQueryData("clasifcriterios", conn);
                xml.generateEntity("clasifcriterios", rdr5);

                MySqlDataReader rdr2 = sql.getQueryData("clientes", conn);
                xml.generateEntity("clientes", rdr2);

                //MySqlDataReader rdr3 = sql.getQueryData("formasPago", conn);
                xml.generateEntity("formasPago", null);

                MySqlDataReader rdr4 = sql.getQueryData("contactos", conn);
                xml.generateEntity("contactos", rdr4);

                MySqlDataReader rdr6 = sql.getQueryData("direcciones", conn);
                xml.generateEntity("direcciones", rdr6);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("XML files generated");
            //Console.ReadLine();
            conn.Close();
        }

        public static void validateXMLFiles()
        {
            XSDBussiness xsd = new XSDBussiness();
            xsd.ValidationXSD("sociedades");
            xsd.ValidationXSD("clientes");
            xsd.ValidationXSD("viaspago");
            xsd.ValidationXSD("contactos");
            xsd.ValidationXSD("direcciones");
            xsd.ValidationXSD("clasifcriterios");

            Console.WriteLine("Done. Press any key to close.");
            Console.ReadLine();
        }


    }


}
