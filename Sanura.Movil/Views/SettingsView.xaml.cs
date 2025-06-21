using Sanura.Movil.Interfaces.ViewModels;

namespace Sanura.Movil.Views;

public partial class SettingsView : ContentPage
{
	public SettingsView(ISettingsViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}