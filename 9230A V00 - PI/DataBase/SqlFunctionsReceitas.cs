using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9230A_V00___PI.DataBase
{
    class SqlFunctionsReceitas
    {
        public static void ExistTable()
        {

            DataTable Data = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Receitas';";

                    dynamic Adapter = SqlGlobalFuctions.ReturnAdapter(CommandString, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Adapter.Fill(Data);
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                }

                if (!(Data.Rows.Count > 0))
                {
                    Create_Table_Receita();
                }
            }
        }

        private static void Create_Table_Receita()
        {
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "CREATE TABLE Receitas (" +
                        "Id int not null IDENTITY(1,1)," +
                        "NomeReceita nvarchar(100)," +
                        "PesoBase real," +
                        "CodigoProduto int," +
                        "PesoPorProduto real, " +
                        "Observacao nvarchar(300));";

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);
                    Call.Open();

                    dynamic Command = SqlGlobalFuctions.ReturnCommand(CommandString, Call);
                    Command.ExecuteNonQuery();

                    CommandString = "ADD FOREIGN KEY (CodigoProduto) REFERENCES Produtos(Id);";

                    Command = SqlGlobalFuctions.ReturnCommand(CommandString, Call);
                    Command.ExecuteNonQuery();

                    Call.Close();
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                }
            }
        }

        public static int IntoDate_Table_Produtos(string nomeReceita, float pesoBase, int codigoProduto, float pesoPorProduto, string observacao)
        {
            int ret = -1;

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Produtos_GS);

                    string query = "INSERT into Receitas (NomeReceita, PesoBase, CodigoProduto, PesoPorProduto, Observacao) VALUES (@NomeReceita, @PesoBase, @CodigoProduto, @PesoPorProduto, @Observacao)";
                    dynamic Command = SqlGlobalFuctions.ReturnCommand(query, Call);
                    Command.Parameters.AddWithValue("@NomeReceita", nomeReceita);
                    Command.Parameters.AddWithValue("@PesoBase", pesoBase);
                    Command.Parameters.AddWithValue("@CodigoProduto", codigoProduto);
                    Command.Parameters.AddWithValue("@PesoPorProduto", pesoPorProduto);
                    Command.Parameters.AddWithValue("@Observacao", observacao);
                    Call.Open();
                    ret = Command.ExecuteNonQuery();
                    Call.Close();
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




    }
}
