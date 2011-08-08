using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Soggiorni
{
    /// <summary>
    /// Interaction logic for SettingsNotifichePremiWindow.xaml
    /// </summary>
    public partial class SettingsNotifichePremiWindow : Window
    {
        public SettingsNotifichePremiWindow()
        {
            InitializeComponent();

            txtboxNumNot.Text = Properties.Settings.Default.CadenzaPremioSoggiorni.ToString();
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = int.Parse(txtboxNumNot.Text);
                if (num <= 1)
                {
                    MessageBox.Show("Il numero inserito non è valido", "Errore range input", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Properties.Settings.Default.CadenzaPremioSoggiorni = num;
                Properties.Settings.Default.Save();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Il numero di soggiorni deve essere un intero", "Errore formato input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.DialogResult = true;
        }


    }
}
