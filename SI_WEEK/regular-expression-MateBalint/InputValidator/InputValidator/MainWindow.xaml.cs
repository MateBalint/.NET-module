using System;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace InputValidator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Regex nameRegex = new Regex(@"^[\p{L} \.\-]+$");
            //Regex phoneRegex = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})");
            Regex emailRegex = new Regex("(?<user>[^@]+)@(?<host>.+)");
            Regex phoneRegex = new Regex(@"_^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$_");

            InformationValidation.ValidateName(txtName, nameRegex);
            InformationValidation.ValidatePhone(txtPhone, phoneRegex);
            InformationValidation.ValidateEmail(txtEmail, emailRegex);
            string formattedPhone = InformationValidation.ReformatPhone(txtPhone.Text);
            txtPhone.Text = formattedPhone;
        }
    }

    public class InformationValidation
    {
        public static void ValidateName(TextBox txtName, Regex nameRegex)
        {
            if (!Regex.IsMatch(txtName.Text, nameRegex.ToString()))
            {
                MessageBox.Show("The name is invalid.");
            }
        }

        public static void ValidatePhone(TextBox txtPhone, Regex phoneRegex)
        {
            if (!Regex.IsMatch(txtPhone.Text, phoneRegex.ToString()))
            {
                MessageBox.Show("The phone number is invalid.");
            }
        }

        public static void ValidateEmail(TextBox txtEmail, Regex emailRegex)
        {
            if (!Regex.IsMatch(txtEmail.Text, emailRegex.ToString()))
            {
                MessageBox.Show("Invalid E-mail address.");
            }
        }

        public static string ReformatPhone(string phoneNumber)
        {
            //string formatPhoneRegex = @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$";
            //string result = Regex.Replace(phoneNumber, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");

            string result = string.Format("{0:(###) ###-####}", phoneNumber);

            return result;
        } 
    }
}
