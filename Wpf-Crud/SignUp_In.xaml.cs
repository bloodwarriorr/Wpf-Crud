using DAL;
using DAL.Services;
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

namespace Wpf_Crud
{
    /// <summary>
    /// Interaction logic for SignUp_In.xaml
    /// </summary>
    public partial class SignUp_In : Page
    {
        IStudentService studentService;
        ISignUpTeacherService teacherService;
        public SignUp_In(IStudentService _studentService,ISignUpTeacherService _teacherService)
        {
            InitializeComponent();
            studentService = _studentService;
            teacherService = _teacherService;
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            string mail = email_tb.Text.Trim().ToLower();
            string password = password_tb.Password.Trim();
            string firstName = firstName_tb.Text.Trim();
            string lastName = lastName_tb.Text.Trim();
            string roll = roll_tb.Text.Trim();
            Guid guid = Guid.NewGuid();
            try
            {
                bool result=teacherService.SignUpTeacher(new DAL.Teacher(guid, mail, firstName, lastName, password, roll));
                if (result)
                {
                    MessageBox.Show("Successfully addded new teacher to the system!");
                }
                else
                {
                    MessageBox.Show("could not added user!");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong, " + ex.Message);
            }

        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            string mail = SignInemail_tb.Text.Trim().ToLower();
            string password = SignInPass_tb.Password.Trim();

            try
            {
               Teacher teacher=teacherService.SignInTeacher(mail, password);
                this.NavigationService.Navigate(new Profile(studentService,teacher));
            }
            catch (Exception ex)
            {

                MessageBox.Show("Could not sign in, " + ex.Message);
            }

        }
    }
}
