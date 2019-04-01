using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private double _firstNum;
        private double _secondNum;
        private char _mathSign;
        private bool _ifPutMinus = true;
        
                             
        private void _ButtonEquals(object sender, EventArgs e)
        {
            if (_textBox.Text.Length == 0 || _textBox.Text.Equals("-"))
            {
                return;
            }

            _secondNum = Convert.ToDouble(_textBox.Text);

            if (_secondNum == 0 && _mathSign == '/')
            {
                MessageBox.Show("Arithmetic Error");
                return;
            }

            _textBox.Text = "";
            switch (_mathSign)
            {
                case '+':
                    _textBox.Text = Convert.ToString(_firstNum+_secondNum);
                    _mathSign = '=';
                    break;

                case '-':
                    _textBox.Text = Convert.ToString(_firstNum - _secondNum);
                    _mathSign = '=';
                    break;

                case '*':
                    _textBox.Text = Convert.ToString(_firstNum * _secondNum);
                    _mathSign = '=';
                    break;

                case '/':                    
                    _textBox.Text = Convert.ToString(_firstNum / _secondNum);
                    _mathSign = '=';
                    break;

                case '=':
                    break;
            }            
        }
               
        private void _Button6(object sender, EventArgs e) 
        {
            _textBox.Font = _ChangeSizeTextBox(_textBox.Text);
            _textBox.Text += "6";
            _ifPutMinus = false;
        }

        private void _Button3(object sender, EventArgs e) 
        {
            _textBox.Font = _ChangeSizeTextBox(_textBox.Text);
            _textBox.Text += "3";
            _ifPutMinus = false;
        }

        private void _Button1(object sender, EventArgs e) 
        {
            _textBox.Font = _ChangeSizeTextBox(_textBox.Text);
            _textBox.Text += "1";
            _ifPutMinus = false;
        }

        private void _Button4(object sender, EventArgs e) 
        {
            _textBox.Font = _ChangeSizeTextBox(_textBox.Text);
            _textBox.Text += "4";
            _ifPutMinus = false;
        }

        private void _Button7(object sender, EventArgs e) 
        {
            _textBox.Font = _ChangeSizeTextBox(_textBox.Text);
            _textBox.Text += "7";
            _ifPutMinus = false;
        }

        private void _ButtonCleanTextBox(object sender, EventArgs e) 
        {
            _textBox.Text = "";
            _firstNum = 0;
            _secondNum = 0;
            _ifPutMinus = true;
        }

        private void _ButtonDeleteNum(object sender, EventArgs e) 
        {
            _textBox.Font = _ChangeSizeTextBox(_textBox.Text);
            if (_textBox.Text.Length > 0)
            {
                _textBox.Text = _textBox.Text.Substring(0, _textBox.Text.Length - 1);
                _ifPutMinus = false;
                return;
            }
            _ifPutMinus = true;
        }
        
        private void _ButtonDivide(object sender, EventArgs e)
        {
            _ifPutMinus = true;

            _mathSign = '/';

            if (_textBox.Text.Length == 0)
            {
                return;
            }
            _firstNum = Convert.ToDouble(_textBox.Text);
            _textBox.Text = "";
        }

        private void _Button8(object sender, EventArgs e) 
        {
            _textBox.Font = _ChangeSizeTextBox(_textBox.Text);
            _ifPutMinus = false;
            _textBox.Text += "8";
        }

        private void _Button9(object sender, EventArgs e) 
        {
            _textBox.Font = _ChangeSizeTextBox(_textBox.Text);
            _ifPutMinus = false;
            _textBox.Text += "9";
        }

        private void _ButtonMultiply(object sender, EventArgs e) 
        {
            _mathSign = '*';
            _ifPutMinus = true;
            if (_textBox.Text.Length == 0 || _textBox.Text.Equals("-"))
            {
                return;
            }
            _firstNum = Convert.ToDouble(_textBox.Text);
            _textBox.Text = "";
        }

        private void _Button5(object sender, EventArgs e) 
        {
            _textBox.Font = _ChangeSizeTextBox(_textBox.Text);
            _ifPutMinus = false;
            _textBox.Text += "5";
        }

        private void _ButtonMinus(object sender, EventArgs e) 
        {
            if (_ifPutMinus) {
                _textBox.Text = "-";
                _ifPutMinus = false;
                return;
            }
            
            _mathSign = '-';

            if (_textBox.Text.Length == 0 ||_textBox.Text.Equals("-"))
            {
                return;
            }

            _firstNum = Convert.ToDouble(_textBox.Text);
            
            _textBox.Text = "";
        }

        private void _Button2(object sender, EventArgs e)
        {
            _textBox.Font = _ChangeSizeTextBox(_textBox.Text);
            _ifPutMinus = false;
            _textBox.Text += "2";
        }

        private void _ButtonPlus(object sender, EventArgs e) 
        {
            _ifPutMinus = true;
            _mathSign = '+';
            if (_textBox.Text.Length == 0 || _textBox.Text.Equals("-"))
            {
                return;
            }
            _firstNum = Convert.ToDouble(_textBox.Text);
            
            _textBox.Text = "";
        }

        private void _ButtonChangeSignPlusOrMinus(object sender, EventArgs e) 
        {
            _ifPutMinus = false;
            if (_textBox.Text.Length == 0 || _textBox.Text.Equals("-"))
            {
                return;
            }

            double textValue = Convert.ToDouble(_textBox.Text);

            if (textValue == 0)
            {
                return;
            }

            if (textValue > 0)
            {
                _textBox.Text = "-" + _textBox.Text;
                return;
            }

            _textBox.Text = (textValue * -1).ToString();
        }

        private void _Button0(object sender, EventArgs e) 
        {
            _textBox.Font = _ChangeSizeTextBox(_textBox.Text);
            _ifPutMinus = false;
            _textBox.Text += "0";
        }
         
        private void _ButtonComa(object sender, EventArgs e) 
        {
            if (_textBox.Text.Contains(","))
            {
                return;
            }

            _ifPutMinus = false;

            if (_textBox.Text.Length == 0 || _textBox.Text.Equals("-"))
            {
                return;
            }
            _textBox.Text += ",";
        }

        private Font _ChangeSizeTextBox(string textBoxValue)
        {
            if (textBoxValue.Length <= 12) {
                return new Font(_textBox.Font.FontFamily, 20);
            }
                if (textBoxValue.Length > 12)
            {
                return new Font(_textBox.Font.FontFamily, 12);
            }
            return _textBox.Font;
        }
                        
        private void _ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();        
        }

        private void _AboutProgramToolStripMenuItemClick(object sender, EventArgs e) 
        {
            MessageBox.Show("Created by Nadiia Ivanova 2019");
        }

        private void _TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
    }
}
