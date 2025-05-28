using ColdWheels.Models;

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

	private void ValidarCampos(Carro carro)
	{
		if (string.IsNullOrEmpty(txtNome.Text)||
           string.IsNullOrEmpty(txtAno.Text)||
           string.IsNullOrEmpty(txtLote.Text)||
		   carro.DirImagem == ""
		   )
		{
			DisplayAlert("Aten��o", "Os campos n�o podem estar vazios", "OK");
		}
	}

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
		DisplayAlert("Sucesso!!", "Carrinho salvo com Sucesso", "OK");
    }
}