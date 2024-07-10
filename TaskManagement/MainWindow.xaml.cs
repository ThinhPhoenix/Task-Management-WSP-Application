using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
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
using TaskManagementRepo.Models;

namespace TaskManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user;
        public ObservableCollection<TaskManagementRepo.Models.Task> Tasks { get; set; }
        public MainWindow(List<TaskManagementRepo.Models.Task> tasks, User user)
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TaskManagementRepo.Models.Task>(tasks);
            TasksDataGrid.ItemsSource = tasks;
            this.user = user;
            DataContext = this;
        }

        private void LoadData()
        {
            TasksDataGrid.ItemsSource = this.Tasks;
        }

        private void Logout_Handler(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            TaskManagementRepo.Models.Task selectedTask = (TaskManagementRepo.Models.Task)TasksDataGrid.SelectedItem;
            if (selectedTask != null)
            {
                
                var options = new DbContextOptionsBuilder<TaskManagementContext>()
               .EnableSensitiveDataLogging()
               .Options;
                using (var _context = new TaskManagementContext(options))
                {
                    var target = _context.Tasks.Where(a => a.TaskId == selectedTask.TaskId).ToList().First();
                    MessageBox.Show("You want to delete task " + selectedTask.Title + " ?");
                    _context.Remove(target);
                    _context.SaveChanges();
                    Tasks.Remove(selectedTask);
                }
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a task to delete.");
            }
        }

        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string description = DescriptionTextBox.Text;
            DateTime? dueDate = DueDatePicker.SelectedDate;
            string priority = ((ComboBoxItem)PriorityComboBox.SelectedItem)?.Content.ToString();
            string status = ((ComboBoxItem)StatusComboBox.SelectedItem)?.Content.ToString();

            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = 12;
            string task_id = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Title is required.");
                return;
            }

            TaskManagementRepo.Models.Task newTask = new TaskManagementRepo.Models.Task
            {
                TaskId = task_id,
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = (byte?)(priority == "Low" ? 1 : priority == "Medium" ? 2 : 3),
                Status = (byte?)(status == "Pending" ? 1 : status == "In Progress" ? 2 : 3)
            };

            Tasks.Add(newTask);

            var options = new DbContextOptionsBuilder<TaskManagementContext>()
              .EnableSensitiveDataLogging()
              .Options;
            using (var _context = new TaskManagementContext(options))
            {
                _context.Add(newTask);
                _context.SaveChanges();
            }

            TitleTextBox.Clear();
            DescriptionTextBox.Clear();
            DueDatePicker.SelectedDate = null;
            PriorityComboBox.SelectedIndex = -1;
            StatusComboBox.SelectedIndex = -1;

            LoadData();
            TabControlG.SelectedIndex = 0;
        }

        private void CancelTask_Click(object sender, RoutedEventArgs e)
        {
            TitleTextBox.Clear();
            DescriptionTextBox.Clear();
            DueDatePicker.SelectedDate = null;
            PriorityComboBox.SelectedIndex = -1;
            StatusComboBox.SelectedIndex = -1;

            TabControlG.SelectedIndex = 0;
        }
    }
}