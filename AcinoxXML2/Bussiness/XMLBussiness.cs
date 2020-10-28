using AcinoxXML2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public List<Sociedad> generateEntitySociedad(MySqlDataReader rdr)
        {
            List<Sociedad> sociedadList = mapingSociedades(rdr);
            GenerateXMLSociedades(sociedadList);
            return sociedadList;
        }
        public  void generateEntity(string typeOfQuery, MySqlDataReader rdr, string codeEntity)
        {
            switch (typeOfQuery)
            {
                case "sociedades":
                    List<Sociedad> sociedadList = mapingSociedades(rdr);
                    GenerateXMLSociedades(sociedadList);
                    break;
                case "clientes":
                    List<Cliente> clientesList = mapingClientes(rdr);
                    GenerateXMLClientes(clientesList, codeEntity);
                    break;
                case "formasPago":
                    List<FormaPago> formaPagoList = mapingFormasPagos();
                    GenerateXMLFormasPagos(formaPagoList, codeEntity);
                    break;
                case "contactos":
                    List<Contacto> contactoList = mapingContactos(rdr);
                    GenerateXMLContactos(contactoList, codeEntity);
                    break;
                case "clasifcriterios":
                    List<ClasificacionCriterio> creteriosList = mapingCriterios(rdr);
                    GenerateXMLCriteriosClasificacion(creteriosList, codeEntity);
                    break;
                case "direcciones":
                    List<Direccion> direccionesList = mapingDirecciones(rdr);
                    GenerateXMLDirecciones(direccionesList, codeEntity);
                    break;
                case "condicionesPago":
                    List<CondicionPago> condicionesPagoList = MapingCondicionesPago(rdr);
                    GenerateXMLCondicionesPago(condicionesPagoList, codeEntity);
                    break;
                case "partabiertas":
                    List<PartidaAbierta> PartidaAbiertaList = mapingPartidasAbiertas(rdr);
                    GenerateXMLPartidasAbiertas(PartidaAbiertaList, codeEntity);
                    break;
                case "ventas":
                    List<Venta> VentaList = mapingVenta(rdr);
                    GenerateXMLVentas(VentaList, codeEntity);
                    break;
                default:
                    break;
            }
        }

        #region mapping
        private List<CondicionPago> MapingCondicionesPago(MySqlDataReader rdr)
        {
            List<CondicionPago> condicionPagoList = new List<CondicionPago>();
            #region condiciones de pago
            CondicionPago condicion1 = new CondicionPago
            {
                Codigo = "1",
                Descripcion = "Sin plazos"
            };
            CondicionPago condicion2 = new CondicionPago
            {
                Codigo = "2",
                Descripcion = "Recibos a 30 días",
                Plazos = new List<PlazoCondicionPago> { 
                    GenerarPlazo("Plazo 1", 30, Convert.ToDecimal(100.0),"1",string.Empty)
                }
            };
            CondicionPago condicion3 = new CondicionPago
            {
                Codigo = "3",
                Descripcion = "Recibos a 30, 60 y 90 días",
                Plazos = new List<PlazoCondicionPago> { 
                    GenerarPlazo("Plazo 1", 30, Convert.ToDecimal(33.33),"1","1"),
                    GenerarPlazo("Plazo 2", 90, Convert.ToDecimal(33.33),"2","1"),
                    GenerarPlazo("Plazo 3", 120, Convert.ToDecimal(33.33),"3","1")
                }
            };
            CondicionPago condicion4 = new CondicionPago
            {
                Codigo = "4",
                Descripcion = "Pagaré a 30 días",
                Plazos = new List<PlazoCondicionPago> {
                    GenerarPlazo("Plazo 1", 30, Convert.ToDecimal(100.0),"PLAZO0","2")
                }
            };
            CondicionPago condicion5 = new CondicionPago
            {
                Codigo = "5",
                Descripcion = "Transferencia a 30 días",
                Plazos = new List<PlazoCondicionPago> {
                    GenerarPlazo("Plazo 1", 30, Convert.ToDecimal(100.0),"1","14")
                }
            };

            condicionPagoList.Add(condicion1);
            condicionPagoList.Add(condicion2);
            condicionPagoList.Add(condicion3);
            condicionPagoList.Add(condicion4);
            condicionPagoList.Add(condicion5);
            #endregion
            return condicionPagoList;
        }

        private static PlazoCondicionPago GenerarPlazo(string descripcion, int dias, decimal porcentaje, string codigoPlazo, string viaPago)
        {
            return new PlazoCondicionPago
            {
                Descripcion = descripcion,
                Dias = dias,
                Porcentaje = porcentaje,
                CodigoPlazo = codigoPlazo,
                CodigoViaPago = viaPago
            };
        }

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
                                                    ? new DateTime(1900, 1, 1)
                                                    : new DateTime(Convert.ToInt32(rdr[12].ToString().Substring(0, 4)),
                                                                   Convert.ToInt32(rdr[12].ToString().Substring(4, 2)),
                                                                   Convert.ToInt32(rdr[12].ToString().Substring(6, 2))));
                cliente.Tipoentidad = rdr[13].ToString();
                cliente.Sector = rdr[14].ToString();
                cliente.Fchaltaerp = (rdr[15] == DBNull.Value || string.IsNullOrEmpty(rdr[15].ToString()) 
                                                    ? new DateTime(1900, 1, 1) 
                                                    : new DateTime(Convert.ToInt32(rdr[15].ToString().Substring(0,4)), 
                                                                   Convert.ToInt32(rdr[15].ToString().Substring(4,2)),
                                                                   Convert.ToInt32(rdr[15].ToString().Substring(6,2))) );
                cliente.Fchinitact = (rdr[16] == DBNull.Value || string.IsNullOrEmpty(rdr[16].ToString())
                                                    ? new DateTime(1900, 1, 1)
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
                                                    ? new DateTime(1900, 1, 1)
                                                    : new DateTime(Convert.ToInt32(rdr[4].ToString().Substring(0, 4)),
                                                                   Convert.ToInt32(rdr[4].ToString().Substring(4, 2)),
                                                                   Convert.ToInt32(rdr[4].ToString().Substring(6, 2))));
                partidaAbierta.Fchvcto = (rdr[5] == DBNull.Value || string.IsNullOrEmpty(rdr[5].ToString())
                                                    ? new DateTime(1900, 1, 1)
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

        private List<Venta> mapingVenta(MySqlDataReader rdr)
        {
            List<Venta> ventaList = new List<Venta>();
            while (rdr.Read())
            {
                Venta venta = new Venta();
                venta.CodCli = rdr[0].ToString();
                venta.Anio = Convert.ToInt32(rdr[1].ToString());
                venta.Mes = Convert.ToUInt32(rdr[2].ToString());
                venta.Importe = string.IsNullOrEmpty(rdr[3].ToString()) ? 0 : Convert.ToDecimal(rdr[3].ToString());
                ventaList.Add(venta);
            }
            rdr.Close();
            return ventaList;
        }

        #endregion

        #region GenerateXML
        private void GenerateXMLCondicionesPago(List<CondicionPago> condicionesPagoList, string codeEntity)
        {
            XmlElement nodoPrincipal;
            XmlDocument doc = CreateXMLHeaders("condspago", out nodoPrincipal, "cndpago");
            foreach (CondicionPago condicion in condicionesPagoList)
            {
                XmlNode condNodo = doc.CreateElement("cond");
                agregarNodo(condNodo, doc.CreateElement("cod"), condicion.Codigo);
                agregarNodo(condNodo, doc.CreateElement("desc"), condicion.Descripcion);
                XmlNode plazosNodo = doc.CreateElement("plazos");
                condNodo.AppendChild(plazosNodo);
                if (condicion.Plazos != null)
                {
                    foreach (PlazoCondicionPago plazoc in condicion.Plazos)
                    {
                        XmlNode plazo = doc.CreateElement("plazo");
                        agregarNodo(plazo, doc.CreateElement("dsc"), plazoc.Descripcion);
                        agregarNodo(plazo, doc.CreateElement("dias"), plazoc.Dias.ToString());
                        agregarNodo(plazo, doc.CreateElement("porc"), plazoc.Porcentaje.ToString().Replace(",", "."));
                        agregarNodo(plazo, doc.CreateElement("codvia"), plazoc.CodigoViaPago);
                        agregarNodo(plazo, doc.CreateElement("codp"), plazoc.CodigoPlazo);

                        plazosNodo.AppendChild(plazo);
                    }
                }

                nodoPrincipal.AppendChild(condNodo);
            }

            SavingXMLFile(doc, "cndpago", codeEntity);
        }

        private void GenerateXMLSociedades(List<Sociedad> sociedadList)
        {
            XmlElement sociedadesNode;
            XmlDocument doc = CreateXMLHeaders("sociedades", out sociedadesNode);
            foreach (Sociedad sociedad in sociedadList)
            {
                XmlNode socNode = doc.CreateElement("soc");
                sociedadesNode.AppendChild(socNode);

                agregarNodo(socNode, doc.CreateElement("cod"), sociedad.Cod);
                agregarNodo(socNode, doc.CreateElement("razons"), sociedad.Cod);
                agregarNodo(socNode, doc.CreateElement("nif"), sociedad.Cod);
                agregarNodo(socNode, doc.CreateElement("codmoneda"), sociedad.Cod);
            }
            SavingXMLFile(doc, "sociedades", string.Empty);
        }

        private void GenerateXMLClientes(List<Cliente> clienteList, string codeEntity)
        {
            XmlElement clientesNode;
            XmlDocument doc = CreateXMLHeaders("clientes", out clientesNode);
            foreach (Cliente Cliente in clienteList)
            {
                XmlNode clienteNode = doc.CreateElement("cliente");
                clientesNode.AppendChild(clienteNode);

                agregarNodo(clienteNode, doc.CreateElement("cod"), Cliente.Cod);
                agregarNodo(clienteNode, doc.CreateElement("nif"), Cliente.Nif);
                agregarNodo(clienteNode, doc.CreateElement("razons"), Cliente.Razons);
                agregarNodo(clienteNode, doc.CreateElement("codcondp"), Cliente.Codcondp);
                agregarNodo(clienteNode, doc.CreateElement("limitrg"), Cliente.Limitrg.ToString().Replace(",", "."));

                XmlNode dims = doc.CreateElement("dims");
                clienteNode.AppendChild(dims);

                XmlNode dim = doc.CreateElement("dim");
                dims.AppendChild(dim);

                agregarNodo(dim, doc.CreateElement("orden"), "1");
                agregarNodo(dim, doc.CreateElement("codelem"), Cliente.Criterio1_ZONA);
                agregarNodo(dim, doc.CreateElement("codcrit"), "1001");

                XmlNode dim2 = doc.CreateElement("dim");
                dims.AppendChild(dim2);

                agregarNodo(dim2, doc.CreateElement("orden"), "2");
                agregarNodo(dim2, doc.CreateElement("codelem"), Cliente.Criterio2_SUBZONA);
                agregarNodo(dim2, doc.CreateElement("codcrit"), "1002");
;
                agregarNodo(clienteNode, doc.CreateElement("lrcomp"), Cliente.Lrcomp.ToString());

                XmlNode viaspNode = doc.CreateElement("viasp");
                clienteNode.AppendChild(viaspNode);

                agregarNodo(viaspNode, doc.CreateElement("codvp"), Cliente.Viasp);

                agregarNodo(clienteNode, doc.CreateElement("lsegcredito"), Cliente.Lsegcredito.ToString().Replace(",", "."));
                agregarNodo(clienteNode, doc.CreateElement("fchcadsegcred"), Cliente.Fchcadsegcred.ToString("yyyy-MM-dd"));
                agregarNodo(clienteNode, doc.CreateElement("tipoentidad"), Cliente.Tipoentidad);
                agregarNodo(clienteNode, doc.CreateElement("sector"), Cliente.Sector);
                agregarNodo(clienteNode, doc.CreateElement("fchaltaerp"), Cliente.Fchaltaerp.ToString("yyyy-MM-dd"));
                agregarNodo(clienteNode, doc.CreateElement("fchinitact"), Cliente.Fchinitact.ToString("yyyy-MM-dd"));
                agregarNodo(clienteNode, doc.CreateElement("ind1"), Cliente.Ind1);
                agregarNodo(clienteNode, doc.CreateElement("ind2"), Cliente.Ind2);
                agregarNodo(clienteNode, doc.CreateElement("ind3"), Cliente.Ind3);
                agregarNodo(clienteNode, doc.CreateElement("ind4"), Cliente.Ind4);
                agregarNodo(clienteNode, doc.CreateElement("ind5"), Cliente.Ind5);
                agregarNodo(clienteNode, doc.CreateElement("ind6"), Cliente.Ind6);
                agregarNodo(clienteNode, doc.CreateElement("ind7"), Cliente.Ind7);
                agregarNodo(clienteNode, doc.CreateElement("ind8"), Cliente.Ind8);
                agregarNodo(clienteNode, doc.CreateElement("ind9"), Cliente.Ind9);

            }
            SavingXMLFile(doc, "clientes", codeEntity);
        }

        private void GenerateXMLFormasPagos(List<FormaPago> formaPagoList, string codeEntity)
        {
            XmlElement viaspagoNode;
            XmlDocument doc = CreateXMLHeaders("viaspago", out viaspagoNode);
            foreach (FormaPago formaPago in formaPagoList)
            {
                XmlNode viaNode = doc.CreateElement("via");
                viaspagoNode.AppendChild(viaNode);

                agregarNodo(viaNode, doc.CreateElement("cod"), formaPago.Cod);
                agregarNodo(viaNode, doc.CreateElement("desc"), formaPago.Desc);
                agregarNodo(viaNode, doc.CreateElement("gencart"), formaPago.Gencart.ToString());
                agregarNodo(viaNode, doc.CreateElement("ind1"), formaPago.Ind1);
                agregarNodo(viaNode, doc.CreateElement("ind2"), formaPago.Ind2);
                agregarNodo(viaNode, doc.CreateElement("numdias"), formaPago.Numdias);
            }
            SavingXMLFile(doc, "viaspago", codeEntity);
        }

        private void GenerateXMLContactos(List<Contacto> contactoList, string codeEntity)
        {
            XmlElement contactosNode;
            XmlDocument doc = CreateXMLHeaders("contactos", out contactosNode);
            foreach (Contacto contacto in contactoList)
            {
                XmlNode contactoNode = doc.CreateElement("contacto");
                contactosNode.AppendChild(contactoNode);

                agregarNodo(contactoNode, doc.CreateElement("codcliente"), contacto.Codcliente);
                agregarNodo(contactoNode, doc.CreateElement("codcontacto"), contacto.Codcontacto);
                agregarNodo(contactoNode, doc.CreateElement("nombre"), contacto.Nombre);
                agregarNodo(contactoNode, doc.CreateElement("nif"), contacto.Nif);
                agregarNodo(contactoNode, doc.CreateElement("tcontacto"), contacto.Tcontacto.ToString());
                agregarNodo(contactoNode, doc.CreateElement("tlfmovil"), contacto.Tlfmovil);
                agregarNodo(contactoNode, doc.CreateElement("tlffijo"), contacto.Tlffijo);
                agregarNodo(contactoNode, doc.CreateElement("fax"), contacto.Fax);
                agregarNodo(contactoNode, doc.CreateElement("email"), contacto.Email);
                agregarNodo(contactoNode, doc.CreateElement("ind1"), contacto.Ind1);
                agregarNodo(contactoNode, doc.CreateElement("ind2"), contacto.Ind2);
                agregarNodo(contactoNode, doc.CreateElement("ind3"), contacto.Ind3);
            }
            SavingXMLFile(doc, "contactos", codeEntity);
        }

        private void GenerateXMLDirecciones(List<Direccion> direccionesList, string codeEntity)
        {
            try
            {
                XmlElement direccionesNode;
                XmlDocument doc = CreateXMLHeaders("direcciones", out direccionesNode);
                foreach (Direccion direccion in direccionesList)
                {
                    XmlNode direccionNode = doc.CreateElement("direccion");
                    direccionesNode.AppendChild(direccionNode);

                    agregarNodo(direccionNode, doc.CreateElement("codcliente"), direccion.CodigoCliente);
                    agregarNodo(direccionNode, doc.CreateElement("coddireccion"), direccion.CodigoDireccion);
                    agregarNodo(direccionNode, doc.CreateElement("tdireccion"), direccion.TipoDireccion.ToString());
                    agregarNodo(direccionNode, doc.CreateElement("ciudad"), direccion.Ciudad);
                    agregarNodo(direccionNode, doc.CreateElement("prov"), direccion.Provincia);
                    agregarNodo(direccionNode, doc.CreateElement("cp"), direccion.CodigoPostal);
                    agregarNodo(direccionNode, doc.CreateElement("pais"), direccion.Pais);
                }
                SavingXMLFile(doc, "direcciones", codeEntity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }

        private void GenerateXMLCriteriosClasificacion(List<ClasificacionCriterio> creteriosList, string codeEntity)
        {
            XmlElement criteriosNode;
            XmlDocument doc = CreateXMLHeaders("clasifcriterios", out criteriosNode);
            foreach (ClasificacionCriterio criterio in creteriosList)
            {
                XmlNode critelemNode = doc.CreateElement("critelem");
                criteriosNode.AppendChild(critelemNode);

                agregarNodo(critelemNode, doc.CreateElement("id"), criterio.Id);
                agregarNodo(critelemNode, doc.CreateElement("cod"), criterio.Codigo);
                agregarNodo(critelemNode, doc.CreateElement("desc"), criterio.Descripcion);
            }
            SavingXMLFile(doc, "clasifcriterios", codeEntity);
        }

        private void GenerateXMLPartidasAbiertas(List<PartidaAbierta> partidaAbiertaList, string codeEntity)
        {
            XmlElement partidaAbiertaNode;
            XmlDocument doc = CreateXMLHeaders("partabiertas", out partidaAbiertaNode);
            foreach (PartidaAbierta partidaAbierta in partidaAbiertaList)
            {
                XmlNode partNode = doc.CreateElement("part");
                partidaAbiertaNode.AppendChild(partNode);

                agregarNodo(partNode, doc.CreateElement("codcli"), partidaAbierta.Codcli);
                agregarNodo(partNode, doc.CreateElement("tdoc"), partidaAbierta.Tdoc);
                agregarNodo(partNode, doc.CreateElement("ndoc"), partidaAbierta.Ndoc);
                agregarNodo(partNode, doc.CreateElement("nvcto"), partidaAbierta.Nvcto);
                agregarNodo(partNode, doc.CreateElement("fchemi"), partidaAbierta.Fchemi.ToString("yyyy-MM-dd"));
                agregarNodo(partNode, doc.CreateElement("fchvcto"), partidaAbierta.Fchvcto.ToString("yyyy-MM-dd"));
                agregarNodo(partNode, doc.CreateElement("importe"), partidaAbierta.Importe.ToString().Replace(",", "."));
                agregarNodo(partNode, doc.CreateElement("estado"), partidaAbierta.Estado.ToString());
                agregarNodo(partNode, doc.CreateElement("dotada"), partidaAbierta.Dotada.ToString());
                agregarNodo(partNode, doc.CreateElement("codvp"), partidaAbierta.Codvp);
                agregarNodo(partNode, doc.CreateElement("codcondp"), partidaAbierta.Codcondp);
                agregarNodo(partNode, doc.CreateElement("codmondoc"), partidaAbierta.Codmondoc);
                agregarNodo(partNode, doc.CreateElement("impmondoc"), partidaAbierta.Impmondoc);
                agregarNodo(partNode, doc.CreateElement("ind1"), partidaAbierta.Ind1);
                agregarNodo(partNode, doc.CreateElement("ind2"), partidaAbierta.Ind2);
                agregarNodo(partNode, doc.CreateElement("ind3"), partidaAbierta.Ind3);
                agregarNodo(partNode, doc.CreateElement("ind4"), partidaAbierta.Ind4);
                agregarNodo(partNode, doc.CreateElement("ind5"), partidaAbierta.Ind5);
                agregarNodo(partNode, doc.CreateElement("ind6"), partidaAbierta.Ind6);
                agregarNodo(partNode, doc.CreateElement("ind7"), partidaAbierta.Ind7);
                agregarNodo(partNode, doc.CreateElement("ind8"), partidaAbierta.Ind8);
                agregarNodo(partNode, doc.CreateElement("ind9"), partidaAbierta.Ind9);
                agregarNodo(partNode, doc.CreateElement("campoid"), partidaAbierta.Campoid);
                agregarNodo(partNode, doc.CreateElement("codejercicio"), partidaAbierta.Codejercicio);
                agregarNodo(partNode, doc.CreateElement("numdocorigen"), partidaAbierta.Numdocorigen);
                            }
            SavingXMLFile(doc, "partabiertas", codeEntity);
        }

        private void GenerateXMLVentas(List<Venta> ventaList, string codeEntity)
        {
            XmlElement ventasNode;
            XmlDocument doc = CreateXMLHeaders("ventas", out ventasNode);
            foreach (Venta venta in ventaList)
            {
                XmlNode ventaNode = doc.CreateElement("venta");
                ventasNode.AppendChild(ventaNode);

                agregarNodo(ventaNode, doc.CreateElement("codcli"), venta.CodCli);
                agregarNodo(ventaNode, doc.CreateElement("anio"), venta.Anio.ToString());
                agregarNodo(ventaNode, doc.CreateElement("mes"), venta.Mes.ToString());
                agregarNodo(ventaNode, doc.CreateElement("importe"), venta.Importe.ToString().Replace(",", "."));
            }
            SavingXMLFile(doc, "ventas", codeEntity);
        }

        private XmlDocument CreateXMLHeaders(string xmlFileName, out XmlElement Node, string xsdFileName = "")
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
            metadata2.Value = (string.IsNullOrEmpty(xsdFileName))?xmlFileName:xsdFileName + ".xsd";
            Node.Attributes.Append(metadata2);

            doc.AppendChild(Node);
            return doc;
        }

        private void SavingXMLFile(XmlDocument xmlDoc, string xmlFileName, string codeEntity)
        {
            string directory = Directory.GetCurrentDirectory();
            string folder = (string.IsNullOrEmpty(codeEntity))? string.Empty: @"\" + codeEntity;
            Directory.CreateDirectory(directory + @"\XML" + folder);
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            XmlWriter writer = XmlWriter.Create(directory + @"\XML" + folder + @"\" + xmlFileName + ".xml", settings);
            xmlDoc.Save(writer);
            writer.Close();
        }

        private void agregarNodo(XmlNode padre, XmlNode hijo, string valorHijo)
        {
            hijo.InnerText = valorHijo;
            padre.AppendChild(hijo);
        }

        #endregion
    }
}
