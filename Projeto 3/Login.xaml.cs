namespace Projeto_3;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {

		try
		{

            List<DadosUsuario> list_usuarios = new List<DadosUsuario>()
			{
                new DadosUsuario()
				{
                    Usuario = "José",
					Senha = "123"
				},
                new DadosUsuario()
				{
					Usuario = "Maria", 
					Senha = "321"
				}

			};

            DadosUsuario dados_digitados = new DadosUsuario()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
            };

			// LINQ 
			if(lista_usuarios.Any(
				i => (dados_digitados.Usuario == i.Usuario &&
				     dados_digitados.Senha == i.Senha) ))
			{
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

                App.Current.MainPage = new Protejida();
			} else
			{

				throw new Exception("Usuário ou senha incorretos.");
			}

		} catch(Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}

    }
}