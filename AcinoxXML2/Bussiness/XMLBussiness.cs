using AcinoxXML2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AcinoxXML2.Bussiness
{
    public class XMLBussiness
    {
        public  void generateEntity(string typeOfQuery, MySqlDataReader rdr)
        {
            switch (typeOfQuery)
            {
                case "sociedades":
                    List<Sociedad> sociedadList = mapingSociedades(rdr);
                    GenerateXMLSociedades(sociedadList);
                    break;
                case "clientes":
                    List<Cliente> clientesList = mapingClientes(rdr);
                    GenerateXMLClientes(clientesList);
                    break;
                case "formasPago":
                    List<FormaPago> formaPagoList = mapingFormaPago(rdr);
                    GenerateXMLFormaPago(formaPagoList);
                    break;
                default:
                    break;
            }
        }

        #region mapping
        public  List<Sociedad> mapingSociedades(MySqlDataReader rdr)
        {
            List<Sociedad> sociedadList = new List<Sociedad>();
            while (rdr.Read())
            {
                Sociedad sociedad = new Sociedad();
                sociedad.Cod = rdr[0].ToString();
                sociedad.Razons = rdr[1].ToString();
                sociedad.Nif = rdr[2].ToString();
                sociedad.Codmoneda = rdr[3].ToString();
                sociedadList.Add(sociedad);
            }
            rdr.Close();
            return sociedadList;
        }

        public List<Cliente> mapingClientes(MySqlDataReader rdr)
        {
            List<Cliente> clienteList = new List<Cliente>();
            while (rdr.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Cod = rdr[0].ToString();
                cliente.Nif = rdr[1].ToString();
                cliente.Razons = rdr[2].ToString();
                cliente.Codcondp = rdr[3].ToString();
                cliente.Limitrg = rdr[4].ToString();
                cliente.Prov = rdr[5].ToString();
                cliente.Criterio1_ZONA = rdr[6].ToString();
                cliente.Criterio2_SUBZONA = rdr[7].ToString();
                cliente.Lrcomp = rdr[8].ToString();
                cliente.Viasp = rdr[9].ToString();
                cliente.Lsegcredito = rdr[10].ToString();
                cliente.Fchcadsegcred = rdr[11].ToString();
                cliente.Tipoentidad = rdr[12].ToString();
                cliente.Sector = rdr[13].ToString();
                cliente.Fchaltaerp = rdr[14].ToString();
                clienteList.Add(cliente);
            }
            rdr.Close();
            return clienteList;
        }

        public List<FormaPago> mapingFormaPago(MySqlDataReader rdr)
        {
            List<FormaPago> formaPagoList = new List<FormaPago>();
            while (rdr.Read())
            {
                FormaPago formaPago = new FormaPago();
                formaPago.Cod = rdr[0].ToString();
                formaPago.Desc = rdr[1].ToString();
                formaPago.Gencart = rdr[2].ToString();
                formaPago.Ind1 = rdr[3].ToString();
                formaPago.Ind2 = rdr[4].ToString();
                formaPago.Numdias = rdr[5].ToString();

                formaPagoList.Add(formaPago);
            }
            rdr.Close();
            return formaPagoList;
        }

        #endregion

        #region GenerateXML

        public void GenerateXMLSociedades(List<Sociedad> sociedadList)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode sociedadesNode = doc.CreateElement("sociedades");
            doc.AppendChild(sociedadesNode);

            XmlAttribute metadata = doc.CreateAttribute("xmlns:xsi");
            metadata.Value = "http://www.w3.org/2001/XMLSchema-instance";
            sociedadesNode.Attributes.Append(metadata);

            XmlAttribute metadata2 = doc.CreateAttribute("xsi:noNamespaceSchemaLocation");
            metadata2.Value = @"..\xsd\sociedades.xsd";
            sociedadesNode.Attributes.Append(metadata2);

            foreach (Sociedad sociedad in sociedadList)
            {
                XmlNode socNode = doc.CreateElement("soc");
                sociedadesNode.AppendChild(socNode);

                XmlNode codNode = doc.CreateElement("cod");
                codNode.InnerText = sociedad.Cod;
                socNode.AppendChild(codNode);

                XmlNode razonsNode = doc.CreateElement("razons");
                razonsNode.InnerText = sociedad.Razons;
                socNode.AppendChild(razonsNode);

                XmlNode nifNode = doc.CreateElement("nif");
                nifNode.InnerText = sociedad.Nif;
                socNode.AppendChild(nifNode);

                XmlNode codmonedaNode = doc.CreateElement("codmoneda");
                codmonedaNode.InnerText = sociedad.Codmoneda;
                socNode.AppendChild(codmonedaNode);
            }

            //Console.WriteLine(sociedadList.GetType().GetGenericArguments()[0]);
            //doc.Save(Console.Out);
            doc.Save("sociedades.xml");
        }

        public void GenerateXMLClientes(List<Cliente> clienteList)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode clientesNode = doc.CreateElement("clientes");
            doc.AppendChild(clientesNode);

            XmlAttribute metadata = doc.CreateAttribute("xmlns:xsi");
            metadata.Value = "http://www.w3.org/2001/XMLSchema-instance";
            clientesNode.Attributes.Append(metadata);

            XmlAttribute metadata2 = doc.CreateAttribute("xsi:noNamespaceSchemaLocation");
            metadata2.Value = @"..\xsd\clientes.xsd";
            clientesNode.Attributes.Append(metadata2);

            foreach (Cliente Cliente in clienteList)
            {
                XmlNode clienteNode = doc.CreateElement("cliente");
                clientesNode.AppendChild(clienteNode);

                XmlNode codNode = doc.CreateElement("cod");
                codNode.InnerText = Cliente.Cod;
                clienteNode.AppendChild(codNode);

                XmlNode nifNode = doc.CreateElement("nif");
                nifNode.InnerText = Cliente.Nif;
                clienteNode.AppendChild(nifNode);

                XmlNode razonsNode = doc.CreateElement("razons");
                razonsNode.InnerText = Cliente.Razons;
                clienteNode.AppendChild(razonsNode);

                XmlNode codcondpNode = doc.CreateElement("codcondp");
                codcondpNode.InnerText = Cliente.Codcondp;
                clienteNode.AppendChild(codcondpNode);

                XmlNode limitrgNode = doc.CreateElement("limitrg");
                limitrgNode.InnerText = Cliente.Limitrg;
                clienteNode.AppendChild(limitrgNode);

                XmlNode provNode = doc.CreateElement("prov");
                provNode.InnerText = Cliente.Prov;
                clienteNode.AppendChild(provNode);

                XmlNode criterio1_ZONANode = doc.CreateElement("criterio1_ZONA");
                criterio1_ZONANode.InnerText = Cliente.Criterio1_ZONA;
                clienteNode.AppendChild(criterio1_ZONANode);

                XmlNode criterio2_SUBZONANode = doc.CreateElement("criterio2_SUBZONA");
                criterio2_SUBZONANode.InnerText = Cliente.Criterio2_SUBZONA;
                clienteNode.AppendChild(criterio2_SUBZONANode);

                XmlNode lrcompNode = doc.CreateElement("lrcomp");
                lrcompNode.InnerText = Cliente.Lrcomp;
                clienteNode.AppendChild(lrcompNode);

                XmlNode viaspNode = doc.CreateElement("viasp");
                viaspNode.InnerText = Cliente.Viasp;
                clienteNode.AppendChild(viaspNode);

                XmlNode lsegcreditoNode = doc.CreateElement("lsegcredito");
                lsegcreditoNode.InnerText = Cliente.Lsegcredito;
                clienteNode.AppendChild(lsegcreditoNode);

                XmlNode fchcadsegcredNode = doc.CreateElement("fchcadsegcred");
                fchcadsegcredNode.InnerText = Cliente.Fchcadsegcred;
                clienteNode.AppendChild(fchcadsegcredNode);

                XmlNode tipoentidadNode = doc.CreateElement("tipoentidad");
                tipoentidadNode.InnerText = Cliente.Tipoentidad;
                clienteNode.AppendChild(tipoentidadNode);

                XmlNode sectorNode = doc.CreateElement("sector");
                sectorNode.InnerText = Cliente.Sector;
                clienteNode.AppendChild(sectorNode);

                XmlNode fchaltaerpNode = doc.CreateElement("fchaltaerp");
                fchaltaerpNode.InnerText = Cliente.Fchaltaerp;
                clienteNode.AppendChild(fchaltaerpNode);
            }

            //Console.WriteLine(sociedadList.GetType().GetGenericArguments()[0]);
            //doc.Save(Console.Out);
            doc.Save("clientes.xml");
        }

        public void GenerateXMLFormaPago(List<FormaPago> formaPagoList)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode viaspagoNode = doc.CreateElement("viaspago");
            doc.AppendChild(viaspagoNode);

            XmlAttribute metadata = doc.CreateAttribute("xmlns:xsi");
            metadata.Value = "http://www.w3.org/2001/XMLSchema-instance";
            viaspagoNode.Attributes.Append(metadata);

            XmlAttribute metadata2 = doc.CreateAttribute("xsi:noNamespaceSchemaLocation");
            metadata2.Value = @"..\xsd\viaspago.xsd";
            viaspagoNode.Attributes.Append(metadata2);

            foreach (FormaPago formaPago in formaPagoList)
            {
                XmlNode viaNode = doc.CreateElement("via");
                viaspagoNode.AppendChild(viaNode);

                XmlNode codNode = doc.CreateElement("cod");
                codNode.InnerText = formaPago.Cod;
                viaNode.AppendChild(codNode);

                XmlNode descNode = doc.CreateElement("desc");
                descNode.InnerText = formaPago.Desc;
                viaNode.AppendChild(descNode);

                XmlNode gencartNode = doc.CreateElement("gencart");
                gencartNode.InnerText = formaPago.Gencart;
                viaNode.AppendChild(gencartNode);

                XmlNode ind1Node = doc.CreateElement("ind1");
                ind1Node.InnerText = formaPago.Ind1;
                viaNode.AppendChild(ind1Node);

                XmlNode ind2Node = doc.CreateElement("ind2");
                ind2Node.InnerText = formaPago.Ind2;
                viaNode.AppendChild(ind2Node);

                XmlNode numdiasNode = doc.CreateElement("numdias");
                numdiasNode.InnerText = formaPago.Numdias;
                viaNode.AppendChild(numdiasNode);
            }

            //Console.WriteLine(sociedadList.GetType().GetGenericArguments()[0]);
            //doc.Save(Console.Out);
            doc.Save("viaspago.xml");
        }


        #endregion
    }
}
