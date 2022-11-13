using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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

namespace H4_SoftwareSecurity_SymmetricEncryption
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SymmetricAlgorithm mySymmetricAlg;
        public string encryptionType;

        Stopwatch stopwatch = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void encryptionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            encryptionType = (sender as ComboBox).SelectedItem.ToString();

            if (encryptionType == "AES")
            {
                mySymmetricAlg = Aes.Create();
            }
            if (encryptionType == "TripleDES")
            {
                mySymmetricAlg = TripleDES.Create();
            }
        }

        private void mode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string mode = (sender as ComboBox).SelectedItem.ToString();

            if (mode == "CBC")
            {
                mySymmetricAlg.Mode = CipherMode.CBC;
            }
            else if (mode == "ECB")
            {
                mySymmetricAlg.Mode = CipherMode.ECB;
            }
        }

        private void bitSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string bitSize = (sender as ComboBox).SelectedItem.ToString();

            if (encryptionType == "TripleDES")
            {
                mySymmetricAlg.KeySize = 128;
            }
            else if (bitSize == "128")
            {
                mySymmetricAlg.KeySize = 128;
            }
            else if (bitSize == "192")
            {
                mySymmetricAlg.KeySize = 192;
            }
            else if (bitSize == "256")
            {
                mySymmetricAlg.KeySize = 256;
            }
        }

        private void ButtonGenerateKeyAndIV(object sender, RoutedEventArgs e)
        {
            mySymmetricAlg.GenerateKey();
            mySymmetricAlg.GenerateIV();

            Key.Text = Convert.ToBase64String(mySymmetricAlg.Key);
            IV.Text = Convert.ToBase64String(mySymmetricAlg.IV);
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Start();

            string plainText = PlainTextASCII.Text;
            string cipherText = Encrypt(plainText);
            CipherTextASCII.Text = cipherText;

            stopwatch.Stop();
            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
            EncryptTime.Text = stopwatchElapsed.ToString();
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Start();

            string cipherText = CipherTextASCII.Text;
            string plainText = Decrypt(cipherText);
            PlainTextASCII.Text = plainText;

            stopwatch.Stop();
            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
            DecryptTime.Text = stopwatchElapsed.ToString();
        }


        public string Encrypt(string plainText)
        {
            ICryptoTransform transform = mySymmetricAlg.CreateEncryptor();
            byte[] encryptedBytes = transform.TransformFinalBlock(ASCIIEncoding.ASCII.GetBytes(plainText), 0, plainText.Length);
            string encryptedText = Convert.ToBase64String(encryptedBytes);

            return encryptedText;
        }

        public string Decrypt(string cipherText)
        {
            ICryptoTransform transform = mySymmetricAlg.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64String(cipherText);
            byte[] decryptedBytes = transform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            string decryptedText = ASCIIEncoding.ASCII.GetString(decryptedBytes);

            return decryptedText;
        }
    }
}
