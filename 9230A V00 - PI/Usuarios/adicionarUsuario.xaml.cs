using _9230A_V00___PI.Utilidades;
using MaterialDesignThemes.Wpf;
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

namespace _9230A_V00___PI.Usuarios
{
    /// <summary>
    /// Interação lógica para adicionarUsuario.xam
    /// </summary>
    public partial class adicionarUsuario : UserControl
    {
        public adicionarUsuario()
        {
            InitializeComponent();

        }



        private void btCriarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUser.Text) || String.IsNullOrEmpty(txtSenha.Password) || String.IsNullOrEmpty(txtSenha1.Password))
            {

                txtTitle.Text = "Campos Vazios";
                txtMessage.Text = "Por favor verifique se todos os campos estão preenchidos";
                pckIcon.Kind = PackIconKind.Error;

                genericButton_Direita.Content = "Fechar";
                genericButton_Esquerda.Content = "Ok";
            }
            else
            {
                if (true)
                {

                }
                if (txtSenha.Password.Equals(txtSenha1.Password))
                {
                    char t = Convert.ToChar(txtUser.Text.Substring(0, 1));

                    if (!char.IsLetter(t))
                    {
                        txtTitle.Text = "Letra ao iniciar";
                        txtMessage.Text = "Por favor inicie o nome do usuário com um caracter do alfabeto";
                        pckIcon.Kind = PackIconKind.Error;

                        genericButton_Direita.Content = "Fechar";
                        genericButton_Esquerda.Content = "Ok";

                    }
                    else
                    {
                        if ((DataBase.SqlFunctionsUsers.ExistTableDBCA(txtUser.Text)) == true)
                        {

                            txtTitle.Text = "Conflito de Usuários";
                            txtMessage.Text = "Esse nome de usuário já existe, por favor informe outro nome";
                            pckIcon.Kind = PackIconKind.Error;

                            genericButton_Direita.Content = "Fechar";
                            genericButton_Esquerda.Content = "Ok";

                        }
                        else
                        {
                            DataBase.SqlFunctionsUsers.CreateTableDBCA(txtUser.Text);

                            string groupUser = "";

                            //if ((bool)rbManutencao.IsChecked)
                            //{
                            //    groupUser = "Manutenção";
                            //}
                            //else if ((bool)rbOperador.IsChecked)
                            //{
                            //    groupUser = "Operador";
                            //}
                            //else if ((bool)rbAdministrador.IsChecked)
                            //{
                            //    groupUser = "Administrador";
                            //}


                            DataBase.SqlFunctionsUsers.IntoDateDBCA(txtUser.Text, DataBase.SqlFunctionsUsers.MD5Cryptography(txtSenha.Password), groupUser, txtEmail.Text, "Created");


                            //mensagem que criou corretamente
                            txtTitle.Text = "Usuário Criado";
                            txtMessage.Text = "Usuário " + txtUser.Text + " cadastrado com sucesso!";
                            pckIcon.Kind = PackIconKind.UserAdd;

                            genericButton_Direita.Content = "Fechar";
                            genericButton_Esquerda.Content = "Ok";


                            //limpa campos
                            txtUser.Text = "";
                            txtSenha.Password = "";
                            txtSenha1.Password = "";
                            txtEmail.Text = "";


                        }
                    }
                }
                else
                {
                    txtTitle.Text = "Senhas não conhecidem";
                    txtMessage.Text = "Por favor as senhas não conhecidem, digitar novamente o campo senha";
                    pckIcon.Kind = PackIconKind.Error;

                    genericButton_Direita.Content = "Fechar";
                    genericButton_Esquerda.Content = "Ok";

                }
            }
        }

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }

        private void DialogHost_LostFocus(object sender, RoutedEventArgs e)
        {
            if (dialogHost.IsOpen)
            {
                dialogHost.IsOpen = false;
            }

        }

        private void lbAdm_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lbAdm.IsSelected)
            {
                pckAdm.Visibility = Visibility.Visible;
                pckMan.Visibility = Visibility.Hidden;
                pckOperador.Visibility = Visibility.Hidden;

            }
        }

        private void lbManutencao_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lbManutencao.IsSelected)
            {
                pckAdm.Visibility = Visibility.Hidden;
                pckMan.Visibility = Visibility.Visible;
                pckOperador.Visibility = Visibility.Hidden;
            }
        }

        private void lbOperador_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lbOperador.IsSelected)
            {
                pckAdm.Visibility = Visibility.Hidden;
                pckMan.Visibility = Visibility.Hidden;
                pckOperador.Visibility = Visibility.Visible;
            }
        }
    }
}
