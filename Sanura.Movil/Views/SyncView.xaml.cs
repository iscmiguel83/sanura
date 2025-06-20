using Sanura.Movil.Interfaces.ViewModels;

namespace Sanura.Movil.Views;

public partial class SyncView : ContentPage
{
	public SyncView(ISyncViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}