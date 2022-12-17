using SistemaAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAPP.ViewModels
{
    public class GastoVIewModel : BaseViewModel
    {
        public GastoDiario MyGasto { get; set; }
        
        public TipoGasto MyTipo { get; set; }
        public GastoVIewModel()
        {
            MyGasto = new GastoDiario();

            MyTipo = new TipoGasto();
        }

        public async Task<bool> AddGasto(string pDescripcion, float pTotal, string pFoto = "0" ,int pTIpoGastoIdtipoGasto = 1) 
        {
            if (IsBusy) return false;

            IsBusy = true;
            try
            {
                MyGasto.Descripcion = pDescripcion;
                MyGasto.Foto = pFoto;
                MyGasto.TipoGastoIdtipoGasto = pTIpoGastoIdtipoGasto;
                MyGasto.Total = pTotal;
                bool R = await MyGasto.AddGasto();
                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            { 
                IsBusy = false; 
            }
        }
        public async Task<List<TipoGasto>> GetQListTipo()
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
                    List<TipoGasto> list = new List<TipoGasto>();
                    list = await MyTipo.GetTipoUsuario();
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

        public async Task<List<GastoDiario>> GetGasto()
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
                    List<GastoDiario> list = new List<GastoDiario>();
                    list = await MyGasto.GetGasto();
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

        public async Task<ObservableCollection<GastoDiario>> GetQList()
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
                    ObservableCollection<GastoDiario> list = new ObservableCollection<GastoDiario>();

                    list = await MyGasto.GetGastosByID();
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
