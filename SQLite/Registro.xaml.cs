using SQLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNom.Text) || string.IsNullOrWhiteSpace(TxtNom.Text) || string.IsNullOrWhiteSpace(TxtNom.Text))
            {
                DisplayAlert("Aviso", "Complete los Campos", "Ok");
            }
            else { 
            var datos = new estudiante { Nombre = TxtNom.Text, Usuario = TxtUsu.Text, Clave = TxtPass.Text };
            _conn.InsertAsync(datos);
            LimpiarCampos();
            }
        }

        void LimpiarCampos()
        {
            TxtNom.Text = "";
            TxtPass.Text = "";
            TxtUsu.Text = "";
            DisplayAlert("Aviso", "Usuario Almacenado", "Ok");

        }
    }
}