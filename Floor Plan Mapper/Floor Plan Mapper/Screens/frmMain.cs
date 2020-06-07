
using Floor_Plan_Mapper.Screens;
using IronOcr;
using iTextSharp.text.pdf;
using Newtonsoft.Json.Linq;
using SautinSoft.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Floor_Plan_Mapper
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose Floor Plan";
            ofd.Filter = "PDF Files |*.pdf";
            ofd.InitialDirectory =@"" + Environment.SpecialFolder.MyDocuments;
            String pathToFile = "";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pathToFile = ofd.FileName;
                txtFile.Text = pathToFile;
                String src = pathToFile.Replace(Path.GetFileName(pathToFile), "");
                DocumentCore dc = DocumentCore.Load("Single.pdf");
                String[] supportedFiles = { pathToFile, "blank.pdf" };
                DocumentCore document = DocumentCore.Load(pathToFile);
                DocumentCore blank = DocumentCore.Load("blank.pdf");
                string singlePDFPath = "Single.pdf";
                string workingDir = @"..\..\";
                DocumentCore singlePDF = new DocumentCore();
                // Create import session.
                foreach (string file in supportedFiles)
                {
                    DocumentCore dc2 = DocumentCore.Load(file);

                    Console.WriteLine("Adding: {0}...", Path.GetFileName(file));

                    // Create import session.
                    ImportSession session = new ImportSession(dc2, singlePDF, StyleImportingMode.KeepSourceFormatting);

                    // Loop through all sections in the source document.
                    foreach (Section sourceSection in dc2.Sections)
                    {
                        // Because we are copying a section from one document to another,
                        // it is required to import the Section into the destination document.
                        // This adjusts any document-specific references to styles, bookmarks, etc.
                        //
                        // Importing a element creates a copy of the original element, but the copy
                        // is ready to be inserted into the destination document.
                        Section importedSection = singlePDF.Import<Section>(sourceSection, true, session);

                        // First section start from new page.
                        if (dc.Sections.IndexOf(sourceSection) == 0)
                            importedSection.PageSetup.SectionStart = SectionStart.NewPage;

                        // Now the new section can be appended to the destination document.
                        singlePDF.Sections.Add(importedSection);
                    }
                }
                singlePDF.Save(singlePDFPath);
                DocumentPaginator dp = dc.GetPaginator(new PaginatorOptions());
                pathToFile = pathToFile.Replace(Path.GetFileName(pathToFile), "");
                for (int i = 0; i < dp.Pages.Count(); i++)
                {
                    if (File.Exists(pathToFile + i.ToString() + ".png"))
                    {
                        File.Delete(pathToFile + i.ToString() + ".png");
                    }
                    dp.Pages[i].Rasterize(150, SautinSoft.Document.Color.White).Save(pathToFile + i.ToString() + ".png");
                }
                picPreview.ImageLocation = pathToFile + "0.png";
            }
        }
        private static Image cropImage(Bitmap img, Rectangle cropArea)
        {
            return img.Clone(cropArea, img.PixelFormat);
        }
        private void btnStudio_Click(object sender, EventArgs e)
        {
            frmMapper f = new frmMapper();
            f.img = picPreview.Image;
            f.buildingName = tbBuildingName.Text;
            f.floor = tbFloor.Text;
            f.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
