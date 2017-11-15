using APIDTERest.Models;
using APIDTERest.wsRefSAP;
using System;

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
                msj.IActeco = xdoc.GetElementsByTagName("Acteco").ToString();
                msj.ICiudadrecep = xdoc.GetElementsByTagName("CiudadRecep").ToString();
                msj.ICmnaorigen = xdoc.GetElementsByTagName("CmnaOrigen").ToString();
                msj.ICmnarecep = xdoc.GetElementsByTagName("CmnaRecep").ToString();
                msj.ICuidadorigen = xdoc.GetElementsByTagName("CiudadOrigen").ToString();
                msj.IDirrecep = xdoc.GetElementsByTagName("DirRecep").ToString();
                msj.IFchemis = xdoc.GetElementsByTagName("FchEmis").ToString();
                msj.IFolio = xdoc.GetElementsByTagName("Folio").ToString();
                msj.IGiroemis = xdoc.GetElementsByTagName("GiroEmis").ToString();
                msj.IGirorecep = xdoc.GetElementsByTagName("GiroRecep").ToString();
                msj.IIva = xdoc.GetElementsByTagName("IVA").ToString();
                msj.IMntexe = xdoc.GetElementsByTagName("MntExe").ToString();
                msj.IMntneto = xdoc.GetElementsByTagName("MntNeto").ToString();
                msj.IMnttotal = xdoc.GetElementsByTagName("MntTotal").ToString();
                msj.IMontoimp = xdoc.GetElementsByTagName("MontoImp").ToString();
                msj.IRutemisor = xdoc.GetElementsByTagName("RUTEmisor").ToString();
                msj.IRutrecep = xdoc.GetElementsByTagName("RUTRecep").ToString();
                msj.IRznsoc = xdoc.GetElementsByTagName("RznSoc").ToString();
                msj.IRznsocrecep = xdoc.GetElementsByTagName("RznSocRecep").ToString();
                msj.ITasaimp = xdoc.GetElementsByTagName("TasaImp").ToString();
                msj.ITasaiva = xdoc.GetElementsByTagName("TasaIVA").ToString();
                msj.ITipodte = xdoc.GetElementsByTagName("TipoDTE").ToString();
                msj.ITipoimp = xdoc.GetElementsByTagName("TipoImp").ToString();
                msj.IUri = value.URI;
                XmlNodeList detalle = xdoc.GetElementsByTagName("Detalle");
                ZebmncDetalleDte[] zdet = new ZebmncDetalleDte[detalle.Count];
                int i = 0;
                foreach (XmlElement nodo in detalle)
                {
                    ZebmncDetalleDte linea = new ZebmncDetalleDte();
                    linea.Codimpadic=nodo.GetElementsByTagName("CodImpAdic").ToString();

                    linea.Nrolindet =nodo.GetElementsByTagName("NroLinDet").ToString();
                    linea.Tpocodigo = nodo.GetElementsByTagName("TpoCodigo").ToString();
                    linea.Vlrcodigo = nodo.GetElementsByTagName("VlrCodigo").ToString();
                    linea.Indagente = nodo.GetElementsByTagName("IndAgente").ToString();
                    linea.Nmbitem = nodo.GetElementsByTagName("NmbItem").ToString();
                    linea.Qtyitem = nodo.GetElementsByTagName("QtyItem").ToString();
                    linea.Unmditem = nodo.GetElementsByTagName("UnmdItem").ToString();
                    linea.Prcitem = nodo.GetElementsByTagName("PrcItem").ToString();
                    linea.Montoitem = nodo.GetElementsByTagName("MontoItem").ToString();
                    zdet[i] = linea;
                    i++;

                }
                msj.TDetalle = zdet;
                try
                {
                    ZBnmcMmRecepcionDteAceptaResponse response = servicio.ZBnmcMmRecepcionDteAcepta(msj);
                    result.Cod_Respuesta = response.ECoderror;
                    result.Desc_Respuesta = response.EMsgerror; //"documento  recepcionado";
                }
                catch(Exception e)
                {
                    result.Cod_Respuesta = "0";
                    result.Desc_Respuesta = "documento no recepcionado";
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
