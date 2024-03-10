using Newtonsoft.Json;
using OfficeOpenXml;
//using System;
//using System.Net;
//using System.Reflection;
//using System.Text;
//using System.Text.Unicode;
//using System.Windows.Forms;
//using System.Windows.Forms.Design;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LBA1TextViewer
{
    public partial class Form1 : Form
    {
        const byte NUMBER_OF_LANGUAGES = 7;
        //English   French  Italian     German      Spanish     Portuguese      Japanese
        List<List<string>> Languages = new List<List<string>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lbTexts.Items.
            populateDataSpreadSheet();
        }

        private string getTextDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "LBA2TextDump\\";
        }

        private void populateDataSpreadSheet()
        {
            lvText.Font = new Font(lvText.Font, FontStyle.Bold);
            lvText.Items.Clear();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string inputPath = AppDomain.CurrentDomain.BaseDirectory + "files\\cleansedData.xlsx";
            FileInfo fileInfo = new FileInfo(inputPath);
            ExcelPackage ep = new ExcelPackage(fileInfo);

            for (int i = 0; i < NUMBER_OF_LANGUAGES; i++)
                Languages.Add(new List<string>());

            for (int i = 1; i < ep.Workbook.Worksheets[0].Rows.Count() + 1; i++)
            {
                Languages[0].Add(ep.Workbook.Worksheets[0].Cells[i, 1].Value.ToString().Replace('@', '\n'));
                Languages[1].Add(ep.Workbook.Worksheets[0].Cells[i, 2].Value.ToString().Replace('@', '\n'));
                Languages[2].Add(ep.Workbook.Worksheets[0].Cells[i, 3].Value.ToString().Replace('@', '\n'));
                Languages[3].Add(ep.Workbook.Worksheets[0].Cells[i, 4].Value.ToString().Replace('@', '\n'));
                Languages[4].Add(ep.Workbook.Worksheets[0].Cells[i, 5].Value.ToString().Replace('@', '\n'));
                Languages[5].Add(ep.Workbook.Worksheets[0].Cells[i, 6].Value.ToString().Replace('@', '\n'));
                string s;
                if (null != ep.Workbook.Worksheets[0].Cells[i, 7].Value)
                    s = ep.Workbook.Worksheets[0].Cells[i, 7].Value.ToString();
                else
                    s = "";
                Languages[6].Add(s.Replace('@', '\n'));
            }
            //AddItemToListView(lvText, 0);
            for (int i = 0; i < Languages[0].Count; i++)
            {
                AddItemToListView(lvText, i);
            }

            for (int i = 0; i < lvText.Columns.Count; i++)
                cboLanguage.Items.Add(lvText.Columns[i].Text);
            cboLanguage.Items.Add("All");
            cboLanguage.SelectedIndex = lvText.Columns.Count;
        }

        private void AddItemToListView(System.Windows.Forms.ListView lv, int itemNumber)
        {
            ListViewItem lvi = new ListViewItem(Languages[0][itemNumber]);
            lvi.Font = new Font(lvi.Font, FontStyle.Regular);
            for (int j = 1; j < NUMBER_OF_LANGUAGES; j++)
                lvi.SubItems.Add(Languages[j][itemNumber]);
            lv.Items.Add(lvi);
        }
        #region old
        /* private void populateDataFiles()
         {
             Languages = new List<List<string>>();
             lvText.Items.Clear();
             string[] fileList = Directory.GetFiles(getTextDirectory());
             for (int i = 0; i < NUMBER_OF_LANGUAGES; i++)
                 Languages.Add(new List<string>());

             //We process entry 0..1...2... for all languages simultaneously
             for (int i = 0; i < fileList.Length; i++)
             {
                 ReadAllEntriesForFile(Languages[i / (fileList.Length / NUMBER_OF_LANGUAGES)], fileList[i]);
             }
             for (int i = 0; i < Languages[0].Count; i++)
             {
                 ListViewItem lvi = new ListViewItem(Languages[0][i]);
                 lvi.SubItems.Add(Languages[1][i]);
                 lvi.SubItems.Add(Languages[2][i]);
                 lvi.SubItems.Add(Languages[3][i]);
                 lvi.SubItems.Add(Languages[4][i]);
                 lvi.SubItems.Add(Languages[5][i]);
                 lvText.Items.Add(lvi);
             }
         }*/
        /*
        private void ReadAllEntriesForFile(List<string> language, string fullFilePath)
        {
            FileStream fs = File.Open(fullFilePath, FileMode.Open);
            char startPos = (char)0;
            BinaryReader br = new BinaryReader(fs);
            byte[] firstEntry = br.ReadBytes(2);
            startPos = (char)(firstEntry[1] << 8);
            startPos |= (char)(firstEntry[0]);
            fs.Position = startPos;

            byte b = 0;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                List<byte> bytes = new List<byte>();
                do
                {
                    if (0 != b) bytes.Add(b);
                    b = br.ReadByte();
                } while (0 != b);
                language.Add(byteListToString(bytes));
            }

            br.Close();
            fs.Close();
        }*/
        /*private string byteListToString(List<byte> byteList)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] b = new byte[byteList.Count];
            for (int i = 0; i < byteList.Count; i++)
                b[i] = byteList[i];

            byte[] unicodeBytes = Encoding.Convert(Encoding.GetEncoding(850), Encoding.Unicode, b);

            char[] uniChars = new char[Encoding.Unicode.GetCharCount(unicodeBytes, 0, unicodeBytes.Length)];
            Encoding.Unicode.GetChars(unicodeBytes, 0, unicodeBytes.Length, uniChars, 0);
            return new string(uniChars);
        }*/

        
        private void btnOutputToFile_Click(object sender, EventArgs e)
        {
            string fName = "ru-RU";
            string path1 = AppDomain.CurrentDomain.BaseDirectory + "JSON\\LBA2\\" + fName + ".json";
            string fileContentsOne = File.ReadAllText(path1);
            dynamic fileContentsOneJson = JsonConvert.DeserializeObject<dynamic>(fileContentsOne);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string outputPath = "E:\\dump\\" + fName + "-LBA2_actual.xlsx";
            FileInfo fileInfo = new FileInfo(outputPath);

            ExcelPackage ep = new ExcelPackage(fileInfo);
            ep.Workbook.Worksheets.Add("LBAText");
            for (int i = 0, row = 1; i < fileContentsOneJson.entries.Count; i++)
            {
                for (int j = 0; j < fileContentsOneJson.entries[i].texts.Count; j++, row++)
                {
                    ep.Workbook.Worksheets[0].Cells[row, 1].Value = fileContentsOneJson.entries[i].texts[j].quote.ToString();
                }
            }
        /*ep.Workbook.Worksheets[0].Cells[1, 1].Value = lvText.Columns[0].Text;
        ep.Workbook.Worksheets[0].Cells[1, 2].Value = lvText.Columns[1].Text;
        ep.Workbook.Worksheets[0].Cells[1, 3].Value = lvText.Columns[2].Text;
        ep.Workbook.Worksheets[0].Cells[1, 4].Value = lvText.Columns[3].Text;
        ep.Workbook.Worksheets[0].Cells[1, 5].Value = lvText.Columns[4].Text;
        for (int i = 0; i < Languages[0].Count; i++)
            ep.Workbook.Worksheets[0].Cells[2 + i, 1].Value = Languages[0][i];
        for (int i = 0; i < Languages[1].Count; i++)
            ep.Workbook.Worksheets[0].Cells[2 + i, 2].Value = Languages[1][i];
        for (int i = 0; i < Languages[2].Count; i++)
            ep.Workbook.Worksheets[0].Cells[2 + i, 3].Value = Languages[2][i];
        for (int i = 0; i < Languages[3].Count; i++)
            ep.Workbook.Worksheets[0].Cells[2 + i, 4].Value = Languages[3][i];
        for (int i = 0; i < Languages[4].Count; i++)
            ep.Workbook.Worksheets[0].Cells[2 + i, 5].Value = Languages[4][i];*/
        ep.Save();
    }
        #endregion

        private void listView1_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < lvText.Columns.Count; i++)
                lvText.Columns[i].Width = (lvText.Width - (SystemInformation.VerticalScrollBarWidth + 5)) / lvText.Columns.Count;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int languageChoice = NUMBER_OF_LANGUAGES;
            for (int i = 0; i < lvText.Columns.Count; i++)
            {
                if (lvText.Columns[i].Text.Equals(cboLanguage.Text))
                {
                    languageChoice = i;
                    i = lvText.Columns.Count;
                }
            }

            lvText.Items.Clear();


            if (NUMBER_OF_LANGUAGES == languageChoice)
            {
                for (int i = 0; i < Languages[0].Count(); i++)
                {
                    //Do any of the Lists contain the search timer at position i
                    bool contains = false;
                    for (int j = 0; j < Languages.Count(); j++)
                        if (Languages[j][i].ToLower().Contains(txtSearchText.Text.ToLower()))
                            contains = true;
                    //One of the Lists contained the search term at position i
                    if (contains)
                        AddItemToListView(lvText, i);
                }
            }
            else
                for (int i = 0; i < Languages[languageChoice].Count; i++)
                    if (Languages[languageChoice][i].ToLower().Contains(txtSearchText.Text.ToLower()))
                        AddItemToListView(lvText, i);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            lvText.Items.Clear();
            for (int i = 0; i < Languages[0].Count; i++)
            {
                AddItemToListView(lvText, i);
            }
        }

        private void lvText_Click(object sender, EventArgs e)
        {
            try
            {
                Point mousePosition = lvText.PointToClient(Control.MousePosition);
                ListViewHitTestInfo hit = lvText.HitTest(mousePosition);
                Clipboard.Clear();
                Clipboard.SetText(hit.SubItem.Text);
            }
            catch { }
        }

        private void btnPopulateFromTextFiles_Click(object sender, EventArgs e)
        {
            //populateDataFiles();
        }

        private void btnPopulateSpreadsheet_Click(object sender, EventArgs e)
        {
            populateDataSpreadSheet();
        }

        private void lvText_DoubleClick(object sender, EventArgs e)
        {
            Point mousePosition = lvText.PointToClient(Control.MousePosition);
            ListViewHitTestInfo hit = lvText.HitTest(mousePosition);
            MessageBox.Show(hit.SubItem.Text);
        }

        private void txtSearchText_Click(object sender, EventArgs e)
        {
            txtSearchText.Text = Clipboard.GetText();
            btnSearch_Click(null, null);
        }

    }

}