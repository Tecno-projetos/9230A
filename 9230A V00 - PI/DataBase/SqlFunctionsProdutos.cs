using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

                    dynamic Adapter_Produtos = SqlGlobalFuctions.ReturnAdapter(CommandString_Produtos, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Adapter_Produtos.Fill(Data_Produtos);
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
                        "Id int not null IDENTITY(1,1)," +
                        "Codigo nvarchar(100) not null primary key," +
                        "Descricao nvarchar(200)," +
                        "Densidade real," +
                        "TipoProduto nvarchar(100), " +
                        "Observacao nvarchar(300));";

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

        public static int IntoDate_Table_Produtos(string codigo, string descricao, float densidade, string tipoProduto, string observacao)
        {
            int ret = -1;

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    string query = "INSERT into Produtos (Codigo, Descricao, Densidade, TipoProduto, Observacao) VALUES (@Codigo, @Descricao, @Densidade, @TipoProduto, @Observacao)";
                    dynamic Command = SqlGlobalFuctions.ReturnCommand(query, Call);
                    Command.Parameters.AddWithValue("@Codigo", codigo);
                    Command.Parameters.AddWithValue("@Descricao", descricao);
                    Command.Parameters.AddWithValue("@Densidade", densidade);
                    Command.Parameters.AddWithValue("@TipoProduto", tipoProduto);
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

        public static DataTable getTableProdutos()
        {
            DataTable Data = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "SELECT * FROM Produtos";

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

        public static int UpdateTableProdutos(int id, string codigo, string descricao, float densidade, string tipoProduto, string observacao)
        {
            int ret = -1;
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                   string densi = densidade.ToString(CultureInfo.GetCultureInfo("en-US"));

                   string CommandString = "UPDATE Produtos SET Codigo = '"+ codigo + "', Descricao = '" + descricao + "', Densidade = '" + densi + "', TipoProduto = '" + tipoProduto + "', Observacao = '" + observacao + "' WHERE Id = " + id + ";".ToString(CultureInfo.GetCultureInfo("en-US"));

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

        public static bool Delete_Rows(int id)
        {
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "DELETE FROM Produtos WHERE Id = " + id + ";";

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Call.Open();

                    dynamic Command = SqlGlobalFuctions.ReturnCommand(CommandString, Call);
                    Command.ExecuteNonQuery();

                    Call.Close();

                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();

                    return false;
                }
            }

            return true;

        }

        public static Int32 getCodigoProdutoUsado(string CodoDigoProduto)
        {
            DataTable Data = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "SELECT COUNT(*) FROM Produtos_Receita WHERE CodigoProduto = '" + CodoDigoProduto + "'";


                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    dynamic Adapter = SqlGlobalFuctions.ReturnAdapter(CommandString, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Adapter.Fill(Data);
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                }
            }

            return Convert.ToInt32(Data.Rows[0][0]);
        }
    }
}
