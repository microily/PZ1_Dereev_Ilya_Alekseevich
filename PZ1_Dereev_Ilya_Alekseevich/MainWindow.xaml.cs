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
using System.Security.Cryptography;
using PZ1_Dereev_Ilya_Alekseevich.Models;

namespace PZ1_Dereev_Ilya_Alekseevich
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string email, password;
            email = tbEmail.Text;
            password = ComputeSha256Hash(tbPassword.Text);


            var context = new Pz1DereevIlyaAlekseevichContext();
            var user = context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user != null)
            {
                MessageBox.Show("Успешный вход!");
                Windows.AdmMenu menu = new Windows.AdmMenu();
                menu.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка почты или пароля");
                MessageBox.Show(password);
            }
        }
        static string ComputeSha256Hash(string rawData) //Хеширование
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Преобразуем строку в байты
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Преобразуем байты в строку в формате hex
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}