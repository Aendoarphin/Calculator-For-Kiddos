using System;
using System.Linq;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form2 : Form
    {
        // Init objects to access conversion factors/sets
        Length length = new Length();
        Volume volume = new Volume();
        Time time = new Time();
        // Comparison container to validate chosen conversion combination
        public string[] conversionSet;
        // Track which radio button is selected
        public string rbClicked = "";
     
        public Form2()
        {
            InitializeComponent();
        }

        private void Conversions_Load(object sender, EventArgs e)
        {
            btnClear_Click(sender, e);
        }

        private void radioButton_Checked(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            // Identify chosen conversion category
            switch (radioButton.Name)
            {
                case "rbLength":
                    if(radioButton.Checked)
                    {
                        // Wipe the previous unit options
                        comboIn.Items.Clear();
                        comboOut.Items.Clear();
                        // Repopulate with new units pertaining to clicked conversion category
                        comboIn.Items.AddRange(new string[] { "Inch", "Foot", "Yard", "Mile" });
                        comboOut.Items.AddRange(new string[] { "Inch", "Foot", "Yard", "Mile" });
                        rbClicked = radioButton.Name;
                        txtInput.Clear();
                        txtOutput.Clear();
                    }
                    break;
                case "rbVolume":
                    if (radioButton.Checked)
                    {
                        comboIn.Items.Clear();
                        comboOut.Items.Clear();
                        comboIn.Items.AddRange(new string[] { "Ounce", "Pint", "Quart", "Gallon" });
                        comboOut.Items.AddRange(new string[] { "Ounce", "Pint", "Quart", "Gallon" });
                        rbClicked = radioButton.Name;
                        txtInput.Clear();
                        txtOutput.Clear();
                    }
                    break;
                case "rbTime":
                    if (radioButton.Checked)
                    {
                        comboIn.Items.Clear();
                        comboOut.Items.Clear();
                        comboIn.Items.AddRange(new string[] { "Second", "Minute", "Hour", "Day" });
                        comboOut.Items.AddRange(new string[] { "Second", "Minute", "Hour", "Day" });
                        rbClicked = radioButton.Name;
                        txtInput.Clear();
                        txtOutput.Clear();
                    }
                    break;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != "" && rbClicked != "")
            {
                // Validate chosen units for both combo boxes
                string[] conversionSet = getConversionSet(rbClicked);
                double input = Convert.ToDouble(txtInput.Text);
                string result = "";
                // Selected unit combinations
                string conversionCombo = comboIn.Text + comboOut.Text;

                switch (rbClicked)
                {
                    case "rbLength":
                        if (conversionSet.Contains(conversionCombo)) // Unit combination is valid
                            result = length.convertLength(conversionCombo, input).ToString();
                        else
                            result = "Error"; // Invalid units (ex. user selected inch → gallon)
                        break;
                    case "rbVolume":
                        if (conversionSet.Contains(conversionCombo))
                            result = volume.convertVolume(conversionCombo, input).ToString();
                        else
                            result = "Error";
                        break;
                    case "rbTime":
                        if (conversionSet.Contains(conversionCombo))
                            result = time.convertTime(conversionCombo, input).ToString();
                        else
                            result = "Error";
                        break;
                }
                txtOutput.Text = result;
            }
            else
            {
                MessageBox.Show("Choose a conversion category and provide an input");
            }

        }

        private string[] getConversionSet(string rbName)
        {
            // Access the class-defined conversion sets (array of unit combinations)
            if (rbName == "rbLength")
            {
                conversionSet = length.lengthConversions;
            }
            else if (rbName == "rbVolume")
            {
                conversionSet = volume.volumeConversions;
            }
            else if (rbName == "rbTime")
            {
                conversionSet = time.timeConversions;
            }
            return conversionSet;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rbLength.Checked = false;
            rbVolume.Checked = false;
            rbTime.Checked = false;
            txtInput.Clear();
            txtOutput.Clear();
            comboIn.Text = "";
            comboOut.Text = "";
            comboIn.Items.Clear();
            comboOut.Items.Clear();
        }
    }
}
