using APIDTERest.Models;
using System;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace APIDTERest.Controllers
{
    public class RecepcionEventoController : ApiController
    {


        // POST: api/RecepcionEvento

        /// <summary>
        /// Metodo para recibir eventos de documentos desde acepta
        /// <Retorno> 
        ///<Cod_Respuesta>1</Cod_Respuesta>
        ///<Desc_Respuesta></Desc_Respuesta>
        ///</Retorno>
        /// </summary>
        /// <param name="value"></param>
        /// <returns>xml</returns>
        public Retorno Post([FromBody]RecepcionDocumento value)
        {
            Retorno result =new Retorno();
            result.Cod_Respuesta = "0";
            result.Desc_Respuesta = "documento no recepcionado";
          /*  String xmlString = value;
            XDocument xml = XDocument.Parse(xmlString);
            XmlSchemaSet esquema = new XmlSchemaSet();
            esquema.Add("", @"C:\Users\fdiaz\Documents\Visual Studio 2015\WebSites\Acepta\xsdEventos.xsd");

            if (Utils.validarEstructura(esquema, xml))
            {
                XmlDocument xdoc = new XmlDocument();

                xdoc.LoadXml(xmlString);
                XmlNodeList evento = xdoc.GetElementsByTagName("Evento");

                XmlNodeList tipoEvento;
                XmlNodeList rutEmisor;
                XmlNodeList rutReceptor;
                XmlNodeList tipoDTE;
                XmlNodeList folio;
                XmlNodeList fechaEmision;
                XmlNodeList fechaEvento;
                XmlNodeList url;
                XmlNodeList descripcion;
                XmlNodeList observacion;

                foreach (XmlElement nodo in evento)
                {
                    tipoEvento = nodo.GetElementsByTagName("TipoEvento");
                    rutEmisor = nodo.GetElementsByTagName("RutEmisor");
                    rutReceptor = nodo.GetElementsByTagName("RutReceptor");
                    tipoDTE = nodo.GetElementsByTagName("TipoDTE");
                    folio = nodo.GetElementsByTagName("Folio");
                    fechaEmision = nodo.GetElementsByTagName("FechaEmision");
                    fechaEvento = nodo.GetElementsByTagName("FechaEvento");
                    url = nodo.GetElementsByTagName("URL");
                    descripcion = nodo.GetElementsByTagName("Descripcion");
                    observacion = nodo.GetElementsByTagName("Observacion");
                    //result = folio[0].InnerText;
                    result = "<Retorno>" +
                            "<Cod_Respuesta>1</Cod_Respuesta >" +
                            "<Desc_Respuesta>Evento Registrado</Desc_Respuesta>" +
                            "</Retorno> "; ;
                }
            }
            */
            return result;
        }

    }
}
