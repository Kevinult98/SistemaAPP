using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using SistemaAPP.Models;


namespace SistemaAPP.ViewModels 
{
    public class UserViewModel : BaseViewModel
    {
        public Usuario MyUser { get; set; }

        public TipoUsuario MyTipo { get; set; }
        public Tools.Crypto MyCrypto { get; set; }

        public UserViewModel()
        {
            MyUser = new Usuario();

            MyTipo = new TipoUsuario();

            MyCrypto = new Tools.Crypto();
        }
        public async Task<bool> AddUser(string pNombreCompleto,
                                        string pCedula,
                                        string pNumeroTelefono,
                                        string pEmail,
                                        string pClave,
                                        string pDireccion,
                                        int pIdTipoUsuario,
                                        string pNombreUsuario 
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
                
                MyUser.NombreCompleto = pNombreCompleto;
                MyUser.Cedula = pCedula;
                MyUser.NumeroTelefono = pNumeroTelefono;
                MyUser.Email = pEmail;
                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pClave);
                MyUser.Clave = EncriptedPassword;
                MyUser.IdTipoUsuario = pIdTipoUsuario;
                MyUser.Direccion = pDireccion;
                MyUser.IdTipoUsuario = pIdTipoUsuario;
                MyUser.NombreUsuario = pNombreUsuario;

                bool R = await MyUser.AddNewUser();

                return R;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            { IsBusy = false; }

        }

        //validar permiso de acceso del usuario
        public async Task<bool> ValidateUserAcces(string pEmail, string pPassword)
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
                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);
                MyUser.NombreUsuario = pEmail;
                MyUser.Clave = EncriptedPassword;
                bool R = await MyUser.ValidateUserAcces();
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
        public async Task<ObservableCollection<Usuario>> GetQList()
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
                    ObservableCollection<Usuario> list = new ObservableCollection<Usuario>();

                    list = await MyUser.GetUsersByID();
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

        public async Task<List<TipoUsuario>> GetQListTipo()
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
                    List<TipoUsuario> list = new List<TipoUsuario>();
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

    }

}
