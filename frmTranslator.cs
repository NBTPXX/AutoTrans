using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RimTrans
{
    public partial class FrmTranslator : Form
    {
        private void Mainfrm_Load(object sender, EventArgs e)
        {
            FormInit();
            FunRefresh();
            //UserDictInitialize();
            SetToolTip();
            //ComBOldVersionInitialize();
            string path = Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == "ID")
                {
                    appid.Text = Read_keyValue(path, "ID");
                    Situation.Id = Read_keyValue(path, "ID");
                }
                if (key == "key")
                {
                    keyword.Text = Read_keyValue(path, "key");
                    Situation.Key = Read_keyValue(path, "key");
                }
            }
            ChkSimplifiedChinese.Checked = true;
        }

        private void SetToolTip()
        {
            ToolTiptt.AutomaticDelay = 100;
            ToolTiptt.AutoPopDelay = 10000;
            ToolTiptt.InitialDelay = 200;
            ToolTiptt.ReshowDelay = 200;
        }

        List<XMLdata> XMLText;
        Dictionary<string, string> UserDict = new Dictionary<string, string>();
        ToolTip ToolTiptt = new ToolTip();

        private void BtnSave_Click(object sender, EventArgs e)
        {
            FuncSave();
        }
        private void FuncSave()
        {
            if (ChkSimplifiedChinese.Checked == true)
            {
                string language = "ChineseSimplified";
                if (Directory.Exists(StaticVars.DIRBASE + LstFiles.Text + "\\Languages\\" + language + "\\"))
                    Directory.Delete(StaticVars.DIRBASE + LstFiles.Text + "\\Languages\\" + language + "\\", true);
                XMLTools.SaveMod(LstFiles.Text, XMLText, language + "\\");
                BtnSave.Enabled = false;
            }
            else if (ChkTraditionalChinese.Checked == true)
            {
                string language = "ChineseTraditional";
                if (Directory.Exists(StaticVars.DIRBASE + LstFiles.Text + "\\Languages\\" + language + "\\"))
                    Directory.Delete(StaticVars.DIRBASE + LstFiles.Text + "\\Languages\\" + language + "\\", true);
                XMLTools.SaveMod(LstFiles.Text, XMLText, language + "\\");
                BtnSave.Enabled = false;
            }

            // 保存文件
        }

        private void LstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstFiles.Enabled == true)
            {
                XMLText = XMLTools.ReadFolder(LstFiles.Text, "ChineseSimplified");
                LoadtoDataGrid();
            }
        }

        private void FormInit()
        {
            if (!Directory.Exists(StaticVars.DIRBASE))
            {
                Directory.CreateDirectory(StaticVars.DIRBASE);
            }
        }
        private void FunRefresh()
        {
            string[] stringList = Directory.GetDirectories(StaticVars.DIRBASE);

            if (stringList.Length > 0)
            {
                foreach (string str in stringList)
                {
                    LstFiles.Items.Add(Path.GetFileName(str));
                }
                LstFiles.SelectedIndex = 0;
                //从eng目录读取文件并载入listbox，默认选择第一个文件。
            }
            else
            {
                button1.Enabled = false;
                LstFiles.Items.Add("目录中未检索到xml文件");
                LstFiles.Enabled = false;
                BtnApply.Enabled = false;
                BtnAPItochnBox.Enabled = false;
            }
        }

        private void LoadtoDataGrid()
        {

            DfData.ClearSelection();
            DfData.DataSource = XMLText;
            // 将对象映射到datagrid里。

            DfData.Columns[0].Width = 100;
            DfData.Columns[0].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            DfData.Columns[1].Width = 300;
            DfData.Columns[2].Width = 300;
            DfData.Columns[3].Width = 100;
            DfData.Columns[4].Width = 100;
            DfData.Columns[5].Width = 150;
            DfData.Columns[6].Width = 300;
            DfData.Columns[0].HeaderText = "变量名";
            DfData.Columns[1].HeaderText = "原文";
            DfData.Columns[2].HeaderText = "译文";
            DfData.Columns[3].HeaderText = "主文件夹名称";
            DfData.Columns[4].HeaderText = "子文件夹名称";
            DfData.Columns[5].HeaderText = "文件名称";
            DfData.Columns[6].HeaderText = "文件目录";
            DfData.Columns[7].HeaderText = "是否已编辑";
            DfRefresh();
        }

        private void DfRefresh()
        {

            foreach (DataGridViewRow row in DfData.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();

                if (XMLText.ElementAt(row.Index).SameInToAndFrom())
                {
                    row.Cells[2].Style.BackColor = Color.LightCyan;
                }
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            TxtCHN.Text = XMLTools.RemoveReturnMark(TxtCHN.Text);
            XMLText.ElementAt(DfData.CurrentRow.Index).ApplyLine(TxtCHN.Text);
            DfData.Refresh();
            //将文本框内容移除换行符，放回变量，并刷新datagrid。
            BtnSave.Enabled = true;
            //做过修改，保存按钮可以使用了。
        }

        private void DfData_SelectionChanged(object sender, EventArgs e)
        {
            if (DfData.CurrentRow.Selected == true)
            {
                Showintxt(DfData.CurrentRow.Index);
            }
        }

        private void Showintxt(int id)
        {
            string engtext = XMLText.ElementAt(id).ContentEng;
            if (UserDict.Count > 0)
            {
                TxtENG.Text = XMLTools.ReplaceWithUserDict(engtext, UserDict);
            }
            else
            {
                TxtENG.Text = engtext;
            }

            TxtCHN.Text = XMLText.ElementAt(id).ContentDest;

            BtnApply.Enabled = true;
            GetAPITranslation();
            logcheck.Text = Situation.check;
        }

        private async void GetAPITranslation()
        {
            TxtAPI.Clear();
            BtnAPItochnBox.Enabled = false;
            Task<string> GetTranslationTask = new Task<string>(FuncAsyncGetTranslation);
            try
            {
                GetTranslationTask.Start();
                TxtAPI.Text = await GetTranslationTask;
                GetTranslationTask.Dispose();
            }
            catch
            {
                TxtAPI.Text = "Nothing";
                GetTranslationTask.Dispose();
            }
            BtnAPItochnBox.Enabled = true;

            string FuncAsyncGetTranslation()
            {
                return XMLTools.GetTranslatedTextFromAPI(XMLTools.RemoveReturnMark(TxtENG.Text));
            }
        }
        public FrmTranslator()
        {
            InitializeComponent();
        }
        private void Mainfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void TxtCHN_Enter(object sender, EventArgs e)
        {
            TxtCHN.SelectAll();
        }
        private void TxtCHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                TxtCHN.SelectAll();
            }
        }

        private void TxtENG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                TxtENG.SelectAll();
            }
            if (e.KeyCode == Keys.Left && e.Modifiers == Keys.Control)
            {
                GetAPITranslation();
                logcheck.Text = Situation.check;
            }
        }

        private void TxtAPI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                TxtAPI.SelectAll();
            }
        }

        private void TxtCHN_DoubleClick(object sender, EventArgs e)
        {
            TxtCHN.SelectAll();
        }

        private void TxtAPI_DoubleClick(object sender, EventArgs e)
        {
            TxtAPI.SelectAll();
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            if (ChkSimplifiedChinese.Checked == true)
                System.Diagnostics.Process.Start(StaticVars.DIRBASE + LstFiles.Text + "\\Languages\\");

            if (ChkTraditionalChinese.Checked == true)
                System.Diagnostics.Process.Start(StaticVars.DIRBASE + LstFiles.Text + "\\Languages\\");
        }

        private void BtnOpenFileOriginal_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(StaticVars.DIRBASE + LstFiles.Text);
        }
        private void TxtCHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void Dfdata_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && e.Modifiers == Keys.Control)
            {
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Down && e.Modifiers == Keys.Control)
            {
                e.Handled = true;
            }
        }
        private void BtnAPItochnBox_Click(object sender, EventArgs e)
        {
            TxtCHN.Text = TxtAPI.Text;
        }

        private void Translatorfrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Control)
            {
                BtnApply_Click(sender, e);
                return;
            }
            if (e.KeyCode == Keys.Up && e.Modifiers == Keys.Control)
            {
                BtnAPItochnBox_Click(sender, e);
                return;
            }
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                BtnSave_Click(sender, e);
                return;
            }
            if (e.KeyCode == Keys.Down && e.Modifiers == Keys.Control)
            {
                for (int i = DfData.CurrentRow.Index; i < DfData.RowCount; i++)
                {
                    if (i + 1 <= DfData.RowCount - 1)
                    {
                        DfData.CurrentCell = DfData[DfData.CurrentCell.ColumnIndex, i + 1];
                    }
                    else
                    {
                        DfData.CurrentCell = DfData[DfData.CurrentCell.ColumnIndex, 0];
                    }
                }
            }
        }

        private void BtnOpenBrowser_Click(object sender, EventArgs e)
        {
            XMLTools.OpenWithBrowser(TxtENG.Text, "Baidu");
        }
        private void FuncInsertSign(string SignToInsert)
        {
            if (TxtCHN.SelectedText == "")
            {
                TxtCHN.SelectedText = "§" + SignToInsert;
            }
            else
            {
                TxtCHN.SelectedText = "§" + SignToInsert + TxtCHN.SelectedText + "§!";
            }
        }

        private void FrmTranslator_SizeChanged(object sender, EventArgs e)
        {
            DfData.Width = Width - 215;
            LstFiles.Height = Height - 327;
            DfData.Height = Height - 327;
            TxtCHN.Width = Width - 260;
            TxtENG.Width = Width - 260;
            TxtAPI.Width = Width - 260;
            progressBar1.Width = DfData.Right - LstFiles.Left;
            LstFiles.Height = DfData.Height;
        }


        private void ChkTraditionalChinese_CheckedChanged(object sender, EventArgs e)
        {
            ChkSimplifiedChinese.Checked = false;
            if (ChkTraditionalChinese.Checked == true && Directory.Exists(StaticVars.DIRBASE + LstFiles.Text + "\\Languages\\ChineseTraditional"))
            {
                XMLText = XMLTools.ReadFolder(LstFiles.Text, "ChineseTraditional");
                LoadtoDataGrid();
            }
            if (ChkSimplifiedChinese.Checked == true)
                Situation.Sit = "zh";
            if (ChkTraditionalChinese.Checked == true)
                Situation.Sit = "cht";
        }
        private void ChkSimplifiedChinese_CheckedChanged(object sender, EventArgs e)
        {
            ChkTraditionalChinese.Checked = false;
            if (ChkSimplifiedChinese.Checked == true && Directory.Exists(StaticVars.DIRBASE + LstFiles.Text + "\\Languages\\ChineseSimplified"))
            {
                XMLText = XMLTools.ReadFolder(LstFiles.Text, "ChineseSimplified");
                LoadtoDataGrid();
            }
            if (ChkTraditionalChinese.Checked == true)
                Situation.Sit = "cht";
            if (ChkSimplifiedChinese.Checked == true)
                Situation.Sit = "zh";
        }


        private void LstFiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Down)
            {
                e.Handled = true;
            }
        }

        private void LstFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.Down)
            {
                e.Handled = true;
            }
        }

        private void LstFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.Down)
            {
                e.Handled = true;
            }
        }


        private void sure_Click(object sender, EventArgs e)
        {
            logcheck.Text = "";
            Situation.check = "";
            string path1 = Application.ExecutablePath + ".config";
            FileInfo info = new FileInfo(path1);
            info.Attributes = FileAttributes.Normal;
            Situation.Id = appid.Text;
            Situation.Key = keyword.Text;
            string path = Application.ExecutablePath;
            writeconfig(path, "ID", appid.Text);
            writeconfig(path, "key", keyword.Text);
            info.Attributes = FileAttributes.Hidden;
            MessageBox.Show("ID和key已经保存在config文件中，下次开启无需再次输入。");        
        }
        string Read_keyValue(string path, string keyname)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            return config.AppSettings.Settings[keyname].Value;
        }
        void writeconfig(string path, string keyname, string keyvalue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == keyname)
                {
                    config.AppSettings.Settings.Remove(key);
                }
            }
            config.AppSettings.Settings.Add(keyname, keyvalue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("AppSettings");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开始自动机翻")
            {
                timer1.Enabled = true; ;
                button1.Text = "暂停自动机翻";
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "开始自动机翻";
                progressBar1.Value = 0;
            }
            BtnSave.Enabled = true;
        }
        //单选输出语言
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSimplifiedChinese.Checked == true && Directory.Exists(StaticVars.DIRBASE + LstFiles.Text + "\\Languages\\ChineseSimplified"))
            {
                XMLText = XMLTools.ReadFolder(LstFiles.Text, "ChineseSimplified");
                LoadtoDataGrid();
            }
            if (ChkTraditionalChinese.Checked == true)
                Situation.Sit = "cht";
            if (ChkSimplifiedChinese.Checked == true)
                Situation.Sit = "zh";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTraditionalChinese.Checked == true && Directory.Exists(StaticVars.DIRBASE + LstFiles.Text + "\\Languages\\ChineseTraditional"))
            {
                XMLText = XMLTools.ReadFolder(LstFiles.Text, "ChineseTraditional");
                LoadtoDataGrid();
            }
            if (ChkSimplifiedChinese.Checked == true)
                Situation.Sit = "zh";
            if (ChkTraditionalChinese.Checked == true)
                Situation.Sit = "cht";
        }

        private void help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请自行注册百度翻译API账号，选免费的那个套餐就行。\n点开始自动机翻就会开始自动翻译了，记得翻译完点保存。\n请把mod文件放置在软件根目录的MODS文件夹中。\n需要配合Rimtrans使用先导出English语言文件。");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = DfData.CurrentRow.Index;
            if (i + 1 <= DfData.RowCount - 1)
            {
                int id = DfData.CurrentRow.Index;
                string engtext = XMLText.ElementAt(id).ContentEng;
                if (UserDict.Count > 0)
                {
                    TxtENG.Text = XMLTools.ReplaceWithUserDict(engtext, UserDict);
                }
                else
                {
                    TxtENG.Text = engtext;
                }
                TxtCHN.Text = XMLText.ElementAt(id).ContentDest;
                string save = XMLTools.GetTranslatedTextFromAPI(XMLTools.RemoveReturnMark(TxtENG.Text));
                if (Situation.check == "登陆成功") 
                {
                    TxtCHN.Text = save;
                    XMLText.ElementAt(DfData.CurrentRow.Index).ApplyLine(XMLTools.RemoveReturnMark(TxtCHN.Text));
                    DfData.Refresh();
                    DfData.CurrentCell = DfData[DfData.CurrentCell.ColumnIndex, i + 1];
                    progressBar1.Value = 100 * (i + 2) / DfData.RowCount;
                }
                else
                {
                    timer1.Enabled = false;
                    button1.Text = "开始自动机翻";
                    progressBar1.Value = 0;
                }
            }
            else
            {
                DfData.CurrentCell = DfData[DfData.CurrentCell.ColumnIndex, 0];
            }
            if (i+1 == DfData.RowCount)
            {
                timer1.Enabled = false;
                button1.Text = "开始自动机翻";
                progressBar1.Value = 0;
            }
            logcheck.Text = Situation.check;
        }
    }   
}

