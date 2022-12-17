using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using System.Net;
using System.Collections.ObjectModel;

namespace SistemaAPP.Models
{
    public class TipoUsuario
    {
        public RestRequest request { get; set; }

        const string mimetype = "application/json";
        const string contentype = "Content-Type";

        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

        public async Task<List<TipoUsuario>> GetTipoUsuario()
        {
            try
            {
                string routeSuFix = string.Format("TipoUsuarios");

                string FinalApiRoute = CnnToApi.ProductionRoute + routeSuFix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);

                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<List<TipoUsuario>>(response.Content);

                if (statusCode == HttpStatusCode.OK)
                {
                    return QList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }

        }

    }
}
