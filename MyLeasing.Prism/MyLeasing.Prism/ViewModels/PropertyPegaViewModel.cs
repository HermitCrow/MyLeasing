using MyLeasing.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MyLeasing.Prism.ViewModels
{
    public class PropertyPegaViewModel : ViewModelBase
    {
        private PropertyResponse _property;
        public PropertyPegaViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "Property";
        }

        public PropertyResponse Property
        {
            get => _property;
            set => SetProperty(ref _property, value);  
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("property"))
            {
                Property = parameters.GetValue<PropertyResponse>("property");
                Title = $"Property: {Property.Neighborhood}";
            }
        }
    }
}
