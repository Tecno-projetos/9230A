using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9230A_V00___PI.DataBase
{
    public class SqlFunctionsProdutos
    {

        public static void ExistTable()
        {

            DataTable Data_Produtos = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString_Produtos = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Produtos';";

                    dynamic Call_Produtos = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Produtos_GS);
                    dynamic Adapter_Produtos = SqlGlobalFuctions.ReturnAdapter(CommandString_Produtos, Utilidades.VariaveisGlobais.Connection_DB_Produtos_GS);

                    Adapter_Produtos.Fill(Utilidades.VariaveisGlobais.Connection_DB_Produtos_GS);
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                }

                if (!(Data_Produtos.Rows.Count > 0))
                {
                    Create_Table_Produtos();
                }
            }
        }

        private static void Create_Table_Produtos()
        {
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "CREATE TABLE Produtos (" +
                        "Codigo string not null primary key," +
                        "Descricao nvarchar(200)," +
                        "Densidade double," +
                        "TipoProduto nvarchar(100), " +
                        "Observacao nvarchar(300));";

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Produtos_GS);
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

        public static string IntoDate_Table_Produtos(string codigo, string descricao, double densidade, string tipoProduto, string observacao)
        {
            string ret = "";

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Produtos_GS);

                    string query = "INSERT into Produtos (Codigo, Descricao, Densidade, TipoProduto, Observacao) VALUES (@Codigo, @Descricao, @Densidade, @TipoProduto, @Observacao)";
                    dynamic Command = SqlGlobalFuctions.ReturnCommand(query, Call);
                    Command.Parameters.AddWithValue("@Codigo", codigo);
                    Command.Parameters.AddWithValue("@Descricao", descricao);
                    Command.Parameters.AddWithValue("@Densidade", densidade);
                    Command.Parameters.AddWithValue("@TipoProduto", tipoProduto);
                    Command.Parameters.AddWithValue("@TipoProduto", observacao);
                    Call.Open();
                    Command.ExecuteNonQuery();
                    Call.Close();
                    ret = "ok";
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                    ret = "erro";
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
