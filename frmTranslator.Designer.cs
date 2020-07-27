namespace RimTrans
{

    partial class FrmTranslator
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTranslator));
            this.TxtAPI = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LstFiles = new System.Windows.Forms.ListBox();
            this.DfData = new System.Windows.Forms.DataGridView();
            this.TxtENG = new System.Windows.Forms.TextBox();
            this.TxtCHN = new System.Windows.Forms.TextBox();
            this.BtnApply = new System.Windows.Forms.Button();
            this.LabAPI = new System.Windows.Forms.Label();
            this.BtnAPItochnBox = new System.Windows.Forms.Button();
            this.BtnOpenFileTranslated = new System.Windows.Forms.Button();
            this.BtnOpenFileOriginal = new System.Windows.Forms.Button();
            this.BtnOpenBrowser = new System.Windows.Forms.Button();
            this.appid = new System.Windows.Forms.TextBox();
            this.keyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sure = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ChkSimplifiedChinese = new System.Windows.Forms.RadioButton();
            this.ChkTraditionalChinese = new System.Windows.Forms.RadioButton();
            this.help = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.logcheck = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DfData)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtAPI
            // 
            this.TxtAPI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtAPI.Font = new System.Drawing.Font("宋体", 10F);
            this.TxtAPI.Location = new System.Drawing.Point(3, 780);
            this.TxtAPI.Multiline = true;
            this.TxtAPI.Name = "TxtAPI";
            this.TxtAPI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtAPI.Size = new System.Drawing.Size(840, 86);
            this.TxtAPI.TabIndex = 3;
            this.TxtAPI.TabStop = false;
            this.TxtAPI.Text = "Baidu API";
            this.TxtAPI.DoubleClick += new System.EventHandler(this.TxtAPI_DoubleClick);
            this.TxtAPI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAPI_KeyDown);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Enabled = false;
            this.BtnSave.Location = new System.Drawing.Point(853, 829);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(100, 36);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.TabStop = false;
            this.BtnSave.Text = "保存文件 (Ctrl+S)";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LstFiles
            // 
            this.LstFiles.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstFiles.FormattingEnabled = true;
            this.LstFiles.IntegralHeight = false;
            this.LstFiles.ItemHeight = 12;
            this.LstFiles.Location = new System.Drawing.Point(3, 7);
            this.LstFiles.Name = "LstFiles";
            this.LstFiles.Size = new System.Drawing.Size(185, 580);
            this.LstFiles.TabIndex = 4;
            this.LstFiles.TabStop = false;
            this.LstFiles.SelectedIndexChanged += new System.EventHandler(this.LstFiles_SelectedIndexChanged);
            this.LstFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LstFiles_KeyDown);
            this.LstFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstFiles_KeyPress);
            this.LstFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LstFiles_KeyUp);
            // 
            // DfData
            // 
            this.DfData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DfData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DfData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DfData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DfData.Location = new System.Drawing.Point(193, 7);
            this.DfData.MultiSelect = false;
            this.DfData.Name = "DfData";
            this.DfData.ReadOnly = true;
            this.DfData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DfData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DfData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.DfData.RowTemplate.Height = 23;
            this.DfData.RowTemplate.ReadOnly = true;
            this.DfData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DfData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DfData.Size = new System.Drawing.Size(885, 580);
            this.DfData.TabIndex = 1;
            this.DfData.SelectionChanged += new System.EventHandler(this.DfData_SelectionChanged);
            this.DfData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dfdata_KeyDown);
            // 
            // TxtENG
            // 
            this.TxtENG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtENG.Font = new System.Drawing.Font("宋体", 10F);
            this.TxtENG.Location = new System.Drawing.Point(3, 601);
            this.TxtENG.Multiline = true;
            this.TxtENG.Name = "TxtENG";
            this.TxtENG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtENG.Size = new System.Drawing.Size(840, 86);
            this.TxtENG.TabIndex = 9;
            this.TxtENG.TabStop = false;
            this.TxtENG.Text = "原文";
            this.TxtENG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtENG_KeyDown);
            // 
            // TxtCHN
            // 
            this.TxtCHN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtCHN.Font = new System.Drawing.Font("宋体", 10F);
            this.TxtCHN.Location = new System.Drawing.Point(3, 690);
            this.TxtCHN.Multiline = true;
            this.TxtCHN.Name = "TxtCHN";
            this.TxtCHN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtCHN.Size = new System.Drawing.Size(840, 86);
            this.TxtCHN.TabIndex = 2;
            this.TxtCHN.Text = "译文";
            this.TxtCHN.DoubleClick += new System.EventHandler(this.TxtCHN_DoubleClick);
            this.TxtCHN.Enter += new System.EventHandler(this.TxtCHN_Enter);
            this.TxtCHN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCHN_KeyDown);
            this.TxtCHN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCHN_KeyPress);
            // 
            // BtnApply
            // 
            this.BtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnApply.Location = new System.Drawing.Point(853, 690);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(100, 36);
            this.BtnApply.TabIndex = 0;
            this.BtnApply.TabStop = false;
            this.BtnApply.Text = "确定翻译(Ctrl+Enter)";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // LabAPI
            // 
            this.LabAPI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LabAPI.AutoSize = true;
            this.LabAPI.Location = new System.Drawing.Point(982, 777);
            this.LabAPI.Name = "LabAPI";
            this.LabAPI.Size = new System.Drawing.Size(90, 13);
            this.LabAPI.TabIndex = 12;
            this.LabAPI.Text = "百度翻译APP ID";
            // 
            // BtnAPItochnBox
            // 
            this.BtnAPItochnBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAPItochnBox.Location = new System.Drawing.Point(853, 740);
            this.BtnAPItochnBox.Name = "BtnAPItochnBox";
            this.BtnAPItochnBox.Size = new System.Drawing.Size(100, 36);
            this.BtnAPItochnBox.TabIndex = 13;
            this.BtnAPItochnBox.TabStop = false;
            this.BtnAPItochnBox.Text = "粘贴机翻内容(Ctrl+↑)";
            this.BtnAPItochnBox.UseVisualStyleBackColor = true;
            this.BtnAPItochnBox.Click += new System.EventHandler(this.BtnAPItochnBox_Click);
            // 
            // BtnOpenFileTranslated
            // 
            this.BtnOpenFileTranslated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOpenFileTranslated.Location = new System.Drawing.Point(976, 651);
            this.BtnOpenFileTranslated.Name = "BtnOpenFileTranslated";
            this.BtnOpenFileTranslated.Size = new System.Drawing.Size(100, 36);
            this.BtnOpenFileTranslated.TabIndex = 14;
            this.BtnOpenFileTranslated.TabStop = false;
            this.BtnOpenFileTranslated.Text = "已汉化文件夹";
            this.BtnOpenFileTranslated.UseVisualStyleBackColor = true;
            this.BtnOpenFileTranslated.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // BtnOpenFileOriginal
            // 
            this.BtnOpenFileOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOpenFileOriginal.Location = new System.Drawing.Point(976, 601);
            this.BtnOpenFileOriginal.Name = "BtnOpenFileOriginal";
            this.BtnOpenFileOriginal.Size = new System.Drawing.Size(100, 36);
            this.BtnOpenFileOriginal.TabIndex = 15;
            this.BtnOpenFileOriginal.TabStop = false;
            this.BtnOpenFileOriginal.Text = "未汉化文件夹";
            this.BtnOpenFileOriginal.UseVisualStyleBackColor = true;
            this.BtnOpenFileOriginal.Click += new System.EventHandler(this.BtnOpenFileOriginal_Click);
            // 
            // BtnOpenBrowser
            // 
            this.BtnOpenBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOpenBrowser.Location = new System.Drawing.Point(853, 651);
            this.BtnOpenBrowser.Name = "BtnOpenBrowser";
            this.BtnOpenBrowser.Size = new System.Drawing.Size(100, 36);
            this.BtnOpenBrowser.TabIndex = 16;
            this.BtnOpenBrowser.TabStop = false;
            this.BtnOpenBrowser.Text = "打开百度翻译网页";
            this.BtnOpenBrowser.UseVisualStyleBackColor = true;
            this.BtnOpenBrowser.Click += new System.EventHandler(this.BtnOpenBrowser_Click);
            // 
            // appid
            // 
            this.appid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.appid.Location = new System.Drawing.Point(976, 793);
            this.appid.Name = "appid";
            this.appid.Size = new System.Drawing.Size(100, 20);
            this.appid.TabIndex = 38;
            // 
            // keyword
            // 
            this.keyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.keyword.Location = new System.Drawing.Point(976, 838);
            this.keyword.Name = "keyword";
            this.keyword.Size = new System.Drawing.Size(100, 20);
            this.keyword.TabIndex = 39;
            this.keyword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1013, 822);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "key";
            // 
            // sure
            // 
            this.sure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sure.Location = new System.Drawing.Point(853, 777);
            this.sure.Name = "sure";
            this.sure.Size = new System.Drawing.Size(100, 36);
            this.sure.TabIndex = 41;
            this.sure.Text = "登陆百度翻译API";
            this.sure.UseVisualStyleBackColor = true;
            this.sure.Click += new System.EventHandler(this.sure_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(853, 601);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 36);
            this.button1.TabIndex = 42;
            this.button1.TabStop = false;
            this.button1.Text = "开始自动机翻";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ChkSimplifiedChinese
            // 
            this.ChkSimplifiedChinese.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkSimplifiedChinese.AutoSize = true;
            this.ChkSimplifiedChinese.Location = new System.Drawing.Point(977, 690);
            this.ChkSimplifiedChinese.Name = "ChkSimplifiedChinese";
            this.ChkSimplifiedChinese.Size = new System.Drawing.Size(49, 17);
            this.ChkSimplifiedChinese.TabIndex = 43;
            this.ChkSimplifiedChinese.TabStop = true;
            this.ChkSimplifiedChinese.Text = "简体";
            this.ChkSimplifiedChinese.UseVisualStyleBackColor = true;
            this.ChkSimplifiedChinese.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ChkTraditionalChinese
            // 
            this.ChkTraditionalChinese.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkTraditionalChinese.AutoSize = true;
            this.ChkTraditionalChinese.Location = new System.Drawing.Point(976, 709);
            this.ChkTraditionalChinese.Name = "ChkTraditionalChinese";
            this.ChkTraditionalChinese.Size = new System.Drawing.Size(49, 17);
            this.ChkTraditionalChinese.TabIndex = 44;
            this.ChkTraditionalChinese.TabStop = true;
            this.ChkTraditionalChinese.Text = "繁体";
            this.ChkTraditionalChinese.UseVisualStyleBackColor = true;
            this.ChkTraditionalChinese.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // help
            // 
            this.help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.help.Location = new System.Drawing.Point(976, 740);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(100, 34);
            this.help.TabIndex = 45;
            this.help.Text = "帮助";
            this.help.UseVisualStyleBackColor = true;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.BackColor = System.Drawing.SystemColors.Highlight;
            this.progressBar1.Location = new System.Drawing.Point(3, 588);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1075, 10);
            this.progressBar1.TabIndex = 46;
            // 
            // logcheck
            // 
            this.logcheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logcheck.AutoSize = true;
            this.logcheck.Location = new System.Drawing.Point(974, 726);
            this.logcheck.Name = "logcheck";
            this.logcheck.Size = new System.Drawing.Size(10, 13);
            this.logcheck.TabIndex = 47;
            this.logcheck.Text = " \r\n";
            // 
            // FrmTranslator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 868);
            this.Controls.Add(this.logcheck);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.help);
            this.Controls.Add(this.ChkTraditionalChinese);
            this.Controls.Add(this.ChkSimplifiedChinese);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keyword);
            this.Controls.Add(this.appid);
            this.Controls.Add(this.BtnOpenBrowser);
            this.Controls.Add(this.BtnOpenFileOriginal);
            this.Controls.Add(this.BtnOpenFileTranslated);
            this.Controls.Add(this.BtnAPItochnBox);
            this.Controls.Add(this.LabAPI);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.TxtCHN);
            this.Controls.Add(this.TxtENG);
            this.Controls.Add(this.DfData);
            this.Controls.Add(this.LstFiles);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtAPI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmTranslator";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RimWorld Mod全自动翻译+手动修改";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mainfrm_FormClosed);
            this.Load += new System.EventHandler(this.Mainfrm_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTranslator_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Translatorfrm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DfData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtAPI;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ListBox LstFiles;
        private System.Windows.Forms.DataGridView DfData;
        private System.Windows.Forms.TextBox TxtENG;
        private System.Windows.Forms.TextBox TxtCHN;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.Label LabAPI;
        private System.Windows.Forms.Button BtnAPItochnBox;
        private System.Windows.Forms.Button BtnOpenFileTranslated;
        private System.Windows.Forms.Button BtnOpenFileOriginal;
        private System.Windows.Forms.Button BtnOpenBrowser;
        private System.Windows.Forms.TextBox appid;
        private System.Windows.Forms.TextBox keyword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sure;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton ChkSimplifiedChinese;
        private System.Windows.Forms.RadioButton ChkTraditionalChinese;
        private System.Windows.Forms.Button help;
        protected internal System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label logcheck;
    }
}