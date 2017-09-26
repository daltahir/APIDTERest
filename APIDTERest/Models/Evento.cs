using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDTERest.Models
{
    public class Evento
    {
        private String tipoEvento;
        private String rutEmisor;
        private String rutReceptor;
        private Int32 tipoDTE;
        private long folio;
        private DateTime fechaEmision;
        private DateTime fechaEvento;
        private String uri;
        private String descripcionEvento;
        private String observacion;

        public string TipoEvento { get; set; }
        public string RutEmisor { get; set; }
        public string RutReceptor { get; set; }
        public int TipoDTE { get; set; }
        public long Folio { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Uri { get; set; }
        public string DescripcionEvento { get; set; }
        public string Observacion { get; set; }
    }
}