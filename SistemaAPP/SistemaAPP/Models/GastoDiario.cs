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
    public class GastoDiario
    {
        public RestRequest request { get; set; }

        const string mimetype = "application/json";
        const string contentype = "Content-Type";
        public GastoDiario()
        {
            ActividadDiaria = new HashSet<ActividadDiarium>();
        }

        public int Idgasto { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Foto { get; set; } = null!;
        public int? TipoGastoIdtipoGasto { get; set; }
        public float Total { get; set; }

        public virtual TipoGasto? TipoGastoIdtipoGastoNavigation { get; set; }
        public virtual ICollection<ActividadDiarium> ActividadDiaria { get; set; }



        public async Task<List<GastoDiario>> GetGasto()
        {
            try
            {
                string routeSuFix = string.Format("GastoDiarios");

                string FinalApiRoute = CnnToApi.ProductionRoute + routeSuFix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);

                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<List<GastoDiario>>(response.Content);

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

        public async Task<bool> AddGasto() 
        {
            bool R = false;
            try
            {
                string FinalApiRoute = CnnToApi.ProductionRoute + "GastoDiarios";

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Post);

                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);

                request.AddHeader(contentype, mimetype);

                string SerializedClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerializedClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    R = true;
                }
                return R;
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        public async Task<ObservableCollection<GastoDiario>> GetGastosByID()
        {

            try
            {
                string routeSuFix = string.Format("GastoDiarios");

                string FinalApiRoute = CnnToApi.ProductionRoute + routeSuFix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);

                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<ObservableCollection<GastoDiario>>(response.Content);

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
