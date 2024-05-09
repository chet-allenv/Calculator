using System;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        // Variable Declaration
        private string currentNumber = string.Empty; // Creates the current number string and sets it to an empty string
        private string mathOperation = string.Empty; // Creates the math operator string and sets it to an empty string
        private string firstNumber = string.Empty; // Creates the first number string and sets it to an empty string
        private string secondNumber = string.Empty; // Creates the second number string and sets it to an empty string

        // Creates the isCalculated boolean flagger that is flagged when an equation is calculated
        private bool isCalculated = false;

        // Constructor
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs when the MainForm for the calculator is loaded
        /// </summary>
        /// <param name="sender"> Object sending the event. </param>
        /// <param name="e"> Event arguments. </param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Sets the currentNumber string to a 0
            currentNumber = "0";

            // Sets the main label's text to the currentNumber
            label1.Text = currentNumber;
        }

        /// <summary>
        /// A generic method for when a button with a number on it is pressed. Also includes the decimal point. 
        /// Adds to the current number until the max of 9 characters is reached.
        /// </summary>
        /// <param name="sender"> Object sending the event. </param>
        /// <param name="e"> Event arguments. </param>
        private void Generic_NumberButton_Click(object sender, EventArgs e)
        {
            // Creates a Button instance of the sender. This is because every possible sender will be a Button.
            Button clickedButton = (Button)sender;

            // If the currentNumber is 9 characters long, returns out of the method.
            if (currentNumber.Length == 9)
            {
                return;
            }

            // Checks if the number is 0 or that the text box says ERROR which happens when a number is divided by 0
            if (currentNumber.Equals("0") || currentNumber.Equals("ERROR"))
            {
                currentNumber = clickedButton.Text; // sets the curentNumber to the clickedButton's text
            }
            else if (isCalculated) // If the isCalculated flag is active
            {
                currentNumber = clickedButton.Text; // Sets the currentNumber to the clickedButton's text
                isCalculated = false; // Resets the isCalculated flag
            }
            else
            {
                currentNumber += clickedButton.Text; // Adds the clickedButton's text to the currentNumber
            }
            
            label1.Text = currentNumber; // Writes the currentNumber to the label's text

            // Debugger code that writes the currentNumber to the console.
            // Debug.WriteLine(currentNumber);
        }

        // THESE METHODS CALL THE Generic_NumberButton_Click() METHOD USING THEIR PARAMETERS.
        // ALL DO THE SAME FUNCTION, UNLESS OTHERWISE NOTED AND SEE THE Generic_NumberButton_Click()
        // METHOD'S DOCUMENTATION FOR A BETTER UNDERSTANDING.
        private void button1_Click(object sender, EventArgs e)
        {
            Generic_NumberButton_Click(sender , e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Generic_NumberButton_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Generic_NumberButton_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Generic_NumberButton_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Generic_NumberButton_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Generic_NumberButton_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Generic_NumberButton_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Generic_NumberButton_Click(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Generic_NumberButton_Click(sender, e);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            // Checks that if the currentNumber doesn't already equal zero so that it avoids having unnecessary zeros.
            if (currentNumber.Equals("0"))
            {
                return; // Returns out of the method so that it isn't ran any further
            }
            // Calls the Generic_NumberButton_Click() method just like all other number buttons
            Generic_NumberButton_Click(sender, e);
        }

        // VERY SIMILAR TO THE NUMBER BUTTONS
        private void buttonPoint_Click(object sender, EventArgs e)
        {
            // Checks that if the currentNumber doesn't already have a decimal point so that it avoids having multiple decimal points.
            if (currentNumber.Contains('.'))
            {
                return;// Returns out of the method so that it isn't ran any further
            }
            // Calls the Generic_NumberButton_Click() method just like all other number buttons
            Generic_NumberButton_Click(sender, e);
        }

        /// <summary>
        /// Clear button that clears the currentNumber and sets it to a 0.
        /// </summary>
        /// <param name="sender"> Object sending the event. </param>
        /// <param name="e"> Event arguments. </param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            // Sets currentNumber to a 0 effectively clearing the number
            currentNumber = "0";

            // Sets the label1 text to the current number
            label1.Text = currentNumber;
        }

        /// <summary>
        /// This is the method when the +/- button is pressed that changes the sign of the number
        /// </summary>
        /// <param name="sender"> Object sending the event. </param>
        /// <param name="e"> Event arguments. </param>
        private void buttonSign_Click(object sender, EventArgs e)
        {
            // Checks if the current number is 0, if so returns out of the method as 0 can't be negative
            if (currentNumber.Equals("0"))
            {
                return;
            }
            else if (currentNumber[0] != '-') // If the first character is NOT a negative sign
            {
                if (currentNumber.Length == 9) // If the currenNumber is greater than 9, it truncates the last number
                {
                    currentNumber = currentNumber.Remove(8);
                }

                // Adds a negative sign to the beginning of the currentNumber string
                currentNumber = "-" + currentNumber;
            }
            else // If the character is a NEGATIVE
            {
                currentNumber = currentNumber.Remove(0, 1); // Removes the first character, which will be the negative sign
            }

            label1.Text = currentNumber; // Sets the label1 to the currentNumber
        }

        /// <summary>
        /// This is a generic method for math operation buttons (+, -, *, /)
        /// </summary>
        /// <param name="sender"> Object sending the event. </param>
        /// <param name="e"> Event arguments. </param>
        private void Generic_MathOPButton_Click(object sender, EventArgs e)
        {
            // Sets isCalculated to false to prevent numbers needing to be entered twice if using the answer of a previous equation
            // as the first number of an equation
            isCalculated = false; 

            if (!mathOperation.Equals(string.Empty)) // Checks if the mathOperation string is NOT empty. If so it returns out of the method.
            {
                return;
            }

            // Creates a new Button object from the sender that will always be a button
            Button buttonClicked = (Button)sender;

            mathOperation = buttonClicked.Text; // Sets the mathOperation string to the text of the pressed math operation button
            firstNumber = currentNumber; // Sets first number to the current number
            currentNumber = "0"; // Sets current number to a 0, resetting current number
            label1.Text = currentNumber; // Sets the label1's text to the current number
            
            // Sets label2's text to the first number plus the pressed operation to help the user remember if needed
            label2.Text = $"{firstNumber} {mathOperation}"; 
        }

        // THESE METHODS CALL THE Generic_MathOPButton_Click() METHOD USING THEIR PARAMETERS.
        // ALL DO THE SAME FUNCTION, UNLESS OTHERWISE NOTED AND SEE THE Generic_MathOPButton_Click()
        // METHOD'S DOCUMENTATION FOR A BETTER UNDERSTANDING.
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Generic_MathOPButton_Click(sender, e);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            Generic_MathOPButton_Click(sender, e);
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            Generic_MathOPButton_Click(sender, e);
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            Generic_MathOPButton_Click(sender, e);
        }

        /// <summary>
        /// This serves as the event for when the Enter button is clicked. It finalizes the calculation and outputs a number.
        /// </summary>
        /// <param name="sender"> Object sending the event. </param>
        /// <param name="e"> Event arguments. </param>
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            // Checks if firstNumber is empty and returns out of the method. This prevents the user from pressing enter and getting an error
            if (firstNumber.Equals(string.Empty))
            {
                return;
            }

            // Sets secondNumber to the cuirrent number
            secondNumber = currentNumber;

            // Creates several double values by parsing the strings to doubles.
            double firstInt = Double.Parse(firstNumber);
            double secondInt = Double.Parse(secondNumber);

            // Creates the output value that will store the result of the operation
            double outputInt = 0; 

            // Creates a flag that is raised when there is an operation error. (DIVIDING BY 0)
            bool isOperatingError = false;

            switch (mathOperation) // A switch statement that checks the value of the mathOperation string.
            {
                case "+": // If mathOperation equals +
                    outputInt = firstInt + secondInt; // Sets the result variable to the result of adding the two numbers
                    break;
                case "-": // If mathOperation equals -
                    outputInt = firstInt - secondInt; // Sets the result variable to the result of subtracting the second from the first
                    break;
                case "*": // If mathOperation equals *
                    outputInt = firstInt * secondInt; // Sets the result variable to the result of multiplying the two numbers
                    break;
                case "/": // If mathOperation equals /
                    if (secondInt == 0) // Checks if the second int is equal to zero. If true,
                    {
                        isOperatingError = true; // Raises the isOperatingError flag.
                    }
                    else
                    {
                        outputInt = firstInt / secondInt; // Sets the result variable to the result of dividing the second from the first
                    }
                    break;
            } 
            
            // Checks if the isOperatingError flag was raised
            if (isOperatingError) // IF SO
            {
                currentNumber = "ERROR"; // Sets the currentNumber to ERROR
            }
            else // IF NOT
            {
                // Sets the current number to the string of the resulting number
                currentNumber = outputInt.ToString();
                
                // If the new currentNumber is longer than 9, it changes the number to its corresponding scientific notation form.
                if (currentNumber.Length > 9)
                {
                    currentNumber = $"{outputInt:E3}"; // truncates the number to the first 4 significant figures.
                }
            }

            // Stores the last equation in the Text of label2
            label2.Text = $"{firstNumber} {mathOperation} {secondNumber} = {currentNumber}";

            label1.Text = currentNumber; // Sets label1's text to the result number.

            isCalculated = true; // Sets the isCalculated flag to true

            // Resets the first and second number strings to empty as well as the mathOperation string
            firstNumber = string.Empty; 
            secondNumber = string.Empty;
            mathOperation = string.Empty;
        }
    }
}
