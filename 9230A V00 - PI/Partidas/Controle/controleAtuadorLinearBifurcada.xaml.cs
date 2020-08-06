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

namespace _9230A_V00___PI.Partidas.Controle
{
    /// <summary>
    /// Interação lógica para controleAtuadorLinearBifurcada.xam
    /// </summary>
    public partial class controleAtuadorLinearBifurcada : UserControl
    {
        public event EventHandler Bt_AbrirEsquerda_Click;
        public event EventHandler Bt_AbrirDireita_Click;
        public event EventHandler Bt_Reset_Click;
        public event EventHandler Bt_Libera_Click;
        public event EventHandler Bt_Manutencao_Click;
        public event EventHandler Bt_Manual_Click;


        public controleAtuadorLinearBifurcada()
        {
            InitializeComponent();
        }

        public void actualize_UI(Utilidades.VariaveisGlobais.type_All Command)
        {


        }

        private void btAbre_Esquerda_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_AbrirEsquerda_Click != null)
                this.Bt_AbrirEsquerda_Click(this, e);

        }

        private void btAbre_Direita_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_AbrirDireita_Click != null)
                this.Bt_AbrirDireita_Click(this, e);
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Reset_Click != null)
                this.Bt_Reset_Click(this, e);
        }

        private void btLibera_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Libera_Click != null)
                this.Bt_Libera_Click(this, e);
        }

        private void btManutencao_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Manutencao_Click != null)
                this.Bt_Manutencao_Click(this, e);
        }

        private void btManual_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Manual_Click != null)
                this.Bt_Manual_Click(this, e);
        }
    }
}
