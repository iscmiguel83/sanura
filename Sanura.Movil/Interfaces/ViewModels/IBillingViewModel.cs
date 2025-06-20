using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Sanura.Core.Entities;

namespace Sanura.Movil.Interfaces.ViewModels;

public interface IBillingViewModel
{
    string Filter
    {
        get;
        set;
    }

    ObservableCollection<Customer> Customers
    {
        get;
    }
    IAsyncRelayCommand LoadDataCommand
    {
        get;
    }

    IAsyncRelayCommand<Customer> ShowCustomerCommand
    {
        get;
    }
}
