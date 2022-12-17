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
    public class Usuario
    {
        public RestRequest request { get; set; }

        const string mimetype = "application/json";
        const string contentype = "Content-Type";
        public Usuario()
        {
            Bitacoras = new HashSet<Bitacora>();
            Equipos = new HashSet<Equipo>();
            ActividadDiariaIdactividads = new HashSet<ActividadDiarium>();
        }

        public int Idusuario { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string? NumeroTelefono { get; set; }
        public string Email { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? CodigoRecuperacion { get; set; }
        public bool? Estado { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string? NombreUsuario { get; set; }

        public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Bitacora> Bitacoras { get; set; }
        public virtual ICollection<Equipo> Equipos { get; set; }

        public virtual ICollection<ActividadDiarium> ActividadDiariaIdactividads { get; set; }

        public async Task<bool> AddNewUser()
        {
            bool R = false;

            try
            {
                string FinalApiRoute = CnnToApi.ProductionRoute + "Usuarios";

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
        public async Task<bool> ValidateUserAcces()
        {
            bool R = false;
            try
            {
                string routeSuFix = string.Format("Usuarios/ValidateUserLogin?pEmail={0}&pPassword={1}", this.NombreUsuario,this.Clave);
                
                string FinalApiRoute = CnnToApi.ProductionRoute + routeSuFix;

               RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);

                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    R = true;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
            return R;

        }
        public async Task<ObservableCollection<Usuario>> GetUsersByID()
        {

            try
            {
                //string routeSuFix = string.Format("Usuarios/GetUsersByID?pUserID={0}", this.Idusuario);

                string routeSuFix = string.Format("Usuarios");

                string FinalApiRoute = CnnToApi.ProductionRoute + routeSuFix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);

                request.AddHeader(CnnToApi.ApiKeyName, CnnToApi.ApiKeyValue);

                request.AddHeader(contentype, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<ObservableCollection<Usuario>>(response.Content);

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
