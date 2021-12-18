using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaMVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btndatos_Clicked(object sender, EventArgs e)
        {
            try
            {
                var personas = new Models.Empleados
                {
                    nombre = this.txtnombre.Text,
                    apellido = this.txtapellido.Text,
                    edad = Convert.ToInt32(this.txtedad.Text),
                    direccion = txtdireccion.Text,
                    puesto = txtpuesto.Text

                };

                ClearScreen();

                var resultado = await App.DataBaseSQLite.GrabarPersonas(personas);

                if (resultado == 1)
                {
                    await DisplayAlert("Agregado", "Registro ingresado correctamente", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "Registro no ingresado", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }

        private void ClearScreen()
        {
            this.txtnombre.Text = String.Empty;
            this.txtapellido.Text = String.Empty;
            this.txtedad.Text = String.Empty;
            this.txtdireccion.Text = String.Empty;
            this.txtpuesto.Text = String.Empty;
        }

        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaPage());
        }
    }

}
