
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using semana6GPaucar.Model;
namespace semana6GPaucar.Views;

public partial class vProductos : ContentPage
{
	private const string Url = "http://192.168.100.61:8080/appProductos/post.php";
	private readonly HttpClient cliente= new HttpClient();
	private ObservableCollection<Productos> pro;
    public vProductos()
	{
		InitializeComponent();
		Obtener();
	}

	public async void Obtener()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Productos>  mostrarPro = JsonConvert.DeserializeObject<List<Productos>>(content);
		pro = new ObservableCollection<Productos>(mostrarPro);
		ListaProductos.ItemsSource = pro;
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new Views.vProductos());
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vAgregar());
    }

    private void ListaProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
      
        var pro = (Productos)e.SelectedItem;
        Navigation.PushAsync(new vEditarBorrar(pro));

    }
}