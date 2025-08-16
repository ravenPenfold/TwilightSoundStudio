namespace Twillight_Sound_Studio
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newSoundArchiveToolStripMenuItem = new ToolStripMenuItem();
            openSoundArchiveToolStripMenuItem = new ToolStripMenuItem();
            saveSoundArchiveToolStripMenuItem = new ToolStripMenuItem();
            saveSoundArchiveAsToolStripMenuItem = new ToolStripMenuItem();
            closeSoundArchiveToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            preferencesToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            sndGrpDropdown = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            btnAdd = new ToolStripButton();
            btnRemove = new ToolStripButton();
            btnImport = new ToolStripButton();
            btnExport = new ToolStripButton();
            panMain = new Panel();
            panGlobal = new Panel();
            groupBox1 = new GroupBox();
            btnUpdateGlobal = new Button();
            txtName = new TextBox();
            label2 = new Label();
            noId = new NumericUpDown();
            label1 = new Label();
            itemsList = new ListView();
            label3 = new Label();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            panMain.SuspendLayout();
            panGlobal.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)noId).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newSoundArchiveToolStripMenuItem, openSoundArchiveToolStripMenuItem, saveSoundArchiveToolStripMenuItem, saveSoundArchiveAsToolStripMenuItem, closeSoundArchiveToolStripMenuItem, toolStripSeparator1, preferencesToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newSoundArchiveToolStripMenuItem
            // 
            newSoundArchiveToolStripMenuItem.Name = "newSoundArchiveToolStripMenuItem";
            newSoundArchiveToolStripMenuItem.Size = new Size(203, 22);
            newSoundArchiveToolStripMenuItem.Text = "New Sound Archive";
            // 
            // openSoundArchiveToolStripMenuItem
            // 
            openSoundArchiveToolStripMenuItem.Name = "openSoundArchiveToolStripMenuItem";
            openSoundArchiveToolStripMenuItem.Size = new Size(203, 22);
            openSoundArchiveToolStripMenuItem.Text = "Open Sound Archive";
            openSoundArchiveToolStripMenuItem.Click += openSoundArchiveToolStripMenuItem_Click;
            // 
            // saveSoundArchiveToolStripMenuItem
            // 
            saveSoundArchiveToolStripMenuItem.Name = "saveSoundArchiveToolStripMenuItem";
            saveSoundArchiveToolStripMenuItem.Size = new Size(203, 22);
            saveSoundArchiveToolStripMenuItem.Text = "Save Sound Archive";
            saveSoundArchiveToolStripMenuItem.Click += saveSoundArchiveToolStripMenuItem_Click;
            // 
            // saveSoundArchiveAsToolStripMenuItem
            // 
            saveSoundArchiveAsToolStripMenuItem.Name = "saveSoundArchiveAsToolStripMenuItem";
            saveSoundArchiveAsToolStripMenuItem.Size = new Size(203, 22);
            saveSoundArchiveAsToolStripMenuItem.Text = "Save Sound Archive As...";
            // 
            // closeSoundArchiveToolStripMenuItem
            // 
            closeSoundArchiveToolStripMenuItem.Name = "closeSoundArchiveToolStripMenuItem";
            closeSoundArchiveToolStripMenuItem.Size = new Size(203, 22);
            closeSoundArchiveToolStripMenuItem.Text = "Close Sound Archive";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(200, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            preferencesToolStripMenuItem.Size = new Size(203, 22);
            preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(203, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, sndGrpDropdown, toolStripSeparator2, btnAdd, btnRemove, btnImport, btnExport });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(83, 22);
            toolStripLabel1.Text = "Sound Group: ";
            // 
            // sndGrpDropdown
            // 
            sndGrpDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            sndGrpDropdown.Items.AddRange(new object[] { "Sequences (SSEQ)", "Sound Archives (SSAR)", "Instrument Banks (SBNK)", "Wave Archives (SWAR)", "Sequence Players", "Sound Groups", "Stream Players", "Sound Streams (STRM)" });
            sndGrpDropdown.Name = "sndGrpDropdown";
            sndGrpDropdown.Size = new Size(250, 25);
            sndGrpDropdown.SelectedIndexChanged += sndGrpDropdown_SelectedIndexChanged;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // btnAdd
            // 
            btnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAdd.Image = Properties.Resources.plus;
            btnAdd.ImageTransparentColor = Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(23, 22);
            btnAdd.Text = "Add Entry";
            // 
            // btnRemove
            // 
            btnRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRemove.Image = Properties.Resources.remove;
            btnRemove.ImageTransparentColor = Color.Magenta;
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(23, 22);
            btnRemove.Text = "Remove Entry";
            // 
            // btnImport
            // 
            btnImport.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnImport.Image = Properties.Resources.import;
            btnImport.ImageTransparentColor = Color.Magenta;
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(23, 22);
            btnImport.Text = "Import File";
            btnImport.Click += btnImport_Click;
            // 
            // btnExport
            // 
            btnExport.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExport.Image = Properties.Resources.export;
            btnExport.ImageTransparentColor = Color.Magenta;
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(23, 22);
            btnExport.Text = "Export File";
            btnExport.Click += btnExport_Click;
            // 
            // panMain
            // 
            panMain.Controls.Add(label3);
            panMain.Controls.Add(panGlobal);
            panMain.Dock = DockStyle.Left;
            panMain.Location = new Point(0, 49);
            panMain.Name = "panMain";
            panMain.Size = new Size(258, 401);
            panMain.TabIndex = 2;
            // 
            // panGlobal
            // 
            panGlobal.Controls.Add(groupBox1);
            panGlobal.Dock = DockStyle.Top;
            panGlobal.Location = new Point(0, 0);
            panGlobal.Name = "panGlobal";
            panGlobal.Size = new Size(258, 110);
            panGlobal.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnUpdateGlobal);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(noId);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(249, 103);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "File Information";
            // 
            // btnUpdateGlobal
            // 
            btnUpdateGlobal.Location = new Point(6, 75);
            btnUpdateGlobal.Name = "btnUpdateGlobal";
            btnUpdateGlobal.Size = new Size(237, 23);
            btnUpdateGlobal.TabIndex = 1;
            btnUpdateGlobal.Text = "Update Entry";
            btnUpdateGlobal.UseVisualStyleBackColor = true;
            btnUpdateGlobal.Click += btnUpdateGlobal_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(57, 46);
            txtName.Name = "txtName";
            txtName.Size = new Size(186, 23);
            txtName.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 49);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 1;
            label2.Text = "Name: ";
            // 
            // noId
            // 
            noId.Location = new Point(57, 17);
            noId.Name = "noId";
            noId.Size = new Size(186, 23);
            noId.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 3;
            label1.Text = "ID:";
            // 
            // itemsList
            // 
            itemsList.Dock = DockStyle.Fill;
            itemsList.Location = new Point(258, 49);
            itemsList.Name = "itemsList";
            itemsList.Size = new Size(542, 401);
            itemsList.TabIndex = 0;
            itemsList.UseCompatibleStateImageBehavior = false;
            itemsList.SelectedIndexChanged += itemsList_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 113);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 1;
            label3.Text = "label3";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(itemsList);
            Controls.Add(panMain);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "Twillight Sound Studio";
            Load += Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panMain.ResumeLayout(false);
            panMain.PerformLayout();
            panGlobal.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)noId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newSoundArchiveToolStripMenuItem;
        private ToolStripMenuItem openSoundArchiveToolStripMenuItem;
        private ToolStripMenuItem saveSoundArchiveToolStripMenuItem;
        private ToolStripMenuItem saveSoundArchiveAsToolStripMenuItem;
        private ToolStripMenuItem closeSoundArchiveToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem preferencesToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox sndGrpDropdown;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnAdd;
        private ToolStripButton btnRemove;
        private ToolStripButton btnImport;
        private ToolStripButton btnExport;
        private Panel panMain;
        private ListView itemsList;
        private Panel panGlobal;
        private GroupBox groupBox1;
        private Label label1;
        private Button btnUpdateGlobal;
        private TextBox txtName;
        private Label label2;
        private NumericUpDown noId;
        private Label label3;
    }
}