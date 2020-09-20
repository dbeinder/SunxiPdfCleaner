using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections.Generic;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Text.RegularExpressions;

namespace SunxiPdfCleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //open files with owner password
            PdfReader.unethicalreading = true;
        }

        private void cbReplaceText_CheckedChanged(object sender, EventArgs e)
        {
            tbReplaceMatch.Enabled = cbReplaceText.Checked;
            tbReplaceReplace.Enabled = cbReplaceText.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbReplaceMatch.Enabled = cbReplaceText.Checked;
            tbReplaceReplace.Enabled = cbReplaceText.Checked;
        }

        private void SetProgress(string state)
        {
            lblProgress.Text = state;
            Application.DoEvents();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbPath.Text))
                return;

            dataGridView1.Rows.Clear();
            Cursor = Cursors.WaitCursor;

            IEnumerable<string> srcFiles;
            if (System.IO.File.GetAttributes(tbPath.Text).HasFlag(FileAttributes.Directory))
            {
                srcFiles = Directory.EnumerateFiles(tbPath.Text, "*.pdf", SearchOption.AllDirectories);
            }
            else
            {
                srcFiles = new string[] { tbPath.Text };
            }

            foreach (var srcFile in srcFiles)
            {
                var dataGridRowNum = dataGridView1.Rows.Add(new object[] { srcFile, 0 });
                try
                {
                    SetProgress("reading...");
                    var reader = new UnethicalPdfReader(srcFile);
                    var dstFile = Path.Combine(Path.GetDirectoryName(srcFile),
                        Path.GetFileNameWithoutExtension(srcFile) + tbSuffix.Text);
                    var outStream = new MemoryStream();

                    var pdfStamper = new PdfStamper(reader, outStream, reader.PdfVersion, false);
                    pdfStamper.RotateContents = false;

                    var processor = cbReplaceText.Checked
                        ? new TextReplaceStreamEditor(tbReplaceMatch.Text, tbReplaceReplace.Text)
                        : new PdfContentStreamEditor();
                    processor.RemoveXObjects = cbRemoveXO.Checked;
                    processor.Watermark = new Regex(tbWatermark.Text, RegexOptions.Compiled);
                    if (cbReplaceText.Checked || cbRemoveXO.Checked)
                    {
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            processor.EditPage(pdfStamper, i);
                            SetProgress($"page: {i} / {reader.NumberOfPages}");
                        }
                    }

                    if (cbRemoveXO.Checked && processor.WatermarkCount != reader.NumberOfPages)
                    {
                        MessageBox.Show($"{processor.WatermarkCount} XObjects removed, but there are {reader.NumberOfPages} pages",
                            "Possible failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (cbRemoveJavascript.Checked && reader.JavaScript != null)
                    {
                        pdfStamper.JavaScript = "";
                    }

                    pdfStamper.Writer.Info?.Clear();
                    pdfStamper.XmpMetadata = new byte[0];
                    pdfStamper.MoreInfo?.Clear();

                    SetProgress("writing...");
                    pdfStamper?.Close();
                    reader?.Close();

                    //re-compress and save the PDF
                    var output = File.Open(dstFile, FileMode.Create);
                    var p2 = new PdfStamper(new PdfReader(outStream.GetBuffer()), output, reader.PdfVersion);
                    if (cbUncompressed.Checked)
                    {
                        p2.Writer.CompressionLevel = PdfStream.NO_COMPRESSION;
                    }
                    else
                    {
                        p2.Writer.CompressionLevel = PdfStream.BEST_COMPRESSION;
                        p2.SetFullCompression();
                    }
                    p2.Close();
                    SetProgress("done");

                    dataGridView1.Rows[dataGridRowNum].ErrorText = ""; ;
                }
                catch (Exception ex)
                {
                    dataGridView1.Rows[dataGridRowNum].ErrorText = ex.Message;
                }
                Application.DoEvents();
            }

            Cursor = Cursors.Arrow;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var browse = new CommonOpenFileDialog()
            {
                EnsurePathExists = true,
                //IsFolderPicker = true,
                Multiselect = false,
                Title = "Select Path for PDF Cleaner",
            };
            browse.Filters.Add(new CommonFileDialogFilter("PDF Files", ".pdf"));
            browse.DefaultExtension = ".pdf";

            if (browse.ShowDialog() == CommonFileDialogResult.Ok)
                tbPath.Text = browse.FileName;
        }
    }

    class UnethicalPdfReader : PdfReader
    {
        public UnethicalPdfReader(string file) : base(file) { encrypted = false; }
    }
}
