using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace AcinoxXML2.Bussiness
{
    //##***********************************************************************************************###
    //
    //
    // Intergrupo 2020
    // Proyecto ACINOX
    // Descripción: Validación de archivos XML contra plantillas XSD
    //
    // Creado: Manuel Cepeda
    // Fecha de creación: 14-oct-2020
    // 
    //
    //##***********************************************************************************************###

    public class XSDBussiness
    {
        public void ValidationXSD(string fileName)
        {
            Console.WriteLine();
            Console.WriteLine("-> Validating: {0}", fileName);

            string directory = Directory.GetCurrentDirectory();
            string xsdFile = directory + @"\XSD\" + fileName + ".xsd";
            string xmlFile = directory + @"\XML\" + fileName + ".xml";

            bool isvalid = true;
            StringBuilder sb = new StringBuilder();

            try
            {

                var xdoc = XDocument.Load(xmlFile);
                var xdoc2 = XDocument.Load(xsdFile);


                var schemas = new XmlSchemaSet();
                using (FileStream stream = File.OpenRead(xsdFile))
                {
                    schemas.Add(XmlSchema.Read(stream, (s, e) =>
                    {
                        var x = e.Message;
                    }));
                }

                xdoc.Validate(schemas, (s, e) =>
                {
                    isvalid = false;

                    switch (e.Severity)
                    {
                        case XmlSeverityType.Error:
                            sb.AppendLine(string.Format("File: {0}, Line : {1}, Message : {2} ",
                                     fileName + ".xml", e.Exception.LineNumber, e.Exception.Message));
                            break;
                        case XmlSeverityType.Warning:
                            sb.AppendLine(string.Format("File: {0}, Line : {1}, Message : {2} ",
                                     fileName + ".xml", e.Exception.LineNumber, e.Exception.Message));
                            break;
                    }

                    
                });
            }
            catch (XmlSchemaValidationException)
            {
                isvalid = false;
                sb.AppendLine(string.Format("** There was an error found related with system verification, please check error in the debug log"));
            }
            catch(Exception e)
            {
                isvalid = false;
                sb.AppendLine(string.Format("**Error found: {0}", e.Message));
            }

            if (isvalid)
            {
                Console.Write("-> no errors found.\n");
            }
            else
            {
                Console.Write(sb);
            }
        }
    }
}
