using DAL;
using DAL.Services;
using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        IStudentService studentManager;
        Teacher teacher;
        public Profile(IStudentService _studentManager,Teacher _teacher)
        {
            studentManager = _studentManager;
            teacher = _teacher;
            InitializeComponent();
        }
        private void btnSaveStudent_Click(object sender, RoutedEventArgs e)
        {
            string name = firstName.Text;
            string roll = studentRoll.Text;
            Guid guid = Guid.NewGuid();
            try
            {
                studentManager.AddStudent(new DAL.Students(guid, name, roll));
                MessageBox.Show("Student saved successfully!");
                firstName.Text = "";
                studentRoll.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong, student has not been saved successfully! \n" + ex.Message);
            }
        }

        private async void btnLoadStudents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var students = await studentManager.GetStudents(teacher.Roll);
                dgStudent.ItemsSource = students;
                MessageBox.Show("Successfuly pulled students!");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong while fetching data! \n" + ex.Message);
            }
        }

        private void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = dgStudent.SelectedItem as Students;
                if (student == null)
                {
                    MessageBox.Show("No student selected");
                    return;
                }
                studentManager.DeleteStudent(student);
                MessageBox.Show(student.Name + " Was deleted successfuly!");
                btnLoadStudents_Click(sender, e);


            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong while trying to delete student! \n" + ex.Message);
            }
        }

        private void btnUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            string name = firstName.Text;
            string roll = studentRoll.Text;
            try
            {
                var student = dgStudent.SelectedItem as Students;
                if (student == null)
                {
                    MessageBox.Show("No student selected");
                    return;
                }
                if (student.Name!=name&&name!="")
                {
                    student.Name = name;
                }
                if (student.Roll!=roll&&roll!="")
                {
                    student.Roll = roll;
                }
                studentManager.UpdateStudent(student);
                MessageBox.Show(student.Name + " Was Updated successfuly!");
                btnLoadStudents_Click(sender, e);


            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong while trying to delete student! \n" + ex.Message);
            }
        }
    }
}
