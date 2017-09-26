using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Schema;

namespace APIDTERest.Models
{
    public class Utils
    {
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static bool validarEstructuraXMLDocumento(String xmlString)
        {
            bool resultado = true;
            XmlSchemaSet esquema = new XmlSchemaSet();
            esquema.Add("", @"C:\Users\fdiaz\Documents\Visual Studio 2015\WebSites\Acepta\xsdDocumento.xsd");

            XDocument doc = XDocument.Load(@"C:\Users\fdiaz\Documents\Visual Studio 2015\WebSites\Acepta\xmlDocumento.xml");

            bool validacion = false;

            doc.Validate(esquema, (s, e) =>
            {
                Console.WriteLine(e.Message);
                validacion = true;
            });


            if (validacion)//TRUE SI EXISTE ERROR EN VALIDACION
            {
                Console.WriteLine("Validación failed");
                resultado = false;
            }
            else
            {
                Console.WriteLine("Validación excelente");
                resultado = true;
            }
            return resultado;
        }

        public static bool validarEstructura(XmlSchemaSet esquema, XDocument xml)
        {
            bool resultado = true;

            bool validacion = false;

            xml.Validate(esquema, (s, e) =>
            {
                Console.WriteLine(e.Message);
                validacion = true;
            });

            if (validacion)//TRUE SI EXISTE ERROR EN VALIDACION
            {
                Console.WriteLine("Validación failed");
                resultado = false;
            }
            else
            {
                Console.WriteLine("Validación excelente");
                resultado = true;
            }
            return resultado;
        }
    }
}