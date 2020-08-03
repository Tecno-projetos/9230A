﻿using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace _9230A_V00___PI.TelasAuxiliares
{
    /// <summary>
    /// Interaction logic for Buffer_Diag.xaml
    /// </summary>
    public partial class Buffer_Diag : Window
    {
        #region Variáveis

        private string Error = null;

        bool primeiro = true;
        Int64 Count = 0;
        Int64 Countlog = 0;
        #endregion

        public Buffer_Diag()
        {
            InitializeComponent();

            #region Diretório 

            string folder = @"C:\Logs"; //nome do diretorio a ser criado

            //Se o diretório não existir...

            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }

            StreamWriter w;

            using (w = File.AppendText(@"C:\Logs\Log" + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".txt"))
            {
                w.WriteLine("{0} {1} {2}", "Abriu Supervisorio: ",DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine("-------------------------------");
            }

            #endregion
        }

        #region Get/Set list error

        public string List_Error
        {
            get
            {
                return Error;
            }
            set
            {

                try
                {
                    Error = value;

                    if (!(Error.Contains("OK")))
                    {
                        Count += 1;
                        listBox.Dispatcher.Invoke(delegate { listBox.Items.Add(Error + Count); });


                        if (Count > 1000)
                        {
                            listBox.Dispatcher.Invoke(delegate { listBox.Items.Clear(); });
                            Count = 0;
                        }

                        StreamWriter w;

                        using (w = File.AppendText(@"C:\Logs\Log" + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".txt"))
                        {
                            Log((Error + Countlog), w);
                            Countlog += 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.List_Error = "Erro na escrita do log" + ex.ToString();
                }
                           
            }
        }

        #endregion

        #region Função List Error

        public static void Log(string logMessage, TextWriter w)
        {
            try
            {
                w.Write("\r\nEntrou : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  Erro:");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
            }
            catch (Exception)
            {
                
            }

        }

        public static void DumpLog(StreamReader r)
        {
            try
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception)
            {

            }

        }

        #endregion

    }
}