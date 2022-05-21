using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modificar : ContentPage
    {
        public int IdSelected;
        private SQLiteAsyncConnection _con;
        IEnumerable<estudiante> resDelete;
        IEnumerable<estudiante> resUpdate;
        public Modificar(int Id, string nombre, string usuario, string clave)
        {
            _con = DependencyService.Get<Database>().GetConnection();
            IdSelected = Id;
            InitializeComponent();
            TxtNom.Text = nombre;
            TxtUsu.Text = usuario;
            TxtPass.Text = clave;
        }

        public IEnumerable<estudiante> Delete(SQLiteConnection db, int Id)
        {
            return db.Query<estudiante>("Delete from estudiante where Id = ?", Id);
        }

        public IEnumerable<estudiante> Update(SQLiteConnection db, string nombre, string usuario, string password, int Id)
        {
            return db.Query<estudiante>("Update estudiante set Nombre = ?, Usuario = ?, Clave = ? where Id = ?", nombre, usuario, password, Id);
        }

        private void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisraeldb");
                var db = new SQLiteConnection(databasePath);
                resUpdate = Update(db, TxtNom.Text, TxtUsu.Text, TxtPass.Text, IdSelected);
                DisplayAlert("Aviso", "Datos Actualizados", "Ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Aviso", "ERROR"+ex.Message, "Ok");
            }
        }

        private void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisraeldb");
                var db = new SQLiteConnection(databasePath);
                resDelete = Delete(db, IdSelected);
                DisplayAlert("Aviso", "Datos Eliminados", "Ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Aviso", "ERROR" + ex.Message, "Ok");
            }

        }
    }
}