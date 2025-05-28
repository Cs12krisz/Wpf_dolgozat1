using MySql.Data.MySqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_dolgozat1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection kapcs = new MySqlConnection("server = srv1.tarhely.pro;database = v2labgwj_12a; uid =v2labgwj_12a; password = 'HASnEeKvbDEPGgvTZubG';");
        List<Film> filmek = new List<Film>();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void lekerdez(object sender, RoutedEventArgs e) {
            kapcs.Open();
            var lekerdezes = new MySqlCommand("SELECT * FROM csigeri_filmek", kapcs).ExecuteReader();
            while (lekerdezes.Read()) { 
                filmek.Add(new Film(lekerdezes.GetString(0), lekerdezes.GetString(1), lekerdezes.GetInt32(2), lekerdezes.GetString(3), lekerdezes.GetString(4),  lekerdezes.GetInt32(5)));
            }

            dgAdatok.ItemsSource = filmek;
            kapcs.Close();
        }

        private void kivalasztott(object sender, SelectionChangedEventArgs e) {
            var item = dgAdatok.SelectedItem as Film;
            Film? film = item;
            lbFilmAzon.Content = film.Filmazon.ToString();
            tb1.Text = film.Cim;
            tb2.Text = film.Ev.ToString();
            tb3.Text = film.Szines;
            tb4.Text = film.Mufaj;
            tb5.Text = film.Hossz.ToString();
        }

        private void modosit(object sender, RoutedEventArgs e) {
            kapcs.Open();
            new MySqlCommand($"UPDATE csigeri_filmek SET cim = '{tb1.Text}', ev = {tb2.Text}, szines = '{tb3.Text}', mufaj = '{tb4.Text}', hossz = {tb5.Text} WHERE filmazon = '{lbFilmAzon.Content}'", kapcs).ExecuteNonQuery();
            filmek.Clear();
            var lekerdezes = new MySqlCommand("SELECT * FROM csigeri_filmek", kapcs).ExecuteReader();
            while (lekerdezes.Read()) {
                filmek.Add(new Film(lekerdezes.GetString(0), lekerdezes.GetString(1), lekerdezes.GetInt32(2), lekerdezes.GetString(3), lekerdezes.GetString(4), lekerdezes.GetInt32(5)));
            }
            dgAdatok.ItemsSource = filmek;
            dgAdatok.Items.Refresh();
            kapcs.Close();

        }
    }
}