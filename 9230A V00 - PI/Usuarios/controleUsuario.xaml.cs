﻿using System;
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
    /// Interação lógica para controleUsuario.xam
    /// </summary>
    public partial class controleUsuario : UserControl
    {
        adicionarUsuario addUser = new adicionarUsuario();



        public controleUsuario()
        {
            InitializeComponent();
        }

        private void btCriarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (spControleUsuario != null)
            {
                spControleUsuario.Children.Clear();

                spControleUsuario.Children.Add(addUser);
            }
            else
            {
                spControleUsuario.Children.Add(addUser);
            }
        }
    }
}
