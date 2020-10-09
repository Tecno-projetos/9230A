using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using SimpleWifi;




namespace _9230A_V00___PI.Telas_Fluxo.Manutenção
{
    /// <summary>
    /// Interação lógica para controleWifi.xam
    /// </summary>
    public partial class controleWifi : UserControl
    {
        private static Wifi wifi;

        private int idexOLD = -1;
        private int idexNew = 0;

        public controleWifi()
        {
            InitializeComponent();

  
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Atualizalistbox();

        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                idexNew = listbox.SelectedIndex;

                if (idexNew != -1)
                {
                    var row_list = (ListBoxItem)listbox.Items[idexNew];

                    if (idexNew != idexOLD)
                    {
                        row_list.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                        row_list.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));


                        if (idexOLD != -1)
                        {
                            var row_listOld = (ListBoxItem)listbox.Items[idexOLD];
                            row_listOld.Background = new SolidColorBrush(Color.FromRgb(60, 60, 60));
                            row_listOld.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        }

                        idexOLD = idexNew;
                    }
                }
            }
            catch (Exception ex)
            {


            }

        }


        private void btConnect_Click(object sender, RoutedEventArgs e)
        {
            if (listbox.Items.Count > 0 && txtSenha.Password.Length > 0 & idexNew >= 0)
            {

                ListBoxItem selectedItem = (ListBoxItem)listbox.SelectedItems[0];
                AccessPoint ap = (AccessPoint)selectedItem.Tag;
                connectWifi(ap, txtSenha.Password);



            }
        }

        private void btDesconectar_Click(object sender, RoutedEventArgs e)
        {
            if (wifi.ConnectionStatus == WifiStatus.Connected)
            {
                wifi.Disconnect();

 
            }
        }


        private void senha_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Utilidades.messageBox inputDialog;

            inputDialog = new Utilidades.messageBox("Confirmação Senha", "A senha digita é: " + txtSenha.Password, MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

            inputDialog.ShowDialog();
        }

        private void btRefresh_Click(object sender, RoutedEventArgs e)
        {
            Atualizalistbox();
        }

        private void PackIcon_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Utilidades.messageBox inputDialog;

            inputDialog = new Utilidades.messageBox("Confirmação Senha", "A senha digita é: " + txtSenha.Password, MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

            inputDialog.ShowDialog();

        }

        #region Funções
        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Teclados.keyboard.openKeyboard();

            }
            catch (Exception ex)
            {
                Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
            }
        }

        private void connectWifi(AccessPoint ap, string password)
        {
            AuthRequest authRequest = new AuthRequest(ap);
            authRequest.Password = password;

            ap.ConnectAsync(authRequest);

        }

        private void Atualizalistbox()
        {
            try
            {
                if (listbox.Items.Count > 0)
                {
                    listbox.Items.Clear();
                }

                wifi = new Wifi();

                List<AccessPoint> aps = wifi.GetAccessPoints();

                int count = 0;

                foreach (AccessPoint ap in aps)
                {

                    ListBoxItem boxItem = new ListBoxItem();

                    boxItem.Name = "_" + count;
                    boxItem.Width = 300;
                    boxItem.Tag = ap;
                    boxItem.Background = new SolidColorBrush(Color.FromRgb(60, 60, 60));
                    boxItem.Content = "Nome = " + ap.Name + "  Sinal = " + ap.SignalStrength;
                    boxItem.FontSize = 16;
                    boxItem.Foreground = new SolidColorBrush(Colors.White);
                    boxItem.VerticalAlignment = VerticalAlignment.Center;
                    boxItem.HorizontalAlignment = HorizontalAlignment.Center;
                    Thickness margin = boxItem.Margin;
                    margin.Top = 5;
                    boxItem.Margin = margin;

                    count++;

                    listbox.Items.Add(boxItem);

                }
            }
            catch (Exception)
            {


            }

        }


        #endregion

        public void atualizaConexao() 
        {
            wifi = new Wifi();

            List<AccessPoint> aps = wifi.GetAccessPoints();

            bool possui = false;

            foreach (AccessPoint ap in aps)
            {
                if (ap.IsConnected)
                {
                    lbConectado.Content = "Conectado";
                    lbNomeWifi.Content = ap.Name;

                    possui = true;
                    break;
                }
            }

            if (!possui)
            {
                lbConectado.Content = "Desconectado";
                lbNomeWifi.Content = "-------";
            }
        }

    }
}
