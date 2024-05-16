namespace semana6GPaucar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new Views.vProductos());
        }
    }
}
