using APIDTERest.Models;
using APIDTERest.wsRefSAP;
using System;
using System.IO;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace APIDTERest.Controllers
{
    public class RecepcionDTEController : ApiController
    {
        public Retorno Post([FromBody] RecepcionDocumento value)
        {
            Retorno result = new Retorno();
            bool resultado = true;

            if (!Utils.validarRut(value.ID.RUT_EMISOR))
            {
                resultado = false;
            }

            if (!Utils.validarRut(value.ID.RUT_RECEPTOR))
            {
                resultado = false;
            }

            if (!Utils.validarNumero(value.ID.TIPO_DTE))
            {
                resultado = false;
            }

            if (!Utils.validarNumero(value.ID.FOLIO))
            {
                resultado = false;
            }

            if (value.URI == "")
            {
                resultado = false;
            }

            if (value.XML_DTE == "")
            {
                resultado = false;
            }

            if (value.PDF != null || value.PDF.Length != 0)
            {
                resultado = true;
            }

            if (resultado)
            {
                //llamamos a SAP
                Z_BNMC_MM_RECEPCION_DTE_ACEPTAClient servicio = new Z_BNMC_MM_RECEPCION_DTE_ACEPTAClient();
                ZBnmcMmRecepcionDteAcepta msj = new ZBnmcMmRecepcionDteAcepta();
                //decodificamos XML interno 
                String DTE = Utils.decoderBase64(value.XML_DTE);
                Console.WriteLine(DTE);
                XmlDocument xdoc = new XmlDocument();

                xdoc.LoadXml(DTE);
                msj.IFchrecep = xdoc.GetElementsByTagName("TmstFirma").Item(0).InnerText.Substring(0,10);
                msj.IActeco = xdoc.GetElementsByTagName("Acteco").Item(0).InnerText;
                msj.ICiudadrecep = xdoc.GetElementsByTagName("CiudadRecep").Item(0).InnerText;
                msj.ICmnaorigen = xdoc.GetElementsByTagName("CmnaOrigen").Item(0).InnerText;
                msj.ICmnarecep = xdoc.GetElementsByTagName("CmnaRecep").Item(0).InnerText;
                msj.ICuidadorigen = xdoc.GetElementsByTagName("CiudadOrigen").Item(0).InnerText;
                msj.IDirrecep = xdoc.GetElementsByTagName("DirRecep").Item(0).InnerText;
                msj.IFchemis = xdoc.GetElementsByTagName("FchEmis").Item(0).InnerText;
                msj.IFolio = xdoc.GetElementsByTagName("Folio").Item(0).InnerText;
                msj.IGiroemis = xdoc.GetElementsByTagName("GiroEmis").Item(0).InnerText;
                msj.IGirorecep = xdoc.GetElementsByTagName("GiroRecep").Item(0).InnerText;
                msj.IIva = xdoc.GetElementsByTagName("IVA").Item(0).InnerText;
                msj.IMntexe = xdoc.GetElementsByTagName("MntExe").Item(0).InnerText;
                msj.IMntneto = xdoc.GetElementsByTagName("MntNeto").Item(0).InnerText;
                msj.IMnttotal = xdoc.GetElementsByTagName("MntTotal").Item(0).InnerText;
                msj.IMontoimp = xdoc.GetElementsByTagName("MontoImp").Item(0).InnerText;
                msj.IRutemisor = xdoc.GetElementsByTagName("RUTEmisor").Item(0).InnerText;
                msj.IRutrecep = xdoc.GetElementsByTagName("RUTRecep").Item(0).InnerText;
                msj.IRznsoc = xdoc.GetElementsByTagName("RznSoc").Item(0).InnerText;
                msj.IRznsocrecep = xdoc.GetElementsByTagName("RznSocRecep").Item(0).InnerText;
                msj.ITasaimp = xdoc.GetElementsByTagName("TasaImp").Item(0).InnerText.Substring(0,3);
                msj.ITasaiva = xdoc.GetElementsByTagName("TasaIVA").Item(0).InnerText;
                msj.ITipodte = xdoc.GetElementsByTagName("TipoDTE").Item(0).InnerText;
                msj.ITipoimp = xdoc.GetElementsByTagName("TipoImp").Item(0).InnerText;
                msj.IUri = value.URI;
                XmlNodeList detalle = xdoc.GetElementsByTagName("Detalle");
                ZebmncDetalleDte[] zdet = new ZebmncDetalleDte[detalle.Count];
                int i = 0;
                foreach (XmlElement nodo in detalle)
                {
                    ZebmncDetalleDte linea = new ZebmncDetalleDte();
                    linea.Codimpadic=nodo.GetElementsByTagName("CodImpAdic").Item(0).InnerText;

                    linea.Nrolindet =nodo.GetElementsByTagName("NroLinDet").Item(0).InnerText;
                    linea.Tpocodigo = nodo.GetElementsByTagName("TpoCodigo").Item(0).InnerText;
                    linea.Vlrcodigo = nodo.GetElementsByTagName("VlrCodigo").Item(0).InnerText;
                    linea.Indagente = nodo.GetElementsByTagName("IndAgente").Item(0).InnerText;
                    linea.Nmbitem = nodo.GetElementsByTagName("NmbItem").Item(0).InnerText;
                    linea.Qtyitem = nodo.GetElementsByTagName("QtyItem").Item(0).InnerText;
                    linea.Unmditem = nodo.GetElementsByTagName("UnmdItem").Item(0).InnerText;
                    linea.Prcitem = nodo.GetElementsByTagName("PrcItem").Item(0).InnerText;
                    linea.Montoitem = nodo.GetElementsByTagName("MontoItem").Item(0).InnerText;
                    zdet[i] = linea;
                    i++;

                }
                msj.TDetalle = zdet;

                XmlNodeList referencias = xdoc.GetElementsByTagName("Referencia");
                ZbmncDocreferencia[] refs = new ZbmncDocreferencia[referencias.Count];
                i = 0;
                foreach (XmlElement nodo in referencias)
                {

                    ZbmncDocreferencia docRef = new ZbmncDocreferencia();
                    docRef.CodigoRef= nodo.GetElementsByTagName("TpoDocRef").Item(0).InnerText;
                    docRef.FolioRef = nodo.GetElementsByTagName("FolioRef").Item(0).InnerText;
                    refs[i] = docRef;
                    i++;
                }
                msj.TDocref = refs;
                    try
                {
                    
                    String user = System.Web.Configuration.WebConfigurationManager.AppSettings["userSAP"];
                    String pass =
                    System.Web.Configuration.WebConfigurationManager.AppSettings["passSAP"];
                    servicio.ClientCredentials.UserName.UserName = user;
                    servicio.ClientCredentials.UserName.Password = pass;
                     ZBnmcMmRecepcionDteAceptaResponse response = servicio.ZBnmcMmRecepcionDteAcepta(msj);
                    //guardamos el pdf en la ruta que nos dice SAP

                    String pathPDF = response.ERutaPdf;
                    String nombreArchivo = pathPDF + value.ID.RUT_EMISOR + value.ID.TIPO_DTE + value.ID.FOLIO + ".pdf";
                    
                    FileStream stream =
                    new FileStream(@nombreArchivo, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                    writer.Write(value.PDF, 0, value.PDF.Length);
                    writer.Close();

                    result.Cod_Respuesta = response.ECoderror;
                    result.Desc_Respuesta = response.EMsgerror; 
                        //"documento  recepcionado";
                }
                catch(Exception e)
                {
                    result.Cod_Respuesta = "0";
                    result.Desc_Respuesta = "documento no recepcionado: error " + e.ToString(); ;
                }
                
            }
            else
            {
                result.Cod_Respuesta = "0";
                result.Desc_Respuesta = "documento no recepcionado";
            }
           

           
            

            

            return result;
        }
    }
}
