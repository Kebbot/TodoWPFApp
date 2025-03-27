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
using Microsoft.EntityFrameworkCore;

namespace TodoWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected TodoDbContext _context = new TodoDbContext();
        public MainWindow()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadTasks();
        }
        private void InitializeDatabase()
        {
            using (var context = new TodoDbContext())
            {
                context.Database.EnsureCreated(); // Создает БД и таблицы, если их нет
            }
        }
        private void LoadTasks()
        {
            lvTasks.ItemsSource = _context.Tasks.ToList();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var task = new TaskItem
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                DueDate = dpDueDate.SelectedDate,
                IsCompleted = false
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();
            LoadTasks();
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var task = button.DataContext as TaskItem;
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            LoadTasks();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            var task = checkBox.DataContext as TaskItem;
            task.IsCompleted = checkBox.IsChecked ?? false;
            _context.SaveChanges();
        }
    }
}