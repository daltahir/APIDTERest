using APIDTERest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
        public Retorno enviar(String ev)
        {
            Retorno result = new Retorno();
            result.Cod_Respuesta = "1";
            result.Desc_Respuesta = "Mensaje DUMMY enviado a ACEPTA";

            String docID = "";
           


            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "datos=" + ev;
            postData += ("&docid=" + docID);
            postData += ("&comando=enviar");
            postData += ("&parametros=");
            byte[] data = encoding.GetBytes(postData);

            // Prepare web request...
            System.Configuration.Configuration rootWebConfig1 =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
          
               String url =
                    System.Web.Configuration.WebConfigurationManager.AppSettings["ulrPostAcepta"];
                HttpWebRequest myRequest =
              (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            return result;
        }
    }
}
