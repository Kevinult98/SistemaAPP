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
    public class Equipo
    {
        public RestRequest request { get; set; }

        const string mimetype = "application/json";
        const string contentype = "Content-Type";
        public int Idequipo { get; set; }
        public string Marca { get; set; } = null!;
        public string? NumeroSerie { get; set; }
        public string Tipo { get; set; } = null!;
        public int? UsuarioidUsuario { get; set; }

        public virtual Usuario? UsuarioidUsuarioNavigation { get; set; }

        public async Task<ObservableCollection<Equipo>> GetUsersByID()
        {

            try
            {
                //string routeSuFix = string.Format("Usuarios/GetUsersByID?pUserID={0}", this.Idusuario);

                string routeSuFix = string.Format("Equipoes");

                string FinalApiRoute = CnnToApi.ProductionRoute + routeSuFix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);

                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<ObservableCollection<Equipo>>(response.Content);

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
