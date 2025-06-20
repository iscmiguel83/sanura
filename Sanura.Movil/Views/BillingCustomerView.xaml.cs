using Sanura.Movil.Interfaces.ViewModels;

namespace Sanura.Movil.Views;

public partial class BillingCustomerView : ContentPage
{
	public BillingCustomerView(IBillingCustomerViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}