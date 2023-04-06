using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        // Flags to track operation states
        public bool modPressed, reciprocalPressed, sqrPressed,
            sqrtPressed, addPressed, subtractPressed, multiplyPressed,
            dividePressed, hasAnswer;
        // Store the two values entered
        public double currentEntry, operand;
        // Store the results
        double result;
        // For modulus (accepts ints)
        int modResult;
        // Access sqr and sqrt conversions
        Operation operation = new Operation();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set state flags
            modPressed = false;
            addPressed = false;
            subtractPressed = false;
            multiplyPressed = false;
            dividePressed = false;
            hasAnswer = false;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            // Init and show the conversions window
            Form2 convertWindow = new Form2();
            convertWindow.Show();
        }

        private void number_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // Check if the button clicked is period button and if
            // current entry already contains period
            if (button.Text == "." && txtEntry.Text.Contains("."))
            {
                return; // exit the method without adding the period
            }

            // If current entry starts with "0" or if hasAnswer flag is true,
            // set current entry to button's text and set hasAnswer flag to false
            if (txtEntry.Text.StartsWith("0") || hasAnswer == true)
            {
                txtEntry.Text = button.Text;
                hasAnswer = false;
            }
            else // If above conditions are false, append button's Text to current entry
            {
                txtEntry.Text += button.Text;
                hasAnswer = false;
            }
        }



        private void basicOperation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // If user typed in a value
            if (txtEntry.Text != "")
            {
                // Store value of pressed button
                operand = Convert.ToDouble(txtEntry.Text);
                // Display buttons pressed
                lblFormulation.Text += (txtEntry.Text + button.Text);
                txtEntry.Text = "";
                // Identify which operation was clicked
                // then set flag for that button
                switch (button.Name)
                {
                    case "btnAdd":
                        addPressed = true;
                        break;
                    case "btnSubtract":
                        subtractPressed = true;
                        break;
                    case "btnMultiply":
                        multiplyPressed = true;
                        break;
                    case "btnDivide":
                        dividePressed = true;
                        break;
                    case "btnMod":
                        modPressed = true;
                        break;
                }
            }
        }

        private void advancedOperation_Click(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            double reciprocal, sqr, sqrt;

            if(txtEntry.Text != "")
            {
                // Identify which operation was pressed
                switch (button.Name)
                {
                    // Assign designated results
                    case "btnReciprocal":
                        reciprocal = 1 / Convert.ToDouble(txtEntry.Text);
                        txtEntry.Text = reciprocal.ToString();
                        break;
                    case "btnSqr":
                        sqr = operation.calculateSqr(Convert.ToDouble(txtEntry.Text));
                        txtEntry.Text = sqr.ToString();
                        break;
                    case "btnSqrt":
                        sqrt = operation.calculateSqrt(Convert.ToDouble(txtEntry.Text));
                        txtEntry.Text = sqrt.ToString();
                        break;
                }
            }
        }

        private void equal_Click(object sender, EventArgs e)
        {   
            if(txtEntry.Text != "" && txtEntry.Text != ".")
                currentEntry = Convert.ToDouble(txtEntry.Text);

            if (modPressed == true)
            {
                int dividend = Convert.ToInt32(operand);
                int divisor = Convert.ToInt32(currentEntry);
                modResult = dividend % divisor;
            }
            else if (addPressed == true)
            {
                result = operand + currentEntry;
                addPressed = false;
            }
            else if (subtractPressed == true)
            {
                result = operand - currentEntry;
                subtractPressed = false;
            }
            else if (multiplyPressed == true)
            {
                result = operand * currentEntry;
                multiplyPressed = false;
            }
            else if (dividePressed == true)
            {
                result = operand / currentEntry;
                dividePressed = false;
            }

            lblFormulation.Text = "";
            if(modPressed == true)
            {
                txtEntry.Text = modResult.ToString();
                setFlags(false);
                operand = 0;
            }
            else
            {
                txtEntry.Text = result.ToString();
                setFlags(false);
                operand = 0;
            }
        }

        public void clearEntry_Click(object sender, EventArgs e)
        {
            txtEntry.Text = "";
        }

        public void clear_Click(object sender, EventArgs e)
        {
            clearEntry_Click(sender, e);
            lblFormulation.Text = "";
            operand = 0;
            result = 0;
            setFlags(false);
        }

        private void setFlags(bool state)
        {
            modPressed = state;
            addPressed = state;
            subtractPressed = state;
            multiplyPressed = state;
            dividePressed = state;
            hasAnswer = state;
        }

        private void toggleSign_Click(object sender, EventArgs e)
        {
            if(txtEntry.Text.StartsWith("-"))
            {
                // Remove the sign
                string unsignedNumber = txtEntry.Text.Remove(0, 1);
                txtEntry.Text = unsignedNumber;
            }
            else
            {
                // Insert a negative sign
                string currentEntry = txtEntry.Text;
                txtEntry.Text = currentEntry.Insert(0, "-");
            }
        }
    }
}
