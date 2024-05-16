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



    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var button = sender as Button;
            bool answer = await DisplayAlert("Confirmaci�n", "�Est�s seguro de eliminar?", "S�", "No");
            if (answer)
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                await cliente.UploadValuesTaskAsync("http://192.168.100.61:8080/appProductos/post.php?codigo=" + txtCodigo.Text, "DELETE", parametros);

                await Navigation.PushAsync(new vProductos());
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }


    private void btnActualizar_Clicked_1(object sender, EventArgs e)
    {

        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
      
            cliente.UploadValues("http://192.168.100.61:8080/appProductos/post.php?producto=" + txtProducto.Text + "&categoria=" + txtCategoria.Text + "&precio=" + txtPrecio.Text + "&codigo=" + txtCodigo.Text, "PUT", parametros);
            DisplayAlert("Procesado", "Informaci�n modificada", "Cerrar");
            Navigation.PushAsync(new vProductos());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alert", ex.Message, "Cerrar");
        }

    }
}
