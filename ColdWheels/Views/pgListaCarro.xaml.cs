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
        if (!ReturnObtido())
        {
            imgObtido.Source = "car_check.png";
        }
        else
            imgObtido.Source = "car.png";
    }
    private void tapFiltrarDesejado_Tapped(object sender, TappedEventArgs e)
    {
        if(!ReturnDesejado())
        {
            imgDesejado.Source = "heart_check.png";
        }
        else
            imgDesejado.Source = "heart.png";
    }
    private void tapDeletar_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void btnFiltrar_Clicked(object sender, EventArgs e)
    {
        string nome = txtFiltroNome.Text;
        var stsObtido = imgObtido.Source as FileImageSource;
        var stsDesejado = imgDesejado.Source as FileImageSource;

        //controller.Filtrar(nome, );

    }

    private bool ReturnDesejado()
    {
        var img = imgDesejado.Source as FileImageSource;

        if (img.File != null && img.File == "heart.png")
        {
            return false;
        }
        return true;
    }

    private bool ReturnObtido()
    {
        var img = imgObtido.Source as FileImageSource;

        if (img.File != null && img.File == "car.png")
        {
            return false;
        }
        return true;
    }
}