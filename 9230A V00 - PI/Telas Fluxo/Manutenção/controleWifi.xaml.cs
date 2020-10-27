using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
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

        private bool abriuTela = false;

        Utilidades.messageBox inputDialog;

        private int idexOLD = -1;
        private int idexNew = 0;

        public controleWifi()
        {
            InitializeComponent();


        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Atualizalistbox();

            abriuTela = true;
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
                else
                {
                    idexOLD = -1;
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
            else
            {
                inputDialog = new Utilidades.messageBox("Digite uma senha válida no campo senha!", "Digite uma senha válida", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                inputDialog.ShowDialog();
            }

        }

        private void btDesconectar_Click(object sender, RoutedEventArgs e)
        {
            if (wifi.ConnectionStatus == WifiStatus.Connected)
            {
                wifi.Disconnect();


            }

            txtSenha.Password = "";
        }


        private void senha_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
         

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
                    boxItem.Content =  ap.Name + "  Sinal = " + ap.SignalStrength;
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
            if (abriuTela)
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

                        lbIpexterno.Content = "IP Externo: " + GetExternalIp();
                        lbIpinterno.Content = "IP Local: " + GetLocalIPAddress();

                        possui = true;
                        break;
                    }
                }

                if (!possui)
                {
                    lbConectado.Content = "Desconectado";
                    lbNomeWifi.Content = "-------";

                    lbIpexterno.Content = "IP Externo: ---.---.---.---";
                    lbIpinterno.Content = "IP Local: ---.---.---.---";
                }

           
                if (wifi.ConnectionStatus == WifiStatus.Connected)
                {
                    btConnect.IsEnabled = false;
                    btDesconectar.IsEnabled = true;

                }
                else
                {
                    btDesconectar.IsEnabled = false;
                    btConnect.IsEnabled = true;
                }
              
            }
        }

        private static string GetExternalIp()
        {
            try
            {
               string externalip = new WebClient().DownloadString("https://ipv4.icanhazip.com/");
  
                return externalip.TrimEnd();
            }
            catch (Exception)
            {
                return "IP Externo: ---.---.---.---";
            }

        }
        public static string GetLocalIPAddress()
        {
            //Código para pegar todos os nomes Wi-fi e conexão local.

            //foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            //{
            //    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            //    {
            //        Console.WriteLine(ni.Name);
            //        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
            //        {
            //            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            //            {
            //                Console.WriteLine(ip.Address.ToString());
            //            }
            //        }
            //    }
            //}



            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)


                    if (ni.Name.Contains("Wi"))
                    {
                        //Console.WriteLine(ni.Name);
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                //Console.WriteLine(ip.Address.ToString());
                                return ip.Address.ToString();
                               
                            }
                        }
                    }
            }

            return "";


            //NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            //foreach (NetworkInterface adapter in adapters)
            //{

            //    IPInterfaceProperties properties = adapter.GetIPProperties();


            //    Console.WriteLine(adapter.Description);
            //    Console.WriteLine("  DNS suffix .............................. : {0}",
            //        properties.DnsSuffix);
            //    Console.WriteLine("  DNS enabled ............................. : {0}",
            //        properties.IsDnsEnabled);
            //    Console.WriteLine("  Dynamically configured DNS .............. : {0}",
            //        properties.IsDynamicDnsEnabled);
            //}
   
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            abriuTela = false;

        }
    }
}
