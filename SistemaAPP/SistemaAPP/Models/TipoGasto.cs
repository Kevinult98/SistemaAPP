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
    public class TipoGasto
    {
        public RestRequest request { get; set; }

        const string mimetype = "application/json";
        const string contentype = "Content-Type";
        public TipoGasto()
        {
            GastoDiarios = new HashSet<GastoDiario>();
        }

        public int IdtipoGasto { get; set; }
        public string Tipo { get; set; } = null!;

        public virtual ICollection<GastoDiario> GastoDiarios { get; set; }

        public async Task<ObservableCollection<TipoGasto>> GetTipoGasto()
        {

            try
            {
                //string routeSuFix = string.Format("Usuarios/GetUsersByID?pUserID={0}", this.Idusuario);

                string routeSuFix = string.Format("TipoGastoes");

                string FinalApiRoute = CnnToApi.ProductionRoute + routeSuFix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);

                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<ObservableCollection<TipoGasto>>(response.Content);

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

        public async Task<List<TipoGasto>> GetTipoUsuario()
        {
            try
            {
                string routeSuFix = string.Format("TipoGastoes");

                string FinalApiRoute = CnnToApi.ProductionRoute + routeSuFix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);

                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<List<TipoGasto>>(response.Content);

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
