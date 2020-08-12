﻿using _9230A_V00___PI.Properties;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace _9230A_V00___PI.Telas_Fluxo.Relatorios
{
    class ExportacaoRelatorios
    {
        #region Exportar PDF


        /// <summary>
        ///  Exporta tabela e adiociona uma linha no cabelaho de produção com datas de exportações
        /// </summary>
        /// <param name="strPdfPath">Caminho a ser salvo o PDF </param>
        /// <param name="strHeader"> O que será escrito no cabeçalho da página</param>
        /// <param name="Producao">Valor de total da produção</param>
        /// <param name="dataExportacaoInicial"> Envia uma data para ser salvo no PDF e para mostrar quando foi iniciado a exportação</param>
        /// <param name="dataExportacaoFinal"> Envia uma data para ser salvo no PDF e para mostrar quando foi finalizado a exportação</param>
               
        public static void exportProducao(String strPdfPath, List<Utilidades.Producao> PesquisaProducao, string strHeader, DateTime dataExportacaoInicial, DateTime dataExportacaoFinal)
        {
            #region Váriveis
            float[] colsW = { 25, 25 };


            double pesoTotalproduzido = 0;
            double volumeTotalProduzido = 0;
            Int64 quantidadeProducoes = 0;
            Int64 quantidadeBateladas = 0;

            #endregion

            #region Cabeçalho

            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            writer.PageEvent = new PDFFooter();

            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.BLACK);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);


            //Adiociona a imagem no projeto e no PDF
            #region Imagem Automasul
            //Busca a imagem
            string filename = "Logo_Automasul.png";
            //Salva a imagem no arquivo Bin
            Resources.Logo_Automasul.Save(Path.GetFullPath(filename));
            string path = Path.GetFullPath(filename);
            //Manda o caminho para o PDF
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(path);
            image.SetAbsolutePosition(0, 20);

            image.ScaleAbsolute(150, 50);
            image.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
            PdfContentByte cbhead = writer.DirectContent;
            PdfTemplate tp = cbhead.CreateTemplate(1000, 1000);
            tp.AddImage(image);

            cbhead.AddTemplate(tp, 0, 842 - 95);
            #endregion

            //Adiociona a imagem no projeto e no PDF
            #region Imagem Becker
            //Busca a imagem
            string filename1 = "Logo_Becker.png";
            //Salva a imagem no arquivo Bin
            Resources.Logo_Becker.Save(Path.GetFullPath(filename1));
            string path1 = Path.GetFullPath(filename1);

            //Manda o caminho para o PDF
            iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(path1);
            image1.SetAbsolutePosition(460, 40);
            image1.ScaleAbsolute(100, 30);
            image1.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            PdfContentByte cbhead1 = writer.DirectContent;
            PdfTemplate tp1 = cbhead1.CreateTemplate(1000, 1000);
            tp1.AddImage(image1);
            cbhead1.AddTemplate(tp1, 0, 842 - 95);
            #endregion


            //Author
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 8, 2, iTextSharp.text.BaseColor.GRAY);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Autor : " + Utilidades.VariaveisGlobais.UserLogged_GS, fntAuthor));
            prgAuthor.Add(new Chunk("\nExportado : " + DateTime.Now.ToShortDateString(), fntAuthor));
            document.Add(prgAuthor);


            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            //document.Add(new Chunk("\n", fntHead));

            #endregion

            //Quantidade de produçoes
            quantidadeProducoes = PesquisaProducao.Count;

            foreach (var item in PesquisaProducao)
            {
                //Quantidade de bateladas em produçao pesquisada.
                quantidadeBateladas = quantidadeBateladas + item.batelada.Count;
                pesoTotalproduzido = pesoTotalproduzido + item.pesoTotalProduzido;
                volumeTotalProduzido = volumeTotalProduzido + item.volumeTotalProduzido;

            }

            document.Add(tableProducao(colsW, "Peso total produzido: " + pesoTotalproduzido + " kg", "Volume total produzido: " + pesoTotalproduzido + " m³", false));
            document.Add(tableProducao(colsW, "Quantidade total produzida: " + quantidadeProducoes + " produções", "Total de bateladas produzidas: " + quantidadeBateladas + " und.", false));
            document.Add(tableProducao(colsW, "Data início produção: " + dataExportacaoInicial.ToShortDateString() + "\n" + dataExportacaoInicial.ToLongTimeString(), "Data fim produção: " + dataExportacaoFinal.ToShortDateString() + "\n" + dataExportacaoFinal.ToLongTimeString(), false)); ;


            //Add a line seperation
            Paragraph p1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p1);

            //Adiocona o detatalhamento da Produção
            Paragraph Detalhamento = new Paragraph();
            BaseFont btnDetalhamento = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntADetalhamento = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12, Font.BOLD, new BaseColor(0, 0, 0));
            Detalhamento.Alignment = Element.ALIGN_CENTER;
     
            Detalhamento.Add(new Chunk("Detalhamento Produção", fntADetalhamento));
            document.Add(Detalhamento);

            document.Add(new Chunk("\n", fntHead));

            int cont = 0;
            int mudanca = 3;

            foreach (var item in PesquisaProducao)
            {                
                if (!(cont < mudanca))
                {
                    document.NewPage();
                    cont = 0;
                    mudanca = 4;
                }

                document.Add(tableProducao("Relatório produção N° produção: " + Convert.ToString(item.id), true));
                document.Add(tableProducao(item.receita.nomeReceita, true));
                document.Add(tableProducao(colsW, "Peso total produção: " + item.pesoTotalProducao + " kg", "Volume total produção: " + item.volumeTotalProducao + " m³", true));
                document.Add(tableProducao(colsW, "Peso total produzido: " + item.pesoTotalProduzido + " kg", "Volume total produzido: " + item.volumeTotalProduzido + " m³", true));
                document.Add(tableProducao("Quantidade de bateldas: " + item.quantidadeBateladas + " und.", true, Element.ALIGN_LEFT));
                document.Add(tableProducao(colsW, "Tempo pré mistura: " + item.tempoPreMistura + " segundos", "Tempo pós mistura: " + item.tempoPosMistura + " segundos", true));
                document.Add(tableProducao(colsW, "Data início produção: " + item.dateTimeInicioProducao, "Data fim produção: " + item.dateTimeFimProducao, true));
                document.Add(new Chunk("\n", fntHead));

                cont++;
            }

            document.Close();
            writer.Close();
            fs.Close();
        }

        private static PdfPTable tableProducao(float[] colsW,string nomeColuna1, string  nomeColuna2, bool comBorda) 
        {

            PdfPTable tabela = new PdfPTable(2);
            tabela.KeepTogether = true;
            BaseColor preto = new BaseColor(0, 0, 0);
            BaseColor fundo = new BaseColor(200, 200, 200);
            BaseColor branco = new BaseColor(255, 255, 255);
            Font font = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, Font.BOLD, preto);
            Font titulo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, Font.BOLD, preto);

            tabela.SetWidths(colsW);
            tabela.HeaderRows = 0;
            tabela.WidthPercentage = 100f;

            tabela.DefaultCell.BorderColor = new BaseColor(255, 255, 255);
            tabela.DefaultCell.BorderColorBottom = new BaseColor(255, 255, 255);
            tabela.DefaultCell.Padding = 5;


            if (comBorda)
            {
                tabela.DefaultCell.Border = PdfPCell.BOX;

                tabela.AddCell(getNewCell(nomeColuna1, titulo, Element.ALIGN_LEFT,5, preto, branco));
                tabela.AddCell(getNewCell(nomeColuna2, titulo, Element.ALIGN_LEFT,5, preto, branco));

            }
            else
            {
                tabela.DefaultCell.Border = PdfPCell.NO_BORDER;

                tabela.AddCell(getNewCell(nomeColuna1, titulo, Element.ALIGN_LEFT, 5, PdfPCell.NO_BORDER, preto, branco));
                tabela.AddCell(getNewCell(nomeColuna2, titulo, Element.ALIGN_LEFT, 5, PdfPCell.NO_BORDER, preto, branco));


            }

            return tabela;


        }
       
        private static PdfPTable tableProducao(string nomeColuna1, bool comBorda)
        {

            PdfPTable tabela = new PdfPTable(1);

            tabela.KeepTogether = true;

            BaseColor preto = new BaseColor(0, 0, 0);
            BaseColor fundo = new BaseColor(200, 200, 200);
            BaseColor branco = new BaseColor(255, 255, 255);
            Font font = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, Font.BOLD, preto);
            Font titulo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, Font.BOLD, preto);

            tabela.HeaderRows = 0;
            tabela.WidthPercentage = 100f;

            tabela.DefaultCell.BorderColor = new BaseColor(255, 255, 255);
            tabela.DefaultCell.BorderColorBottom = new BaseColor(255, 255, 255);
            tabela.DefaultCell.Padding = 5;


            if (comBorda)
            {
                tabela.DefaultCell.Border = PdfPCell.BOX;

                tabela.AddCell(getNewCell(nomeColuna1, titulo, Element.ALIGN_CENTER, 5, preto, branco));

            }
            else
            {
                tabela.DefaultCell.Border = PdfPCell.NO_BORDER;

                tabela.AddCell(getNewCell(nomeColuna1, titulo, Element.ALIGN_CENTER, 5, PdfPCell.NO_BORDER, preto, branco));


            }

            return tabela;


        }
     
        private static PdfPTable tableProducao(string nomeColuna1, bool comBorda, int alinhamento)
        {

            PdfPTable tabela = new PdfPTable(1);
            tabela.KeepTogether = true;
            BaseColor preto = new BaseColor(0, 0, 0);
            BaseColor fundo = new BaseColor(200, 200, 200);
            BaseColor branco = new BaseColor(255, 255, 255);
            Font font = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, Font.BOLD, preto);
            Font titulo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, Font.BOLD, preto);

            tabela.HeaderRows = 0;
            tabela.WidthPercentage = 100f;

            tabela.DefaultCell.BorderColor = new BaseColor(255, 255, 255);
            tabela.DefaultCell.BorderColorBottom = new BaseColor(255, 255, 255);
            tabela.DefaultCell.Padding = 5;


            if (comBorda)
            {
                tabela.DefaultCell.Border = PdfPCell.BOX;

                tabela.AddCell(getNewCell(nomeColuna1, titulo, alinhamento, 5, preto, branco));

            }
            else
            {
                tabela.DefaultCell.Border = PdfPCell.NO_BORDER;

                tabela.AddCell(getNewCell(nomeColuna1, titulo, alinhamento, 5, PdfPCell.NO_BORDER, preto, branco));


            }

            return tabela;


        }

        #endregion

        public class PDFFooter : PdfPageEventHelper
        {

            PdfTemplate template;
            PdfContentByte cb;

            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                cb = writer.DirectContent;
                template = cb.CreateTemplate(50, 50);
            }


            // write on end of each page
            public override void OnEndPage(PdfWriter writer, Document document)
            {

                //Adiociona os direitos autorais na última página
                #region Footer
                base.OnEndPage(writer, document);
                PdfPTable footerTbl = new PdfPTable(1);
                footerTbl.WidthPercentage = 100f;
                footerTbl.TotalWidth = 1000f;
                footerTbl.HorizontalAlignment = 0;
                PdfPCell cell;
                footerTbl.DefaultCell.HorizontalAlignment = 0;
                footerTbl.WidthPercentage = 100;
                cell = new PdfPCell(new Phrase("Copyright © " + DateTime.Now.Year + " | Automasul ", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                cell.Border = 0;
                cell.Colspan = 1;
                cell.PaddingLeft = 0;
                cell.HorizontalAlignment = 0;
                footerTbl.AddCell(cell);
                footerTbl.WriteSelectedRows(0, -30, 230, 30, writer.DirectContent);

                base.OnEndPage(writer, document);

                int pageN = writer.PageNumber;
                String text = pageN.ToString();
                iTextSharp.text.Rectangle pageSize = document.PageSize;

                cb.SetRGBColorFill(100, 100, 100);

                cb.BeginText();
                cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 11F);
                cb.SetTextMatrix(document.RightMargin, pageSize.GetBottom(document.BottomMargin));
                cb.ShowText(text);

                cb.EndText();

                cb.AddTemplate(template, document.RightMargin + 0, pageSize.GetBottom(document.BottomMargin));
                #endregion

            }

            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                base.OnCloseDocument(writer, document);

                template.BeginText();
                template.SetFontAndSize(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 11F);
                template.SetTextMatrix(0, 0);
                //template.ShowText("BOdsta" + (writer.PageNumber - 1));
                template.EndText();
            }

            //write on close of document

        }

        //Função de converter o Chart em imagem para adicionar em Gráficos, ou outros fins;
        #region Buscar Imagem Chart
        /// <summary>
        /// Converter o Gráfco em imagem
        /// </summary>
        /// <param name="visual"> ENviar apenas o Chart (Nome colocado em suas propriedades)</param>
        /// <param name="filename">Nome que deseja salvar essa imagem (Importante se utilzado para PDF pois o mesmo deve ter o mesmo nome.)</param>
        public static void Savetopng(FrameworkElement visual, string filename)
        {
            try
            {
                var encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();

                EncodeVisual(visual, filename, encoder);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Função privada para converter a o Chart para imagem
        /// </summary>
        /// <param name="visual">Objeto que deseja salvar em tipo PNG</param>
        /// <param name="filename">Onde será salvo</param>
        /// <param name="encoder">Tipo de codificação da imagem</param>
        private static void EncodeVisual(FrameworkElement visual, string filename, System.Windows.Media.Imaging.BitmapEncoder encoder)
        {
            try
            {
                // Os itens 96 e 74 deve-se ser modificado conforme a necessidade da imagem.
                var bitmap = new System.Windows.Media.Imaging.RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 74, PixelFormats.Pbgra32);

                bitmap.Render(visual);

                var frame = System.Windows.Media.Imaging.BitmapFrame.Create(bitmap);
                encoder.Frames.Add(frame);

                using (var stream = File.Create(filename)) encoder.Save(stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");

            }
        }
        #endregion

        private static PdfPCell getNewCell(string Texto, Font Fonte, int Alinhamento, float Espacamento, int Borda, BaseColor CorBorda, BaseColor CorFundo)
        {
            var cell = new PdfPCell(new Phrase(Texto, Fonte));
            cell.HorizontalAlignment = Alinhamento;
            cell.Padding = Espacamento;
            cell.Border = Borda;
            cell.BorderColor = CorBorda;
            cell.BackgroundColor = CorFundo;

            return cell;
        }
        private static PdfPCell getNewCell(string Texto, Font Fonte, int Alinhamento, float Espacamento, BaseColor CorBorda, BaseColor CorFundo)
        {
            var cell = new PdfPCell(new Phrase(Texto, Fonte));
            cell.HorizontalAlignment = Alinhamento;
            cell.Padding = Espacamento;
            cell.Border = PdfPCell.BOX;
            cell.BorderColor = CorBorda;
            cell.BackgroundColor = CorFundo;

            return cell;
        }



    }
}
