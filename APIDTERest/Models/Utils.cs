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
        public static Byte[] Base64DecodeByte(string base64EncodedData)
        {
            Byte[] base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return base64EncodedBytes;
        }

        public static bool validarRut(string campoValidar)
        {
            bool resultado = true;

            campoValidar = campoValidar.Replace("-", "");

            string digitoVerificador = campoValidar.Substring(campoValidar.Length - 1);
            string sinDigito = campoValidar.Substring(0, campoValidar.Length - 1);

            if (validarNumero(sinDigito))
            {
                int rut = Convert.ToInt32(sinDigito);

                int Digito;
                int Contador;
                int Multiplo;
                int Acumulador;
                String RutDigito;

                Contador = 2;
                Acumulador = 0;

                while (rut != 0)
                {
                    Multiplo = (rut % 10) * Contador;
                    Acumulador = Acumulador + Multiplo;
                    rut = rut / 10;
                    Contador = Contador + 1;
                    if (Contador == 8)
                    {
                        Contador = 2;
                    }
                }

                Digito = 11 - (Acumulador % 11);
                RutDigito = Digito.ToString().Trim();
                if (Digito == 10)
                {
                    RutDigito = "K";
                }
                if (Digito == 11)
                {
                    RutDigito = "0";
                }

                if (RutDigito != digitoVerificador)
                {
                    resultado = false;
                }
            }
            else
            {
                resultado = false;
            }

            return resultado;
        }

        public static bool validarNumero(string campoValidar)
        {
            bool resultado = true;

            int num;

            resultado = Int32.TryParse(campoValidar.ToString(), out num);

            return resultado;
        }

        public static bool validarFecha(string campoValidar)
        {
            bool resultado = true;

            DateTime fecha;

            resultado = DateTime.TryParse(campoValidar, out fecha);

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

        public static string decoderBase64(string campoValidar)
        {
            string resultado = "";

            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(campoValidar);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                resultado = result;
            }
            catch (Exception ex)
            {

            }

            return resultado;
        }
    }
}