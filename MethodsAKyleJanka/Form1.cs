using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Author: Kyle Janka
        //ID: 565104
        //Date: 4/19/19
        //Goal-Purpose of the Program: (Added Valdiation & Created Methods) Calculates 1 year of Fuel and 5 years total cost between 2 cars. 

        const decimal fuelCostV = 2.50m;
        const decimal milesPerYearV = 12000;

        private void calcBtn_Click(object sender, EventArgs e)
        {
            //Declare String Variables - Stores User Entered Text
            string carOneMakeV = carOneMakeTxt.Text;
            string carTwoMakeV = carTwoMakeTxt.Text;
            string carOneModelV = carOneModelTxt.Text;
            string carTwoModelV = carOneModelTxt.Text;


            //Declare Decimal Variables
            decimal carOneYrMadeV;
            decimal carTwoYrMadeV;
            decimal carOneMpgV;
            decimal carTwoMpgV;
            decimal carOnePurchPriceV;
            decimal carTwoPurchPriceV;
            decimal carOneRepairCostV;
            decimal carTwoRepairCostV;
            decimal carOneInsCostV;
            decimal carTwoInsCostV;
            decimal calcOneFuelV;
            decimal calcTwoFuelV;
            decimal calcOneTotalV;
            decimal calcTwoTotalV;

            //Validation Variables
            bool validateCarOneMade;
            bool validateCarTwoMade;
            bool validateCarOneMpg;
            bool validateCarTwoMpg;
            bool validateCarOnePurch;
            bool validateCarTwoPurch;
            bool validateCarOneRepair;
            bool validateCarTwoRepair;
            bool validateCarOneIns;
            bool validateCarTwoIns;



            //Input - Converts String Inputs into Decimals

            //Validation

            validateCarOneMade = decimal.TryParse(carOneYrManufTxt.Text, out carOneYrMadeV);
            if (validateCarOneMade == false)
            {
                MessageBox.Show("Please enter a valid manufactured year for car one.");
                return;
            }
            validateCarTwoMade = decimal.TryParse(carTwoYrManufTxt.Text, out carTwoYrMadeV);
            if (validateCarTwoMade == false)
            {
                MessageBox.Show("Please enter a valid manufactured year for car two.");
                return;
            }
            validateCarOneMpg = decimal.TryParse(carOneMpgTxt.Text, out carOneMpgV);
            if(validateCarOneMpg == false)
            {
                MessageBox.Show("Please enter a valid MPG for car one.");
                return;
            }
            validateCarTwoMpg = decimal.TryParse(carTwoMpgTxt.Text, out carTwoMpgV);
            if (validateCarTwoMpg == false)
            {
                MessageBox.Show("Please enter a valid MPG for car two.");
                return;
            }
            validateCarOnePurch = decimal.TryParse(carOnePurchPriceTxt.Text, out carOnePurchPriceV);
            if (validateCarOnePurch == false)
            {
                MessageBox.Show("Please enter a valid purchase price for car one.");
                return;
            }
            validateCarTwoPurch = decimal.TryParse(carTwoPurchPriceTxt.Text, out carTwoPurchPriceV);
            if (validateCarTwoPurch == false)
            {
                MessageBox.Show("Please enter a valid purchase price for car two.");
                return;
            }
            validateCarOneRepair = decimal.TryParse(carOneRepairCostTxt.Text, out carOneRepairCostV);
            if (validateCarOneRepair == false)
            {
                MessageBox.Show("Please enter a valid repair cost for car one.");
                return;
            }
            validateCarTwoRepair = decimal.TryParse(carTwoRepairCostTxt.Text, out carTwoRepairCostV);
            if (validateCarTwoRepair == false)
            {
                MessageBox.Show("Please enter a valid repair cost for car two.");
                return;
            }
            validateCarOneIns = decimal.TryParse(carOneInsCostTxt.Text, out carOneInsCostV);
            if (validateCarOneIns == false)
            {
                MessageBox.Show("Please enter a valid insurance cost for car one.");
                return;
            }
            validateCarTwoIns = decimal.TryParse(carTwoInsCostTxt.Text, out carTwoInsCostV);
            if (validateCarTwoIns == false)
            {
                MessageBox.Show("Please enter a valid insurance cost for car two.");
                return;
            }

            //Processing

            //Calling new method
            calcOneFuelV = KyleJankaMETHODCalc1YearFuelCost(milesPerYearV, fuelCostV, carOneMpgV);
            calcTwoFuelV = KyleJankaMETHODCalc1YearFuelCost(milesPerYearV, fuelCostV, carTwoMpgV);
            //Original code
            calcOneTotalV = carOnePurchPriceV + calcOneFuelV * 5 + carOneRepairCostV * 5 + carOneInsCostV * 5;
            calcTwoTotalV = carTwoPurchPriceV + calcTwoFuelV * 5 + carTwoRepairCostV * 5 + carTwoInsCostV * 5;

            //Output
            calcCarOneFuelTxt.Text = calcOneFuelV.ToString("c");
            calcCarTwoFuelTxt.Text = calcTwoFuelV.ToString("c");
            calcCarOneTotalTxt.Text = calcOneTotalV.ToString("c");
            calcCarTwoTotalTxt.Text = calcTwoTotalV.ToString("c");

            

            //Clears the Color from the Total Labels
            calcCarOneTotalTxt.BackColor = Color.Transparent;
            calcCarTwoTotalTxt.BackColor = Color.Transparent;



            //Displays the Most Expensive Total in Red
            if (calcOneTotalV > calcTwoTotalV)
            {
                calcCarOneTotalTxt.BackColor = Color.Red;
            }
            else
            {
                calcCarTwoTotalTxt.BackColor = Color.Red;
            }
        }

        //New method to calculate fuel cost for one year
        private decimal KyleJankaMETHODCalc1YearFuelCost(decimal passIn_milesPerYearV, decimal passIn_fuelCostV, decimal passIn_carMpgV)
        {
            //Declares local variable to store one year cost 
            decimal local_1YearFuelCostDec;
            //Takes values passed in and calculates them
            local_1YearFuelCostDec = passIn_milesPerYearV / passIn_carMpgV * passIn_fuelCostV;
            //returns the local variable
            return local_1YearFuelCostDec;
 

        }

    }
}
