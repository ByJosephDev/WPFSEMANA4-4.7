using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace WPFSEMANA4_4._7
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
 
    public partial class MainWindow : Window
    {

        SqlConnection connection = new SqlConnection("Server=JOSEPH;DataBase=DBPRUEBAS;Integrated Security=true");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Person> people = new List<Person>();

            connection.Open();
            SqlCommand command = new SqlCommand("BuscarPersonaNombre", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 50;
            parameter1.Value = "";
            parameter1.ParameterName = "@FirstName";

            command.Parameters.Add(parameter1);

            SqlDataReader dataReader = command.ExecuteReader();

            while(dataReader.Read())
            {
                people.Add(new Person
                {
                    PersonId = dataReader["PersonId"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    FirstName = dataReader["FirstName"].ToString()
                });
            }

            connection.Close();
            dgvPeople.ItemsSource = people;

        }

    }
}
