using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDTERest.Models
{
    public class RecepcionDocumento   
    {


        public string URI { get; set; }
        public cabecera ID { get; set; }
        public string XML_DTE { get; set; }
        public string PDF { get; set; }
    }
    public class cabecera
    {
        public string RUT_EMISOR { get; set; }
        public string RUT_RECEPTOR { get; set; }
        public string TIPO_DTE { get; set; }
        public string FOLIO { get; set; }
    }
}