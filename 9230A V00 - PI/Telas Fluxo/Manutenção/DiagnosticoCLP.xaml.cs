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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _9230A_V00___PI.Telas_Fluxo.Manutenção
{
    /// <summary>
    /// Interaction logic for DiagnosticoCLP.xaml
    /// </summary>
    public partial class DiagnosticoCLP : UserControl
    {
        public DiagnosticoCLP()
        {
            InitializeComponent();

            wbSample.Navigate("http://192.168.0.10");
        }

		private void txtUrl_KeyUp(object sender, KeyEventArgs e)
		{
            try
            {
                if (e.Key == Key.Enter)
                    wbSample.Navigate(txtUrl.Text);
            }
            catch (Exception)
            {

            }

		}

		private void wbSample_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
		{
			txtUrl.Text = e.Uri.OriginalString;
		}

		private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = ((wbSample != null) && (wbSample.CanGoBack));
		}

		private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = ((wbSample != null) && (wbSample.CanGoForward));
		}

		private void GoToPage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
			wbSample.Navigate("http://192.168.0.10");
		}

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wbSample.Navigate(txtUrl.Text);
            }
            catch (Exception)
            {
            }
			
		}

        private void browsebackward_Click(object sender, RoutedEventArgs e)
        {
			
            try
            {
				wbSample.GoBack();
			}
            catch (Exception)
            {
            }

		}

        private void BrowseForward_Click(object sender, RoutedEventArgs e)
        {
            try
			{
				wbSample.GoForward();
			}
            catch (Exception)
            {

            }

		}
    }
}
