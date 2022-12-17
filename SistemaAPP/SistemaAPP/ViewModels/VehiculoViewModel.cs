using SistemaAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAPP.ViewModels
{
    public class VehiculoViewModel : BaseViewModel
    {
        public Vehiculo MyVehiculo { get; set; }

        public VehiculoViewModel()
        {
            MyVehiculo = new Vehiculo();
        }

        public async Task<List<Vehiculo>> GetQListTipo()
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
                    List<Vehiculo> list = new List<Vehiculo>();
                    list = await MyVehiculo.GetVehiculo();
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
