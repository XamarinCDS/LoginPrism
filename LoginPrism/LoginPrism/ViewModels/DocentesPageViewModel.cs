using LoginPrism.Model;
using LoginPrism.Service;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LoginPrism.ViewModels
{
    public class DocentesPageViewModel : BindableBase
    {
        private ObservableCollection<Login> docentes;
        private ApiService api;
        private DelegateCommand delegateCommand;
        private string usuario;
        private string clave;
        private string nombre;
        private string telefono;
        public DelegateCommand RegisterCommand => delegateCommand ?? (delegateCommand = new DelegateCommand(RegisterDocente));
        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value; RaisePropertyChanged("Usuario");
            }
        }
        public string Clave
        {
            get
            {
                return clave;
            }
            set
            {
                clave = value; RaisePropertyChanged("Clave");
            }
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value; RaisePropertyChanged("Nombre");
            }
        }
        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value; RaisePropertyChanged("Telefono");
            }
        }
        public ApiService Api
        {
            get
            {
                if (api == null)
                {
                    api = new ApiService();
                }
                return api;
            }
        }
        public ObservableCollection<Login> Docentes
        {
            get
            {
                if (docentes == null)
                {
                    loadDocentes();
                }
                return docentes;
            }
            set
            {
                docentes = value; RaisePropertyChanged("Docentes");
            }
        }
        private async void loadDocentes()
        {
            this.Docentes = await Api.GetAll<Login>("usuarios");
        }
        public DocentesPageViewModel()
        {
            loadDocentes();
        }
        private async void RegisterDocente()
        {
            if (String.IsNullOrWhiteSpace(Nombre)||String.IsNullOrWhiteSpace(Telefono) || String.IsNullOrWhiteSpace(Usuario) || String.IsNullOrWhiteSpace(Clave))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Uno o mas campos estan vacios", "Aceptar");
                return;
            }
            Login docente = new Login();
            docente.nombre = Nombre;
            docente.telefono = Telefono;
            docente.usu = Usuario;
            docente.passw = Clave;
            var resp = await Api.Post<Login>("usuarios",docente);
            if (resp)
            {
                await App.Current.MainPage.DisplayAlert("Exito", "El docente ha sido registrado", "Aceptar");
                loadDocentes();
                Nombre = String.Empty;
                Usuario = String.Empty;
                Clave = String.Empty;
                Telefono = String.Empty;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "El docente no ha sido registrado", "Aceptar");
            }
        }
    }
}
