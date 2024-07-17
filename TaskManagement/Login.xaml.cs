using Microsoft.EntityFrameworkCore;
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
using TaskManagementRepo.Models;

namespace TaskManagement
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private TaskManagementContext _context;

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Handler(object sender, RoutedEventArgs e)
        {
            try
            {
                var options = new DbContextOptionsBuilder<TaskManagementContext>()
               .EnableSensitiveDataLogging()
               .Options;
                using (var _context = new TaskManagementContext(options))
                {
                    List<User> users = _context.Users.Where(a => a.Username == username.Text && a.Password == password.Text).ToList();
                    if (users.Count > 0)
                    {
                        User user = users.First();
                        List<TaskManagementRepo.Models.Task> tasks = _context.Tasks.Where(a => a.UserId == user.UserId).ToList();
                        MainWindow mainWindow = new MainWindow(tasks, user);
                        mainWindow.Show();
                        this.Close();
                    }
                }
            }
            catch { MessageBox.Show("Incorrect username or password"); }
           
            
        }
    }
}
