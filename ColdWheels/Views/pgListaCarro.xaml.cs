using ColdWheels.Models;
using ColdWheels.Controllers;
namespace ColdWheels.Views;

public partial class pgListaCarro : ContentPage
{
    CarroController controller;
   	public pgListaCarro()
	{
		InitializeComponent();

       controller =
               new CarroController();
        AtualizarListView();
    }
    private void AtualizarListView()
    {
        lsvLista.ItemsSource =
            controller.GetAll();
    }
   
    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.
            Navigation.PopAsync();
    }

    private void tapFiltrarObtido_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void tapFiltrarDesejado_Tapped(object sender, TappedEventArgs e)
    {

    }
    private void tapDeletar_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void btnFiltrar_Clicked(object sender, EventArgs e)
    {
        string nome = txtFiltroNome.Text;

    }
}