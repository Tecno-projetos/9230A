using _9230A_V00___PI.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace _9230A_V00___PI.Telas_Fluxo.Controle_Produção
{
    /// <summary>
    /// Interaction logic for TelaStatusProducao.xaml
    /// </summary>
    public partial class TelaStatusProducao : UserControl
    {
        int slotSolicitado = 0;

        public int SlotSolicitado { get => slotSolicitado; set => slotSolicitado = value; }

        public TelaStatusProducao()
        {
            InitializeComponent();
        }

        private void btLeftList_Produtos_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Produtos, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset - 20);
        }

        private void btDownList_Produtos_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Produtos, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset + 5);
        }

        private void btRightList_Produtos_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Produtos, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset + 20);
        }

        private void btUpList_Produtos_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Produtos, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset - 5);
        }


        public void atualizaGridProdutos(Utilidades.VariaveisGlobais.SlotBatelada batelada)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Produto");
            dt.Columns.Add("Peso");
            dt.Columns.Add("Peso Dosado");

            foreach (var item in Utilidades.VariaveisGlobais.ProducaoReceita.batelada[batelada.NumeroBatelada -1].produtos)
            {
                DataRow dr = dt.NewRow();

                dr["Produto"] = item.descricao;
                dr["Peso"] = item.pesoDesejado;
                dr["Peso Dosado"] = item.pesoDosado;

                dt.Rows.Add(dr);
            }

            DataGrid_Produtos.Dispatcher.Invoke(delegate { DataGrid_Produtos.ItemsSource = dt.DefaultView; });
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var teste = slotSolicitado;


            atualizaStatusSlots();
        }

        private void btSlot1_Click(object sender, RoutedEventArgs e)
        {
            SlotSolicitado = 1;
            atualizaStatusSlots();
        }

        private void btSlot2_Click(object sender, RoutedEventArgs e)
        {
            SlotSolicitado = 2;
            atualizaStatusSlots();
        }

        private void btSlot3_Click(object sender, RoutedEventArgs e)
        {
            SlotSolicitado = 3;
            atualizaStatusSlots();
        }

        private void atualizaStatusSlots()
        {
            if (SlotSolicitado ==1)
            {
                btSlot1.Background = new SolidColorBrush(Colors.Green);
                btSlot2.Background = new SolidColorBrush(Colors.Gray);
                btSlot3.Background = new SolidColorBrush(Colors.Gray);
                lb_Status_Batelada = Utilidades.functions.controleStatus(VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Status_Batelada, lb_Status_Batelada);

                //Atualiza produtos no data grid
                atualizaGridProdutos(VariaveisGlobais.executaProducao.ControleExecucao.Slot_1);


                //Atualiza o botão 
                if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pre.Item_Atual_Iniciado_Dosagem ||
                    VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pos.Item_Atual_Iniciado_Dosagem
                    )
                {
                    if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pre.Item_Atual_Finalizado_Dosagem ||
                        VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pos.Item_Atual_Finalizado_Dosagem
                        )
                    {
                        btDosarManual.Background = new SolidColorBrush(Colors.Orange);
                        txtDosarManual.Foreground = new SolidColorBrush(Colors.Black);
                        txtDosarManual.Text = "Salvando Valor Dosagem";
                    }
                    else
                    {
                        btDosarManual.Background = new SolidColorBrush(Colors.Orange);
                        txtDosarManual.Foreground = new SolidColorBrush(Colors.Black);
                        txtDosarManual.Text = "Finalizar Dosagem Manual";
                    }
                }
                else
                {
                    if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pre.Habilitado_Inicio_Dosagem ||
                        VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pos.Habilitado_Inicio_Dosagem
                        )
                    {
                        btDosarManual.Background = new SolidColorBrush(Colors.Yellow);
                        txtDosarManual.Foreground = new SolidColorBrush(Colors.Black);
                        txtDosarManual.Text = "Iniciar Dosagem Manual";
                    }
                    else
                    {
                        btDosarManual.Background = new SolidColorBrush(Colors.Gray);
                        txtDosarManual.Foreground = new SolidColorBrush(Colors.Black);
                        txtDosarManual.Text = "Salvando Valor Dosagem";
                    }
                }

            }
            else if (SlotSolicitado == 2)
            {
                btSlot1.Background = new SolidColorBrush(Colors.Gray);
                btSlot2.Background = new SolidColorBrush(Colors.Green);
                btSlot3.Background = new SolidColorBrush(Colors.Gray);
                lb_Status_Batelada = Utilidades.functions.controleStatus(VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Status_Batelada, lb_Status_Batelada);

                //Atualiza o botão 
                if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pre.Item_Atual_Iniciado_Dosagem ||
                    VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pos.Item_Atual_Iniciado_Dosagem
                    )
                {
                    if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pre.Item_Atual_Finalizado_Dosagem ||
                        VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pos.Item_Atual_Finalizado_Dosagem
                        )
                    {
                        btDosarManual.Background = new SolidColorBrush(Colors.Orange);
                        txtDosarManual.Foreground = new SolidColorBrush(Colors.Black);
                        txtDosarManual.Text = "Salvando Valor Dosagem";
                    }
                    else
                    {
                        btDosarManual.Background = new SolidColorBrush(Colors.Orange);
                        txtDosarManual.Foreground = new SolidColorBrush(Colors.Black);
                        txtDosarManual.Text = "Finalizar Dosagem Manual";
                    }
                }
                else
                {
                    if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pre.Habilitado_Inicio_Dosagem ||
                        VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pos.Habilitado_Inicio_Dosagem
                        )
                    {
                        btDosarManual.Background = new SolidColorBrush(Colors.Yellow);
                        txtDosarManual.Foreground = new SolidColorBrush(Colors.Black);
                        txtDosarManual.Text = "Iniciar Dosagem Manual";
                    }
                    else
                    {
                        btDosarManual.Background = new SolidColorBrush(Colors.Gray);
                        txtDosarManual.Foreground = new SolidColorBrush(Colors.Black);
                        txtDosarManual.Text = "Salvando Valor Dosagem";
                    }
                }

                atualizaGridProdutos(VariaveisGlobais.executaProducao.ControleExecucao.Slot_2);
            }
            else if (SlotSolicitado == 3)
            {
                btSlot1.Background = new SolidColorBrush(Colors.Gray);
                btSlot2.Background = new SolidColorBrush(Colors.Gray);
                btSlot3.Background = new SolidColorBrush(Colors.Green);
                lb_Status_Batelada = Utilidades.functions.controleStatus(VariaveisGlobais.executaProducao.ControleExecucao.Slot_3.Status_Batelada, lb_Status_Batelada);

                atualizaGridProdutos(VariaveisGlobais.executaProducao.ControleExecucao.Slot_3);
            }

            
        }

        private void DataGrid_Produtos_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            int IndexAtual = e.Row.GetIndex();

            //Verifica o slot que esta selecionado
            if (SlotSolicitado == 1)
            {
                //Verifica o item atual é o mesmo que o produto atual que esta em produção
                if (IndexAtual == VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Produto_Atual_Em_Producao)
                {
                    if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pre.Habilitado_Inicio_Dosagem ||
                        VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pos.Habilitado_Inicio_Dosagem
                        )
                    {
                        e.Row.Background = new SolidColorBrush(Colors.Yellow);
                        e.Row.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    }
                    else
                    {
                        e.Row.Background = new SolidColorBrush(Colors.ForestGreen);
                        e.Row.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    }

                }
            }
            else if (SlotSolicitado == 2)
            {
                //Verifica o item atual é o mesmo que o produto atual que esta em produção
                if (IndexAtual == VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Produto_Atual_Em_Producao)
                {
                    if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pre.Habilitado_Inicio_Dosagem ||
                        VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pos.Habilitado_Inicio_Dosagem
                        )
                    {
                        e.Row.Background = new SolidColorBrush(Colors.Yellow);
                        e.Row.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    }
                    else
                    {
                        e.Row.Background = new SolidColorBrush(Colors.ForestGreen);
                        e.Row.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    }

                }
            }
            else if (SlotSolicitado == 3)
            {
                //Verifica o item atual é o mesmo que o produto atual que esta em produção
                if (IndexAtual == VariaveisGlobais.executaProducao.ControleExecucao.Slot_3.Produto_Atual_Em_Producao)
                {
                    if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_3.Complemento_Pre.Habilitado_Inicio_Dosagem ||
                        VariaveisGlobais.executaProducao.ControleExecucao.Slot_3.Complemento_Pos.Habilitado_Inicio_Dosagem
                        )
                    {
                        e.Row.Background = new SolidColorBrush(Colors.Yellow);
                        e.Row.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    }
                    else
                    {
                        e.Row.Background = new SolidColorBrush(Colors.ForestGreen);
                        e.Row.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    }

                }
            }


        }

        private void btDosarManual_Click(object sender, RoutedEventArgs e)
        {
            //SLOT 1 PRÉ
            if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pre.Habilitado_Inicio_Dosagem ||
                (VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pre.Item_Atual_Iniciado_Dosagem && !VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pre.Item_Atual_Finalizado_Dosagem)
                )
            {
                VariaveisGlobais.executaProducao.InicioDosagemManualComplementoPre(SlotSolicitado);
            }
            //SLOT 1 POS
            if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pos.Habilitado_Inicio_Dosagem ||
                (VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pos.Item_Atual_Iniciado_Dosagem && !VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.Complemento_Pos.Item_Atual_Finalizado_Dosagem)
                )
            {
                VariaveisGlobais.executaProducao.InicioDosagemManualComplementoPos(SlotSolicitado);
            }

            //SLOT 2 PRÉ
            if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pre.Habilitado_Inicio_Dosagem ||
                (VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pre.Item_Atual_Iniciado_Dosagem && !VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pre.Item_Atual_Finalizado_Dosagem)
                )
            {
                VariaveisGlobais.executaProducao.InicioDosagemManualComplementoPre(SlotSolicitado);
            }

            //SLOT 2 PÓS
            if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pos.Habilitado_Inicio_Dosagem ||
                (VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pos.Item_Atual_Iniciado_Dosagem && !VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.Complemento_Pos.Item_Atual_Finalizado_Dosagem)
                )
            {
                VariaveisGlobais.executaProducao.InicioDosagemManualComplementoPos(SlotSolicitado);
            }

            //SLOT 3 PRÉ
            if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_3.Complemento_Pre.Habilitado_Inicio_Dosagem ||
                (VariaveisGlobais.executaProducao.ControleExecucao.Slot_3.Complemento_Pre.Item_Atual_Iniciado_Dosagem && !VariaveisGlobais.executaProducao.ControleExecucao.Slot_3.Complemento_Pre.Item_Atual_Finalizado_Dosagem)
                )
            {
                VariaveisGlobais.executaProducao.InicioDosagemManualComplementoPre(SlotSolicitado);
            }
            //SLOT 3 PÓS
            if (VariaveisGlobais.executaProducao.ControleExecucao.Slot_3.Complemento_Pos.Habilitado_Inicio_Dosagem ||
                (VariaveisGlobais.executaProducao.ControleExecucao.Slot_3.Complemento_Pos.Item_Atual_Iniciado_Dosagem && !VariaveisGlobais.executaProducao.ControleExecucao.Slot_3.Complemento_Pos.Item_Atual_Finalizado_Dosagem)
                )
            {
                VariaveisGlobais.executaProducao.InicioDosagemManualComplementoPos(SlotSolicitado);
            }

        }
    }
}
