
using System.Net;


namespace semana6GPaucar.Views
{
    public partial class vAgregar : ContentPage
    {
        public vAgregar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
             
                parametros.Add("producto",txtProducto.Text);
                parametros.Add("categoria",txtCategoria.Text);
                parametros.Add("precio",txtPrecio.Text);
                cliente.UploadValues("http://192.168.100.61:8080/appProductos/post.php","POST", parametros);
                DisplayAlert("Procesado", "Información guardada", "Cerrar");
                Navigation.PushAsync(new vProductos());            

              
            }
            catch (Exception ex)
            {
                
                DisplayAlert("Error", ex.ToString(), "Cerrar");
            }
        }
    }
}
