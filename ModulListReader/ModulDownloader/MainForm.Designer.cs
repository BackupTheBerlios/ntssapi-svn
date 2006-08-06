namespace ModulDownloader
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tVInhaltsbaum = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btNewVersion = new System.Windows.Forms.Button();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.gBMyBible = new System.Windows.Forms.GroupBox();
            this.btInstallGreensToMyBible = new System.Windows.Forms.Button();
            this.cBInstallToMyBible = new System.Windows.Forms.CheckBox();
            this.cBModulListServers = new System.Windows.Forms.ComboBox();
            this.btDownloadSelection = new System.Windows.Forms.Button();
            this.bWModullist = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gBMyBible.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AccessibleDescription = null;
            this.splitContainer1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BackgroundImage = null;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Font = null;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AccessibleDescription = null;
            this.splitContainer1.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.BackgroundImage = null;
            this.splitContainer1.Panel1.Controls.Add(this.tVInhaltsbaum);
            this.splitContainer1.Panel1.Font = null;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AccessibleDescription = null;
            this.splitContainer1.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.BackgroundImage = null;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Font = null;
            // 
            // tVInhaltsbaum
            // 
            this.tVInhaltsbaum.AccessibleDescription = null;
            this.tVInhaltsbaum.AccessibleName = null;
            resources.ApplyResources(this.tVInhaltsbaum, "tVInhaltsbaum");
            this.tVInhaltsbaum.BackgroundImage = null;
            this.tVInhaltsbaum.CheckBoxes = true;
            this.tVInhaltsbaum.ImageList = this.imageList1;
            this.tVInhaltsbaum.Name = "tVInhaltsbaum";
            this.tVInhaltsbaum.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.node_AfterCheck);
            this.tVInhaltsbaum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            this.imageList1.Images.SetKeyName(24, "");
            this.imageList1.Images.SetKeyName(25, "");
            this.imageList1.Images.SetKeyName(26, "");
            this.imageList1.Images.SetKeyName(27, "");
            this.imageList1.Images.SetKeyName(28, "");
            this.imageList1.Images.SetKeyName(29, "");
            this.imageList1.Images.SetKeyName(30, "");
            this.imageList1.Images.SetKeyName(31, "");
            this.imageList1.Images.SetKeyName(32, "");
            this.imageList1.Images.SetKeyName(33, "");
            this.imageList1.Images.SetKeyName(34, "");
            this.imageList1.Images.SetKeyName(35, "");
            this.imageList1.Images.SetKeyName(36, "");
            this.imageList1.Images.SetKeyName(37, "");
            this.imageList1.Images.SetKeyName(38, "");
            this.imageList1.Images.SetKeyName(39, "");
            this.imageList1.Images.SetKeyName(40, "");
            this.imageList1.Images.SetKeyName(41, "");
            this.imageList1.Images.SetKeyName(42, "");
            this.imageList1.Images.SetKeyName(43, "");
            this.imageList1.Images.SetKeyName(44, "");
            this.imageList1.Images.SetKeyName(45, "");
            this.imageList1.Images.SetKeyName(46, "");
            this.imageList1.Images.SetKeyName(47, "");
            this.imageList1.Images.SetKeyName(48, "");
            this.imageList1.Images.SetKeyName(49, "");
            this.imageList1.Images.SetKeyName(50, "");
            this.imageList1.Images.SetKeyName(51, "");
            this.imageList1.Images.SetKeyName(52, "");
            this.imageList1.Images.SetKeyName(53, "");
            this.imageList1.Images.SetKeyName(54, "");
            this.imageList1.Images.SetKeyName(55, "");
            this.imageList1.Images.SetKeyName(56, "");
            this.imageList1.Images.SetKeyName(57, "");
            this.imageList1.Images.SetKeyName(58, "");
            this.imageList1.Images.SetKeyName(59, "");
            this.imageList1.Images.SetKeyName(60, "");
            this.imageList1.Images.SetKeyName(61, "");
            this.imageList1.Images.SetKeyName(62, "");
            this.imageList1.Images.SetKeyName(63, "");
            this.imageList1.Images.SetKeyName(64, "");
            this.imageList1.Images.SetKeyName(65, "");
            this.imageList1.Images.SetKeyName(66, "");
            this.imageList1.Images.SetKeyName(67, "");
            this.imageList1.Images.SetKeyName(68, "");
            this.imageList1.Images.SetKeyName(69, "");
            this.imageList1.Images.SetKeyName(70, "");
            this.imageList1.Images.SetKeyName(71, "");
            this.imageList1.Images.SetKeyName(72, "");
            this.imageList1.Images.SetKeyName(73, "");
            this.imageList1.Images.SetKeyName(74, "");
            this.imageList1.Images.SetKeyName(75, "");
            this.imageList1.Images.SetKeyName(76, "");
            this.imageList1.Images.SetKeyName(77, "");
            this.imageList1.Images.SetKeyName(78, "");
            this.imageList1.Images.SetKeyName(79, "");
            this.imageList1.Images.SetKeyName(80, "");
            this.imageList1.Images.SetKeyName(81, "");
            this.imageList1.Images.SetKeyName(82, "");
            this.imageList1.Images.SetKeyName(83, "");
            this.imageList1.Images.SetKeyName(84, "");
            this.imageList1.Images.SetKeyName(85, "");
            this.imageList1.Images.SetKeyName(86, "");
            this.imageList1.Images.SetKeyName(87, "");
            this.imageList1.Images.SetKeyName(88, "");
            this.imageList1.Images.SetKeyName(89, "");
            this.imageList1.Images.SetKeyName(90, "");
            this.imageList1.Images.SetKeyName(91, "");
            this.imageList1.Images.SetKeyName(92, "");
            this.imageList1.Images.SetKeyName(93, "");
            this.imageList1.Images.SetKeyName(94, "");
            this.imageList1.Images.SetKeyName(95, "");
            this.imageList1.Images.SetKeyName(96, "");
            this.imageList1.Images.SetKeyName(97, "");
            this.imageList1.Images.SetKeyName(98, "");
            this.imageList1.Images.SetKeyName(99, "");
            this.imageList1.Images.SetKeyName(100, "");
            this.imageList1.Images.SetKeyName(101, "");
            this.imageList1.Images.SetKeyName(102, "");
            this.imageList1.Images.SetKeyName(103, "");
            this.imageList1.Images.SetKeyName(104, "");
            this.imageList1.Images.SetKeyName(105, "");
            this.imageList1.Images.SetKeyName(106, "");
            this.imageList1.Images.SetKeyName(107, "");
            this.imageList1.Images.SetKeyName(108, "");
            this.imageList1.Images.SetKeyName(109, "");
            this.imageList1.Images.SetKeyName(110, "");
            this.imageList1.Images.SetKeyName(111, "");
            this.imageList1.Images.SetKeyName(112, "");
            this.imageList1.Images.SetKeyName(113, "");
            this.imageList1.Images.SetKeyName(114, "");
            this.imageList1.Images.SetKeyName(115, "");
            this.imageList1.Images.SetKeyName(116, "");
            this.imageList1.Images.SetKeyName(117, "");
            this.imageList1.Images.SetKeyName(118, "");
            this.imageList1.Images.SetKeyName(119, "");
            this.imageList1.Images.SetKeyName(120, "");
            this.imageList1.Images.SetKeyName(121, "");
            this.imageList1.Images.SetKeyName(122, "");
            this.imageList1.Images.SetKeyName(123, "");
            this.imageList1.Images.SetKeyName(124, "");
            this.imageList1.Images.SetKeyName(125, "");
            this.imageList1.Images.SetKeyName(126, "");
            this.imageList1.Images.SetKeyName(127, "");
            this.imageList1.Images.SetKeyName(128, "");
            this.imageList1.Images.SetKeyName(129, "");
            this.imageList1.Images.SetKeyName(130, "");
            this.imageList1.Images.SetKeyName(131, "");
            this.imageList1.Images.SetKeyName(132, "");
            this.imageList1.Images.SetKeyName(133, "");
            this.imageList1.Images.SetKeyName(134, "");
            this.imageList1.Images.SetKeyName(135, "");
            this.imageList1.Images.SetKeyName(136, "");
            this.imageList1.Images.SetKeyName(137, "");
            this.imageList1.Images.SetKeyName(138, "");
            this.imageList1.Images.SetKeyName(139, "");
            this.imageList1.Images.SetKeyName(140, "");
            this.imageList1.Images.SetKeyName(141, "");
            this.imageList1.Images.SetKeyName(142, "");
            this.imageList1.Images.SetKeyName(143, "");
            this.imageList1.Images.SetKeyName(144, "");
            this.imageList1.Images.SetKeyName(145, "");
            this.imageList1.Images.SetKeyName(146, "");
            this.imageList1.Images.SetKeyName(147, "");
            this.imageList1.Images.SetKeyName(148, "");
            this.imageList1.Images.SetKeyName(149, "");
            this.imageList1.Images.SetKeyName(150, "");
            this.imageList1.Images.SetKeyName(151, "");
            this.imageList1.Images.SetKeyName(152, "");
            this.imageList1.Images.SetKeyName(153, "");
            this.imageList1.Images.SetKeyName(154, "");
            this.imageList1.Images.SetKeyName(155, "");
            this.imageList1.Images.SetKeyName(156, "");
            this.imageList1.Images.SetKeyName(157, "");
            this.imageList1.Images.SetKeyName(158, "");
            this.imageList1.Images.SetKeyName(159, "");
            this.imageList1.Images.SetKeyName(160, "");
            this.imageList1.Images.SetKeyName(161, "");
            this.imageList1.Images.SetKeyName(162, "");
            this.imageList1.Images.SetKeyName(163, "");
            this.imageList1.Images.SetKeyName(164, "");
            this.imageList1.Images.SetKeyName(165, "");
            this.imageList1.Images.SetKeyName(166, "");
            this.imageList1.Images.SetKeyName(167, "");
            this.imageList1.Images.SetKeyName(168, "");
            this.imageList1.Images.SetKeyName(169, "");
            this.imageList1.Images.SetKeyName(170, "");
            this.imageList1.Images.SetKeyName(171, "");
            this.imageList1.Images.SetKeyName(172, "");
            this.imageList1.Images.SetKeyName(173, "");
            this.imageList1.Images.SetKeyName(174, "");
            this.imageList1.Images.SetKeyName(175, "");
            this.imageList1.Images.SetKeyName(176, "");
            this.imageList1.Images.SetKeyName(177, "");
            this.imageList1.Images.SetKeyName(178, "");
            this.imageList1.Images.SetKeyName(179, "");
            this.imageList1.Images.SetKeyName(180, "");
            this.imageList1.Images.SetKeyName(181, "");
            this.imageList1.Images.SetKeyName(182, "");
            this.imageList1.Images.SetKeyName(183, "");
            this.imageList1.Images.SetKeyName(184, "");
            this.imageList1.Images.SetKeyName(185, "");
            this.imageList1.Images.SetKeyName(186, "");
            this.imageList1.Images.SetKeyName(187, "");
            this.imageList1.Images.SetKeyName(188, "");
            this.imageList1.Images.SetKeyName(189, "");
            this.imageList1.Images.SetKeyName(190, "");
            this.imageList1.Images.SetKeyName(191, "");
            this.imageList1.Images.SetKeyName(192, "");
            this.imageList1.Images.SetKeyName(193, "");
            this.imageList1.Images.SetKeyName(194, "");
            this.imageList1.Images.SetKeyName(195, "");
            this.imageList1.Images.SetKeyName(196, "");
            this.imageList1.Images.SetKeyName(197, "");
            this.imageList1.Images.SetKeyName(198, "");
            this.imageList1.Images.SetKeyName(199, "");
            this.imageList1.Images.SetKeyName(200, "");
            this.imageList1.Images.SetKeyName(201, "");
            this.imageList1.Images.SetKeyName(202, "");
            this.imageList1.Images.SetKeyName(203, "");
            this.imageList1.Images.SetKeyName(204, "");
            this.imageList1.Images.SetKeyName(205, "");
            this.imageList1.Images.SetKeyName(206, "");
            this.imageList1.Images.SetKeyName(207, "");
            this.imageList1.Images.SetKeyName(208, "");
            this.imageList1.Images.SetKeyName(209, "");
            this.imageList1.Images.SetKeyName(210, "");
            this.imageList1.Images.SetKeyName(211, "");
            this.imageList1.Images.SetKeyName(212, "");
            this.imageList1.Images.SetKeyName(213, "");
            this.imageList1.Images.SetKeyName(214, "");
            this.imageList1.Images.SetKeyName(215, "");
            this.imageList1.Images.SetKeyName(216, "");
            this.imageList1.Images.SetKeyName(217, "");
            this.imageList1.Images.SetKeyName(218, "");
            this.imageList1.Images.SetKeyName(219, "");
            this.imageList1.Images.SetKeyName(220, "");
            this.imageList1.Images.SetKeyName(221, "");
            this.imageList1.Images.SetKeyName(222, "");
            this.imageList1.Images.SetKeyName(223, "");
            this.imageList1.Images.SetKeyName(224, "");
            this.imageList1.Images.SetKeyName(225, "");
            this.imageList1.Images.SetKeyName(226, "");
            this.imageList1.Images.SetKeyName(227, "");
            this.imageList1.Images.SetKeyName(228, "");
            this.imageList1.Images.SetKeyName(229, "");
            this.imageList1.Images.SetKeyName(230, "");
            this.imageList1.Images.SetKeyName(231, "");
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.btNewVersion);
            this.panel1.Controls.Add(this.linkLabel3);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.gBMyBible);
            this.panel1.Controls.Add(this.cBModulListServers);
            this.panel1.Controls.Add(this.btDownloadSelection);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // btNewVersion
            // 
            this.btNewVersion.AccessibleDescription = null;
            this.btNewVersion.AccessibleName = null;
            resources.ApplyResources(this.btNewVersion, "btNewVersion");
            this.btNewVersion.BackColor = System.Drawing.Color.Red;
            this.btNewVersion.BackgroundImage = null;
            this.btNewVersion.Font = null;
            this.btNewVersion.Name = "btNewVersion";
            this.btNewVersion.UseVisualStyleBackColor = false;
            this.btNewVersion.Click += new System.EventHandler(this.btNewVersion_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AccessibleDescription = null;
            this.linkLabel3.AccessibleName = null;
            resources.ApplyResources(this.linkLabel3, "linkLabel3");
            this.linkLabel3.Font = null;
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.TabStop = true;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AccessibleDescription = null;
            this.linkLabel2.AccessibleName = null;
            resources.ApplyResources(this.linkLabel2, "linkLabel2");
            this.linkLabel2.Font = null;
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Click += new System.EventHandler(this.linkLabel2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AccessibleDescription = null;
            this.linkLabel1.AccessibleName = null;
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Font = null;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // gBMyBible
            // 
            this.gBMyBible.AccessibleDescription = null;
            this.gBMyBible.AccessibleName = null;
            resources.ApplyResources(this.gBMyBible, "gBMyBible");
            this.gBMyBible.BackgroundImage = null;
            this.gBMyBible.Controls.Add(this.btInstallGreensToMyBible);
            this.gBMyBible.Controls.Add(this.cBInstallToMyBible);
            this.gBMyBible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gBMyBible.Font = null;
            this.gBMyBible.Name = "gBMyBible";
            this.gBMyBible.TabStop = false;
            // 
            // btInstallGreensToMyBible
            // 
            this.btInstallGreensToMyBible.AccessibleDescription = null;
            this.btInstallGreensToMyBible.AccessibleName = null;
            resources.ApplyResources(this.btInstallGreensToMyBible, "btInstallGreensToMyBible");
            this.btInstallGreensToMyBible.BackgroundImage = null;
            this.btInstallGreensToMyBible.Font = null;
            this.btInstallGreensToMyBible.Name = "btInstallGreensToMyBible";
            this.btInstallGreensToMyBible.UseVisualStyleBackColor = true;
            this.btInstallGreensToMyBible.Click += new System.EventHandler(this.btInstallGreensToMyBible_Click_1);
            // 
            // cBInstallToMyBible
            // 
            this.cBInstallToMyBible.AccessibleDescription = null;
            this.cBInstallToMyBible.AccessibleName = null;
            resources.ApplyResources(this.cBInstallToMyBible, "cBInstallToMyBible");
            this.cBInstallToMyBible.BackgroundImage = null;
            this.cBInstallToMyBible.Font = null;
            this.cBInstallToMyBible.Name = "cBInstallToMyBible";
            this.cBInstallToMyBible.UseVisualStyleBackColor = true;
            // 
            // cBModulListServers
            // 
            this.cBModulListServers.AccessibleDescription = null;
            this.cBModulListServers.AccessibleName = null;
            resources.ApplyResources(this.cBModulListServers, "cBModulListServers");
            this.cBModulListServers.BackgroundImage = null;
            this.cBModulListServers.FormattingEnabled = true;
            this.cBModulListServers.Name = "cBModulListServers";
            this.cBModulListServers.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cBModulListServers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cBModulListServers_KeyDown);
            this.cBModulListServers.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // btDownloadSelection
            // 
            this.btDownloadSelection.AccessibleDescription = null;
            this.btDownloadSelection.AccessibleName = null;
            resources.ApplyResources(this.btDownloadSelection, "btDownloadSelection");
            this.btDownloadSelection.BackgroundImage = null;
            this.btDownloadSelection.Font = null;
            this.btDownloadSelection.Name = "btDownloadSelection";
            this.btDownloadSelection.UseVisualStyleBackColor = true;
            this.btDownloadSelection.Click += new System.EventHandler(this.btDownloadSelection_Click);
            // 
            // bWModullist
            // 
            this.bWModullist.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWModullist_DoWork);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AccessibleDescription = null;
            this.menuStrip1.AccessibleName = null;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackgroundImage = null;
            this.menuStrip1.Font = null;
            this.menuStrip1.Name = "menuStrip1";
            // 
            // MainForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = null;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gBMyBible.ResumeLayout(false);
            this.gBMyBible.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tVInhaltsbaum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btDownloadSelection;
        private System.Windows.Forms.ComboBox cBModulListServers;
        private System.ComponentModel.BackgroundWorker bWModullist;
        private System.Windows.Forms.GroupBox gBMyBible;
        private System.Windows.Forms.CheckBox cBInstallToMyBible;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Button btInstallGreensToMyBible;
        private System.Windows.Forms.Button btNewVersion;


    }
}

