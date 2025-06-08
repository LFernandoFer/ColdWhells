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
   
    private void tapFiltrarObtido_Tapped(object sender, TappedEventArgs e)
    {
        FiltrarObtido();
    }
    private void FiltrarObtido()
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
        FiltrarDesejado();
    }
    private void FiltrarDesejado()
    {
        if (!ReturnDesejado())
        {
            imgDesejado.Source = "heart_check.png";
        }
        else
            imgDesejado.Source = "heart.png";
    }
    private async void tapDeletar_Tapped(object sender, TappedEventArgs e)
    {
        TappedEventArgs tapped =
              (TappedEventArgs)e;

        if (tapped.Parameter is Carro registro)
        {

            bool validacao =
                await DisplayAlert(
                    "Confirma��o",
                    "Deseja realmente excluir o carrinho?",
                    "Sim", "N�o");

            if (validacao)
            {
                //Iremos chamar a rotina de exclus�o
                //da camada controller
                //e ap�s excluir o registro iremos
                //atualizar a lista
                controller.Delete(registro);
                AtualizarListView();
            }
        }
    }

    private void btnFiltrar_Clicked(object sender, EventArgs e)
    {
        var nome = txtFiltroNome.Text;
        var rtnDesejado = ReturnDesejado();
        var rtnObtido = ReturnObtido();

        if(string.IsNullOrEmpty(nome))
            {
            nome = null;
            }
        lsvLista.ItemsSource = controller.Filtrar(nome, rtnObtido, rtnDesejado);
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

    private async void tapChangeDesejo_Tapped(object sender, TappedEventArgs e)
    {
        TappedEventArgs tapped =
             (TappedEventArgs)e;

        if (tapped.Parameter is Carro registro)
        {
            if (registro.Desejado == true)
            {
                bool validacao =
                    await DisplayAlert(
                        "Confirma��o",
                        "Deseja realmente retirar o carrinho da lista de desejos?",
                        "Sim", "N�o");

                if (validacao)
                {
                    registro.Desejado = false;
                    controller.Update(registro);
                    FiltrarDesejado();
                    AtualizarListView();
                }
            }
            else if(registro.Desejado == false)
            {
                bool validacao =
                   await DisplayAlert(
                       "Confirma��o",
                       "Deseja adicionar o carrinho da lista de desejos?",
                       "Sim", "N�o");

                if (validacao)
                {
                    registro.Desejado = true;
                    controller.Update(registro);
                    FiltrarDesejado();
                    AtualizarListView();
                }
            }
        }
    }

    private async void taChangeObtido_Tapped(object sender, TappedEventArgs e)
    {
        TappedEventArgs tapped =
             (TappedEventArgs)e;

        if (tapped.Parameter is Carro registro)
        {
            if (registro.Obtido == true)
            {
                bool validacao =
                    await DisplayAlert(
                        "Confirma��o",
                        "Deseja realmente marcar como N�o Obtido?",
                        "Sim", "N�o");

                if (validacao)
                {
                    registro.Obtido = false;
                    controller.Update(registro);
                    FiltrarObtido();
                    AtualizarListView();
                }
            }
            else if (registro.Obtido == false)
            {
                bool validacao =
                   await DisplayAlert(
                       "Confirma��o",
                       "Deseja marcar o carrinho como Obtido?",
                       "Sim", "N�o");

                if (validacao)
                {
                    registro.Obtido = true;
                    controller.Update(registro);
                    FiltrarObtido();
                    AtualizarListView();
                }
            }
        }
    }
}