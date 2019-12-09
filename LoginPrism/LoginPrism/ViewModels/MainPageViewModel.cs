using LoginPrism.Service;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LoginPrism.ViewModels
{
    class MainPageViewModel : BindableBase
    {
        #region Atributos
        private string usuario;
        private string clave;
        private DelegateCommand delegateCommand;
        private INavigationService navigationService;
        private int tryOuts=0;
        private ApiService api;
        #endregion
        #region Propiedades
        public DelegateCommand LoginCommand => delegateCommand ?? (delegateCommand = new DelegateCommand(login));
        public ApiService Api
        {
            get
            {
                if (api==null)
                {
                    api = new ApiService();
                }
                return api;
            }
        }
        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;RaisePropertyChanged("Usuario");
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
                clave = value;RaisePropertyChanged("Clave");
            }
        }
        #endregion
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        public async void login()
        {
            if (String.IsNullOrWhiteSpace(Usuario))
            {
                await App.Current.MainPage.DisplayAlert("Error", "El usuario no puede quedar vacio", "Aceptar");
                return;
            }
            if (String.IsNullOrWhiteSpace(Clave))
            {
                await App.Current.MainPage.DisplayAlert("Error", "El usuario no puede quedar vacio", "Aceptar");
                return;
            }
            if (! await Api.LoginValidate(Usuario,Clave))
            {
                if (tryOuts>3)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Muchos intentos Fallidos", "Aceptar");
                    return;
                }
                await App.Current.MainPage.DisplayAlert("Error", "Usuario o clave erronea", "Aceptar");
                tryOuts++;
                return;
            }
            await navigationService.NavigateAsync("LoguedPage");
        }
    }

}
