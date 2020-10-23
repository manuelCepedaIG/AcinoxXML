using AcinoxXML2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace AcinoxXML2.Bussiness
{
    //##***********************************************************************************************###
    //
    //
    // Intergrupo 2020
    // Proyecto ACINOX
    // Descripción: Mapeado de entidades y generación de XML
    //
    // Creado: Manuel Cepeda
    // Fecha de creación: 5-oct-2020
    // 
    //
    //##***********************************************************************************************###


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
                case "clasifcriterios":
                    List<ClasificacionCriterio> creteriosList = mapingCriterios(rdr);
                    GenerateXMLCriteriosClasificacion(creteriosList);
                    break;
                case "direcciones":
                    List<Direccion> direccionesList = mapingDirecciones(rdr);
                    GenerateXMLDirecciones(direccionesList);
                    break;
                case "partabiertas":
                    List<PartidaAbierta> PartidaAbiertaList = mapingPartidasAbiertas(rdr);
                    GenerateXMLPartidasAbiertas(PartidaAbiertaList);
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
                cliente.Limitrg = string.IsNullOrEmpty(rdr[4].ToString()) ? 0 : Convert.ToDecimal(rdr[4].ToString());
                cliente.Prov = rdr[5].ToString();
                cliente.Criterio1_ZONA = rdr[6].ToString();
                cliente.Criterio2_SUBZONA = rdr[7].ToString();
                cliente.Lrcomp = string.IsNullOrEmpty(rdr[8].ToString()) ? 0 : Convert.ToUInt32(rdr[8].ToString());
                cliente.Viasp = rdr[9].ToString();
                cliente.ClasifContable = rdr[10].ToString();
                cliente.Lsegcredito = string.IsNullOrEmpty(rdr[11].ToString()) ? 0 : Convert.ToDecimal(rdr[11].ToString());
                cliente.Fchcadsegcred = (rdr[12] == DBNull.Value || string.IsNullOrEmpty(rdr[12].ToString())
                                                    ? new DateTime(1, 1, 1)
                                                    : new DateTime(Convert.ToInt32(rdr[12].ToString().Substring(0, 4)),
                                                                   Convert.ToInt32(rdr[12].ToString().Substring(4, 2)),
                                                                   Convert.ToInt32(rdr[12].ToString().Substring(6, 2))));
                cliente.Tipoentidad = rdr[13].ToString();
                cliente.Sector = rdr[14].ToString();
                cliente.Fchaltaerp = (rdr[15] == DBNull.Value || string.IsNullOrEmpty(rdr[15].ToString()) 
                                                    ? new DateTime(1, 1, 1) 
                                                    : new DateTime(Convert.ToInt32(rdr[15].ToString().Substring(0,4)), 
                                                                   Convert.ToInt32(rdr[15].ToString().Substring(4,2)),
                                                                   Convert.ToInt32(rdr[15].ToString().Substring(6,2))) );
                cliente.Fchinitact = (rdr[16] == DBNull.Value || string.IsNullOrEmpty(rdr[16].ToString())
                                                    ? new DateTime(1, 1, 1)
                                                    : new DateTime(Convert.ToInt32(rdr[16].ToString().Substring(0, 4)),
                                                                   Convert.ToInt32(rdr[16].ToString().Substring(4, 2)),
                                                                   Convert.ToInt32(rdr[16].ToString().Substring(6, 2))));
                cliente.Ind1 = rdr[17].ToString();
                cliente.Ind2 = rdr[18].ToString();
                cliente.Ind3 = rdr[19].ToString();
                cliente.Ind4 = rdr[20].ToString();
                cliente.Ind5 = rdr[21].ToString();
                cliente.Ind6 = rdr[22].ToString();
                cliente.Ind7 = rdr[23].ToString();
                cliente.Ind8 = rdr[24].ToString();
                cliente.Ind9 = rdr[25].ToString();
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
            formaPago.Gencart = 0;
            formaPago.Ind1 = "001";
            formaPago.Ind2 = "EFECTIVO";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "2";
            formaPago.Desc = "Cheques";
            formaPago.Gencart = 0;
            formaPago.Ind1 = "002";
            formaPago.Ind2 = "CHEQUE AL DIA";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "5";
            formaPago.Desc = "Consignacion";
            formaPago.Gencart = 0;
            formaPago.Ind1 = "003";
            formaPago.Ind2 = "CONSIGNACION";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "1";
            formaPago.Desc = "Efectivo";
            formaPago.Gencart = 0;
            formaPago.Ind1 = "004";
            formaPago.Ind2 = "EFECTIVO - DOLAR";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "3";
            formaPago.Desc = "Otros";
            formaPago.Gencart = 0;
            formaPago.Ind1 = "005";
            formaPago.Ind2 = "TARJETA DB";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "2";
            formaPago.Desc = "Cheques";
            formaPago.Gencart = 0;
            formaPago.Ind1 = "006";
            formaPago.Ind2 = "CHEQUES POSFECHADOS";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "1";
            formaPago.Desc = "Efectivo";
            formaPago.Gencart = 0;
            formaPago.Ind1 = "007";
            formaPago.Ind2 = "TRASFERENCIA ELECTRONICA";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "3";
            formaPago.Desc = "Otros";
            formaPago.Gencart = 0;
            formaPago.Ind1 = "998";
            formaPago.Ind2 = "BONOS";
            formaPago.Numdias = "0";
            formaPagoList.Add(formaPago);

            formaPago = new FormaPago();
            formaPago.Cod = "3";
            formaPago.Desc = "Otros";
            formaPago.Gencart = 0;
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
                contacto.Tcontacto = Convert.ToInt32(rdr[4].ToString());
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

        private List<Direccion> mapingDirecciones(MySqlDataReader rdr)
        {
            List<Direccion> direcciones = new List<Direccion>();
            try
            {
                while (rdr.Read())
                {
                    Direccion direccion = new Direccion();
                    direccion.CodigoCliente = rdr[0].ToString();
                    direccion.CodigoDireccion = rdr[1].ToString();
                    direccion.TipoDireccion = Convert.ToInt32(rdr[2]);
                    direccion.Domicilio = rdr[3].ToString();
                    direccion.Ciudad = rdr[4].ToString();
                    direccion.Provincia = rdr[5].ToString();
                    direccion.CodigoPostal = rdr[6].ToString();
                    direccion.Pais = rdr[7].ToString();
                    direccion.Indicador1 = rdr[8].ToString();
                    direccion.Indicador2 = rdr[9].ToString();
                    direccion.Indicador3 = rdr[10].ToString();
                    direcciones.Add(direccion);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }

            return direcciones;
        }

        private List<ClasificacionCriterio> mapingCriterios(MySqlDataReader rdr)
        {
            List<ClasificacionCriterio> clasificacionCriterio = new List<ClasificacionCriterio>();
            while (rdr.Read())
            {
                ClasificacionCriterio criterios = new ClasificacionCriterio();
                criterios.Id = rdr[0].ToString();
                criterios.Codigo = rdr[1].ToString();
                criterios.Descripcion = rdr[2].ToString();
                clasificacionCriterio.Add(criterios);
            }
            rdr.Close();
            return clasificacionCriterio;
        }

        private List<PartidaAbierta> mapingPartidasAbiertas(MySqlDataReader rdr)
        {
            List<PartidaAbierta> partidaAbiertaList = new List<PartidaAbierta>();
            while (rdr.Read())
            {
                PartidaAbierta partidaAbierta = new PartidaAbierta();
                partidaAbierta.Codcli = rdr[0].ToString();
                partidaAbierta.Tdoc = rdr[1].ToString();
                partidaAbierta.Ndoc = rdr[2].ToString();
                partidaAbierta.Nvcto = rdr[3].ToString();
                partidaAbierta.Fchemi = (rdr[4] == DBNull.Value || string.IsNullOrEmpty(rdr[4].ToString())
                                                    ? new DateTime(1, 1, 1)
                                                    : new DateTime(Convert.ToInt32(rdr[4].ToString().Substring(0, 4)),
                                                                   Convert.ToInt32(rdr[4].ToString().Substring(4, 2)),
                                                                   Convert.ToInt32(rdr[4].ToString().Substring(6, 2))));
                partidaAbierta.Fchvcto = (rdr[5] == DBNull.Value || string.IsNullOrEmpty(rdr[5].ToString())
                                                    ? new DateTime(1, 1, 1)
                                                    : new DateTime(Convert.ToInt32(rdr[5].ToString().Substring(0, 4)),
                                                                   Convert.ToInt32(rdr[5].ToString().Substring(4, 2)),
                                                                   Convert.ToInt32(rdr[5].ToString().Substring(6, 2))));
                partidaAbierta.Importe = string.IsNullOrEmpty(rdr[6].ToString()) ? 0 : Convert.ToDecimal(rdr[6].ToString());
                partidaAbierta.Estado = string.IsNullOrEmpty(rdr[7].ToString()) ? 0 : Convert.ToUInt32(rdr[7].ToString());
                partidaAbierta.Dotada = string.IsNullOrEmpty(rdr[8].ToString()) ? 0 : Convert.ToUInt32(rdr[8].ToString());
                partidaAbierta.Codvp = rdr[9].ToString();
                partidaAbierta.Codcondp = rdr[10].ToString();
                partidaAbierta.Codmondoc = rdr[11].ToString();
                partidaAbierta.Impmondoc = rdr[12].ToString();
                partidaAbierta.Ind1 = rdr[13].ToString();
                partidaAbierta.Ind2 = rdr[14].ToString();
                partidaAbierta.Ind3 = rdr[15].ToString();
                partidaAbierta.Ind4 = rdr[16].ToString();
                partidaAbierta.Ind5 = rdr[17].ToString();
                partidaAbierta.Ind6 = rdr[18].ToString();
                partidaAbierta.Ind7 = rdr[19].ToString();
                partidaAbierta.Ind8 = rdr[20].ToString();
                partidaAbierta.Ind9 = rdr[21].ToString();
                partidaAbierta.Campoid = rdr[22].ToString();
                partidaAbierta.Codejercicio = rdr[23].ToString();
                partidaAbierta.Numdocorigen = rdr[24].ToString();
                partidaAbiertaList.Add(partidaAbierta);
            }
            rdr.Close();
            return partidaAbiertaList;
        }

        #endregion

        #region GenerateXML

        private void GenerateXMLSociedades(List<Sociedad> sociedadList)
        {
            XmlElement sociedadesNode;
            XmlDocument doc = CreateXMLHeaders("sociedades", out sociedadesNode);
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
            SavingXMLFile(doc, "sociedades");
        }

        private void GenerateXMLClientes(List<Cliente> clienteList)
        {
            XmlElement clientesNode;
            XmlDocument doc = CreateXMLHeaders("clientes", out clientesNode);
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
                limitrgNode.InnerText = Cliente.Limitrg.ToString().Replace(",", "."); ;
                clienteNode.AppendChild(limitrgNode);

                XmlNode provNode = doc.CreateElement("prov");
                provNode.InnerText = Cliente.Prov;
                clienteNode.AppendChild(provNode);

                XmlNode dims = doc.CreateElement("dims");
                clienteNode.AppendChild(dims);

                XmlNode dim = doc.CreateElement("dim");
                dims.AppendChild(dim);

                XmlNode dimOrden = doc.CreateElement("orden");
                dimOrden.InnerText = "1";
                dim.AppendChild(dimOrden);

                XmlNode dimCodElem = doc.CreateElement("codelem");
                dimCodElem.InnerText = Cliente.Criterio1_ZONA;
                dim.AppendChild(dimCodElem);

                XmlNode dimCodCrit = doc.CreateElement("codcrit");
                dimCodCrit.InnerText = "1001";
                dim.AppendChild(dimCodCrit);

                XmlNode dim2 = doc.CreateElement("dim");
                dims.AppendChild(dim2);

                XmlNode dim2Orden = doc.CreateElement("orden");
                dim2Orden.InnerText = "2";
                dim2.AppendChild(dim2Orden);

                XmlNode dim2CodElem = doc.CreateElement("codelem");
                dim2CodElem.InnerText = Cliente.Criterio2_SUBZONA;
                dim2.AppendChild(dim2CodElem);

                XmlNode dim2CodCrit = doc.CreateElement("codcrit");
                dim2CodCrit.InnerText = "1002";
                dim2.AppendChild(dim2CodCrit);

                XmlNode lrcompNode = doc.CreateElement("lrcomp");
                lrcompNode.InnerText = Cliente.Lrcomp.ToString();
                clienteNode.AppendChild(lrcompNode);

                XmlNode viaspNode = doc.CreateElement("viasp");
                clienteNode.AppendChild(viaspNode);

                XmlNode codvp = doc.CreateElement("codvp");
                codvp.InnerText = Cliente.Viasp;
                viaspNode.AppendChild(codvp);

                XmlNode lsegcreditoNode = doc.CreateElement("lsegcredito");
                lsegcreditoNode.InnerText = Cliente.Lsegcredito.ToString().Replace(",", "."); ;
                clienteNode.AppendChild(lsegcreditoNode);

                XmlNode fchcadsegcredNode = doc.CreateElement("fchcadsegcred");
                fchcadsegcredNode.InnerText = Cliente.Fchcadsegcred.ToString("yyyy-MM-dd");
                clienteNode.AppendChild(fchcadsegcredNode);

                XmlNode tipoentidadNode = doc.CreateElement("tipoentidad");
                tipoentidadNode.InnerText = Cliente.Tipoentidad;
                clienteNode.AppendChild(tipoentidadNode);

                XmlNode sectorNode = doc.CreateElement("sector");
                sectorNode.InnerText = Cliente.Sector;
                clienteNode.AppendChild(sectorNode);

                XmlNode fchaltaerpNode = doc.CreateElement("fchaltaerp");
                fchaltaerpNode.InnerText = Cliente.Fchaltaerp.ToString("yyyy-MM-dd");
                clienteNode.AppendChild(fchaltaerpNode);

                XmlNode fchinitactNode = doc.CreateElement("fchinitact");
                fchinitactNode.InnerText = Cliente.Fchinitact.ToString("yyyy-MM-dd");
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

                //XmlNode tieneavalNode = doc.CreateElement("tieneaval");
                //tieneavalNode.InnerText = Cliente.TieneAval;
                //clienteNode.AppendChild(tieneavalNode);

                //XmlNode tipoavalNode = doc.CreateElement("tipoaval");
                //tipoavalNode.InnerText = Cliente.TipoAval;
                //clienteNode.AppendChild(tipoavalNode);
            }
            SavingXMLFile(doc, "clientes");
        }

        private void GenerateXMLFormasPagos(List<FormaPago> formaPagoList)
        {
            XmlElement viaspagoNode;
            XmlDocument doc = CreateXMLHeaders("viaspago", out viaspagoNode);
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
                gencartNode.InnerText = formaPago.Gencart.ToString();
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
            SavingXMLFile(doc, "viaspago");
        }

        private void GenerateXMLContactos(List<Contacto> contactoList)
        {
            XmlElement contactosNode;
            XmlDocument doc = CreateXMLHeaders("contactos", out contactosNode);
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
                tcontactoNode.InnerText = contacto.Tcontacto.ToString();
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
            SavingXMLFile(doc, "contactos");
        }

        private void GenerateXMLDirecciones(List<Direccion> direccionesList)
        {

            try
            {
                XmlElement direccionNode;
                XmlDocument doc = CreateXMLHeaders("direcciones", out direccionNode);
                foreach (Direccion direccion in direccionesList)
                {
                    XmlNode socNode = doc.CreateElement("direccion");
                    direccionNode.AppendChild(socNode);

                    XmlNode idNode = doc.CreateElement("codcliente");
                    idNode.InnerText = direccion.CodigoCliente;
                    socNode.AppendChild(idNode);

                    XmlNode codNode = doc.CreateElement("coddireccion");
                    codNode.InnerText = direccion.CodigoDireccion;
                    socNode.AppendChild(codNode);

                    XmlNode tipoDireccionNode = doc.CreateElement("tdireccion");
                    tipoDireccionNode.InnerText = direccion.TipoDireccion.ToString();
                    socNode.AppendChild(tipoDireccionNode);

                    XmlNode ciudadNode = doc.CreateElement("ciudad");
                    ciudadNode.InnerText = direccion.Ciudad;
                    socNode.AppendChild(ciudadNode);

                    XmlNode providenciaNode = doc.CreateElement("prov");
                    providenciaNode.InnerText = direccion.Provincia;
                    socNode.AppendChild(providenciaNode);

                    XmlNode codigoPostalNode = doc.CreateElement("cp");
                    codigoPostalNode.InnerText = direccion.CodigoPostal;
                    socNode.AppendChild(codigoPostalNode);

                    XmlNode paisNode = doc.CreateElement("pais");
                    paisNode.InnerText = direccion.Pais;
                    socNode.AppendChild(paisNode);
                }
                SavingXMLFile(doc, "direcciones");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }

        private void GenerateXMLCriteriosClasificacion(List<ClasificacionCriterio> creteriosList)
        {
            XmlElement criteriosNode;
            XmlDocument doc = CreateXMLHeaders("clasifcriterios", out criteriosNode);
            foreach (ClasificacionCriterio criterio in creteriosList)
            {
                XmlNode socNode = doc.CreateElement("critelem");
                criteriosNode.AppendChild(socNode);

                XmlNode idNode = doc.CreateElement("id");
                idNode.InnerText = criterio.Id;
                socNode.AppendChild(idNode);

                XmlNode codNode = doc.CreateElement("cod");
                codNode.InnerText = criterio.Codigo;
                socNode.AppendChild(codNode);

                XmlNode descNode = doc.CreateElement("desc");
                descNode.InnerText = criterio.Descripcion;
                socNode.AppendChild(descNode);
            }
            SavingXMLFile(doc, "clasifcriterios");
        }

        private void GenerateXMLPartidasAbiertas(List<PartidaAbierta> partidaAbiertaList)
        {
            XmlElement partidaAbiertaNode;
            XmlDocument doc = CreateXMLHeaders("partabiertas", out partidaAbiertaNode);
            foreach (PartidaAbierta partidaAbierta in partidaAbiertaList)
            {
                XmlNode partNode = doc.CreateElement("part");
                partidaAbiertaNode.AppendChild(partNode);

                XmlNode codcliNode = doc.CreateElement("codcli");
                codcliNode.InnerText = partidaAbierta.Codcli;
                partNode.AppendChild(codcliNode);

                XmlNode tdocNode = doc.CreateElement("tdoc");
                tdocNode.InnerText = partidaAbierta.Tdoc;
                partNode.AppendChild(tdocNode);

                XmlNode ndocNode = doc.CreateElement("ndoc");
                ndocNode.InnerText = partidaAbierta.Ndoc;
                partNode.AppendChild(ndocNode);

                XmlNode nvctoNode = doc.CreateElement("nvcto");
                nvctoNode.InnerText = partidaAbierta.Nvcto;
                partNode.AppendChild(nvctoNode);

                XmlNode fchemiNode = doc.CreateElement("fchemi");
                fchemiNode.InnerText = partidaAbierta.Fchemi.ToString("yyyy-MM-dd");
                partNode.AppendChild(fchemiNode);

                XmlNode fchvctoNode = doc.CreateElement("fchvcto");
                fchvctoNode.InnerText = partidaAbierta.Fchvcto.ToString("yyyy-MM-dd");
                partNode.AppendChild(fchvctoNode);

                XmlNode importeNode = doc.CreateElement("importe");
                importeNode.InnerText = partidaAbierta.Importe.ToString().Replace(",",".");
                partNode.AppendChild(importeNode);

                XmlNode estadoNode = doc.CreateElement("estado");
                estadoNode.InnerText = partidaAbierta.Estado.ToString();
                partNode.AppendChild(estadoNode);

                XmlNode dotadaNode = doc.CreateElement("dotada");
                dotadaNode.InnerText = partidaAbierta.Dotada.ToString();
                partNode.AppendChild(dotadaNode);

                XmlNode codvpNode = doc.CreateElement("codvp");
                codvpNode.InnerText = partidaAbierta.Codvp;
                partNode.AppendChild(codvpNode);

                XmlNode codcondpNode = doc.CreateElement("codcondp");
                codcondpNode.InnerText = partidaAbierta.Codcondp;
                partNode.AppendChild(codcondpNode);

                XmlNode codmondocNode = doc.CreateElement("codmondoc");
                codmondocNode.InnerText = partidaAbierta.Codmondoc;
                partNode.AppendChild(codmondocNode);

                XmlNode impmondocNode = doc.CreateElement("impmondoc");
                impmondocNode.InnerText = partidaAbierta.Impmondoc;
                partNode.AppendChild(impmondocNode);

                XmlNode ind1Node = doc.CreateElement("ind1");
                ind1Node.InnerText = partidaAbierta.Ind1;
                partNode.AppendChild(ind1Node);

                XmlNode ind2Node = doc.CreateElement("ind2");
                ind2Node.InnerText = partidaAbierta.Ind2;
                partNode.AppendChild(ind2Node);

                XmlNode ind3Node = doc.CreateElement("ind3");
                ind3Node.InnerText = partidaAbierta.Ind3;
                partNode.AppendChild(ind3Node);

                XmlNode ind4Node = doc.CreateElement("ind4");
                ind4Node.InnerText = partidaAbierta.Ind4;
                partNode.AppendChild(ind4Node);

                XmlNode ind5Node = doc.CreateElement("ind5");
                ind5Node.InnerText = partidaAbierta.Ind5;
                partNode.AppendChild(ind5Node);

                XmlNode ind6Node = doc.CreateElement("ind6");
                ind6Node.InnerText = partidaAbierta.Ind6;
                partNode.AppendChild(ind6Node);

                XmlNode ind7Node = doc.CreateElement("ind7");
                ind7Node.InnerText = partidaAbierta.Ind7;
                partNode.AppendChild(ind7Node);

                XmlNode ind8Node = doc.CreateElement("ind8");
                ind8Node.InnerText = partidaAbierta.Ind8;
                partNode.AppendChild(ind8Node);

                XmlNode ind9Node = doc.CreateElement("ind9");
                ind9Node.InnerText = partidaAbierta.Ind9;
                partNode.AppendChild(ind9Node);

                XmlNode campoidNode = doc.CreateElement("campoid");
                campoidNode.InnerText = partidaAbierta.Campoid;
                partNode.AppendChild(campoidNode);

                XmlNode codejercicioNode = doc.CreateElement("codejercicio");
                codejercicioNode.InnerText = partidaAbierta.Codejercicio;
                partNode.AppendChild(codejercicioNode);

                XmlNode numdocorigenNode = doc.CreateElement("numdocorigen");
                numdocorigenNode.InnerText = partidaAbierta.Numdocorigen;
                partNode.AppendChild(numdocorigenNode);
            }
            SavingXMLFile(doc, "partabiertas");
        }

        private XmlDocument CreateXMLHeaders(string xmlFileName, out XmlElement Node)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            Node = doc.CreateElement(xmlFileName);

            string xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XmlSchema schema = new XmlSchema();
            schema.Namespaces.Add("xsi", xsi);
            doc.Schemas.Add(schema);

            Node.SetAttribute("xmlns:xsi", xsi);

            XmlAttribute metadata2 = doc.CreateAttribute("noNamespaceSchemaLocation", xsi);
            metadata2.Value = xmlFileName + ".xsd";
            Node.Attributes.Append(metadata2);

            doc.AppendChild(Node);
            return doc;
        }

        private void SavingXMLFile(XmlDocument xmlDoc, string xmlFileName)
        {
            string directory = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(directory + @"\XML");
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            XmlWriter writer = XmlWriter.Create(directory + @"\XML\"+ xmlFileName + ".xml", settings);
            xmlDoc.Save(writer);
            writer.Close();
        }

        #endregion
    }
}
