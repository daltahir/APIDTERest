using APIDTERest.Models;
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
            string xmlString = "";
            Retorno result = new Retorno();
            bool resultado = true;

            XmlDocument xdoc = new XmlDocument();
            RecepcionDocumento documento = new RecepcionDocumento();
            cabecera Cabecera = new cabecera();

            XDocument xml = XDocument.Parse(xmlString);
            XDocument xmlDTE = new XDocument();
            XDocument xmlPDF = new XDocument();
            XmlSchemaSet esquema = new XmlSchemaSet();
            //byte[] bytesPDF;

            esquema.Add("", @"C:\Users\fdiaz\Source\Repos\APIDTERest\APIDTERest\Resources\xsdDocumento.xsd");

            if (Utils.validarEstructura(esquema, xml))
            {
                xdoc.LoadXml(xmlString);
                XmlNodeList RecepcionDocumento = xdoc.GetElementsByTagName("RecepcionDocumento");
                XmlNodeList lista = ((XmlElement)RecepcionDocumento[0]).GetElementsByTagName("ID");

                XmlNodeList rutEmisor;
                XmlNodeList rutReceptor;
                XmlNodeList tipoDTE;
                XmlNodeList folio;
                XmlNodeList DTE;
                XmlNodeList PDF;
                XmlNodeList URI;

                foreach (XmlElement nodo in lista)
                {
                    rutEmisor = nodo.GetElementsByTagName("RUT_EMISOR");
                    if (Utils.validarRut(rutEmisor[0].InnerText))
                    {
                        Cabecera.RUT_EMISOR = rutEmisor[0].InnerText;
                    }
                    else
                    {
                        resultado = false;
                    }

                    rutReceptor = nodo.GetElementsByTagName("RUT_RECEPTOR");
                    if (Utils.validarRut(rutReceptor[0].InnerText))
                    {
                        Cabecera.RUT_RECEPTOR = rutReceptor[0].InnerText;
                    }
                    else
                    {
                        resultado = false;
                    }

                    tipoDTE = nodo.GetElementsByTagName("TIPO_DTE");
                    if (Utils.validarNumero(tipoDTE[0].InnerText))
                    {
                        Cabecera.TIPO_DTE = tipoDTE[0].InnerText;
                    }
                    else
                    {
                        resultado = false;
                    }

                    folio = nodo.GetElementsByTagName("FOLIO");
                    if (Utils.validarNumero(folio[0].InnerText))
                    {
                        Cabecera.FOLIO = folio[0].InnerText;
                    }
                    else
                    {
                        resultado = false;
                    }
                }

                foreach (XmlElement nodo in RecepcionDocumento)
                {

                    URI = nodo.GetElementsByTagName("URI");
                    if (URI[0].InnerText != "")
                    {
                        documento.URI = URI[0].InnerText;
                    }
                    else
                    {
                        resultado = false;
                    }

                    DTE = nodo.GetElementsByTagName("XML_DTE");
                    if (DTE[0].InnerText != "")
                    {
                        documento.XML_DTE = Utils.decoderBase64(DTE[0].InnerText);
                    }
                    else
                    {
                        resultado = false;
                    }

                    PDF = nodo.GetElementsByTagName("PDF");
                    if (PDF[0].InnerText != "")
                    {
                        //bytesPDF = Convert.FromBase64String(PDF[0].InnerText);
                        documento.PDF = Convert.FromBase64String(PDF[0].InnerText);
                    }
                    else
                    {
                        resultado = false;
                    }
                }
            }

            if(resultado)
            {
                result.Cod_Respuesta = "1";
                result.Desc_Respuesta = "documento  recepcionado";
            }
            else
            {
                result.Cod_Respuesta = "0";
                result.Desc_Respuesta = "documento no recepcionado";
            }

            //if (value != null)
            //{
            //    result.Cod_Respuesta = "1";
            //    result.Desc_Respuesta = "documento  recepcionado";
            //}
            //else
            //{
            //    result.Cod_Respuesta = "0";
            //    result.Desc_Respuesta = "documento no recepcionado";
            //}
            
            /*
            string result = "<Retorno>"  +
                            "<Cod_Respuesta>0</Cod_Respuesta >" +
                            "<Desc_Respuesta>Documento no Registrado</Desc_Respuesta>" +
                            "</Retorno> ";*/
                            
            //result = "<Retorno>" +
            //            "<Cod_Respuesta>1</Cod_Respuesta >" +
            //            "<Desc_Respuesta>Documento Registrado</Desc_Respuesta>" +
            //            "</Retorno> ";
            //    }

            return result;
        }
    }
}
