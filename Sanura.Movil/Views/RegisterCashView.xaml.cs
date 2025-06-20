using Sanura.Movil.Interfaces.ViewModels;

namespace Sanura.Movil.Views;

public partial class RegisterCashView : ContentPage
{
	public RegisterCashView(IRegisterCashViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}