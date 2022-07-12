using iTextSharp.text;
using iTextSharp.text.pdf;
using PRONTU.Controller;
using PRONTU.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRONTU
{
    public partial class Relatorios : Form
    {
        static BaseFont fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        public Relatorios()
        {
            InitializeComponent();
            gbAtendimento.Visible = false;
            PopularComboBoxPaciente();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            string rb = "";
            rb = gbTipos.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;

            switch (rb)
            {
                case "Relatório de atendimentos":
                    GerarRelatorioAtendimentos();
                    break;

                case "Laudo":
                    GerarLaudo();
                    break;
            }
        }

        private void CheckedChangedTipo(object sender, EventArgs e)
        {

            string rb = "";
            rb = gbTipos.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;

            if (rb.Equals("Relatório de atendimentos"))
            {
                gbAtendimento.Visible = true;
                gbLaudo.Visible = false;

                Point pt = new Point(12, 272);
                this.gbAtendimento.Location = pt;
            }
            else
            {
                gbAtendimento.Visible = false;
                gbLaudo.Visible = true;

                Point pt = new Point(12, 272);
                this.gbLaudo.Location = pt;
            }
        }

        private void PopularComboBoxPaciente()
        {
            var _pacientes = new List<String>();
            RelatorioAtendimentoController relatorio = new RelatorioAtendimentoController();

            _pacientes = relatorio.RetornarPacientesAtendimento(1);

            cbPaciente.Items.Add("Todos os pacientes");

            foreach (var v in _pacientes)
            {
                cbPaciente.Items.Add(v);
            }

            cbPaciente.SelectedIndex = cbPaciente.FindStringExact("Todos os pacientes"); // iniciar com TODOS
        }

        public void GerarRelatorioAtendimentos()
        {
            RelatorioAtendimentoController atendimento = new RelatorioAtendimentoController();
            var _atendimento = new List<RelatorioAtendimentoModel>();

            _atendimento = atendimento.RetornarAtendimentos(1, dpDataInicial.Value, dpDataFinal.Value, cbPaciente.Text);

            if (dpDataInicial.Value.Date > dpDataFinal.Value.Date)
            {
                MessageBox.Show("Data inicial maior que a data final", "Relatório de atendimentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                
            // GERAÇÃO DO RELATÓRIO
            if (_atendimento.Count() > 0)
            {
                var fonteNormal27 = new iTextSharp.text.Font(fonteBase, 27, iTextSharp.text.Font.NORMAL, BaseColor.Black);
                var fonteNormal12 = new iTextSharp.text.Font(fonteBase, 12, iTextSharp.text.Font.NORMAL, BaseColor.Black);

                // cálculo da quantidade total de páginas
                int totalPaginas = 1;
                int totalLinhas = _atendimento.Count;
                if (totalLinhas > 25)
                    totalPaginas += (int)Math.Ceiling((totalLinhas - 25) / 29F);

                // Configuração do documento PDF
                var pxPorMm = 72 / 25.5F;
                var pdf = new Document(PageSize.A4, 15 * pxPorMm, 15 * pxPorMm, 15 * pxPorMm, 20 * pxPorMm);
                var nomeArquivo = $"atendimentos_{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf";
                var arquivo = new FileStream(nomeArquivo, FileMode.Create);
                var writer = PdfWriter.GetInstance(pdf, arquivo);
                writer.PageEvent = new EventosDePagina(totalPaginas);
                pdf.Open();

                // Adição do título
                var titulo = new Paragraph("Relatório de Atendimentos", fonteNormal27);
                titulo.Alignment = Element.ALIGN_LEFT;
                //titulo.SpacingAfter = 4;
                pdf.Add(titulo);

                // Adiciona subtitulo
                var subTitulo = new Paragraph($"Período de {dpDataInicial.Value.ToString("d")} a {dpDataFinal.Value.ToString("d")}\n\n", fonteNormal12);
                subTitulo.Alignment = Element.ALIGN_LEFT;
                pdf.Add(subTitulo);

                // adição da imagem
                //var caminhoImagem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img\\logo_prontu_cinza_verde.png");
                string caminhoImagem = "";
                var c = Directory.GetParent(Directory.GetCurrentDirectory());
                if(c != null)
                {
                    caminhoImagem = c.ToString().Replace("bin", "img\\logo_prontu_cinza_verde.png");
                }
                if (File.Exists(caminhoImagem))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(caminhoImagem);
                    float razaoAlturaLargura = logo.Width / logo.Height;
                    float alturaLogo = 32; // alterar esse valor para trocar a dimensão da imagem
                    float larguraLogo = alturaLogo * razaoAlturaLargura;
                    logo.ScaleToFit(larguraLogo, alturaLogo);
                    var margemEsquerda = pdf.PageSize.Width - pdf.RightMargin - larguraLogo;
                    var margemTopo = pdf.PageSize.Height - pdf.TopMargin - 54;
                    logo.SetAbsolutePosition(margemEsquerda, margemTopo);
                    writer.DirectContent.AddImage(logo, false);
                }

                // Adição da tabela de dados
                var tabela = new PdfPTable(6);
                float[] larguraColunas = { 5.5f, 1.5f, 1f, 2f, 2f, 1f};
                tabela.SetWidths(larguraColunas);
                tabela.DefaultCell.BorderWidth = 0;
                tabela.WidthPercentage = 100;

                // Adição das células de títulos das colunas
                CriarCelulaTexto(tabela, "Paciente", PdfPCell.ALIGN_LEFT, true, false, 12, 25);
                CriarCelulaTexto(tabela, "Data", PdfPCell.ALIGN_LEFT, true, false, 12, 25);
                CriarCelulaTexto(tabela, "Hora", PdfPCell.ALIGN_LEFT, true, false, 12, 25);
                //CriarCelulaTexto(tabela, "Atendido", PdfPCell.ALIGN_CENTER, true, false, 12, 25);
                CriarCelulaTexto(tabela, "Convênio", PdfPCell.ALIGN_LEFT, true, false, 12, 25);
                CriarCelulaTexto(tabela, "Valor", PdfPCell.ALIGN_LEFT, true, false, 12, 25);
                CriarCelulaTexto(tabela, "Pago", PdfPCell.ALIGN_CENTER, true, false, 12, 25);

                // adição dos registros na tabela de dados
                foreach (var a in _atendimento)
                {
                    // Paciente
                    CriarCelulaTexto(tabela, a.Nome, PdfPCell.ALIGN_LEFT, false, false, 12, 25);
                    // Data
                    CriarCelulaTexto(tabela, a.Horario.ToString("d"), PdfPCell.ALIGN_LEFT, false, false, 12, 25);
                    // Hora
                    CriarCelulaTexto(tabela, a.Horario.ToString("HH:mm"), PdfPCell.ALIGN_LEFT, false, false, 12, 25);
                    // Atendido
                    //CriarCelulaTexto(tabela, a.Presenca ? "Sim" : "Não", PdfPCell.ALIGN_CENTER, false, false, 12, 25);
                    // Convênio
                    CriarCelulaTexto(tabela, a.Convenio, PdfPCell.ALIGN_LEFT, false, false, 12, 25);
                    // Valor
                    CriarCelulaTexto(tabela, a.Valor_pago.ToString("C2"), PdfPCell.ALIGN_LEFT, false, false, 12, 25);
                    // Pago
                    CriarCelulaTexto(tabela, a.Pagto ? "Sim" : "Não", PdfPCell.ALIGN_CENTER, false, false, 12, 25);
                }

                pdf.Add(tabela);

                pdf.Close();
                arquivo.Close();

                // Move o arquivo para area de trabalho
                //string origem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeArquivo);
                //string destino = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nomeArquivo);
                //System.IO.File.Move(origem, destino);

                // Abre o PDF no visualizador padrão
                var caminhoPDF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeArquivo);
                if (File.Exists(caminhoPDF))
                {
                    Process.Start(new ProcessStartInfo()
                    {
                        Arguments = $"/c start {caminhoPDF}",
                        FileName = "cmd.exe",
                        CreateNoWindow = true
                    });
                }
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado", "Relatório de atendimentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        static void CriarCelulaTexto(PdfPTable tabela, string texto, int alinhamentoHorz, bool negrito, bool italico, int tamahoFonte, int alturaCelula)
        {
            int estilo = iTextSharp.text.Font.NORMAL;
            if(negrito && italico)
            {
                estilo = iTextSharp.text.Font.BOLDITALIC;
            }
            else if (negrito)
            {
                estilo = iTextSharp.text.Font.BOLD;
            }
            else if (italico)
            {
                estilo= iTextSharp.text.Font.ITALIC;
            }

            var fonteCelula = new iTextSharp.text.Font(fonteBase, tamahoFonte, estilo, BaseColor.Black);

            // linhas zebradas
            var bgColor = iTextSharp.text.BaseColor.White;
            if(tabela.Rows.Count % 2 == 1)
                bgColor = new BaseColor(0.95F, 0.95F, 0.95F);

            var celula = new PdfPCell(new Phrase(texto, fonteCelula));
            celula.HorizontalAlignment = alinhamentoHorz;
            celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            celula.Border = 0;
            celula.BorderWidthBottom = 1;
            celula.FixedHeight = alturaCelula;
            celula.PaddingBottom = 5;
            celula.BackgroundColor = bgColor;
            tabela.AddCell(celula);
        }

        public void GerarLaudo()
        {
            LaudoController laudo = new LaudoController();
            var _laudo = new List<LaudoModel>();

            _laudo = laudo.RetornarDadosDoProfissional(1);

            var fonteNormal12 = new iTextSharp.text.Font(fonteBase, 12, iTextSharp.text.Font.NORMAL, BaseColor.Black);
            var fonteNormal14 = new iTextSharp.text.Font(fonteBase, 14, iTextSharp.text.Font.NORMAL, BaseColor.Black);
            var fonteBold12 = new iTextSharp.text.Font(fonteBase, 12, iTextSharp.text.Font.BOLD, BaseColor.Black);
            var fonteBold16 = new iTextSharp.text.Font(fonteBase, 16, iTextSharp.text.Font.BOLD, BaseColor.Black);
            var fonteUnderline12 = new iTextSharp.text.Font(fonteBase, 12, iTextSharp.text.Font.UNDERLINE, BaseColor.Black);

            // Configuração do documento PDF
            var pxPorMm = 72 / 25.5F;
            var pdf = new Document(PageSize.A4, 15 * pxPorMm, 15 * pxPorMm, 15 * pxPorMm, 20 * pxPorMm);
            var nomeArquivo = $"laudo_{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf";
            var arquivo = new FileStream(nomeArquivo, FileMode.Create);
            var writer = PdfWriter.GetInstance(pdf, arquivo);
            //writer.PageEvent = new EventosDePagina(totalPaginas);
            pdf.Open();

            // Adição dos dados do profissional
            var profissional = new Paragraph(_laudo[0].Nome + " - " + _laudo[0].Profissao + " - " + _laudo[0].Registro_profissional, fonteNormal14);
            profissional.Alignment = Element.ALIGN_CENTER;
            profissional.SpacingAfter = 10;
            pdf.Add(profissional);

            // Adição da linha do paciente
            var paciente = new Paragraph("Nome:\nDocumento:", fonteBold12);
            paciente.Alignment = Element.ALIGN_LEFT;
            paciente.SpacingAfter = 10;
            pdf.Add(paciente);

            // Adição do título
            var titulo = new Paragraph(txtTitulo.Text, fonteBold16);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 10;
            pdf.Add(titulo);

            if (String.IsNullOrEmpty(txtDiagnostico.Text))
            {
                // Adição das linhas em branco
                var vazio = new Paragraph("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n", fonteBold16);
                vazio.Alignment = Element.ALIGN_LEFT;
                pdf.Add(vazio);
            }
            else
            {
                // Adiciona o texto informado
                var textoDetalhado = new Paragraph(txtDiagnostico.Text + "\n\n", fonteNormal12);
                textoDetalhado.Alignment = Element.ALIGN_LEFT;
                pdf.Add(textoDetalhado);
            }

            // Adição da assinatura
            var nomeAssinatura = new Paragraph(_laudo[0].Nome, fonteUnderline12);
            var assinatura = new Paragraph(_laudo[0].Profissao + "\n" + _laudo[0].Registro_profissional + "\n" +
                _laudo[0].Cidade + " - " + _laudo[0].Uf + "\n" + _laudo[0].Telefone + "\n" + _laudo[0].Email, fonteNormal12);
            assinatura.Alignment = Element.ALIGN_LEFT;
            pdf.Add(nomeAssinatura);
            pdf.Add(assinatura);

            // Adição da data
            string texto = DateTime.Now.ToLongDateString();
            string strData = char.ToUpper(texto[0]) + texto.Substring(1);
            var data = new Paragraph(strData, fonteNormal12);
            data.Alignment = Element.ALIGN_RIGHT;
            pdf.Add(data);

            pdf.Close();
            arquivo.Close();

            //string origem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeArquivo);
            //string destino = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nomeArquivo);
            //System.IO.File.Move(origem, destino);

            // Abre o PDF no visualizador padrão
            var caminhoPDF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeArquivo);
            if (File.Exists(caminhoPDF))
            {
                Process.Start(new ProcessStartInfo()
                {
                    Arguments = $"/c start {caminhoPDF}",
                    FileName = "cmd.exe",
                    CreateNoWindow = true
                });
            }
        }
    }
}
