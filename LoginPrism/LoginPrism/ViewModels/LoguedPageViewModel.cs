using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoginPrism.ViewModels
{
    public class LoguedPageViewModel : BindableBase
    {
        #region Atributos

        private INavigationService navigationService;
        private DelegateCommand delegateCommand;
        private DelegateCommand delegateCommand2;
        #endregion
        #region Propiedades
        public DelegateCommand DCommand => delegateCommand ?? (delegateCommand = new DelegateCommand(Docentes));
        public DelegateCommand MCommand => delegateCommand2 ?? (delegateCommand2 = new DelegateCommand(Materias));
        
        #endregion

        public LoguedPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        private async void Docentes()
        {
            await navigationService.NavigateAsync("DocentesPage");
        }
        private async void Materias()
        {
            await navigationService.NavigateAsync("MateriasPage");
        }
    }
}
