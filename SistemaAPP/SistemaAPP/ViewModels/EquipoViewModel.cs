using SistemaAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAPP.ViewModels
{
    public class EquipoViewModel : BaseViewModel
    {
        public Equipo MyEquipo { get; set; }
        public EquipoViewModel()
        {
            MyEquipo = new Equipo();
        }

        public async Task<ObservableCollection<Equipo>> GetQList()
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
                    ObservableCollection<Equipo> list = new ObservableCollection<Equipo>();

                    list = await MyEquipo.GetUsersByID();
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
