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
        public Retorno Post([FromBody]Evento value)
        {
            string xmlString = "";
            Retorno result =new Retorno();
            bool resultado = true;
            XDocument xml = XDocument.Parse(xmlString);
            XmlSchemaSet esquema = new XmlSchemaSet();
            //Evento eventos = new Evento();
            esquema.Add("", @"C:\Users\fdiaz\Source\Repos\APIDTERest\APIDTERest\Resources\xsdEventos.xsd");

            if (Utils.validarEstructura(esquema, xml))
            {
                XmlDocument xdoc = new XmlDocument();

                xdoc.LoadXml(xmlString);
                XmlNodeList nodoEventos = xdoc.GetElementsByTagName("Evento");

                XmlNodeList tipoEvento;
                XmlNodeList rutEmisor;
                XmlNodeList rutReceptor;
                XmlNodeList tipoDTE;
                XmlNodeList folio;
                XmlNodeList fechaEmision;
                XmlNodeList fechaEvento;
                XmlNodeList uri;
                XmlNodeList descripcion_evento;
                XmlNodeList observacion;

                foreach (XmlElement nodo in nodoEventos)
                {
                    tipoEvento = nodo.GetElementsByTagName("TipoEvento");
                    if (tipoEvento[0].InnerText != "")
                    {
                        value.TipoEvento = tipoEvento[0].InnerText;                        
                    }
                    else
                    {
                        resultado = false;
                    }

                    rutEmisor = nodo.GetElementsByTagName("RutEmisor");
                    if (Utils.validarRut(rutEmisor[0].InnerText))
                    {
                        value.RutEmisor = rutEmisor[0].InnerText;
                    }
                    else
                    {
                        resultado = false;
                    }

                    rutReceptor = nodo.GetElementsByTagName("RutReceptor");
                    if (Utils.validarRut(rutReceptor[0].InnerText))
                    {
                        value.RutReceptor = rutReceptor[0].InnerText;
                    }
                    else
                    {
                        resultado = false;
                    }

                    tipoDTE = nodo.GetElementsByTagName("TipoDTE");
                    if (Utils.validarNumero(tipoDTE[0].InnerText))
                    {
                        value.TipoDTE = Convert.ToInt32(tipoDTE[0].InnerText);
                    }
                    else
                    {
                        resultado = false;
                    }

                    folio = nodo.GetElementsByTagName("Folio");
                    if (Utils.validarNumero(folio[0].InnerText))
                    {
                        value.Folio = Convert.ToInt64(folio[0].InnerText);
                    }
                    else
                    {
                        resultado = false;
                    }

                    fechaEmision = nodo.GetElementsByTagName("FechaEmision");
                    if (Utils.validarFecha(fechaEmision[0].InnerText))
                    {
                        value.FechaEmision = Convert.ToDateTime(fechaEmision[0].InnerText);
                    }
                    else
                    {
                        resultado = false;
                    }

                    fechaEvento = nodo.GetElementsByTagName("FechaEvento");
                    if (Utils.validarFecha(fechaEvento[0].InnerText))
                    {
                        value.FechaEvento = Convert.ToDateTime(fechaEvento[0].InnerText);
                    }
                    else
                    {
                        resultado = false;
                    }

                    uri = nodo.GetElementsByTagName("URI");
                    if (uri[0].InnerText != "")
                    {
                        value.Uri = uri[0].InnerText;
                    }
                    else
                    {
                        resultado = false;
                    }

                    descripcion_evento = nodo.GetElementsByTagName("Descripcion_Evento");
                    if (descripcion_evento[0].InnerText != "")
                    {
                        value.DescripcionEvento = descripcion_evento[0].InnerText;
                    }
                    else
                    {
                        resultado = false;
                    }

                    observacion = nodo.GetElementsByTagName("Observacion");
                    if (observacion[0].InnerText != "")
                    {
                        value.Observacion = observacion[0].InnerText;
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
                result.Desc_Respuesta = "Evento Agregado";
            }
            else
            {
                result.Cod_Respuesta = "0";
                result.Desc_Respuesta = "Evento No Agregado";
            }

            return result;
        }
    }
}
