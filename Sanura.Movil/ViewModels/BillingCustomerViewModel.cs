using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Sanura.Movil.Interfaces.ViewModels;

namespace Sanura.Movil.ViewModels;

public partial class BillingCustomerViewModel : ObservableObject, IBillingCustomerViewModel, IQueryAttributable
{
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        
    }
}
