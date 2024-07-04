namespace Projeto_3
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();

            string? usario_logado = null;
		Task.Run(async () =>
		{
			usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

            if(usario_logado == null)
            {
                MainPage = new long();


            } else
            {
                MainPage = new Protejida(); 
            }
			
		});

            MainPage = new Login();

        }
        
        protected override Window CreateWindow(IActivationState activationState)
        {

            var window = base.CreateWindow(activationState);


            window.Width = 400;
            window.Height = 600;


            return window;
        }

    } // Fecha classe 

} // Fecha namespace 
