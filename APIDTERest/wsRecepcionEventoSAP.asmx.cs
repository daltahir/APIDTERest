using APIDTERest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace APIDTERest
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://dte.crewvalue.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public Retorno enviar(Evento ev)
        {
            Retorno result = new Retorno();
            result.Cod_Respuesta = "1";
            result.Desc_Respuesta = "Mensaje DUMMY enviado a ACEPTA";
            return result;
        }
    }
}
