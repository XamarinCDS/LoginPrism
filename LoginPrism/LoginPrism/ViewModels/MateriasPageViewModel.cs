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
    public class MateriasPageViewModel : BindableBase
    {
        private ObservableCollection<Materia> materias;
        private ApiService api;
        private DelegateCommand delegateCommand;
        private string nombre;
        private string descripcion;
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
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value; RaisePropertyChanged("Descripcion");
            }
        }
        public DelegateCommand RegisterCommand => delegateCommand ?? (delegateCommand = new DelegateCommand(RegisterMateria));
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
        public ObservableCollection<Materia> Materias
        {
            get
            {
                if (materias == null)
                {
                    loadMaterias();
                }
                return materias;
            }
            set
            {
                materias = value; RaisePropertyChanged("Materias");
            }
        }
        private async void loadMaterias()
        {
            this.Materias = await Api.GetAll<Materia>("materias");
        }
        public MateriasPageViewModel()
        {
            loadMaterias();
        }
        private async void RegisterMateria()
        {
            if (String.IsNullOrWhiteSpace(Nombre) || String.IsNullOrWhiteSpace(Descripcion))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Uno o mas campos estan vacios", "Aceptar");
                return;
            }
            Materia mat = new Materia();
            mat.nombre = Nombre;
            mat.descripcion = Descripcion;
            var resp = await Api.Post<Materia>("materias", mat);
            if (resp)
            {
                await App.Current.MainPage.DisplayAlert("Exito", "La materia ha sido registrada", "Aceptar");
                loadMaterias();
                Nombre = String.Empty;
                Descripcion = String.Empty;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "La materia no ha sido registrada", "Aceptar");
            }
        }
    }
}
