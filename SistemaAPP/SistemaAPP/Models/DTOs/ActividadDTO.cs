using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAPP.Models.DTOs
{
    public class ActividadDTO
    {
        public RestRequest request { get; set; }

        const string mimetype = "application/json";
        const string contentype = "Content-Type";
        public int Idactividad { get; set; }
        public int HoraEntrada { get; set; }
        public int HoraSalida { get; set; }
        public string Lugar { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int TipoActividadIdtipo { get; set; }
        public int GastoDiarioIdgasto { get; set; }
        public int VehiculoIdvehiculo { get; set; }

        public async Task<bool> AddNewActividad()
        {
            bool R = false;

            try
            {
      
                string FinalApiRoute = CnnToApi.ProductionRoute + "ActividadDiariums";

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
    }
}
