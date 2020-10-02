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
                    List<FormaPago> formaPagoList = mapingFormasPagos();
                    GenerateXMLFormasPagos(formaPagoList);
                    break;
                case "contactos":
                    List<Contacto> contactoList = mapingContactos(rdr);
                    GenerateXMLContactos(contactoList);
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

        public List<FormaPago> mapingFormasPagos()
        {
            List<FormaPago> formaPagoList = new List<FormaPago>();

            #region formas pago

            FormaPago formaPago = new FormaPago();
            formaPago.Cod = "1";
            formaPago.Desc = "Efectivo";
            formaPago.Gencart = "0";
            formaPago.Ind1 = "001";
            formaPago.Ind2 = "EFECTIVO";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "2";
            formaPago.Desc = "Cheques";
            formaPago.Gencart = "0";
            formaPago.Ind1 = "002";
            formaPago.Ind2 = "CHEQUE AL DIA";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "5";
            formaPago.Desc = "Consignacion";
            formaPago.Gencart = "0";
            formaPago.Ind1 = "003";
            formaPago.Ind2 = "CONSIGNACION";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "1";
            formaPago.Desc = "Efectivo";
            formaPago.Gencart = "0";
            formaPago.Ind1 = "004";
            formaPago.Ind2 = "EFECTIVO - DOLAR";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "3";
            formaPago.Desc = "Otros";
            formaPago.Gencart = "0";
            formaPago.Ind1 = "005";
            formaPago.Ind2 = "TARJETA DB";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "2";
            formaPago.Desc = "Cheques";
            formaPago.Gencart = "0";
            formaPago.Ind1 = "006";
            formaPago.Ind2 = "CHEQUES POSFECHADOS";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "1";
            formaPago.Desc = "Efectivo";
            formaPago.Gencart = "0";
            formaPago.Ind1 = "007";
            formaPago.Ind2 = "TRASFERENCIA ELECTRONICA";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "3";
            formaPago.Desc = "Otros";
            formaPago.Gencart = "0";
            formaPago.Ind1 = "998";
            formaPago.Ind2 = "BONOS";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "3";
            formaPago.Desc = "Otros";
            formaPago.Gencart = "0";
            formaPago.Ind1 = "999";
            formaPago.Ind2 = "OTROS";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            #endregion

            return formaPagoList;

        }

        public List<Contacto> mapingContactos(MySqlDataReader rdr)
        {
            List<Contacto> contactoList = new List<Contacto>();
            while (rdr.Read())
            {
                Contacto contacto = new Contacto();
                contacto.Codcliente = rdr[0].ToString();
                contacto.Codcontacto = rdr[1].ToString();
                contacto.Nombre = rdr[2].ToString();
                contacto.Nif = rdr[3].ToString();
                contacto.Tcontacto = rdr[4].ToString();
                contacto.Coddireccion = rdr[5].ToString();
                contacto.Tlfmovil = rdr[6].ToString();
                contacto.Tlffijo = rdr[7].ToString();
                contacto.Fax = rdr[8].ToString();
                contacto.Email = rdr[9].ToString();
                contacto.Ind1 = rdr[10].ToString();
                contacto.Ind2 = rdr[11].ToString();
                contacto.Ind3 = rdr[12].ToString();

                contactoList.Add(contacto);
            }
            rdr.Close();
            return contactoList;
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

            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            XmlWriter writer = XmlWriter.Create(@"sociedades.xml", settings);
            doc.Save(writer);
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

                XmlNode fchinitactNode = doc.CreateElement("fchinitact");
                fchinitactNode.InnerText = Cliente.Fchinitact;
                clienteNode.AppendChild(fchinitactNode);

                XmlNode ind1Node = doc.CreateElement("ind1");
                ind1Node.InnerText = Cliente.Ind1;
                clienteNode.AppendChild(ind1Node);

                XmlNode ind2Node = doc.CreateElement("ind2");
                ind2Node.InnerText = Cliente.Ind2;
                clienteNode.AppendChild(ind2Node);

                XmlNode ind3Node = doc.CreateElement("ind3");
                ind3Node.InnerText = Cliente.Ind3;
                clienteNode.AppendChild(ind3Node);

                XmlNode ind4Node = doc.CreateElement("ind4");
                ind4Node.InnerText = Cliente.Ind4;
                clienteNode.AppendChild(ind4Node);

                XmlNode ind5Node = doc.CreateElement("ind5");
                ind5Node.InnerText = Cliente.Ind5;
                clienteNode.AppendChild(ind5Node);

                XmlNode ind6Node = doc.CreateElement("ind6");
                ind6Node.InnerText = Cliente.Ind6;
                clienteNode.AppendChild(ind6Node);

                XmlNode ind7Node = doc.CreateElement("ind7");
                ind7Node.InnerText = Cliente.Ind7;
                clienteNode.AppendChild(ind7Node);

                XmlNode ind8Node = doc.CreateElement("ind8");
                ind8Node.InnerText = Cliente.Ind8;
                clienteNode.AppendChild(ind8Node);

                XmlNode ind9Node = doc.CreateElement("ind9");
                ind9Node.InnerText = Cliente.Ind9;
                clienteNode.AppendChild(ind9Node);

                XmlNode tieneavalNode = doc.CreateElement("tieneaval");
                tieneavalNode.InnerText = Cliente.TieneAval;
                clienteNode.AppendChild(tieneavalNode);

                XmlNode tipoavalNode = doc.CreateElement("tipoaval");
                tipoavalNode.InnerText = Cliente.TipoAval;
                clienteNode.AppendChild(tipoavalNode);
            }

            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            XmlWriter writer = XmlWriter.Create(@"clientes.xml", settings);
            doc.Save(writer);
        }

        public void GenerateXMLFormasPagos(List<FormaPago> formaPagoList)
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

            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            XmlWriter writer = XmlWriter.Create(@"viaspago.xml", settings);
            doc.Save(writer);
        }

        public void GenerateXMLContactos(List<Contacto> contactoList)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode contactosNode = doc.CreateElement("contactos");
            doc.AppendChild(contactosNode);

            XmlAttribute metadata = doc.CreateAttribute("xmlns:xsi");
            metadata.Value = "http://www.w3.org/2001/XMLSchema-instance";
            contactosNode.Attributes.Append(metadata);

            XmlAttribute metadata2 = doc.CreateAttribute("xsi:noNamespaceSchemaLocation");
            metadata2.Value = @"..\xsd\contactos.xsd";
            contactosNode.Attributes.Append(metadata2);

            foreach (Contacto contacto in contactoList)
            {
                XmlNode contactoNode = doc.CreateElement("contacto");
                contactosNode.AppendChild(contactoNode);

                XmlNode codclienteNode = doc.CreateElement("codcliente");
                codclienteNode.InnerText = contacto.Codcliente;
                contactoNode.AppendChild(codclienteNode);

                XmlNode codcontactoNode = doc.CreateElement("codcontacto");
                codcontactoNode.InnerText = contacto.Codcontacto;
                contactoNode.AppendChild(codcontactoNode);

                XmlNode nombreNode = doc.CreateElement("nombre");
                nombreNode.InnerText = contacto.Nombre;
                contactoNode.AppendChild(nombreNode);

                XmlNode nifNode = doc.CreateElement("nif");
                nifNode.InnerText = contacto.Nif;
                contactoNode.AppendChild(nifNode);

                XmlNode tcontactoNode = doc.CreateElement("tcontacto");
                tcontactoNode.InnerText = contacto.Tcontacto;
                contactoNode.AppendChild(tcontactoNode);

                XmlNode coddireccionNode = doc.CreateElement("coddireccion");
                coddireccionNode.InnerText = contacto.Coddireccion;
                contactoNode.AppendChild(coddireccionNode);

                XmlNode tlfmovilNode = doc.CreateElement("tlfmovil");
                tlfmovilNode.InnerText = contacto.Tlfmovil;
                contactoNode.AppendChild(tlfmovilNode);

                XmlNode tlffijoNode = doc.CreateElement("tlffijo");
                tlffijoNode.InnerText = contacto.Tlffijo;
                contactoNode.AppendChild(tlffijoNode);

                XmlNode faxNode = doc.CreateElement("fax");
                faxNode.InnerText = contacto.Fax;
                contactoNode.AppendChild(faxNode);

                XmlNode emailNode = doc.CreateElement("email");
                emailNode.InnerText = contacto.Email;
                contactoNode.AppendChild(emailNode);

                XmlNode ind1Node = doc.CreateElement("ind1");
                ind1Node.InnerText = contacto.Ind1;
                contactoNode.AppendChild(ind1Node);

                XmlNode ind2Node = doc.CreateElement("ind2");
                ind2Node.InnerText = contacto.Ind2;
                contactoNode.AppendChild(ind2Node);

                XmlNode ind3Node = doc.CreateElement("ind3");
                ind3Node.InnerText = contacto.Ind3;
                contactoNode.AppendChild(ind3Node);
            }

            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            XmlWriter writer = XmlWriter.Create(@"contactos.xml", settings);
            doc.Save(writer);
        }


        #endregion
    }
}
