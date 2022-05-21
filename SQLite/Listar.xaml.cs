using SQLite.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listar : ContentPage
    {
        private SQLiteAsyncConnection _con;
        private ObservableCollection<estudiante> _TablaEstudiante;
        public Listar()
        {
            InitializeComponent();
            _con = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            OnOppearing();
        }

        
        protected async void OnOppearing()
        {
            var res = await _con.Table<estudiante>().ToListAsync();
            _TablaEstudiante = new ObservableCollection<estudiante>(res);
            ListaUsuarios.ItemsSource = _TablaEstudiante;
        }
        
        private void ListaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (estudiante)e.SelectedItem;
            var item = Obj.Id.ToString();
            var item1 = Obj.Nombre.ToString();
            var item2 = Obj.Usuario.ToString();
            var item3 = Obj.Clave.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Modificar(ID, item1, item2, item3));
            }
            catch (Exception)
            {

            }

        }
    }
}