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
