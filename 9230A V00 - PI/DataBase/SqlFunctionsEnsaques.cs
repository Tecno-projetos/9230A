using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9230A_V00___PI.DataBase
{
    public class SqlFunctionsEnsaques
    {

        #region Producao Ensaque

        public static void ExistTableProducaoEnsaque()
        {

            DataTable Data_Produtos = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString_Produtos = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProducaoEnsaque';";

                    dynamic Adapter_Produtos = SqlGlobalFuctions.ReturnAdapter(CommandString_Produtos, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Adapter_Produtos.Fill(Data_Produtos);
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                }

                if (!(Data_Produtos.Rows.Count > 0))
                {
                    Create_Table_ProducaoEnsaque();
                }
            }
        }

        private static void Create_Table_ProducaoEnsaque()
        {
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "CREATE TABLE ProducaoEnsaque (" +
                        "Id int not null IDENTITY(1,1)," +
                        "IdProducao int," +    //FK do Id da receita     
                        "PesoDejado real," +
                        "DataInicioProducao datetime," +
                        "DataFimProducao datetime," +
                        "FinalizouProducao bit," +
                        "CONSTRAINT FK_IdProducao FOREIGN KEY (IdProducao) REFERENCES Producao(Id), " +
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

        public static int IntoDate_Table_ProducaoEnsaque(int idProducao, float pesoDessejado, DateTime dataIncioProducao, DateTime dataFimProducao, string Observacao)
        {
            int ret = -1;

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    int id = -1;
                    string CommandString = "SELECT MAX(Id) AS maxid FROM ProducaoEnsaque";
                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    dynamic Adapter = SqlGlobalFuctions.ReturnAdapter(CommandString, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);
                    DataTable Data = new DataTable();
                    Adapter.Fill(Data);

                    //last id is null?
                    if (DBNull.Value.Equals(Data.Rows[0][0]))
                        id = 1;
                    else
                        id = Convert.ToInt32(Data.Rows[0][0]) + 1;

                    dynamic Command = SqlGlobalFuctions.ReturnCommand(CommandString, Call);

                    Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    string query = "INSERT into ProducaoEnsaque (" +
                        "IdProducao, " +
                        "PesoDejado, " +
                        "DataInicioProducao, " +
                        "DataFimProducao, " +
                        "FinalizouProducao, " +
                        "Observacao) VALUES (" +
                        "@IdProducao, " +
                        "@PesoDejado, " +
                        "@DataInicioProducao, " +
                        "@DataFimProducao, " +
                        "@FinalizouProducao, " +
                        "@Observacao)";

                    Command = SqlGlobalFuctions.ReturnCommand(query, Call);
                    Command.Parameters.AddWithValue("@IdProducao", idProducao);
                    Command.Parameters.AddWithValue("@PesoDejado", pesoDessejado);
                    Command.Parameters.AddWithValue("@DataInicioProducao", dataIncioProducao);
                    Command.Parameters.AddWithValue("@DataFimProducao", dataFimProducao);
                    Command.Parameters.AddWithValue("@FinalizouProducao", false);
                    Command.Parameters.AddWithValue("@Observacao", Observacao);
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

        public static int Update_Finaliza_Producao()
        {
            int ret = -1;
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    dynamic DTnow = new DateTime();
                    DTnow = DateTime.Now;

                    DTnow = DTnow.ToString("yyyyMMdd") + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;

                    string CommandString = "UPDATE ProducaoEnsaque SET FinalizouProducao = 'true', DataFimProducao = '" + DTnow + "' WHERE FinalizouProducao = 'false';";

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

        public static int getIdProducaoEnsaque(int IdProducao)
        {
            DataTable Data = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "SELECT Id FROM ProducaoEnsaque WHERE IdProducao = '" + IdProducao + "' ";

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
            if (Data.Rows.Count > 0 )
            {
                return Convert.ToInt32(Data.Rows[0][0]);
            }
            else
            {
                return -1;

            }

        }

        public static DataTable getProducaoEnsaqueFromDateTime(DateTime dtIn, DateTime dtOut)
        {
            DataTable Data = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
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


                    string CommandString = "SELECT * FROM ProducaoEnsaque WHERE DataFimProducao >= '" + DTIn + "' AND DataFimProducao <= '" + DTOut + "'";

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




        #endregion

        #region Ensaque

        public static void ExistTableEnsaques()
        {

            DataTable Data_Produtos = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString_Produtos = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Ensaques';";

                    dynamic Adapter_Produtos = SqlGlobalFuctions.ReturnAdapter(CommandString_Produtos, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Adapter_Produtos.Fill(Data_Produtos);
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
                }

                if (!(Data_Produtos.Rows.Count > 0))
                {
                    Create_Table_Ensaques();
                }
            }
        }

        private static void Create_Table_Ensaques()
        {
            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "CREATE TABLE Ensaques (" +
                        "Id bigint not null IDENTITY(1,1)," +
                        "IdEnsaque int," +    //FK do Id da receita     
                        "PesoDosado real," +
                        "CONSTRAINT FK_IdEnsaque FOREIGN KEY (IdEnsaque) REFERENCES ProducaoEnsaque(Id), " +
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

        public static int IntoDate_Table_Ensaques(int idEnsaque, float pesoDosado, string Observacao)
        {
            int ret = -1;

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Call.Open();

                    string query = "INSERT into Ensaques (" +
                        "IdEnsaque, " +
                        "PesoDosado," +
                        "Observacao) VALUES (" +
                        "@IdEnsaque, " +
                        "@PesoDosado, " +
                        "@Observacao)";

                    dynamic Command = SqlGlobalFuctions.ReturnCommand(query, Call);
                    Command.Parameters.AddWithValue("@IdEnsaque", idEnsaque);
                    Command.Parameters.AddWithValue("@PesoDosado", pesoDosado);
                    Command.Parameters.AddWithValue("@Observacao", Observacao);
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

        public static DataTable getEnsaqueFromIdProducaoEnsaque(int IdProducaoEnsaque)
        {
            DataTable Data = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "SELECT * FROM Ensaques WHERE IdEnsaque = '" + IdProducaoEnsaque + "'";

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

        public static string getNameReceita(int IdProducao)
        {
            DataTable Data = new DataTable();

            if (Utilidades.VariaveisGlobais.DB_Connected_GS)
            {
                try
                {
                    string CommandString = "SELECT NomeReceita FROM Receitas WHERE Id = '" + IdProducao + "' ";

                    dynamic Call = SqlGlobalFuctions.ReturnCall(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    dynamic Adapter = SqlGlobalFuctions.ReturnAdapter(CommandString, Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS);

                    Adapter.Fill(Data);
                }
                catch (Exception ex)
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
       
                }
            }

            if (Data.Rows.Count > 0)
            {
                return Convert.ToString(Data.Rows[0][0]);
            }
            else
            {
                return "Sem Receita";

            }
        }


        #endregion


    }
}
