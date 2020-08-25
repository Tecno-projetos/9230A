using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9230A_V00___PI.DataBase
{
    class SqlFunctionsReceitas
    {
        private static bool ExistTable(string nomeTabela)
        {

            DataTable Data_Produtos = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString_Produtos = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + nomeTabela +"';";

                    dynamic Adapter_Produtos = SqlGlobalFuctions.ReturnAdapter(CommandString_Produtos, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Adapter_Produtos.Fill(Data_Produtos);
                }
                catch (Exception ex)
                {
             
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                }

                if (!(Data_Produtos.Rows.Count > 0))
                {
                    return false;
                }
                else
                {
                    return true;
                }


            }

            return false;
        }



        public static void Create_Table_Receita()
        {
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                if (!ExistTable("Receitas"))
                {
                    try
                    {
                        string CommandString = "CREATE TABLE Receitas (" +
                            "Id int not null IDENTITY(1,1)," +
                            "NomeReceita nvarchar(100)," +
                            "PesoBase real," +
                            "Observacao nvarchar(300)," +
                            "PRIMARY KEY (Id));";

                        dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);
                        Call.Open();

                        dynamic Command = SqlGlobalFuctions.ReturnCommand(CommandString, Call);
                        Command.ExecuteNonQuery();

                        Call.Close();
                    }
                    catch (Exception ex)
                    {
                        Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                    }
                }
     
            }
        }

        public static int IntoDate_Table_Receita(string nomeReceita, float pesoBase, string observacao)
        {
            int ret = -1;

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    string query = "INSERT into Receitas (NomeReceita, PesoBase, Observacao) VALUES (@NomeReceita, @PesoBase, @Observacao)";
                    dynamic Command = SqlGlobalFuctions.ReturnCommand(query, Call);
                    Command.Parameters.AddWithValue("@NomeReceita", nomeReceita);
                    Command.Parameters.AddWithValue("@PesoBase", pesoBase);
                    Command.Parameters.AddWithValue("@Observacao", observacao);
                    Call.Open();
                    ret = Command.ExecuteNonQuery();
                    Call.Close();
                    ret = 0;
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                    ret = -1;
                }

                return ret;
            }
            else
            {
                return ret;
            }
        }

        public static int Create_Table_Receita_Produtos()
        {
            int ret = -1;


            if (!ExistTable("Produtos_Receita"))
            {
                if (Utilidades.VariaveisGlobais.DB_Connected_GS)
                {
                    try
                    {
                        string CommandString = "CREATE TABLE Produtos_Receita (" +
                            "IdReceita int not null," +
                            "CodigoProduto nvarchar(100) not null," +
                            "PesoProduto real, " +
                            "TipoDosagem nvarchar(100), " +
                            "CONSTRAINT FK_IdReceita FOREIGN KEY (IdReceita) REFERENCES Receitas(Id), " +
                            "CONSTRAINT FK_CodigoProduto FOREIGN KEY (CodigoProduto) REFERENCES Produtos(Codigo));";

                        dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);
                        Call.Open();

                        dynamic Command = SqlGlobalFuctions.ReturnCommand(CommandString, Call);
                        Command.ExecuteNonQuery();

                        Call.Close();
                        ret = 0;
                    }
                    catch (Exception ex)
                    {
                        Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                        ret = -1;
                    }
                }
                else
                {
                    return ret;
                }
            }
            else
            {
                return 0;
            }
            return ret;

        }

        public static int IntoDate_Table_Receita_Produtos(int IdReceita, string codigoProduto, float pesoProduto, string tipoDosagem)
        {
            int ret = -1;

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    string query = "INSERT into Produtos_Receita (IdReceita, CodigoProduto, PesoProduto, TipoDosagem) VALUES (@IdReceita, @CodigoProduto, @PesoProduto, @TipoDosagem)";
                    dynamic Command = SqlGlobalFuctions.ReturnCommand(query, Call);
                    Command.Parameters.AddWithValue("@IdReceita", IdReceita);
                    Command.Parameters.AddWithValue("@CodigoProduto", codigoProduto);
                    Command.Parameters.AddWithValue("@PesoProduto", pesoProduto);
                    Command.Parameters.AddWithValue("@TipoDosagem", tipoDosagem);
                    Call.Open();
                    ret = Command.ExecuteNonQuery();
                    Call.Close();
                    ret = 0;
                }
                catch (Exception ex)
                {

                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                    ret = -1;
                }

                return ret;
            }
            else
            {
                return ret;
            }
        }

        public static int Update_Table_Receita(string nomeReceitaNew, string nomeReceitaOld, float pesoBase, string observacao)
        {
            int ret = -1;
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string pBase = Convert.ToString(pesoBase, CultureInfo.GetCultureInfo("en-US"));
                    
                    
                    string CommandString = "UPDATE Receitas SET NomeReceita = '" + nomeReceitaNew
                        + "' PesoBase = '" + pBase
                        + "' Observacao = '" + observacao 
                        + "' WHERE NomeReceita = " + nomeReceitaOld + ";";

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);
                    dynamic Command = SqlGlobalFuctions.ReturnCommand(CommandString, Call);

                    Call.Open();
                    ret = Command.ExecuteNonQuery();
                    Call.Close();
                    return ret;
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                    ret = -1;
                    return ret;
                }
            }
            else
            {
                return ret;
            }

        }

        public static int getIdReceita(string NomeReceita)
        {
            DataTable Data = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "SELECT Id FROM Receitas WHERE NomeReceita = '"+ NomeReceita+"' ";

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    dynamic Adapter = SqlGlobalFuctions.ReturnAdapter(CommandString, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Adapter.Fill(Data);
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                    return -1;
                }
            }

            return Convert.ToInt32(Data.Rows[0][0]);
        }

        public static DataTable getReceitas()
        {
            DataTable Data = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "SELECT * FROM Receitas";

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    dynamic Adapter = SqlGlobalFuctions.ReturnAdapter(CommandString, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Adapter.Fill(Data);
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                }
            }

            return Data;
        }

        public static DataTable getProdutosReceita(int IdReceita)
        {
            DataTable Data = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "SELECT * FROM Produtos_Receita WHERE IdReceita = '" + IdReceita + "'";

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    dynamic Adapter = SqlGlobalFuctions.ReturnAdapter(CommandString, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Adapter.Fill(Data);
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                }
            }

            return Data;
        }

        public static int AddNewRecipeBD()
        {
            //Retornos
            // 0 = Foi criado a receita com sucesso
            //-1 = Problema ao inserir a receita na tabela, possivel causa é nome da receita já existente.
            //-2 = Pegando Id da receita atual, possivel causa é receita não existir
            //-3 = inserindo produtos na tabela de produtos da receita, possível causa problema de conexão com banco de dados.
            //-4 = 
            //-5 = Possui mais que 2 itens em automático


            //Passo de inserção da receita no banco de dados
            //1 Passo precisamos inserir os dados da receita na tabel da receita.
            //2 Passo Inserir os dados na tabela de produtos da receita criada.


            //Executando Passo 1
            if (IntoDate_Table_Receita(Utilidades.VariaveisGlobais.ReceitaCadastro.nomeReceita, Utilidades.VariaveisGlobais.ReceitaCadastro.pesoBase, Utilidades.VariaveisGlobais.ReceitaCadastro.observacao) != 0)
            {
                return -1;
            }

            //Pegando o ID da receita
            int IdReceita = getIdReceita(Utilidades.VariaveisGlobais.ReceitaCadastro.nomeReceita);

            if (IdReceita < 0)
            {
                return -3;
            }

            //========================================================================================================================================================
            //Ordenar a lista com as seguintes especificações:
            //1 - produtos que são matérias primas manuais
            //2 - produtos que são matérias primas automaticas
            //3 - produtos que são complementos

            List<Utilidades.ProdutoReceita> listDummy = new List<Utilidades.ProdutoReceita>();

            //Adiciona os produtos em manuais e apaga da lista
            foreach (var item in Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos)
            {
                if (item.tipoDosagemMateriaPrima.Equals("Manual"))
                {
                    listDummy.Add(item);
                }
            }

            //Variavel auxiliar para verificar se possui 2 produtos adicionados
            // = 0 1 item
            // = 1 2 item
            int auxiliarAutomatico = -1;
            //Lembra que só pode colocar dois produtos com dosagem automatica, ai vem a condição: 
            //SE TIVER DOIS PRODUTOS COM DOSAGEM AUTOMÁTICA, VERIFICAR A DENSIDADE DO PRODUTO E COLOCAR PRIMEIRO O PRODUTO MAIS LEVE E DEPOIS O MAIS PESADO.
            //Variaveis para armazenar conforme odernação da lista 1 a menor desidade e depois a maior densindade 
            var automatico1 = new Utilidades.ProdutoReceita();
            var automatico2 = new Utilidades.ProdutoReceita();

            foreach (var item in Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos)
            {
                if (item.tipoDosagemMateriaPrima.Equals("Automático"))
                {
                    //Conta um para adiocionar a primeira auxiliar
                    auxiliarAutomatico++; //Resultado se um item valor == 0 se não valor == 1

                    //Adiciona o 1 automatico na lista
                    if (auxiliarAutomatico == 0)
                    {
                        automatico1 = item;
                    }
                    else
                    {
                        automatico2 = item;
                    }
                }
            }

            //Verifica se possui produto automático adicionado na receita
            if (auxiliarAutomatico != -1)
            {
                //Verifica se possui mais de um item automatico na receita e compara a densidade.
                if (auxiliarAutomatico == 1)
                {
                    //Verifica se o automatico 1 tem a menor densindade se possuir adiciona primeiro se não possui adiciona o automatico2
                    if (automatico1.produto.densidade <= automatico2.produto.densidade)
                    {
                        listDummy.Add(automatico1);
                        listDummy.Add(automatico2);
                    }
                    else
                    {
                        listDummy.Add(automatico2);
                        listDummy.Add(automatico1);
                    }

                }
                else
                {
                    if (auxiliarAutomatico == 0)
                    {
                        //Se a receita possuir apenas um item em automatico só irar ser adicionado o automatico1
                        listDummy.Add(automatico1);
                    }
                    else
                    {
                        //Se entrar nessa exeção indica que existem mais que 2 produtos em AUTOMÁTICO
                        return -5;
                    }
                   
                }
  
            }
 

            //Adiciona os produtos automáticos e apaga os manuais
            foreach (var item in Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos)
            {
                if (item.produto.tipoProduto.Equals("Complemento"))
                {
                    listDummy.Add(item);
                }
            }

            //limpar a lista de produtos de receita cadastro e passar a lista dummy
            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.Clear();
            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos = listDummy;

            //========================================================================================================================================================


            //Executando Passo 2
            foreach (var item in Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos)
            {
                if (IntoDate_Table_Receita_Produtos(IdReceita, item.produto.codigo, item.pesoPorProduto, item.tipoDosagemMateriaPrima) != 0)
                {
                    return -4;
                }
            }

            return 0;
        }

        public static int EditRecipeBD()
        {
            //Retornos
            // 0 = Foi criado a receita com sucesso
            //-1 = Problema ao inserir a receita na tabela, possivel causa é nome da receita já existente.
            //-2 = Pegando Id da receita atual, possivel causa é receita não existir
            //-3 = inserindo produtos na tabela de produtos da receita, possível causa problema de conexão com banco de dados.

            //Passo de inserção da receita no banco de dados
            //1 Passo precisamos inserir os dados da receita na tabel da receita.
            //2 Passo Inserir os dados na tabela de produtos da receita criada.


            //Executando Passo 1
            //if (Update_Table_Receita(Utilidades.VariaveisGlobais.ReceitaCadastro.nomeReceita, Utilidades.VariaveisGlobais.ReceitaCadastro.pesoBase, Utilidades.VariaveisGlobais.ReceitaCadastro.observacao) != 0)
            //{
            //    return -1;
            //}

            //Pegando o ID da receita
            int IdReceita = getIdReceita(Utilidades.VariaveisGlobais.ReceitaCadastro.nomeReceita);

            if (IdReceita < 0)
            {
                return -3;
            }

            //========================================================================================================================================================
            //Ordenar a lista com as seguintes especificações:
            //1 - produtos que são matérias primas manuais
            //2 - produtos que são matérias primas automaticas
            //3 - produtos que são complementos

            List<Utilidades.ProdutoReceita> listDummy = new List<Utilidades.ProdutoReceita>();

            //Adiciona os produtos em manuais e apaga da lista
            foreach (var item in Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos)
            {
                if (item.tipoDosagemMateriaPrima.Equals("Manual"))
                {
                    listDummy.Add(item);
                }
            }

            //Adiciona os produtos automáticos e apaga os manuais
            foreach (var item in Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos)
            {
                if (item.tipoDosagemMateriaPrima.Equals("Automático"))
                {
                    listDummy.Add(item);
                }
            }

            //Adiciona os produtos automáticos e apaga os manuais
            foreach (var item in Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos)
            {
                if (item.produto.tipoProduto.Equals("Complemento"))
                {
                    listDummy.Add(item);
                }
            }

            //limpar a lista de produtos de receita cadastro e passar a lista dummy
            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.Clear();
            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos = listDummy;

            //========================================================================================================================================================


            //Executando Passo 2
            foreach (var item in Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos)
            {
                if (IntoDate_Table_Receita_Produtos(IdReceita, item.produto.codigo, item.pesoPorProduto, item.tipoDosagemMateriaPrima) != 0)
                {
                    return -4;
                }
            }

            return 0;
        }


        public static int DeleteReceita(string NomeReceita)
        {
            int ret = -1;
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    //Pega o id da receita antes de apagar a receita
                    int IdReceita = getIdReceita(NomeReceita);

                    //Apaga os produtos da receita na tabela de Produtos_Receita
                    
                    string CommandString = "DELETE FROM Produtos_Receita WHERE IdReceita = '" + IdReceita + "';";

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Call.Open();

                    dynamic Command = SqlGlobalFuctions.ReturnCommand(CommandString, Call);

                    Command.ExecuteNonQuery();

                    //Apaga a receita na tabela de receita
                    CommandString = "DELETE FROM Receitas WHERE Id = '" + IdReceita + "';";

                    Command = SqlGlobalFuctions.ReturnCommand(CommandString, Call);
                    Command.ExecuteNonQuery();

                    Call.Close();
                    ret = 0;
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                    ret = -1;
                }

                return ret;
            }
            else
            {
                return ret;
            }
        }

        public static int getExistReceita(string IdReceita)
        {
            DataTable Data = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "SELECT * FROM Receitas WHERE NomeReceita = '"+ IdReceita + "';";

                    dynamic Adapter = SqlGlobalFuctions.ReturnAdapter(CommandString, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Adapter.Fill(Data);
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                }

                if (!(Data.Rows.Count > 0))
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

    }
}
