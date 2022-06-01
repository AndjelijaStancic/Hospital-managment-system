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
using Model;
using Controller;
using System.ComponentModel;

namespace SimsProjekat
{
    /// <summary>
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        private StatController stat_Controller;


        public event PropertyChangedEventHandler PropertyChangedEvent;

        public List<StatDisplay> statisticsDoctors { get; set; }
        public StatHospitalDisplay statisticsHospital { get; set; }

        public List<GradeCount> gradeCount { get; set; }

        public List<GradeCount> gradeCountDoctor { get; set; }

        public StatisticsPage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            stat_Controller = app.StatController;
            this.statisticsDoctors = stat_Controller.GetAllStatDoctor();
            this.statisticsHospital = stat_Controller.GetStatHospital();
            this.gradeCount = stat_Controller.CountGradesHospital();
            
            gradeOne.Text = statisticsHospital.GradeOne.ToString();
            gradeTwo.Text = statisticsHospital.GradeTwo.ToString();
            gradeThree.Text = statisticsHospital.GradeThree.ToString();
            grade.Text = statisticsHospital.Grade.ToString();


            this.DataContext = this;
           
        }

        private void Show(object sender, RoutedEventArgs e)
        {
            Statistics.Visibility = Visibility.Visible;
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Statistics.Visibility = Visibility.Collapsed;
            HospitalGrades.Visibility = Visibility.Collapsed;
            Grades.Visibility = Visibility.Collapsed;
            DocGrades.Visibility = Visibility.Collapsed;
        }

        private void detailClick(object sender, RoutedEventArgs e)
        {
            Grades.Visibility = Visibility.Visible;
            DocGrades.Visibility = Visibility.Visible;
            this.gradeCountDoctor = stat_Controller.CountGradesDoctor(((StatDisplay)StatGrid.SelectedItem).Id);
            Name.Text = ((StatDisplay)StatGrid.SelectedItem).Name;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Stat.Text.Equals("Doktori"))
            {
                StatisticsGrid.Visibility = Visibility.Collapsed;
                StatHospital.Visibility = Visibility.Visible;
                HospitalGrades.Visibility= Visibility.Visible;  
            }
            else if (Stat.Text.Equals("Bolnica"))
            {
                StatisticsGrid.Visibility = Visibility.Visible;
                StatHospital.Visibility = Visibility.Collapsed;
                HospitalGrades.Visibility = Visibility.Collapsed;
            }

        }

    }
}
