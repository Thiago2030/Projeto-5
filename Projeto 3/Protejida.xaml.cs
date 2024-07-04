namespace Projeto_3;

public partial class Protejida : ContentPage
{
	public Protejida()
	{
		InitializeComponent();

		string? usario_logado = null;
		Task.Run(async () =>
		{
			usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
            lbl_boasvindas.Text = $"Bem-vindo"(a) {usuario_logado}",
            

		});
    }

	private async void Button_Clicked(object sender, EventArgs e)
	{
		bool confirmacao = await DisplayAlert("Tem Certeza?", "Sair do app?", "Sim", "N�o");


		if (confirmacao)
		{
			SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new Login();
		}
    }
}