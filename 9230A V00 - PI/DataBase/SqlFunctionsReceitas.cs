using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9230A_V00___PI.DataBase
{
    class SqlFunctionsReceitas
    {
        private static void Create_Table_Produtos(string nomeTabela)
        {
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "CREATE TABLE "+nomeTabela+" (" +
                        "NomeReceita nvarchar(100)," +
                        "PesoBase double(200)," +
                        "CodigoProduto nvarchar(100)," +
                        "PesoPorProduto double, " +
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

    }
}
