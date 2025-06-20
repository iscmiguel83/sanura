using Sanura.Movil.Interfaces.ViewModels;

namespace Sanura.Movil.Views;

public partial class BillingView : ContentPage
{
	public BillingView(IBillingViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}