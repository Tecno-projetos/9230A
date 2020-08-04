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

            cbAddGroup.Items.Add("Administrador");
            cbAddGroup.Items.Add("Manutenção");
            cbAddGroup.Items.Add("Operador");


        }



        private void btCriarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUser.Text) || String.IsNullOrEmpty(txtSenha.Password) || String.IsNullOrEmpty(txtSenha1.Password) || String.IsNullOrEmpty(cbAddGroup.Text))
            {

                txtTitle.Text = "Campos Vazios";
                txtMessage.Text = "Por favor verifique se todos os campos estão preenchidos";
                pckIcon.Kind = PackIconKind.Error;

                genericButton_Direita.Content = "Fechar";
                genericButton_Esquerda.Content = "Ok";
            }
            else
            {
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


        private void btCriar_Click(object sender, RoutedEventArgs e)
        {
            //if (TBUser.Text == "" || TBPassword.Password == "" || CBGroups.Text == "")
            //{
            //    MessageBox.Show("Por favor verifique se todos os campos estão preenchidos", "Campos Vazios", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else
            //{
            //    char t = Convert.ToChar(TBUser.Text.Substring(0, 1));

            //    if (!char.IsLetter(t))
            //    {
            //        MessageBox.Show("Por favor inicie o nome do usuário com um caracter do alfabeto", "Letra ao iniciar", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    else
            //    {

            //        if ((DataBase.SqlFunctionsUsers.ExistTableDBCA(TBUser.Text)) == true)
            //        {
            //            MessageBox.Show("Conflito de usuário, por favor informe outro nome", "Conflito de Usuários", MessageBoxButton.OK, MessageBoxImage.Error);
            //        }
            //        else
            //        {
            //            DataBase.SqlFunctionsUsers.CreateTableDBCA(TBUser.Text);


            //            DataBase.SqlFunctionsUsers.IntoDateDBCA(TBUser.Text, DataBase.SqlFunctionsUsers.MD5Cryptography(TBPassword.Password), CBGroups.Text, TBEmail.Text, "Created");

            //            //limpa campos
            //            TBUser.Text = "";
            //            TBPassword.Password = "";
            //            TBEmail.Text = "";
            //            CBGroups.Text = "";

            //            //mensagem que criou corretamente
            //            MessageBox.Show("Usuário cadastrado com sucesso!!!", "Cadastro concluido", MessageBoxButton.OK, MessageBoxImage.Information);

            //            //resize window and hidden grid
            //            this.Width = 217;
            //            BTCreatUser.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            //            Enable_Create_User = false;
            //        }
            //    }
            //}
        }

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }
    }
}
