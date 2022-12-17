using SistemaAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAPP.ViewModels
{
    public class TipoUsuarioViewModel : BaseViewModel
    {
        public TipoUsuario MyTipo { get; set; }
        public Usuario MyUser { get; set; }
        public TipoUsuarioViewModel()
        {
            MyTipo = new TipoUsuario();
        }
     
    }
}
