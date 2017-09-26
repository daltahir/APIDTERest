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
            
            Retorno result = new Retorno();
           
            if (value != null)
            {
                result.Cod_Respuesta = "1";
                result.Desc_Respuesta = "documento  recepcionado";
            }
            else
            {
                result.Cod_Respuesta = "0";
                result.Desc_Respuesta = "documento no recepcionado";
            }
            /*
            string result = "<Retorno>"  +
                            "<Cod_Respuesta>0</Cod_Respuesta >" +
                            "<Desc_Respuesta>Documento no Registrado</Desc_Respuesta>" +
                            "</Retorno> ";

           // XmlDocument xdoc = new XmlDocument();

  //          xdoc.LoadXml(xmlString);
            //XDocument xml = XDocument.Load(@"C:\Users\fdiaz\Documents\Visual Studio 2015\WebSites\Acepta\xmlDocumento.xml");
           // XDocument xml = XDocument.Parse(xmlString);
            XmlSchemaSet esquema = new XmlSchemaSet();
            esquema.Add("", @"C:\Users\Diego\Documents\Visual Studio 2017\Projects\APIDTERest\APIDTERest\Resources\xsdDocumento.xsd");

          //  if (Utils.validarEstructura(esquema, xml))
           // {
                XmlNodeList RecepcionDocumento = xdoc.GetElementsByTagName("RecepcionDocumento");
                XmlNodeList lista = ((XmlElement)RecepcionDocumento[0]).GetElementsByTagName("ID");

                XmlNodeList rutEmisor;
                XmlNodeList rutReceptor;
                XmlNodeList tipoDTE;
                XmlNodeList folio;
                XmlNodeList xmlDTE;
                XmlNodeList PDF;
                Documento doc = new Documento();

                foreach (XmlElement nodo in lista)
                {
                    rutEmisor = nodo.GetElementsByTagName("RUT_EMISOR");
                    rutReceptor = nodo.GetElementsByTagName("RUT_RECEPTOR");
                    tipoDTE = nodo.GetElementsByTagName("TIPO_DTE");
                    folio = nodo.GetElementsByTagName("FOLIO");
                  //  doc.RutEmisor = rutEmisor.ToString();
                  //  doc.RutReceptor = rutReceptor.ToString();
                   
                }

                foreach (XmlElement nodo in RecepcionDocumento)
                {
                    xmlDTE = nodo.GetElementsByTagName("XML_DTE");
                    PDF = nodo.GetElementsByTagName("PDF");
                }
                result = "<Retorno>" +
                            "<Cod_Respuesta>1</Cod_Respuesta >" +
                            "<Desc_Respuesta>Documento Registrado</Desc_Respuesta>" +
                            "</Retorno> ";
        //    }
        */
            return result;
            

        }



    }

}
