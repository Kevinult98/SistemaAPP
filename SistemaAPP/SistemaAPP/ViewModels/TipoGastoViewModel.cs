using SistemaAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAPP.ViewModels
{
    public class TipoGastoViewModel : BaseViewModel
    {
        TipoGasto Mygasto { get; set; }

        public TipoGastoViewModel()
        {
            Mygasto = new TipoGasto();
        }

        public async Task<ObservableCollection<TipoGasto>> GetQList()
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
                    ObservableCollection<TipoGasto> list = new ObservableCollection<TipoGasto>();

                    list = await Mygasto.GetTipoGasto();
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
