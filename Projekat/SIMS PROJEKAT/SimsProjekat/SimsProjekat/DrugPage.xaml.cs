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
using Controller;
using Model;
using System.ComponentModel;

namespace SimsProjekat
{
    
    public partial class DrugPage : Window
    {
        private DrugController drug_Controller;

        public event PropertyChangedEventHandler PropertyChangedEvent;

        public List<Drug> ApprovedDrugs { get; set; }
        public List<Drug> RejectedDrugs { get; set; }
        public List<Drug> Drugs { get; set; }
        public List<String> Name { get; set; }
        public List<String> Dose { get; set; }
        public List<String> Ingredients { get; set; }
        public List<String> Allergens { get; set; }

        public DrugPage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            drug_Controller = app.DrugController;
            this.ApprovedDrugs = drug_Controller.GetAllApprovedDrugs();
            this.RejectedDrugs = drug_Controller.GetAllRejectedDrugs();
            this.Drugs = drug_Controller.GetAllDrugs();
            this.DataContext = this;
        }

        private void IngredientADrugButton(object sender, RoutedEventArgs e)
        {
            
            AIngredientsBorder.Visibility = Visibility.Visible;
            int drugId = ((Drug)ApprovedGrid.SelectedItem).Id;
            foreach(Drug drug in ApprovedDrugs)
            {
                if(drug.Id == drugId)
                {
                    IngredientsDrugDisplay.Text = drug.Ingredients;
                    DrugNameDisplay.Text = drug.Name;
                }
            }
        }

        private void ApprovedDrugButton(object sender, RoutedEventArgs e)
        {
            Approved.Visibility = Visibility.Collapsed;
            Rejected.Visibility = Visibility.Visible;
            AllApprovedDrugs.Visibility = Visibility.Visible;
            AllRejectedDrugs.Visibility = Visibility.Collapsed;
        }

        private void RejectedDrugButton(object sender, RoutedEventArgs e)
        {
            Approved.Visibility = Visibility.Visible;
            Rejected.Visibility = Visibility.Collapsed;
            AllApprovedDrugs.Visibility = Visibility.Collapsed;
            AllRejectedDrugs.Visibility = Visibility.Visible;
        }

        private void AllDrugsNav(object sender, RoutedEventArgs e)
        {

        }

        private void AllEqpNav(object sender, RoutedEventArgs e)
        {

        }

        private void AllRoomsNav(object sender, RoutedEventArgs e)
        {

        }

        private void StatNav(object sender, RoutedEventArgs e)
        {

        }

        private void SettNav(object sender, RoutedEventArgs e)
        {

        }

        private void ProfileNav(object sender, RoutedEventArgs e)
        {

        }

        private void LogOutClick(object sender, RoutedEventArgs e)
        {

        }

        private void AAllergensButton(object sender, RoutedEventArgs e)
        {
            
            
            int drugId = ((Drug)ApprovedGrid.SelectedItem).Id;
            foreach (Drug drug in ApprovedDrugs)
            {
                if (drug.Id == drugId)
                {
                    AllergensDisplay.Text = drug.Allergens;
                    DrugNameDis.Text = drug.Name;
                }
            }
            AAllergensBorder.Visibility = Visibility.Visible;


        }

        private void deleteButton(object sender, RoutedEventArgs e)
        {
            int drugId = -1;
            drugId = ((Drug)ApprovedGrid.SelectedItem).Id;
            drug_Controller.DeleteDrug(drugId);
            ApprovedRefreshSource();
        }

        private void changeDrugButton(object sender, RoutedEventArgs e)
        {

        }

        public void RejectedRefreshSource()
        {
            this.Drugs = this.drug_Controller.GetAllRejectedDrugs();
            RejectedGrid.ItemsSource = this.Drugs;
            RejectedGrid.Items.Refresh();
        }

        public void ApprovedRefreshSource()
        {
            this.Drugs = this.drug_Controller.GetAllApprovedDrugs();
            ApprovedGrid.ItemsSource = this.Drugs;
            ApprovedGrid.Items.Refresh();
        }

        private void addDrugButton(object sender, RoutedEventArgs e)
        {
            AddDrug.Visibility = Visibility.Visible;
            Approved.Visibility = Visibility.Collapsed;
            Rejected.Visibility = Visibility.Collapsed;
            AllApprovedDrugs.Visibility = Visibility.Collapsed;
            AllRejectedDrugs.Visibility = Visibility.Collapsed;

            

        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            AddDrug.Visibility = Visibility.Collapsed;
            Approved.Visibility = Visibility.Collapsed;
            Rejected.Visibility = Visibility.Visible;
            AllApprovedDrugs.Visibility = Visibility.Visible;
            AllRejectedDrugs.Visibility = Visibility.Collapsed;
        }

        private void AddNewDrugClick(object sender, RoutedEventArgs e)
        {
            AddDrug.Visibility = Visibility.Collapsed;
            Approved.Visibility = Visibility.Collapsed;
            Rejected.Visibility = Visibility.Visible;
            AllApprovedDrugs.Visibility = Visibility.Collapsed;
            AllRejectedDrugs.Visibility = Visibility.Visible;

            Drug newDrug = new Drug(-1, NewDrugName.Text, NewDose.Text, NewIngredients.Text, NewAllergens.Text, false);
            drug_Controller.CreateDrug(newDrug);

            NewDrugName.Clear();
            NewDose.Clear();
            NewIngredients.Clear();
            NewAllergens.Clear();
            RejectedRefreshSource();
        }

        private void ExitDisplay(object sender, RoutedEventArgs e)
        {
            AIngredientsBorder.Visibility = Visibility.Collapsed;
            AAllergensBorder.Visibility= Visibility.Collapsed;
        }

        private void IngredientDrugButton(object sender, RoutedEventArgs e)
        {

        }

        private void RIngredientDrugButton(object sender, RoutedEventArgs e)
        {
            
            RIngredientsBorder.Visibility= Visibility.Visible;
            RAllergensBorder.Visibility = Visibility.Collapsed;
            int drugId = ((Drug)RejectedGrid.SelectedItem).Id;
            List<Drug> updatedR = drug_Controller.GetAllRejectedDrugs();
            foreach (Drug drug in updatedR)
            {
                if (drug.Id == drugId)
                {
                    IngredientsDrugRDisplay.Text = drug.Ingredients;
                    DrugRNameDisplay.Text = drug.Name;
                }
            }
        }

        private void RAllergensButton(object sender, RoutedEventArgs e)
        {
            
            RAllergensBorder.Visibility = Visibility.Visible;
            RIngredientsBorder.Visibility = Visibility.Collapsed;
            int drugId = ((Drug)RejectedGrid.SelectedItem).Id;
            List<Drug> updatedR = drug_Controller.GetAllRejectedDrugs();
            foreach (Drug drug in updatedR)
            {
                if (drug.Id == drugId)
                {
                    AllergensRDisplay.Text = drug.Allergens;
                    DrugRNameDis.Text = drug.Name;
                }
            }

        }

        private void deleteRButton(object sender, RoutedEventArgs e)
        {
            int drugId = -1;
            drugId = ((Drug)RejectedGrid.SelectedItem).Id;
            drug_Controller.DeleteDrug(drugId);
            RejectedRefreshSource();
        }

        private void RExitDisplay(object sender, RoutedEventArgs e)
        {
            AllRejectedDrugs.Visibility = Visibility.Visible;
            RIngredientsBorder.Visibility = Visibility.Collapsed;
            RAllergensBorder.Visibility= Visibility.Collapsed;


        }
    }
}
