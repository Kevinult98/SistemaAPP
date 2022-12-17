using Newtonsoft.Json;
using RestSharp;
using SistemaAPP.Models;
using SistemaAPP.Models.DTOs;
using SistemaAPP.Tools;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAPP.ViewModels
{
    public class ActividadDiariaViewModel : BaseViewModel
    {
        public ActividadDiarium MyActividad { get; set; }

        public ActividadDTO MyActividadDTO { get; set; }

        public ActividadDiariaViewModel()
        {
            MyActividad = new ActividadDiarium();
            MyActividadDTO = new ActividadDTO();
        }


      


        public async Task<bool> AddActividad( int pHoraEntrada,
                                             int pHoraSalida, string pLugar, 
                                             int pGastoDiario , int pTipoActividad, 
                                             int pVehiculo, string pDesc
                                       )
        {
            if (IsBusy)
            {
                return false;
            }
            else
            {
                IsBusy = true;
            }
            try
            {


                MyActividadDTO.HoraEntrada = pHoraEntrada;
                MyActividadDTO.HoraSalida = pHoraSalida;
                MyActividadDTO.Lugar = pLugar;
                MyActividadDTO.Descripcion = pDesc;

                MyActividadDTO.GastoDiarioIdgasto = pGastoDiario;
                MyActividadDTO.TipoActividadIdtipo = pTipoActividad;
                MyActividadDTO.VehiculoIdvehiculo = pVehiculo;

                //MyActividad.GastoDiarioIdgastoNavigation = pGastoDiario;
                //MyActividad.TipoActividadIdtipoNavigation = pTipoActividad;
                ////MyActividad.VehiculoIdvehiculoNavigation = pVehiculo;
                //MyActividad.Idactividad = 40;

                bool R = await MyActividadDTO.AddNewActividad();

                return R;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            { IsBusy = false; }

        }

        public async Task<List<ActividadDiarium>> GetQListActividad()
        {
            if (IsBusy)
            {
                return null;
            }
            else
            {
                IsBusy = true;

                try
                {
                    List<ActividadDiarium> list = new List<ActividadDiarium>();
                    list = await MyActividad.GetActividadByID();
                    if (list == null)
                    {
                        return null;
                    }
                    else
                    {
                        return list;
                    }

                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
    }
}
