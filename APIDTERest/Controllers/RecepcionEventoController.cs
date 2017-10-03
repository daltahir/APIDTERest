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
        /// 
        public Retorno Post([FromBody]Evento value)
        {
            Retorno result = new Retorno();
            bool resultado = true;
            
            if (value.TipoEvento == "")
            {
                resultado = false;
            }

            if (!Utils.validarRut(value.RutEmisor))
            {
                resultado = false;
            }

            if (!Utils.validarRut(value.RutReceptor))
            {
                resultado = false;
            }

            if (!Utils.validarNumero(value.TipoDTE.ToString()))
            {
                resultado = false;
            }

            if (!Utils.validarNumero(value.Folio.ToString()))
            {
                resultado = false;
            }

            if (!Utils.validarFecha(value.FechaEmision.ToString()))
            {
                resultado = false;
            }

            if (!Utils.validarFecha(value.FechaEvento.ToString()))
            {
                resultado = false;
            }

            if (value.Uri == "")
            {
                resultado = false;
            }

            if (value.DescripcionEvento == "")
            {
                resultado = false;
            }

            if (value.Observacion == "")
            {
                resultado = false;
            }

            if (resultado)
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
