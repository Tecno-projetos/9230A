using _9230A_V00___PI.Properties;
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
        /// <param name="dtblTable"> Enviar um data table para criar as colunas e a as linhas </param>
        /// <param name="strPdfPath">Caminho a ser salvo o PDF </param>
        /// <param name="strHeader"> O que será escrito no cabeçalho da página</param>
        /// <param name="Producao">Valor de total da produção</param>
        /// <param name="dataExportacaoInicial"> Envia uma data para ser salvo no PDF e para mostrar quando foi iniciado a exportação</param>
        /// <param name="dataExportacaoFinal"> Envia uma data para ser salvo no PDF e para mostrar quando foi finalizado a exportação</param>
               
        public static void ExportDataTableToPdf(DataTable dtblTable, String strPdfPath, string strHeader, string Producao, DateTime dataExportacaoInicial, DateTime dataExportacaoFinal)
        {
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

            //Add Data de exportação
            BaseFont bfntParagraph = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntProducao = new Font(bfntParagraph, 12, 1, iTextSharp.text.BaseColor.BLACK);

            #endregion

            //Cria a table para inserir os dados
            #region Cabeçalho do Relatório

            BaseColor preto = new BaseColor(0, 0, 0);
            BaseColor fundo = new BaseColor(200, 200, 200);
            BaseColor branco = new BaseColor(255, 255, 255);
            Font font = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, Font.BOLD, preto);
            Font titulo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, Font.BOLD, preto);

            float[] colsW = { 25, 25 };


            PdfPTable table_Linha1 = new PdfPTable(2);
            PdfPTable table_Linha2 = new PdfPTable(2);
            PdfPTable table_Linha3 = new PdfPTable(2);


            table_Linha1 = createTable(table_Linha1, colsW);
            table_Linha2 = createTable(table_Linha2, colsW);
            table_Linha3 = createTable(table_Linha3, colsW);

            table_Linha1.AddCell(getNewCell("Peso total produzido:" +"1500000" + " kg",  titulo, Element.ALIGN_LEFT, 10, PdfPCell.NO_BORDER, preto, branco));
            table_Linha1.AddCell(getNewCell("Volume total produzido:" + "1500000" + " m³", titulo, Element.ALIGN_LEFT, 10, PdfPCell.NO_BORDER, preto, branco));

            table_Linha2.AddCell(getNewCell("Quantidade total produzida:" + "150" + " produções", titulo, Element.ALIGN_LEFT, 10, PdfPCell.NO_BORDER, preto, branco));
            table_Linha2.AddCell(getNewCell("Total de Bateladas prooduzidas:" + "150" + " und.", titulo, Element.ALIGN_LEFT, 10, PdfPCell.NO_BORDER, preto, branco));

            table_Linha3.AddCell(getNewCell("Data Inicial pesquisa:" + DateTime.Now.ToString(), titulo, Element.ALIGN_LEFT, 10, PdfPCell.NO_BORDER, preto, branco)); ;
            table_Linha3.AddCell(getNewCell("Data Final pesquisa:" + DateTime.Now.ToString(), titulo, Element.ALIGN_LEFT, 10, PdfPCell.NO_BORDER, preto, branco));

            #endregion

            document.Add(table_Linha1);
            document.Add(table_Linha2);
            document.Add(table_Linha3);

            //Add a line seperation
            Paragraph p1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p1);


            //document.Add(new Chunk("Produção Total = " + Producao));
            //document.Add(new Chunk("\nExportado Data: " + dataExportacaoInicial + " a Data: " + dataExportacaoFinal));


            ////Write the table
            //PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            ////Table header
            //BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, iTextSharp.text.BaseColor.WHITE);

            ////Adiciona tabela
            //for (int i = 0; i < dtblTable.Columns.Count; i++)
            //{
            //    PdfPCell cell = new PdfPCell();
            //    cell.BackgroundColor = iTextSharp.text.BaseColor.GRAY;
            //    cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
            //    table.AddCell(cell);
            //}
            ////table Data
            //for (int i = 0; i < dtblTable.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dtblTable.Columns.Count; j++)
            //    {
            //        table.AddCell(dtblTable.Rows[i][j].ToString());
            //    }
            //}
            //document.Add(table);

            document.Close();
            writer.Close();
            fs.Close();
        }


        private static PdfPTable createTable(PdfPTable tabela, float[] colsW) 
        {
            tabela.SetWidths(colsW);
            tabela.HeaderRows = 0;
            tabela.WidthPercentage = 100f;
            tabela.DefaultCell.Border = PdfPCell.NO_BORDER;
            tabela.DefaultCell.BorderColor = new BaseColor(255, 255, 255);
            tabela.DefaultCell.BorderColorBottom = new BaseColor(255, 255, 255);
            tabela.DefaultCell.Padding = 10;

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

        private static PdfPCell getNewCell(string Texto, Font Fonte, int Alinhamento, float Espacamento, int Borda, BaseColor CorBorda)
        {
            return getNewCell(Texto, Fonte, Alinhamento, Espacamento, Borda, CorBorda, new BaseColor(255, 255, 255));
        }
        private static PdfPCell getNewCell(string Texto, Font Fonte, int Alinhamento = 0, float Espacamento = 5, int Borda = 0)
        {
            return getNewCell(Texto, Fonte, Alinhamento, Espacamento, Borda, new BaseColor(0, 0, 0), new BaseColor(255, 255, 255));
        }


    }
}
