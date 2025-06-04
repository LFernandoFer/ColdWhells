using ColdWheels.Models;
using ColdWheels.Services;
namespace ColdWheels.Views;

public partial class pgCadCarro : ContentPage
{
	public pgCadCarro()
	{
		InitializeComponent();
	}

	private Carro RetornarCarro()
	{
		Carro carro = new Carro();
		carro.Nome = txtNome.Text;
		carro.Lote = txtLote.Text;
		carro.Ano = txtAno.Text;
		carro.DirImagem = "";
		carro.Desejado = false;
		carro.Obtido = false;
		return carro;
	}

	private bool ValidarCampos(Carro carro)
	{
		if (string.IsNullOrEmpty(txtNome.Text)||
           string.IsNullOrEmpty(txtAno.Text)||
           string.IsNullOrEmpty(txtLote.Text)//||
		   //Validar caminho da imagem
		   )
		{
			DisplayAlert("Atenção", "Os campos não podem estar vazios", "OK");
			return false;
		}
		return true;
	}

	private void LimparCampos()
	{
		txtNome.Text = "";
		txtLote.Text = "";
		txtAno.Text = "";
		ckbDesejado.IsChecked = false;
		ckbObtido.IsChecked = false;
	}

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
		Carro carro = RetornarCarro();
		ValidarCampos(carro);
		LimparCampos();


		//DisplayAlert("Sucesso!!", "Carrinho salvo com Sucesso", "OK");
    }
}