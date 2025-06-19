using Sanura.Movil.Interfaces.ViewModels;

namespace Sanura.Movil.Views;

public partial class HomeView : ContentPage
{
	public HomeView(IHomeViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}