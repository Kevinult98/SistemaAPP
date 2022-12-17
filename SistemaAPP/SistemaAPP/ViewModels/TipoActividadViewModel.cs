using SistemaAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAPP.ViewModels
{
    public class TipoActividadViewModel: BaseViewModel
    {
        public TipoActividad MyActividad { get; set; }

        public TipoActividadViewModel()
        {
            MyActividad = new TipoActividad();
        }

        public async Task<List<TipoActividad>> GetQListTipo()
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
                    List<TipoActividad> list = new List<TipoActividad>();
                    list = await MyActividad.GetTipoActividad();
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
