using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9230A_V00___PI.DataBase
{
    class SQLFunctionsProducao
    {


        public static void Create_Table_Producao()
        {
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "CREATE TABLE Producao (" +
                        "Id int not null," +  //PK
                        "IdReceitaBase int," +    //FK do Id da receita     
                        "QtdBateladas int," +
                        "TempoPreMistura int," +
                        "TempoPosMistura int," +
                        "PesoTotalProducao real," +
                        "PesoTotalProduzido real," +
                        "VolumeTotalProducao real," +
                        "VolumeTotalProduzido real," +
                        "CodigoProdutoDosagemAutomaticaSilo1 nvarchar(100) not null," +
                        "CodigoProdutoDosagemAutomaticaSilo2 nvarchar(100) not null," +
                        "DataInicioProducao datetime," +
                        "DataFimProducao datetime," +
                        "IniciouProducao bit," +
                        "FinalizouProducao bit," +
                        "CONSTRAINT FK_IdReceitaBase FOREIGN KEY (IdReceitaBase) REFERENCES Receitas(Id), " +
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

        public static void Create_Table_Bateladas()
        {
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "CREATE TABLE Bateladas (" +
                        "IdProducao int not null," +
                        "CodigoProduto nvarchar(100) not null," +
                        "ValorDesejado real," +
                        "ValorDosado real," +
                        "NumeroBatelada int," +
                        "CONSTRAINT FK_IdProducao FOREIGN KEY (IdProducao) REFERENCES Producao(Id), " +
                        "CONSTRAINT FK_CodigoProduto FOREIGN KEY (CodigoProduto) REFERENCES Produtos(Codigo));";

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

        public static int IntoDate_Table_Producao(ref Utilidades.Producao producao)
        {
            int ret = -1;

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    int idProd = -1;
                    string CommandString = "SELECT MAX(Id) AS maxid FROM Producao";
                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    dynamic Adapter = SqlGlobalFuctions.ReturnAdapter(CommandString, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);
                    DataTable Data = new DataTable();
                    Adapter.Fill(Data);

                    //last id is null?
                    if (DBNull.Value.Equals(Data.Rows[0][0]))
                        idProd = 1;
                    else
                        idProd = Convert.ToInt32(Data.Rows[0][0]) + 1;

                    dynamic Command = SqlGlobalFuctions.ReturnCommand(CommandString, Call);

                    Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    string query = "INSERT into Producao (" +
                        "Id, " +
                        "IdReceitaBase, " +
                        "QtdBateladas, " +
                        "TempoPreMistura, " +
                        "TempoPosMistura, " +
                        "PesoTotalProducao, " +
                        "PesoTotalProduzido, " +
                        "VolumeTotalProducao, " +
                        "VolumeTotalProduzido, " +
                        "CodigoProdutoDosagemAutomaticaSilo1, " +
                        "CodigoProdutoDosagemAutomaticaSilo2, " +
                        "DataInicioProducao, " +
                        "DataFimProducao, " +
                        "IniciouProducao," +
                        "FinalizouProducao) VALUES (" +
                        "@Id, " +
                        "@IdReceitaBase, " +
                        "@QtdBateladas, " +
                        "@TempoPreMistura, " +
                        "@TempoPosMistura, " +
                        "@PesoTotalProducao, " +
                        "@PesoTotalProduzido, " +
                        "@VolumeTotalProducao, " +
                        "@VolumeTotalProduzido, " +
                        "@CodigoProdutoDosagemAutomaticaSilo1, " +
                        "@CodigoProdutoDosagemAutomaticaSilo2, " +
                        "@DataInicioProducao, " +
                        "@DataFimProducao," +
                        "@IniciouProducao," +
                        "@FinalizouProducao)";

                    //Atualiza o Id da produção 
                    producao.id = idProd;

                    Command = SqlGlobalFuctions.ReturnCommand(query, Call);
                    Command.Parameters.AddWithValue("@Id", producao.id);
                    Command.Parameters.AddWithValue("@IdReceitaBase", producao.IdReceitaBase);
                    Command.Parameters.AddWithValue("@QtdBateladas", producao.quantidadeBateladas);
                    Command.Parameters.AddWithValue("@TempoPreMistura", producao.tempoPreMistura);
                    Command.Parameters.AddWithValue("@TempoPosMistura", producao.tempoPosMistura);
                    Command.Parameters.AddWithValue("@PesoTotalProducao", producao.pesoTotalProducao);
                    Command.Parameters.AddWithValue("@PesoTotalProduzido", producao.pesoTotalProduzido);
                    Command.Parameters.AddWithValue("@VolumeTotalProducao", producao.volumeTotalProducao);
                    Command.Parameters.AddWithValue("@VolumeTotalProduzido", producao.volumeTotalProduzido);
                    Command.Parameters.AddWithValue("@CodigoProdutoDosagemAutomaticaSilo1", producao.CodigoProdutoDosagemAutomaticaSilo1);
                    Command.Parameters.AddWithValue("@CodigoProdutoDosagemAutomaticaSilo2", producao.CodigoProdutoDosagemAutomaticaSilo2);
                    Command.Parameters.AddWithValue("@DataInicioProducao", producao.dateTimeInicioProducao);
                    Command.Parameters.AddWithValue("@DataFimProducao", producao.dateTimeFimProducao);
                    Command.Parameters.AddWithValue("@IniciouProducao", producao.IniciouProducao);
                    Command.Parameters.AddWithValue("@FinalizouProducao", producao.FinalizouProducao);
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

        public static int IntoDate_Table_Bateladas(ref Utilidades.Producao producao)
        {
            int ret = -1;

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {

                    foreach (var bateladas in producao.batelada)
                    {
                        foreach (var ProdBateladas in bateladas.produtos)
                        {
                            dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                            string query = "INSERT into Bateladas (" +
                                "IdProducao, " +
                                "CodigoProduto, " +
                                "ValorDesejado, " +
                                "ValorDosado, " +
                                "NumeroBatelada) VALUES (" +
                                "@IdProducao, " +
                                "@CodigoProduto, " +
                                "@ValorDesejado, " +
                                "@ValorDosado, " +
                                "@NumeroBatelada)";

                            dynamic Command = SqlGlobalFuctions.ReturnCommand(query, Call);
                            Command.Parameters.AddWithValue("@IdProducao", producao.id);
                            Command.Parameters.AddWithValue("@CodigoProduto", ProdBateladas.id);
                            Command.Parameters.AddWithValue("@ValorDesejado", ProdBateladas.pesoDesejado);
                            Command.Parameters.AddWithValue("@ValorDosado", ProdBateladas.pesoDosado);
                            Command.Parameters.AddWithValue("@NumeroBatelada", bateladas.numeroBatelada);

                            Call.Open();
                            ret = Command.ExecuteNonQuery();
                            Call.Close();
                            ret = 0;
                        }
                    }

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


        public static int AddProducao(Utilidades.Producao producao)
        {
            Utilidades.messageBox inputDialog;
            int ret = -1;

            if (IntoDate_Table_Producao(ref producao) != -1)
            {
                if (IntoDate_Table_Bateladas(ref producao) != -1)
                {
                    ret = 0;
                }
                else
                {
                    inputDialog = new Utilidades.messageBox("Falha inserir DB", "Falha ao inserir dados na tabela de bateladas!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                    inputDialog.ShowDialog();
                }
            }
            else
            {
                inputDialog = new Utilidades.messageBox("Falha inserir DB", "Falha ao inserir dados na tabela de produção!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                inputDialog.ShowDialog();
            }

            return ret;
            
        }

        public static List<Utilidades.Producao> PesquisaDateInDateOut(DateTime dtIn, DateTime dtOut)
        {
            List<Utilidades.Producao> listProducao = new List<Utilidades.Producao>();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                DataTable Data = new DataTable();
                
                Utilidades.Producao dummyProducao;
                try
                {
                    dynamic DTIn;
                    dynamic DTOut;

                    if (Utilidades.VariaveisGlobais.SQLCe_GS)
                    {
                        DTIn = dtIn.ToString("yyyyMMdd") + " " + dtIn.Hour + ":" + dtIn.Minute;
                        DTOut = dtOut.ToString("yyyyMMdd") + " " + dtOut.Hour + ":" + dtOut.Minute;
                    }
                    else
                    {
                        DTIn = dtIn;
                        DTOut = dtOut;
                    }

                    string CommandString = "SELECT * FROM Producao Where FinalizouProducao = 'True' AND FinalizouProducao >= '" + DTIn + "' AND FinalizouProducao <= '" + DTOut + "'";

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);
                    Call.Open();

                    dynamic Adapter = SqlGlobalFuctions.ReturnAdapter(CommandString, Utilidades.VariaveisGlobais.Connection_DB_Users_GS);

                    Adapter.Fill(Data);

                    foreach (var item in Data.Rows)
                    {
                        dummyProducao = new Utilidades.Producao();

                        //Chamar uma função que recebe uma linha do DB e retorna um tipo producao assim é só adicionar na lista


                        //listProducao.Add()
                    }

                    Call.Close();
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                }
            }

            return listProducao;
        }

    }
}
