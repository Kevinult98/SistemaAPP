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
    public class ActividadDiarium
    {
        public RestRequest request { get; set; }

        const string mimetype = "application/json";
        const string contentype = "Content-Type";
        public ActividadDiarium()
        {
            UsuarioidUsuarios = new HashSet<Usuario>();
        }

        public int Idactividad { get; set; }
        public DateTime Fecha { get; set; }
        public int HoraEntrada { get; set; }
        public int HoraSalida { get; set; }
        public string Lugar { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int TipoActividadIdtipo { get; set; }
        public int GastoDiarioIdgasto { get; set; }
        public int? VehiculoIdvehiculo { get; set; }

        public virtual GastoDiario GastoDiarioIdgastoNavigation { get; set; } = null!;
        public virtual TipoActividad TipoActividadIdtipoNavigation { get; set; } = null!;
        public virtual Vehiculo? VehiculoIdvehiculoNavigation { get; set; }

        public virtual ICollection<Usuario> UsuarioidUsuarios { get; set; }


      

        public async Task<List<ActividadDiarium>> GetActividadByID()
        {
            try
            {
                //string routeSuFix = string.Format("Usuarios/GetUsersByID?pUserID={0}", this.Idusuario);

                string routeSuFix = string.Format("ActividadDiariums");

                string FinalApiRoute = CnnToApi.ProductionRoute + routeSuFix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);

                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<List<ActividadDiarium>>(response.Content);

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
