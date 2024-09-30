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
using System.Windows.Shapes;
using PZ1_Dereev_Ilya_Alekseevich.Models;

namespace PZ1_Dereev_Ilya_Alekseevich.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdmMenu.xaml
    /// </summary>
    public partial class AdmMenu : Window
    {
        private readonly Pz1DereevIlyaAlekseevichContext _context;

        public AdmMenu()
        {
            InitializeComponent();
            _context = new Pz1DereevIlyaAlekseevichContext(); // Инициализация контекста
            LoadData(); // Вызов метода загрузки данных
        }

        private void LoadData()
        {
            // Получение списка пользователей из базы данных
            var user = _context.Users.ToList();

            // Проверка, есть ли данные
            if (user.Count == 0)
            {
                MessageBox.Show("Данные не найдены");
            }

            // Привязка данных к DataGrid
            admDg.ItemsSource = user;
        }
    }
}