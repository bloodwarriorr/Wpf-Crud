using DAL;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

namespace Wpf_Crud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IStudentService studentManager;
        ISignUpTeacherService teacherManager;
        public MainWindow(IStudentService _studentManager, ISignUpTeacherService _teacherManager)
        {
            
            InitializeComponent();
            studentManager = _studentManager;
            teacherManager = _teacherManager;
            Loaded += WindowLoaded;
            MouseDown += Window_MouseDown;
        }


        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new SignUp_In(studentManager,teacherManager));
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
           this.WindowState=WindowState.Minimized;
        }

        private void Maximize(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Normal:
                    this.WindowState=WindowState.Maximized;
                    break;
                case WindowState.Minimized:
                    this.WindowState=WindowState.Normal;
                    break;
                case WindowState.Maximized:
                    this.WindowState=WindowState.Normal;
                    break;
                default:
                    break;
            }
        }
    }
}
