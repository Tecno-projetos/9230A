using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9230A_V00___PI.DataBase
{
    public class SqlFunctionsProdutos
    {

        private static void Create_Table_Produtos()
        {
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    //==== BUT BEFORE REMEMBER TO CHECK IF THERE IS A JA TABLE WITH THE NAME YOU WANT TO ====
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

    }
}
