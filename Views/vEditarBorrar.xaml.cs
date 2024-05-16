using System.Net;
using semana6GPaucar.Model;
namespace semana6GPaucar.Views;


public partial class vEditarBorrar : ContentPage
{
	public vEditarBorrar(Productos pro)
	{
        InitializeComponent();
        txtProducto.Text = pro.Producto;
        txtCategoria.Text = pro.Categoria;
        txtPrecio.Text =pro.Precio.ToString();
        txtCodigo.Text = pro.Codigo.ToString();
    }

   

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues("http://192.168.100.61:8080/appProductos/post.php?codigo=" + txtCodigo.Text, "DELETE", parametros);
            DisplayAlert("Procesado", "Datos Eliminados", "Cerrar");
            Navigation.PushAsync(new vProductos());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alert", ex.Message, "Cerrar");
        }

    }

    private void btnActualizar_Clicked_1(object sender, EventArgs e)
    {

        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
      
            cliente.UploadValues("http://192.168.100.61:8080/appProductos/post.php?producto=" + txtProducto.Text + "&categoria=" + txtCategoria.Text + "&precio=" + txtPrecio.Text + "&codigo=" + txtCodigo.Text, "PUT", parametros);
            DisplayAlert("Procesado", "Información modificada", "Cerrar");
            Navigation.PushAsync(new vProductos());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alert", ex.Message, "Cerrar");
        }

    }
}
