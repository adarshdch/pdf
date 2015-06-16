using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Text.RegularExpressions;


namespace PDFReaderTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ofdPDF.ShowDialog();
            txtPdfFile.Text = ofdPDF.FileName;

          
            //txtPdfFile.Text=@"C:\Sneha\My Work\PDFReaderTest1\102660910.pdf";
        }

        private void ParsePdf(string fileName)
        {

            rTxtAllRefs.Text = "";
            rTxtRef.Text = "";
            rTxtSplitRef.Text = "";

            if (!File.Exists(fileName))
                throw new FileNotFoundException("fileName");
            using (PdfReader reader = new PdfReader(fileName))
            {
                
 
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                int totalpages = reader.NumberOfPages;
                int refStartPage;

                bool refFound;
                refFound = false;
                StringBuilder st=new StringBuilder() ;

                string text, text1, text2, findText,f2,f1;


                findText = "references \n";
                f2 = "references\n";
                   
                 text1 = "";
                text2 = "";
                text = "";
                refFound = false ;
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                        text = PdfTextExtractor.GetTextFromPage(reader, page , strategy);
 
                }

                if (text != null)
                {
                    if ((text.ToLower()).Contains(findText) )
                        {
                            refFound = true;
                        }
                    else
                    {
                        if( (text.ToLower()).Contains(f2))
                        {
                            refFound = true;
                            findText = f2;
                        }
                    }

                }

                ////Regex emailRegex = new Regex(@"(?<NO>\d+)\.\s*(?<AU>.+?)\.\s*(?<Tit1>.+?)\.\s*(?<Pub>.+?)\s*(?<py>\d{4});(?<vol>.d+)((*)\(?<IS>\d*)()*):\s*(i*)(?<sp>\d+)–(i*)(?<ep>\d+)\.",
                //Regex emailRegex = new Regex(@"(?<NO>\d+)\.\s*(?<AU>.+?)\.\s*(?<TI>.+?)\.\s*(?<JR>.+?).\s*(?<PY>\d{4});\s*(?<VO>\d+)\s*\((?<IS>\d+)\):\s*(?<SP>\d+)–(?<EP>\d+)\.",
                //     RegexOptions.IgnoreCase); //.((.(?<IS>\d+).))*


                Regex emailRegex = new Regex(@"(?<NO>\d+)\.\s*(?<AU>.+?)\.\s*(?<Tit1>.+?)\.\s*(?<Pub>.+?)\s*(?<py>\d{4});(?<vol>.+?):\s*(?<sp>\d+)–(?<ep>\d+)\.",
                    RegexOptions.IgnoreCase); //.((.(?<IS>\d+).))*


                //Regex emailRegex = new Regex(@"\.\n(?<NO>\d+)\.\s*",
                //    RegexOptions.IgnoreCase); //.((.(?<IS>\d+).))*
                
                
                //text = "Iwakura Y, Nakae S, Saijo S, Ishigame H. The roles of IL-17A in inflammatory immune responses and host defense against pathogens. Immunol Rev 2008;226:57–79.";
                    //text = "Iwakura Y, Nakae S, Saijo S, Ishigame " + Environment.NewLine + "H. The roles of IL-17A in inflammatory" + Environment.NewLine + "immune responses and host defense" + Environment.NewLine + "against pathogens. Immunol Rev 2008;" + Environment.NewLine + "226:57–79.";
                
//                st.AppendLine("Li YP, Chen W, Liang Y, Li E, Stashenko");
//                    st.Append("P. Atp6i-deficient mice exhibit severe");
//st.Append("osteopetrosis due to loss of osteoclastmediated");
//st.Append("extracellular acidification. Nature");
//st.Append("Genet 1999;23:447–451.");

//text = st.ToString();


                if (refFound == true)
                {
                    text2 = text.Substring(0, text.IndexOf(findText) + 1);
                    text1 = text.Substring(text.ToLower().IndexOf(findText));//+ findText.Length);

                    rTxtRef.Text = text1;

                    //text1 = text1.Replace("\n", "");

                    //text = " 16. Burgess TL, Qian Y, Kaufman S, et al.  The ligand for osteoprotegerin (OPGL)  directly activates mature osteoclasts.   J Cell Biol 1999;145:527–538. © 2015 BY QUINTESSENCE PUBLISHING CO, INC. PRINTING OF THIS DOCUMENT IS RESTRICTED TO PERSONAL USE ONLY.  NO PART MAY BE REPRODUCED OR TRANSMITTED IN ANY FORM WITHOUT WRITTEN PERMISSION FROM THE PUBLISHER.  The International Journal of Periodontics & Restorative Dentistry e34 17. Li YP, Chen W, Liang Y, Li E, Stashenko  P. Atp6i­ deficient mice exhibit severe  osteopetrosis due to loss of osteoclast­ mediated extracellular acidification. Na ­ ture Genet 1999;23:447–451. 18. Zhang F, Wang CL, Koyama Y, et al.  Compressive force stimulates the gene  expression of IL­ 17s and their receptors  in MC3T3­ E1 cells. Connect Tissue Res  2010;51:359–369. ";
                    //text1 = " N PERMISSION FROM THE PUBLISHER.  The International Journal of Periodontics & Restorative Dentistry e34 17. Li YP, Chen W, Liang Y, Li E, Stashenko  P. Atp6i­ deficient mice exhibit severe  osteopetrosis due to loss of osteoclast­ mediated extracellular acidification. Na ­ ture Genet 1999;23:447–451. 18. Zhang F, Wang CL, Koyama Y, et al.  Compressive force stimulates the gene  expression of IL­ 17s and their receptors  in MC3T3­ E1 cells. Connect Tissue Res  2010;51:359–369. ";

                    Match m = emailRegex.Match(text1);
                    text1 = "";
                    if (m.Length > 0)
                    {
                        while (m.Success)
                        {
                            text1 = text1 + Environment.NewLine + Environment.NewLine + m.Value;
                            text2 = m.Value;
                            m = m.NextMatch();
                        }

                        if (text1.Length > 0)
                        {
                            rTxtAllRefs.Text = text1;
                            //string[] str = text1.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                            //if (str.Length > 0)
                            //    rTxtRef.Text = str[0];

                            //rTxtRef.Text = text1.Substring(text1.IndexOf("\n") + 1, (text1.Substring(text1.IndexOf("\n") + 1)).IndexOf("\n"));
                        }
                        string[] result = emailRegex.Split(text2);
                        rTxtSplitRef.Text += "AUTHOR - " + result[2] + Environment.NewLine;
                        rTxtSplitRef.Text += "Tiltle - " + result[3] + Environment.NewLine;
                        rTxtSplitRef.Text += "Publisher - " + result[4] + Environment.NewLine;
                        rTxtSplitRef.Text += "PY - " + result[5] + Environment.NewLine;
                        rTxtSplitRef.Text += "Vol - " + result[6] + Environment.NewLine;
                        rTxtSplitRef.Text += "SP - " + result[7] + Environment.NewLine;
                        rTxtSplitRef.Text += "EP - " + result[8] + Environment.NewLine;
                    }
                    else
                        MessageBox.Show("No refs found with given expression");

            
                }
                else
                    MessageBox.Show("No refs found");
            }
        }

        private void btnGetRef_Click(object sender, EventArgs e)
        {
            ParsePdf(txtPdfFile.Text);
        }
    }
}
