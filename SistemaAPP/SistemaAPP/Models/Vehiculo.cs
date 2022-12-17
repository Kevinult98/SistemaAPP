using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using System.Net;

namespace SistemaAPP.Models
{
    public class Vehiculo
    {
        public RestRequest request { get; set; }

        const string mimetype = "application/json";
        const string contentype = "Content-Type";
        public Vehiculo()
        {
            ActividadDiaria = new HashSet<ActividadDiarium>();
        }

        public int Idvehiculo { get; set; }
        public string Placa { get; set; } = null!;
        public string Marca { get; set; } = null!;

        public virtual ICollection<ActividadDiarium> ActividadDiaria { get; set; }

        public async Task<List<Vehiculo>> GetVehiculo()
        {
            try
            {
                string routeSuFix = string.Format("Vehiculoes");

                string FinalApiRoute = CnnToApi.ProductionRoute + routeSuFix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);

                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<List<Vehiculo>>(response.Content);

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
