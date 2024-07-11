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

        private String RandomString_Generator(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = TitleTextBox.Text;
                string description = DescriptionTextBox.Text;
                DateTime? dueDate = DueDatePicker.SelectedDate;
                string priority = ((ComboBoxItem)PriorityComboBox.SelectedItem)?.Content.ToString();
                string status = ((ComboBoxItem)StatusComboBox.SelectedItem)?.Content.ToString();
                string task_id = TaskIDTB.Text;

                TaskManagementRepo.Models.Task selectedTask = (TaskManagementRepo.Models.Task)TasksDataGrid.SelectedItem == null ? new TaskManagementRepo.Models.Task() : (TaskManagementRepo.Models.Task)TasksDataGrid.SelectedItem;


                if (string.IsNullOrWhiteSpace(title))
                {
                    MessageBox.Show("Title is required.");
                    return;
                }

                TaskManagementRepo.Models.Task newTask = new TaskManagementRepo.Models.Task
                {
                    TaskId = task_id,
                    Title = title,
                    UserId = user.UserId,
                    Description = description,
                    DueDate = dueDate,
                    Priority = (byte?)(priority == "Low" ? 1 : priority == "Medium" ? 2 : 3),
                    Status = (byte?)(status == "Pending" ? 1 : status == "In Progress" ? 2 : 3)
                };

                var options = new DbContextOptionsBuilder<TaskManagementContext>()
                  .EnableSensitiveDataLogging()
                  .Options;
                using (var _context = new TaskManagementContext(options))
                {

                    if (isUpdate.Text == "false")
                    {
                        _context.Add(newTask);
                        _context.SaveChanges();
                        Tasks.Add(newTask);
                    }
                    else
                    {
                        _context.Tasks.Update(newTask);
                        _context.SaveChanges();
                    }
                }

                TitleTextBox.Clear();
                DescriptionTextBox.Clear();
                DueDatePicker.SelectedDate = null;
                PriorityComboBox.SelectedIndex = -1;
                StatusComboBox.SelectedIndex = -1;

                TabControlG.SelectedIndex = 0;
                LoadData();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
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

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            TabControlG.SelectedIndex = 1;
            TaskManagementRepo.Models.Task selectedTask = (TaskManagementRepo.Models.Task)TasksDataGrid.SelectedItem;
            isUpdate.Text = "true";

            TaskIDTB.Text = selectedTask.TaskId;
            TitleTextBox.Text = selectedTask.Title;
            DescriptionTextBox.Text = selectedTask.Description; 
            DueDatePicker.SelectedDate = selectedTask.DueDate;
            PriorityComboBox.SelectedIndex = (int)selectedTask.Priority - 1;
            StatusComboBox.SelectedIndex = (int)selectedTask.Status - 1;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TabControlG.SelectedIndex = 1;
            isUpdate.Text = "false";
            
            string taskid = RandomString_Generator(12);
            TaskIDTB.Text = taskid;
        }

        private void Search_Handler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var options = new DbContextOptionsBuilder<TaskManagementContext>()
                  .EnableSensitiveDataLogging()
                  .Options;
                List<TaskManagementRepo.Models.Task> tasks = new List<TaskManagementRepo.Models.Task>();
                using (var _context = new TaskManagementContext(options))
                {
                    tasks = _context.Tasks.Where(t => t.Title.Contains(SearchTextBox.Text)).ToList();
                    Tasks = new ObservableCollection<TaskManagementRepo.Models.Task>(tasks);
                }
                LoadData();
            }
        }
    }
}