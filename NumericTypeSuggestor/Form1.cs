using System.Numerics;

namespace NumericTypeSuggestor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void IntegralChecked(object sender, EventArgs e)
        {
            PreciseCheckbox.Visible = !IntegralCheckbox.Checked;

            RecalculateSuggestedType();
        }

        private void RecalculateSuggestedType()
        {
            if (IsInputComplete())
            {
                var minValue = BigInteger.Parse(
                    MinInputField.Text);
                var maxValue = BigInteger.Parse(
                    MaxInputField.Text);

                if(maxValue >= minValue)
                {
                    SuggestedTypeLabel.Text = 
                        TypeSuggestor.GetName(
                            minValue,
                            maxValue,
                            IntegralCheckbox.Checked,
                            PreciseCheckbox.Checked);
                    return;
                }
                SuggestedTypeLabel.Text = "not enough data";
            }
        }
        private void SetColorOfMaxValueTextField()
        {
            bool isValid = true;

            if (IsInputComplete())
            {
                var minValue = BigInteger.Parse(
                    MinInputField.Text);
                var maxValue = BigInteger.Parse(
                    MaxInputField.Text);

                if(maxValue < minValue) isValid = false;
            }
            MaxInputField.BackColor = isValid ? 
                Color.WhiteSmoke : Color.IndianRed;
        }

        private bool IsInputComplete() =>
            MinInputField.Text.Length > 0 &&
            MinInputField.Text != "-" &&
            MaxInputField.Text.Length > 0 &&
            MaxInputField.Text != "-";

        private void PreciseCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            RecalculateSuggestedType();
        }

        private void InputField_TextChanged(object sender, EventArgs e)
        {
            RecalculateSuggestedType();
            SetColorOfMaxValueTextField();
        }

        private void InputField_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!IsValidInput(e.KeyChar, textBox))
            {
                e.Handled = true;
            }
        }

        private static bool IsValidInput(char keyChar, TextBox textBox)
        {
            return char.IsControl(keyChar) || char.IsDigit(keyChar)
                || (keyChar == '-' && textBox.SelectionLength == 0);
        }
    }
}
