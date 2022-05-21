using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {

            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();

        }

        public IEnumerable<estudiante> Select_Where(SQLiteConnection db, string usu, string pass)
        {
            return db.Query<estudiante>("Select * from estudiante where usuario = ? and clave = ?", usu, pass);
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisraeldb");
            var db = new SQLiteConnection(databasePath);
            db.CreateTable<estudiante>();
            IEnumerable<estudiante> res = Select_Where(db, TxtUsu.Text, TxtPass.Text);
            if (res.Count() > 0)
            {
                Navigation.PushAsync(new Listar());

            }
            else
            {
                DisplayAlert("Alert", "Usuario no registrado", "OK");
            }

        }

        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}