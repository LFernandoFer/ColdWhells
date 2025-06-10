using ColdWheels.Models;
using ColdWheels.Controllers;
using ColdWheels.Services;
namespace ColdWheels.Views;

public partial class pgCadCarro : ContentPage
{
    string selectedImagePath = "";
    public pgCadCarro()
	{
		InitializeComponent();
	}
    private async void btnSelecionarImagem_Clicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync();
        if (result != null)
        {
            selectedImagePath = result.FullPath;
            carroImg.Source = selectedImagePath;
        }
    }
    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        
        if(!ValidarCampos())
		{
			DisplayAlert("Atenção", "Os campos devem estar preenchidos corretamente", "OK");
			return;
		}
        Carro carro = RetornarCarro();
		IsDesejado(carro);
		IsObtido(carro);
		if (SalvarCarro(carro))
		{
            DisplayAlert("Sucesso!!", "Carrinho salvo com Sucesso", "OK");
            LimparCampos();
        }
		return;
    }

    private bool ValidarCampos()
    {
        if (string.IsNullOrEmpty(txtNome.Text) ||
           string.IsNullOrEmpty(txtAno.Text) ||
           string.IsNullOrEmpty(txtLote.Text)//||
                                             //Validar caminho da imagem
           )
        {
            DisplayAlert("Atenção", "Os campos não podem estar vazios", "OK");
            return false;
        }
        return true;
    }

    private Carro RetornarCarro()
	{
		Carro carro = new Carro();
		carro.Nome = txtNome.Text;
		carro.Lote = txtLote.Text;
		carro.Ano = txtAno.Text;
		carro.DirImagem = selectedImagePath;
		carro.Desejado = false;
		carro.Obtido = false;
		return carro;
	}

	private void IsObtido(Carro carro)
	{
		if(ckbObtido.IsChecked)
		{
			carro.Obtido = true;
		}
	}

    private void IsDesejado(Carro carro)
    {
        if (ckbDesejado.IsChecked)
        {
            carro.Desejado = true;
        }
    }

    private bool SalvarCarro(Carro carro)
	{
		CarroController controller = new CarroController();
		controller.Insert(carro);
		return true;
	}
	
	private void LimparCampos()
	{
		txtNome.Text = "";
		txtLote.Text = "";
		txtAno.Text = "";
		selectedImagePath = "";
		ckbDesejado.IsChecked = false;
		ckbObtido.IsChecked = false;
	}
}