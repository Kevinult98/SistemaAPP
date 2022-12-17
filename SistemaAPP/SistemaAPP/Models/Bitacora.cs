using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using System.Net;

namespace SistemaAPP.Models
{
    public class Bitacora
    {
        public RestRequest request { get; set; }

        const string mimetype = "application/json";
        const string contentype = "Content-Type";
        public int Idreporte { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public int? Idusuario { get; set; }

        public virtual Usuario? IdusuarioNavigation { get; set; }
    }
}
