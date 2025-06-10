using ColdWheels.Models;
using ColdWheels.Controllers;
using System.Collections.ObjectModel;
namespace ColdWheels.Views;

public partial class pgListaCarro : ContentPage
{
    private readonly CarroController controller;
    private bool FilterObtido, FilterDesejado;

    public pgListaCarro()
    {
        InitializeComponent();
        controller = new CarroController();
        AtualizarListView();
    }

    private void AtualizarListView()
    {
        lsvLista.ItemsSource = new ObservableCollection<Carro>(controller.GetAll());
    }

    private void AtualizarIconesFiltro()
    {
        imgObtidoFilter.Source = FilterObtido ? "car_check.png" : "car.png";
        imgDesejadoFilter.Source = FilterDesejado ? "heart_check.png" : "heart.png";
    }

    private void btnFiltrar_Clicked(object sender, EventArgs e)
    {
        var nome = string.IsNullOrWhiteSpace(txtFiltroNome.Text) ? null : txtFiltroNome.Text;
        lsvLista.ItemsSource = new ObservableCollection<Carro>(
            controller.Filtrar(nome, FilterObtido, FilterDesejado));
    }

    private void FilterObtido_Tapped(object sender, EventArgs e)
    {
        FilterObtido = !FilterObtido;
        AtualizarIconesFiltro();
    }

    private void FilterDesejado_Tapped(object sender, EventArgs e)
    {
        FilterDesejado = !FilterDesejado;
        AtualizarIconesFiltro();
    }

    private async void tapChangeDesejo_Tapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Carro carro)
        {
            carro.Desejado = !carro.Desejado;
            controller.Update(carro);
            AtualizarListView();
        }
    }

    private async void taChangeObtido_Tapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Carro carro)
        {
            carro.Obtido = !carro.Obtido;
            controller.Update(carro);
            AtualizarListView();
        }
    }

    private void btnMostrarTodos(object sender, EventArgs e)
    {

        lsvLista.ItemsSource = controller.GetAll();
    }

    private async void tapDeletar_Tapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Carro carro)
        {
            if (await DisplayAlert("Confirmação", "Deseja realmente excluir?", "Sim", "Não"))
            {
                controller.Delete(carro);
                AtualizarListView();
            }
        }
    }
}