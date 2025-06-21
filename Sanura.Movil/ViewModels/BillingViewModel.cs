using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Sanura.Core.Entities;
using Sanura.Movil.Interfaces.ViewModels;
using Sanura.Movil.Models;
using Sanura.Movil.Views;

namespace Sanura.Movil.ViewModels;

public partial class BillingViewModel : ObservableObject, IBillingViewModel
{
    private readonly string filePath;

    public BillingViewModel()
    {
        this.filePath = Path.Combine(FileSystem.AppDataDirectory, Constants.FileName);

        Routing.RegisterRoute(Constants.BillingCustomer, typeof(BillingCustomerView));
    }

    [ObservableProperty]
    private string filter = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Customer> customers = [];

    [RelayCommand]
    private async Task LoadDataAsync()
    {
        this.customers.Clear();
        if (File.Exists(this.filePath))
        {
            var json = await File.ReadAllTextAsync(this.filePath);
            var seller = JsonConvert.DeserializeObject<Seller>(json);
            if (seller != null && seller is Seller)
            {
                foreach (var customer in seller.Customers)
                {
                    this.Customers.Add(customer);
                }
            }
        }
    }

    [RelayCommand]
    private async Task ShowCustomerAsync(Customer customer)
    {
        var parameters = new ShellNavigationQueryParameters
            {
                { "Customer", customer}
            };
        await Shell.Current.GoToAsync(Constants.BillingCustomer, parameters);
    }

    partial void OnFilterChanged(string value)
    {
        
    }

}
