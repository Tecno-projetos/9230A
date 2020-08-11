using System;
using System.Collections.Generic;
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
                        "Id int not null IDENTITY(1,1)," +  //PK
                        "IdReceitaBase nvarchar(100)," +    //FK do Id da receita     
                        "QtdBateladas int," +
                        "TempoPreMistura int," +
                        "TempoPosMistura int," +
                        "PesoTotalProducao real," +
                        "PesoTotalProduzido real," +
                        "PesoPorBatelada real," +
                        "VolumeTotalProducao real," +
                        "VolumeTotalProduzido real," +
                        "VolumePorBatelada real," +
                        "CodigoProdutodDosagemAutomaticaSilo1 nvarchar(100) not null," +
                        "CodigoProdutodDosagemAutomaticaSilo2 nvarchar(100) not null," +
                        "DataInicioProducao datetime," +
                        "DataFimProducao datetime," +
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
                        "IdProducao nvarchar(100)," +
                        "CodigoProduto nvarchar(100) not null," +
                        "ValorDosado real," +
                        "NumeroBatelada int," +
                        "CONSTRAINT FK_IdProducao FOREIGN KEY (IdProducao) REFERENCES Producao(Id), " +
                        "CONSTRAINT FK_CodigoProduto FOREIGN KEY (CodigoProduto) REFERENCES Produtos(Codigo), " +
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
}
