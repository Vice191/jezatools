﻿using System.Collections;
using System.Windows.Forms;
using HtmlAgilityPack;
using jeza.Travian.Framework;
using HtmlDocument=HtmlAgilityPack.HtmlDocument;

namespace jeza.Travian.GameCenter
{
    partial class ProcessCenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessCenter));
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTabs = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBoxAlly = new System.Windows.Forms.GroupBox();
            this.labelSettingsAllyId = new System.Windows.Forms.Label();
            this.labelSettingsAllyName = new System.Windows.Forms.Label();
            this.buttonSettingsNapAdd = new System.Windows.Forms.Button();
            this.buttonSettingsWarAdd = new System.Windows.Forms.Button();
            this.buttonSettingsAllyAdd = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.labelSettingsWar = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.labelSettingsNap = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelSettingsAlly = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxLanguage = new System.Windows.Forms.GroupBox();
            this.comboBoxSettingsLanguages = new System.Windows.Forms.ComboBox();
            this.labelLanguageId = new System.Windows.Forms.Label();
            this.panelOverviewLogins = new System.Windows.Forms.Panel();
            this.groupBoxOverview = new System.Windows.Forms.GroupBox();
            this.buttonOwerviewSave = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.tabPageRallyPoint = new System.Windows.Forms.TabPage();
            this.panelRallyPointVillage = new System.Windows.Forms.Panel();
            this.buttonUpdateRallyPoint = new System.Windows.Forms.Button();
            this.comboBoxRallyPointVillages = new System.Windows.Forms.ComboBox();
            this.panelRallyPoint = new System.Windows.Forms.Panel();
            this.dataGridViewRallyPoint = new System.Windows.Forms.DataGridView();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.panelMapSelection = new System.Windows.Forms.Panel();
            this.panelMapPopulate = new System.Windows.Forms.Panel();
            this.buttonMapPopulate = new System.Windows.Forms.Button();
            this.groupBoxMapExcluded = new System.Windows.Forms.GroupBox();
            this.checkBoxExcludedPlayers = new System.Windows.Forms.CheckBox();
            this.checkBoxExcludedAlliances = new System.Windows.Forms.CheckBox();
            this.groupBoxMapOases = new System.Windows.Forms.GroupBox();
            this.checkBoxUnoccupiedOasis = new System.Windows.Forms.CheckBox();
            this.checkBoxMapOccupiedOasis = new System.Windows.Forms.CheckBox();
            this.groupBoxMapAlliace = new System.Windows.Forms.GroupBox();
            this.checkBoxAlly = new System.Windows.Forms.CheckBox();
            this.checkBoxWar = new System.Windows.Forms.CheckBox();
            this.checkBoxNap = new System.Windows.Forms.CheckBox();
            this.groupBoxMapFarms = new System.Windows.Forms.GroupBox();
            this.checkBoxFarmsNoProfit = new System.Windows.Forms.CheckBox();
            this.checkBoxFarmsHighRish = new System.Windows.Forms.CheckBox();
            this.checkBoxFarmsLowRisk = new System.Windows.Forms.CheckBox();
            this.checkBoxFarmsMiddleRisk = new System.Windows.Forms.CheckBox();
            this.panelMapUpdate = new System.Windows.Forms.Panel();
            this.groupBoxMapUpdate = new System.Windows.Forms.GroupBox();
            this.labelMapDistance = new System.Windows.Forms.Label();
            this.buttonMapUpdate = new System.Windows.Forms.Button();
            this.comboBoxMapVillages = new System.Windows.Forms.ComboBox();
            this.labelMapVillage = new System.Windows.Forms.Label();
            this.textBoxMapDistance = new System.Windows.Forms.TextBox();
            this.panelMapList = new System.Windows.Forms.Panel();
            this.dataGridViewMap = new System.Windows.Forms.DataGridView();
            this.valleyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPageBuildQueue = new System.Windows.Forms.TabPage();
            this.panelBuildQueueSelect = new System.Windows.Forms.Panel();
            this.labelBuildQueueLevel = new System.Windows.Forms.Label();
            this.labelBuildQueueBuilding = new System.Windows.Forms.Label();
            this.buttonBuildQueueAdd = new System.Windows.Forms.Button();
            this.comboBoxBuildQueueLevel = new System.Windows.Forms.ComboBox();
            this.comboBoxBuildQueueBuilding = new System.Windows.Forms.ComboBox();
            this.panelBuildQueueList = new System.Windows.Forms.Panel();
            this.listBoxBuildQueues = new System.Windows.Forms.ListBox();
            this.panelBuildQueueHead = new System.Windows.Forms.Panel();
            this.buttonBuildQueueSelect = new System.Windows.Forms.Button();
            this.comboBoxBuildQueueVillages = new System.Windows.Forms.ComboBox();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.tabPageStatistics = new System.Windows.Forms.TabPage();
            this.tabPageMarketPlace = new System.Windows.Forms.TabPage();
            this.tabPageBrowser = new System.Windows.Forms.TabPage();
            this.panelBrowserUrl = new System.Windows.Forms.Panel();
            this.textBoxBrowserUrl = new System.Windows.Forms.TextBox();
            this.buttonBrowserGo = new System.Windows.Forms.Button();
            this.panelBrowser = new System.Windows.Forms.Panel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panelHead = new System.Windows.Forms.Panel();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.VillageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allianceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coordinates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.populationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valleyTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMain.SuspendLayout();
            this.panelTabs.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxAlly.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxLanguage.SuspendLayout();
            this.panelOverviewLogins.SuspendLayout();
            this.groupBoxOverview.SuspendLayout();
            this.tabPageRallyPoint.SuspendLayout();
            this.panelRallyPointVillage.SuspendLayout();
            this.panelRallyPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRallyPoint)).BeginInit();
            this.tabPageMap.SuspendLayout();
            this.panelMapSelection.SuspendLayout();
            this.panelMapPopulate.SuspendLayout();
            this.groupBoxMapExcluded.SuspendLayout();
            this.groupBoxMapOases.SuspendLayout();
            this.groupBoxMapAlliace.SuspendLayout();
            this.groupBoxMapFarms.SuspendLayout();
            this.panelMapUpdate.SuspendLayout();
            this.groupBoxMapUpdate.SuspendLayout();
            this.panelMapList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valleyBindingSource)).BeginInit();
            this.tabPageBuildQueue.SuspendLayout();
            this.panelBuildQueueSelect.SuspendLayout();
            this.panelBuildQueueList.SuspendLayout();
            this.panelBuildQueueHead.SuspendLayout();
            this.tabPageBrowser.SuspendLayout();
            this.panelBrowserUrl.SuspendLayout();
            this.panelBrowser.SuspendLayout();
            this.panelHead.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.Controls.Add(this.panelTabs);
            this.panelMain.Controls.Add(this.panelHead);
            this.panelMain.Controls.Add(this.panelStatus);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1193, 865);
            this.panelMain.TabIndex = 0;
            // 
            // panelTabs
            // 
            this.panelTabs.Controls.Add(this.tabControl);
            this.panelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabs.Location = new System.Drawing.Point(0, 28);
            this.panelTabs.Name = "panelTabs";
            this.panelTabs.Size = new System.Drawing.Size(1193, 722);
            this.panelTabs.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSettings);
            this.tabControl.Controls.Add(this.tabPageRallyPoint);
            this.tabControl.Controls.Add(this.tabPageMap);
            this.tabControl.Controls.Add(this.tabPageBuildQueue);
            this.tabControl.Controls.Add(this.tabPageReports);
            this.tabControl.Controls.Add(this.tabPageStatistics);
            this.tabControl.Controls.Add(this.tabPageMarketPlace);
            this.tabControl.Controls.Add(this.tabPageBrowser);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1193, 722);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.panel2);
            this.tabPageSettings.Controls.Add(this.panel1);
            this.tabPageSettings.Controls.Add(this.panelOverviewLogins);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(1185, 696);
            this.tabPageSettings.TabIndex = 0;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBoxAlly);
            this.panel2.Location = new System.Drawing.Point(289, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(379, 123);
            this.panel2.TabIndex = 3;
            // 
            // groupBoxAlly
            // 
            this.groupBoxAlly.Controls.Add(this.labelSettingsAllyId);
            this.groupBoxAlly.Controls.Add(this.labelSettingsAllyName);
            this.groupBoxAlly.Controls.Add(this.buttonSettingsNapAdd);
            this.groupBoxAlly.Controls.Add(this.buttonSettingsWarAdd);
            this.groupBoxAlly.Controls.Add(this.buttonSettingsAllyAdd);
            this.groupBoxAlly.Controls.Add(this.textBox5);
            this.groupBoxAlly.Controls.Add(this.textBox6);
            this.groupBoxAlly.Controls.Add(this.labelSettingsWar);
            this.groupBoxAlly.Controls.Add(this.textBox3);
            this.groupBoxAlly.Controls.Add(this.textBox4);
            this.groupBoxAlly.Controls.Add(this.labelSettingsNap);
            this.groupBoxAlly.Controls.Add(this.textBox2);
            this.groupBoxAlly.Controls.Add(this.textBox1);
            this.groupBoxAlly.Controls.Add(this.labelSettingsAlly);
            this.groupBoxAlly.Location = new System.Drawing.Point(3, 3);
            this.groupBoxAlly.Name = "groupBoxAlly";
            this.groupBoxAlly.Size = new System.Drawing.Size(373, 109);
            this.groupBoxAlly.TabIndex = 0;
            this.groupBoxAlly.TabStop = false;
            this.groupBoxAlly.Text = "Ally";
            // 
            // labelSettingsAllyId
            // 
            this.labelSettingsAllyId.AutoSize = true;
            this.labelSettingsAllyId.Location = new System.Drawing.Point(181, 16);
            this.labelSettingsAllyId.Name = "labelSettingsAllyId";
            this.labelSettingsAllyId.Size = new System.Drawing.Size(22, 13);
            this.labelSettingsAllyId.TabIndex = 13;
            this.labelSettingsAllyId.Text = "Aid";
            // 
            // labelSettingsAllyName
            // 
            this.labelSettingsAllyName.AutoSize = true;
            this.labelSettingsAllyName.Location = new System.Drawing.Point(65, 16);
            this.labelSettingsAllyName.Name = "labelSettingsAllyName";
            this.labelSettingsAllyName.Size = new System.Drawing.Size(35, 13);
            this.labelSettingsAllyName.TabIndex = 12;
            this.labelSettingsAllyName.Text = "Name";
            // 
            // buttonSettingsNapAdd
            // 
            this.buttonSettingsNapAdd.Location = new System.Drawing.Point(291, 54);
            this.buttonSettingsNapAdd.Name = "buttonSettingsNapAdd";
            this.buttonSettingsNapAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonSettingsNapAdd.TabIndex = 11;
            this.buttonSettingsNapAdd.Text = "Add";
            this.buttonSettingsNapAdd.UseVisualStyleBackColor = true;
            this.buttonSettingsNapAdd.Click += new System.EventHandler(this.buttonSettingsNapAdd_Click);
            // 
            // buttonSettingsWarAdd
            // 
            this.buttonSettingsWarAdd.Location = new System.Drawing.Point(291, 80);
            this.buttonSettingsWarAdd.Name = "buttonSettingsWarAdd";
            this.buttonSettingsWarAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonSettingsWarAdd.TabIndex = 10;
            this.buttonSettingsWarAdd.Text = "Add";
            this.buttonSettingsWarAdd.UseVisualStyleBackColor = true;
            this.buttonSettingsWarAdd.Click += new System.EventHandler(this.buttonSettingsWarAdd_Click);
            // 
            // buttonSettingsAllyAdd
            // 
            this.buttonSettingsAllyAdd.Location = new System.Drawing.Point(291, 27);
            this.buttonSettingsAllyAdd.Name = "buttonSettingsAllyAdd";
            this.buttonSettingsAllyAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonSettingsAllyAdd.TabIndex = 9;
            this.buttonSettingsAllyAdd.Text = "Add";
            this.buttonSettingsAllyAdd.UseVisualStyleBackColor = true;
            this.buttonSettingsAllyAdd.Click += new System.EventHandler(this.buttonSettingsAllyAdd_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(184, 83);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 8;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(68, 82);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 7;
            // 
            // labelSettingsWar
            // 
            this.labelSettingsWar.AutoSize = true;
            this.labelSettingsWar.Location = new System.Drawing.Point(8, 89);
            this.labelSettingsWar.Name = "labelSettingsWar";
            this.labelSettingsWar.Size = new System.Drawing.Size(27, 13);
            this.labelSettingsWar.TabIndex = 6;
            this.labelSettingsWar.Text = "War";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(184, 58);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(68, 57);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 4;
            // 
            // labelSettingsNap
            // 
            this.labelSettingsNap.AutoSize = true;
            this.labelSettingsNap.Location = new System.Drawing.Point(8, 64);
            this.labelSettingsNap.Name = "labelSettingsNap";
            this.labelSettingsNap.Size = new System.Drawing.Size(27, 13);
            this.labelSettingsNap.TabIndex = 3;
            this.labelSettingsNap.Text = "Nap";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(184, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // labelSettingsAlly
            // 
            this.labelSettingsAlly.AutoSize = true;
            this.labelSettingsAlly.Location = new System.Drawing.Point(8, 38);
            this.labelSettingsAlly.Name = "labelSettingsAlly";
            this.labelSettingsAlly.Size = new System.Drawing.Size(23, 13);
            this.labelSettingsAlly.TabIndex = 0;
            this.labelSettingsAlly.Text = "Ally";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxLanguage);
            this.panel1.Location = new System.Drawing.Point(8, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 66);
            this.panel1.TabIndex = 2;
            // 
            // groupBoxLanguage
            // 
            this.groupBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLanguage.Controls.Add(this.comboBoxSettingsLanguages);
            this.groupBoxLanguage.Controls.Add(this.labelLanguageId);
            this.groupBoxLanguage.Location = new System.Drawing.Point(3, 3);
            this.groupBoxLanguage.Name = "groupBoxLanguage";
            this.groupBoxLanguage.Size = new System.Drawing.Size(264, 53);
            this.groupBoxLanguage.TabIndex = 1;
            this.groupBoxLanguage.TabStop = false;
            this.groupBoxLanguage.Text = "Language";
            // 
            // comboBoxSettingsLanguages
            // 
            this.comboBoxSettingsLanguages.FormattingEnabled = true;
            this.comboBoxSettingsLanguages.Location = new System.Drawing.Point(94, 20);
            this.comboBoxSettingsLanguages.Name = "comboBoxSettingsLanguages";
            this.comboBoxSettingsLanguages.Size = new System.Drawing.Size(150, 21);
            this.comboBoxSettingsLanguages.TabIndex = 1;
            // 
            // labelLanguageId
            // 
            this.labelLanguageId.AutoSize = true;
            this.labelLanguageId.Location = new System.Drawing.Point(14, 20);
            this.labelLanguageId.Name = "labelLanguageId";
            this.labelLanguageId.Size = new System.Drawing.Size(55, 13);
            this.labelLanguageId.TabIndex = 0;
            this.labelLanguageId.Text = "Language";
            // 
            // panelOverviewLogins
            // 
            this.panelOverviewLogins.Controls.Add(this.groupBoxOverview);
            this.panelOverviewLogins.Location = new System.Drawing.Point(8, 78);
            this.panelOverviewLogins.Name = "panelOverviewLogins";
            this.panelOverviewLogins.Size = new System.Drawing.Size(275, 145);
            this.panelOverviewLogins.TabIndex = 0;
            // 
            // groupBoxOverview
            // 
            this.groupBoxOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOverview.Controls.Add(this.buttonOwerviewSave);
            this.groupBoxOverview.Controls.Add(this.textBoxPassword);
            this.groupBoxOverview.Controls.Add(this.textBoxServer);
            this.groupBoxOverview.Controls.Add(this.labelUsername);
            this.groupBoxOverview.Controls.Add(this.labelServer);
            this.groupBoxOverview.Controls.Add(this.textBoxUsername);
            this.groupBoxOverview.Controls.Add(this.labelPassword);
            this.groupBoxOverview.Location = new System.Drawing.Point(3, 3);
            this.groupBoxOverview.Name = "groupBoxOverview";
            this.groupBoxOverview.Size = new System.Drawing.Size(264, 133);
            this.groupBoxOverview.TabIndex = 1;
            this.groupBoxOverview.TabStop = false;
            this.groupBoxOverview.Text = "Login Data";
            // 
            // buttonOwerviewSave
            // 
            this.buttonOwerviewSave.Location = new System.Drawing.Point(94, 96);
            this.buttonOwerviewSave.Name = "buttonOwerviewSave";
            this.buttonOwerviewSave.Size = new System.Drawing.Size(150, 23);
            this.buttonOwerviewSave.TabIndex = 14;
            this.buttonOwerviewSave.Text = "Save";
            this.buttonOwerviewSave.UseVisualStyleBackColor = true;
            this.buttonOwerviewSave.Click += new System.EventHandler(this.buttonOwerviewSave_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(94, 69);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(150, 20);
            this.textBoxPassword.TabIndex = 11;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(94, 17);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(150, 20);
            this.textBoxServer.TabIndex = 13;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(9, 50);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 8;
            this.labelUsername.Text = "Username";
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(11, 24);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(38, 13);
            this.labelServer.TabIndex = 12;
            this.labelServer.Text = "Server";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(94, 43);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(150, 20);
            this.textBoxUsername.TabIndex = 9;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(11, 76);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 10;
            this.labelPassword.Text = "Password";
            // 
            // tabPageRallyPoint
            // 
            this.tabPageRallyPoint.Controls.Add(this.panelRallyPointVillage);
            this.tabPageRallyPoint.Controls.Add(this.panelRallyPoint);
            this.tabPageRallyPoint.Location = new System.Drawing.Point(4, 22);
            this.tabPageRallyPoint.Name = "tabPageRallyPoint";
            this.tabPageRallyPoint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRallyPoint.Size = new System.Drawing.Size(1185, 696);
            this.tabPageRallyPoint.TabIndex = 1;
            this.tabPageRallyPoint.Text = "Rally Point";
            this.tabPageRallyPoint.UseVisualStyleBackColor = true;
            // 
            // panelRallyPointVillage
            // 
            this.panelRallyPointVillage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRallyPointVillage.Controls.Add(this.buttonUpdateRallyPoint);
            this.panelRallyPointVillage.Controls.Add(this.comboBoxRallyPointVillages);
            this.panelRallyPointVillage.Location = new System.Drawing.Point(3, 3);
            this.panelRallyPointVillage.Name = "panelRallyPointVillage";
            this.panelRallyPointVillage.Size = new System.Drawing.Size(1179, 35);
            this.panelRallyPointVillage.TabIndex = 3;
            // 
            // buttonUpdateRallyPoint
            // 
            this.buttonUpdateRallyPoint.Enabled = false;
            this.buttonUpdateRallyPoint.Location = new System.Drawing.Point(207, 3);
            this.buttonUpdateRallyPoint.Name = "buttonUpdateRallyPoint";
            this.buttonUpdateRallyPoint.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateRallyPoint.TabIndex = 1;
            this.buttonUpdateRallyPoint.Text = "Update";
            this.buttonUpdateRallyPoint.UseVisualStyleBackColor = true;
            this.buttonUpdateRallyPoint.Click += new System.EventHandler(this.buttonUpdateRallyPoint_Click);
            // 
            // comboBoxRallyPointVillages
            // 
            this.comboBoxRallyPointVillages.FormattingEnabled = true;
            this.comboBoxRallyPointVillages.Location = new System.Drawing.Point(3, 3);
            this.comboBoxRallyPointVillages.Name = "comboBoxRallyPointVillages";
            this.comboBoxRallyPointVillages.Size = new System.Drawing.Size(198, 21);
            this.comboBoxRallyPointVillages.TabIndex = 0;
            // 
            // panelRallyPoint
            // 
            this.panelRallyPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRallyPoint.Controls.Add(this.dataGridViewRallyPoint);
            this.panelRallyPoint.Location = new System.Drawing.Point(3, 44);
            this.panelRallyPoint.Name = "panelRallyPoint";
            this.panelRallyPoint.Size = new System.Drawing.Size(1179, 649);
            this.panelRallyPoint.TabIndex = 2;
            // 
            // dataGridViewRallyPoint
            // 
            this.dataGridViewRallyPoint.AllowUserToAddRows = false;
            this.dataGridViewRallyPoint.AllowUserToDeleteRows = false;
            this.dataGridViewRallyPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRallyPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRallyPoint.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRallyPoint.Name = "dataGridViewRallyPoint";
            this.dataGridViewRallyPoint.ReadOnly = true;
            this.dataGridViewRallyPoint.Size = new System.Drawing.Size(1179, 649);
            this.dataGridViewRallyPoint.TabIndex = 0;
            // 
            // tabPageMap
            // 
            this.tabPageMap.Controls.Add(this.panelMapSelection);
            this.tabPageMap.Controls.Add(this.panelMapList);
            this.tabPageMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Size = new System.Drawing.Size(1185, 696);
            this.tabPageMap.TabIndex = 2;
            this.tabPageMap.Text = "Map";
            this.tabPageMap.UseVisualStyleBackColor = true;
            // 
            // panelMapSelection
            // 
            this.panelMapSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMapSelection.Controls.Add(this.panelMapPopulate);
            this.panelMapSelection.Controls.Add(this.panelMapUpdate);
            this.panelMapSelection.Location = new System.Drawing.Point(0, 0);
            this.panelMapSelection.Name = "panelMapSelection";
            this.panelMapSelection.Size = new System.Drawing.Size(173, 696);
            this.panelMapSelection.TabIndex = 1;
            // 
            // panelMapPopulate
            // 
            this.panelMapPopulate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMapPopulate.Controls.Add(this.buttonMapPopulate);
            this.panelMapPopulate.Controls.Add(this.groupBoxMapExcluded);
            this.panelMapPopulate.Controls.Add(this.groupBoxMapOases);
            this.panelMapPopulate.Controls.Add(this.groupBoxMapAlliace);
            this.panelMapPopulate.Controls.Add(this.groupBoxMapFarms);
            this.panelMapPopulate.Location = new System.Drawing.Point(6, 150);
            this.panelMapPopulate.Name = "panelMapPopulate";
            this.panelMapPopulate.Size = new System.Drawing.Size(164, 543);
            this.panelMapPopulate.TabIndex = 20;
            // 
            // buttonMapPopulate
            // 
            this.buttonMapPopulate.Location = new System.Drawing.Point(7, 378);
            this.buttonMapPopulate.Name = "buttonMapPopulate";
            this.buttonMapPopulate.Size = new System.Drawing.Size(75, 23);
            this.buttonMapPopulate.TabIndex = 17;
            this.buttonMapPopulate.Text = "Populate";
            this.buttonMapPopulate.UseVisualStyleBackColor = true;
            this.buttonMapPopulate.Click += new System.EventHandler(this.buttonMapPopulate_Click);
            // 
            // groupBoxMapExcluded
            // 
            this.groupBoxMapExcluded.Controls.Add(this.checkBoxExcludedPlayers);
            this.groupBoxMapExcluded.Controls.Add(this.checkBoxExcludedAlliances);
            this.groupBoxMapExcluded.Location = new System.Drawing.Point(7, 227);
            this.groupBoxMapExcluded.Name = "groupBoxMapExcluded";
            this.groupBoxMapExcluded.Size = new System.Drawing.Size(154, 69);
            this.groupBoxMapExcluded.TabIndex = 22;
            this.groupBoxMapExcluded.TabStop = false;
            this.groupBoxMapExcluded.Text = "Excluded";
            // 
            // checkBoxExcludedPlayers
            // 
            this.checkBoxExcludedPlayers.AutoSize = true;
            this.checkBoxExcludedPlayers.Location = new System.Drawing.Point(6, 19);
            this.checkBoxExcludedPlayers.Name = "checkBoxExcludedPlayers";
            this.checkBoxExcludedPlayers.Size = new System.Drawing.Size(137, 17);
            this.checkBoxExcludedPlayers.TabIndex = 4;
            this.checkBoxExcludedPlayers.Text = "Show Excluded Players";
            this.checkBoxExcludedPlayers.UseVisualStyleBackColor = true;
            // 
            // checkBoxExcludedAlliances
            // 
            this.checkBoxExcludedAlliances.AutoSize = true;
            this.checkBoxExcludedAlliances.Location = new System.Drawing.Point(5, 42);
            this.checkBoxExcludedAlliances.Name = "checkBoxExcludedAlliances";
            this.checkBoxExcludedAlliances.Size = new System.Drawing.Size(145, 17);
            this.checkBoxExcludedAlliances.TabIndex = 5;
            this.checkBoxExcludedAlliances.Text = "Show Excluded Alliances";
            this.checkBoxExcludedAlliances.UseVisualStyleBackColor = true;
            // 
            // groupBoxMapOases
            // 
            this.groupBoxMapOases.Controls.Add(this.checkBoxUnoccupiedOasis);
            this.groupBoxMapOases.Controls.Add(this.checkBoxMapOccupiedOasis);
            this.groupBoxMapOases.Location = new System.Drawing.Point(7, 302);
            this.groupBoxMapOases.Name = "groupBoxMapOases";
            this.groupBoxMapOases.Size = new System.Drawing.Size(154, 70);
            this.groupBoxMapOases.TabIndex = 21;
            this.groupBoxMapOases.TabStop = false;
            this.groupBoxMapOases.Text = "Oases";
            // 
            // checkBoxUnoccupiedOasis
            // 
            this.checkBoxUnoccupiedOasis.AutoSize = true;
            this.checkBoxUnoccupiedOasis.Location = new System.Drawing.Point(6, 19);
            this.checkBoxUnoccupiedOasis.Name = "checkBoxUnoccupiedOasis";
            this.checkBoxUnoccupiedOasis.Size = new System.Drawing.Size(143, 17);
            this.checkBoxUnoccupiedOasis.TabIndex = 3;
            this.checkBoxUnoccupiedOasis.Text = "Show Unoccupied Oasis";
            this.checkBoxUnoccupiedOasis.UseVisualStyleBackColor = true;
            // 
            // checkBoxMapOccupiedOasis
            // 
            this.checkBoxMapOccupiedOasis.AutoSize = true;
            this.checkBoxMapOccupiedOasis.Location = new System.Drawing.Point(6, 42);
            this.checkBoxMapOccupiedOasis.Name = "checkBoxMapOccupiedOasis";
            this.checkBoxMapOccupiedOasis.Size = new System.Drawing.Size(131, 17);
            this.checkBoxMapOccupiedOasis.TabIndex = 18;
            this.checkBoxMapOccupiedOasis.Text = "Show Occupied Oasis";
            this.checkBoxMapOccupiedOasis.UseVisualStyleBackColor = true;
            // 
            // groupBoxMapAlliace
            // 
            this.groupBoxMapAlliace.Controls.Add(this.checkBoxAlly);
            this.groupBoxMapAlliace.Controls.Add(this.checkBoxWar);
            this.groupBoxMapAlliace.Controls.Add(this.checkBoxNap);
            this.groupBoxMapAlliace.Location = new System.Drawing.Point(7, 125);
            this.groupBoxMapAlliace.Name = "groupBoxMapAlliace";
            this.groupBoxMapAlliace.Size = new System.Drawing.Size(154, 96);
            this.groupBoxMapAlliace.TabIndex = 20;
            this.groupBoxMapAlliace.TabStop = false;
            this.groupBoxMapAlliace.Text = "Alliance";
            // 
            // checkBoxAlly
            // 
            this.checkBoxAlly.AutoSize = true;
            this.checkBoxAlly.Location = new System.Drawing.Point(9, 19);
            this.checkBoxAlly.Name = "checkBoxAlly";
            this.checkBoxAlly.Size = new System.Drawing.Size(112, 17);
            this.checkBoxAlly.TabIndex = 0;
            this.checkBoxAlly.Text = "Show Alliance Ally";
            this.checkBoxAlly.UseVisualStyleBackColor = true;
            // 
            // checkBoxWar
            // 
            this.checkBoxWar.AutoSize = true;
            this.checkBoxWar.Location = new System.Drawing.Point(9, 65);
            this.checkBoxWar.Name = "checkBoxWar";
            this.checkBoxWar.Size = new System.Drawing.Size(116, 17);
            this.checkBoxWar.TabIndex = 2;
            this.checkBoxWar.Text = "Show Alliance War";
            this.checkBoxWar.UseVisualStyleBackColor = true;
            // 
            // checkBoxNap
            // 
            this.checkBoxNap.AutoSize = true;
            this.checkBoxNap.Location = new System.Drawing.Point(9, 42);
            this.checkBoxNap.Name = "checkBoxNap";
            this.checkBoxNap.Size = new System.Drawing.Size(116, 17);
            this.checkBoxNap.TabIndex = 1;
            this.checkBoxNap.Text = "Show Alliance Nap";
            this.checkBoxNap.UseVisualStyleBackColor = true;
            // 
            // groupBoxMapFarms
            // 
            this.groupBoxMapFarms.Controls.Add(this.checkBoxFarmsNoProfit);
            this.groupBoxMapFarms.Controls.Add(this.checkBoxFarmsHighRish);
            this.groupBoxMapFarms.Controls.Add(this.checkBoxFarmsLowRisk);
            this.groupBoxMapFarms.Controls.Add(this.checkBoxFarmsMiddleRisk);
            this.groupBoxMapFarms.Location = new System.Drawing.Point(7, 3);
            this.groupBoxMapFarms.Name = "groupBoxMapFarms";
            this.groupBoxMapFarms.Size = new System.Drawing.Size(154, 116);
            this.groupBoxMapFarms.TabIndex = 19;
            this.groupBoxMapFarms.TabStop = false;
            this.groupBoxMapFarms.Text = "Farms";
            // 
            // checkBoxFarmsNoProfit
            // 
            this.checkBoxFarmsNoProfit.AutoSize = true;
            this.checkBoxFarmsNoProfit.Location = new System.Drawing.Point(9, 19);
            this.checkBoxFarmsNoProfit.Name = "checkBoxFarmsNoProfit";
            this.checkBoxFarmsNoProfit.Size = new System.Drawing.Size(123, 17);
            this.checkBoxFarmsNoProfit.TabIndex = 7;
            this.checkBoxFarmsNoProfit.Text = "Show No Profit Farm";
            this.checkBoxFarmsNoProfit.UseVisualStyleBackColor = true;
            // 
            // checkBoxFarmsHighRish
            // 
            this.checkBoxFarmsHighRish.AutoSize = true;
            this.checkBoxFarmsHighRish.Location = new System.Drawing.Point(9, 88);
            this.checkBoxFarmsHighRish.Name = "checkBoxFarmsHighRish";
            this.checkBoxFarmsHighRish.Size = new System.Drawing.Size(133, 17);
            this.checkBoxFarmsHighRish.TabIndex = 10;
            this.checkBoxFarmsHighRish.Text = "Show High Risk Farms";
            this.checkBoxFarmsHighRish.UseVisualStyleBackColor = true;
            // 
            // checkBoxFarmsLowRisk
            // 
            this.checkBoxFarmsLowRisk.AutoSize = true;
            this.checkBoxFarmsLowRisk.Checked = true;
            this.checkBoxFarmsLowRisk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFarmsLowRisk.Location = new System.Drawing.Point(9, 42);
            this.checkBoxFarmsLowRisk.Name = "checkBoxFarmsLowRisk";
            this.checkBoxFarmsLowRisk.Size = new System.Drawing.Size(134, 17);
            this.checkBoxFarmsLowRisk.TabIndex = 11;
            this.checkBoxFarmsLowRisk.Text = "Show Low Risk  Farms";
            this.checkBoxFarmsLowRisk.UseVisualStyleBackColor = true;
            // 
            // checkBoxFarmsMiddleRisk
            // 
            this.checkBoxFarmsMiddleRisk.AutoSize = true;
            this.checkBoxFarmsMiddleRisk.Checked = true;
            this.checkBoxFarmsMiddleRisk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFarmsMiddleRisk.Location = new System.Drawing.Point(9, 65);
            this.checkBoxFarmsMiddleRisk.Name = "checkBoxFarmsMiddleRisk";
            this.checkBoxFarmsMiddleRisk.Size = new System.Drawing.Size(142, 17);
            this.checkBoxFarmsMiddleRisk.TabIndex = 12;
            this.checkBoxFarmsMiddleRisk.Text = "Show Middle Risk Farms";
            this.checkBoxFarmsMiddleRisk.UseVisualStyleBackColor = true;
            // 
            // panelMapUpdate
            // 
            this.panelMapUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMapUpdate.Controls.Add(this.groupBoxMapUpdate);
            this.panelMapUpdate.Location = new System.Drawing.Point(6, 4);
            this.panelMapUpdate.Name = "panelMapUpdate";
            this.panelMapUpdate.Size = new System.Drawing.Size(164, 140);
            this.panelMapUpdate.TabIndex = 19;
            // 
            // groupBoxMapUpdate
            // 
            this.groupBoxMapUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMapUpdate.Controls.Add(this.labelMapDistance);
            this.groupBoxMapUpdate.Controls.Add(this.buttonMapUpdate);
            this.groupBoxMapUpdate.Controls.Add(this.comboBoxMapVillages);
            this.groupBoxMapUpdate.Controls.Add(this.labelMapVillage);
            this.groupBoxMapUpdate.Controls.Add(this.textBoxMapDistance);
            this.groupBoxMapUpdate.Location = new System.Drawing.Point(7, 4);
            this.groupBoxMapUpdate.Name = "groupBoxMapUpdate";
            this.groupBoxMapUpdate.Size = new System.Drawing.Size(154, 133);
            this.groupBoxMapUpdate.TabIndex = 17;
            this.groupBoxMapUpdate.TabStop = false;
            this.groupBoxMapUpdate.Text = "Update From Map";
            // 
            // labelMapDistance
            // 
            this.labelMapDistance.AutoSize = true;
            this.labelMapDistance.Location = new System.Drawing.Point(6, 16);
            this.labelMapDistance.Name = "labelMapDistance";
            this.labelMapDistance.Size = new System.Drawing.Size(49, 13);
            this.labelMapDistance.TabIndex = 14;
            this.labelMapDistance.Text = "Distance";
            // 
            // buttonMapUpdate
            // 
            this.buttonMapUpdate.Enabled = false;
            this.buttonMapUpdate.Location = new System.Drawing.Point(6, 98);
            this.buttonMapUpdate.Name = "buttonMapUpdate";
            this.buttonMapUpdate.Size = new System.Drawing.Size(123, 23);
            this.buttonMapUpdate.TabIndex = 6;
            this.buttonMapUpdate.Text = "Update";
            this.buttonMapUpdate.UseVisualStyleBackColor = true;
            this.buttonMapUpdate.Click += new System.EventHandler(this.buttonMapUpdate_Click);
            // 
            // comboBoxMapVillages
            // 
            this.comboBoxMapVillages.FormattingEnabled = true;
            this.comboBoxMapVillages.Location = new System.Drawing.Point(6, 71);
            this.comboBoxMapVillages.Name = "comboBoxMapVillages";
            this.comboBoxMapVillages.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMapVillages.TabIndex = 15;
            // 
            // labelMapVillage
            // 
            this.labelMapVillage.AutoSize = true;
            this.labelMapVillage.Location = new System.Drawing.Point(6, 55);
            this.labelMapVillage.Name = "labelMapVillage";
            this.labelMapVillage.Size = new System.Drawing.Size(38, 13);
            this.labelMapVillage.TabIndex = 16;
            this.labelMapVillage.Text = "Village";
            // 
            // textBoxMapDistance
            // 
            this.textBoxMapDistance.Location = new System.Drawing.Point(6, 32);
            this.textBoxMapDistance.Name = "textBoxMapDistance";
            this.textBoxMapDistance.Size = new System.Drawing.Size(119, 20);
            this.textBoxMapDistance.TabIndex = 13;
            this.textBoxMapDistance.Text = "1";
            // 
            // panelMapList
            // 
            this.panelMapList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMapList.Controls.Add(this.dataGridViewMap);
            this.panelMapList.Location = new System.Drawing.Point(179, 4);
            this.panelMapList.Name = "panelMapList";
            this.panelMapList.Size = new System.Drawing.Size(1006, 692);
            this.panelMapList.TabIndex = 0;
            // 
            // dataGridViewMap
            // 
            this.dataGridViewMap.AllowUserToAddRows = false;
            this.dataGridViewMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMap.AutoGenerateColumns = false;
            this.dataGridViewMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VillageId,
            this.playerDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.allianceDataGridViewTextBoxColumn,
            this.Coordinates,
            this.populationDataGridViewTextBoxColumn,
            this.valleyTypeDataGridViewTextBoxColumn});
            this.dataGridViewMap.DataSource = this.valleyBindingSource;
            this.dataGridViewMap.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMap.Name = "dataGridViewMap";
            this.dataGridViewMap.Size = new System.Drawing.Size(1006, 692);
            this.dataGridViewMap.TabIndex = 0;
            // 
            // valleyBindingSource
            // 
            this.valleyBindingSource.DataSource = typeof(jeza.Travian.Framework.Valley);
            // 
            // tabPageBuildQueue
            // 
            this.tabPageBuildQueue.Controls.Add(this.panelBuildQueueSelect);
            this.tabPageBuildQueue.Controls.Add(this.panelBuildQueueList);
            this.tabPageBuildQueue.Controls.Add(this.panelBuildQueueHead);
            this.tabPageBuildQueue.Location = new System.Drawing.Point(4, 22);
            this.tabPageBuildQueue.Name = "tabPageBuildQueue";
            this.tabPageBuildQueue.Size = new System.Drawing.Size(1185, 696);
            this.tabPageBuildQueue.TabIndex = 3;
            this.tabPageBuildQueue.Text = "Build Queue";
            this.tabPageBuildQueue.UseVisualStyleBackColor = true;
            // 
            // panelBuildQueueSelect
            // 
            this.panelBuildQueueSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBuildQueueSelect.Controls.Add(this.labelBuildQueueLevel);
            this.panelBuildQueueSelect.Controls.Add(this.labelBuildQueueBuilding);
            this.panelBuildQueueSelect.Controls.Add(this.buttonBuildQueueAdd);
            this.panelBuildQueueSelect.Controls.Add(this.comboBoxBuildQueueLevel);
            this.panelBuildQueueSelect.Controls.Add(this.comboBoxBuildQueueBuilding);
            this.panelBuildQueueSelect.Location = new System.Drawing.Point(297, 44);
            this.panelBuildQueueSelect.Name = "panelBuildQueueSelect";
            this.panelBuildQueueSelect.Size = new System.Drawing.Size(880, 649);
            this.panelBuildQueueSelect.TabIndex = 2;
            // 
            // labelBuildQueueLevel
            // 
            this.labelBuildQueueLevel.AutoSize = true;
            this.labelBuildQueueLevel.Location = new System.Drawing.Point(330, 11);
            this.labelBuildQueueLevel.Name = "labelBuildQueueLevel";
            this.labelBuildQueueLevel.Size = new System.Drawing.Size(33, 13);
            this.labelBuildQueueLevel.TabIndex = 4;
            this.labelBuildQueueLevel.Text = "Level";
            // 
            // labelBuildQueueBuilding
            // 
            this.labelBuildQueueBuilding.AutoSize = true;
            this.labelBuildQueueBuilding.Location = new System.Drawing.Point(4, 11);
            this.labelBuildQueueBuilding.Name = "labelBuildQueueBuilding";
            this.labelBuildQueueBuilding.Size = new System.Drawing.Size(56, 13);
            this.labelBuildQueueBuilding.TabIndex = 3;
            this.labelBuildQueueBuilding.Text = "Building Id";
            // 
            // buttonBuildQueueAdd
            // 
            this.buttonBuildQueueAdd.Location = new System.Drawing.Point(383, 30);
            this.buttonBuildQueueAdd.Name = "buttonBuildQueueAdd";
            this.buttonBuildQueueAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonBuildQueueAdd.TabIndex = 2;
            this.buttonBuildQueueAdd.Text = "Add";
            this.buttonBuildQueueAdd.UseVisualStyleBackColor = true;
            // 
            // comboBoxBuildQueueLevel
            // 
            this.comboBoxBuildQueueLevel.FormattingEnabled = true;
            this.comboBoxBuildQueueLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.comboBoxBuildQueueLevel.Location = new System.Drawing.Point(333, 30);
            this.comboBoxBuildQueueLevel.Name = "comboBoxBuildQueueLevel";
            this.comboBoxBuildQueueLevel.Size = new System.Drawing.Size(43, 21);
            this.comboBoxBuildQueueLevel.TabIndex = 1;
            this.comboBoxBuildQueueLevel.Text = "10";
            // 
            // comboBoxBuildQueueBuilding
            // 
            this.comboBoxBuildQueueBuilding.FormattingEnabled = true;
            this.comboBoxBuildQueueBuilding.Location = new System.Drawing.Point(4, 30);
            this.comboBoxBuildQueueBuilding.Name = "comboBoxBuildQueueBuilding";
            this.comboBoxBuildQueueBuilding.Size = new System.Drawing.Size(323, 21);
            this.comboBoxBuildQueueBuilding.TabIndex = 0;
            // 
            // panelBuildQueueList
            // 
            this.panelBuildQueueList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panelBuildQueueList.Controls.Add(this.listBoxBuildQueues);
            this.panelBuildQueueList.Location = new System.Drawing.Point(9, 44);
            this.panelBuildQueueList.Name = "panelBuildQueueList";
            this.panelBuildQueueList.Size = new System.Drawing.Size(282, 649);
            this.panelBuildQueueList.TabIndex = 1;
            // 
            // listBoxBuildQueues
            // 
            this.listBoxBuildQueues.FormattingEnabled = true;
            this.listBoxBuildQueues.Location = new System.Drawing.Point(4, 11);
            this.listBoxBuildQueues.Name = "listBoxBuildQueues";
            this.listBoxBuildQueues.Size = new System.Drawing.Size(275, 628);
            this.listBoxBuildQueues.TabIndex = 0;
            // 
            // panelBuildQueueHead
            // 
            this.panelBuildQueueHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBuildQueueHead.Controls.Add(this.buttonBuildQueueSelect);
            this.panelBuildQueueHead.Controls.Add(this.comboBoxBuildQueueVillages);
            this.panelBuildQueueHead.Location = new System.Drawing.Point(9, 4);
            this.panelBuildQueueHead.Name = "panelBuildQueueHead";
            this.panelBuildQueueHead.Size = new System.Drawing.Size(1168, 34);
            this.panelBuildQueueHead.TabIndex = 0;
            // 
            // buttonBuildQueueSelect
            // 
            this.buttonBuildQueueSelect.Location = new System.Drawing.Point(207, 3);
            this.buttonBuildQueueSelect.Name = "buttonBuildQueueSelect";
            this.buttonBuildQueueSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonBuildQueueSelect.TabIndex = 3;
            this.buttonBuildQueueSelect.Text = "Select";
            this.buttonBuildQueueSelect.UseVisualStyleBackColor = true;
            this.buttonBuildQueueSelect.Click += new System.EventHandler(this.buttonBuildQueueSelect_Click);
            // 
            // comboBoxBuildQueueVillages
            // 
            this.comboBoxBuildQueueVillages.FormattingEnabled = true;
            this.comboBoxBuildQueueVillages.Location = new System.Drawing.Point(3, 3);
            this.comboBoxBuildQueueVillages.Name = "comboBoxBuildQueueVillages";
            this.comboBoxBuildQueueVillages.Size = new System.Drawing.Size(198, 21);
            this.comboBoxBuildQueueVillages.TabIndex = 2;
            // 
            // tabPageReports
            // 
            this.tabPageReports.Location = new System.Drawing.Point(4, 22);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Size = new System.Drawing.Size(1185, 696);
            this.tabPageReports.TabIndex = 4;
            this.tabPageReports.Text = "Reports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // tabPageStatistics
            // 
            this.tabPageStatistics.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatistics.Name = "tabPageStatistics";
            this.tabPageStatistics.Size = new System.Drawing.Size(1185, 696);
            this.tabPageStatistics.TabIndex = 5;
            this.tabPageStatistics.Text = "Statistics";
            this.tabPageStatistics.UseVisualStyleBackColor = true;
            // 
            // tabPageMarketPlace
            // 
            this.tabPageMarketPlace.Location = new System.Drawing.Point(4, 22);
            this.tabPageMarketPlace.Name = "tabPageMarketPlace";
            this.tabPageMarketPlace.Size = new System.Drawing.Size(1185, 696);
            this.tabPageMarketPlace.TabIndex = 6;
            this.tabPageMarketPlace.Text = "MarketPlace";
            this.tabPageMarketPlace.UseVisualStyleBackColor = true;
            // 
            // tabPageBrowser
            // 
            this.tabPageBrowser.Controls.Add(this.panelBrowserUrl);
            this.tabPageBrowser.Controls.Add(this.panelBrowser);
            this.tabPageBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabPageBrowser.Name = "tabPageBrowser";
            this.tabPageBrowser.Size = new System.Drawing.Size(1185, 696);
            this.tabPageBrowser.TabIndex = 7;
            this.tabPageBrowser.Text = "Browser";
            this.tabPageBrowser.UseVisualStyleBackColor = true;
            // 
            // panelBrowserUrl
            // 
            this.panelBrowserUrl.Controls.Add(this.textBoxBrowserUrl);
            this.panelBrowserUrl.Controls.Add(this.buttonBrowserGo);
            this.panelBrowserUrl.Location = new System.Drawing.Point(9, 4);
            this.panelBrowserUrl.Name = "panelBrowserUrl";
            this.panelBrowserUrl.Size = new System.Drawing.Size(1002, 39);
            this.panelBrowserUrl.TabIndex = 1;
            // 
            // textBoxBrowserUrl
            // 
            this.textBoxBrowserUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBrowserUrl.Location = new System.Drawing.Point(-1, 5);
            this.textBoxBrowserUrl.Name = "textBoxBrowserUrl";
            this.textBoxBrowserUrl.Size = new System.Drawing.Size(919, 20);
            this.textBoxBrowserUrl.TabIndex = 4;
            // 
            // buttonBrowserGo
            // 
            this.buttonBrowserGo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonBrowserGo.Location = new System.Drawing.Point(924, 3);
            this.buttonBrowserGo.Name = "buttonBrowserGo";
            this.buttonBrowserGo.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowserGo.TabIndex = 3;
            this.buttonBrowserGo.Text = "Go";
            this.buttonBrowserGo.UseVisualStyleBackColor = true;
            this.buttonBrowserGo.Click += new System.EventHandler(this.buttonBrowserGo_Click);
            // 
            // panelBrowser
            // 
            this.panelBrowser.Controls.Add(this.webBrowser);
            this.panelBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBrowser.Location = new System.Drawing.Point(0, 0);
            this.panelBrowser.Name = "panelBrowser";
            this.panelBrowser.Size = new System.Drawing.Size(1185, 696);
            this.panelBrowser.TabIndex = 0;
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(7, 49);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1167, 644);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // panelHead
            // 
            this.panelHead.AutoSize = true;
            this.panelHead.Controls.Add(this.labelDateTime);
            this.panelHead.Controls.Add(this.buttonRun);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(1193, 28);
            this.panelHead.TabIndex = 2;
            // 
            // labelDateTime
            // 
            this.labelDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDateTime.AutoSize = true;
            this.labelDateTime.Location = new System.Drawing.Point(1075, 12);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(106, 13);
            this.labelDateTime.TabIndex = 5;
            this.labelDateTime.Text = "0000-01-01 01:01:01";
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(12, 2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 4;
            this.buttonRun.Text = "Start";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.SetBotStatus);
            // 
            // panelStatus
            // 
            this.panelStatus.AutoSize = true;
            this.panelStatus.Controls.Add(this.textBoxStatus);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 750);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1193, 115);
            this.panelStatus.TabIndex = 0;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Location = new System.Drawing.Point(4, 4);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxStatus.Size = new System.Drawing.Size(1185, 108);
            this.textBoxStatus.TabIndex = 0;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Game Center";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // VillageId
            // 
            this.VillageId.DataPropertyName = "VillageId";
            this.VillageId.HeaderText = "VillageId";
            this.VillageId.Name = "VillageId";
            // 
            // playerDataGridViewTextBoxColumn
            // 
            this.playerDataGridViewTextBoxColumn.DataPropertyName = "Player";
            this.playerDataGridViewTextBoxColumn.HeaderText = "Player";
            this.playerDataGridViewTextBoxColumn.Name = "playerDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Village";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // allianceDataGridViewTextBoxColumn
            // 
            this.allianceDataGridViewTextBoxColumn.DataPropertyName = "Alliance";
            this.allianceDataGridViewTextBoxColumn.HeaderText = "Alliance";
            this.allianceDataGridViewTextBoxColumn.Name = "allianceDataGridViewTextBoxColumn";
            // 
            // Coordinates
            // 
            this.Coordinates.DataPropertyName = "Coordinates";
            this.Coordinates.HeaderText = "Coordinates";
            this.Coordinates.Name = "Coordinates";
            // 
            // populationDataGridViewTextBoxColumn
            // 
            this.populationDataGridViewTextBoxColumn.DataPropertyName = "Population";
            this.populationDataGridViewTextBoxColumn.HeaderText = "Population";
            this.populationDataGridViewTextBoxColumn.Name = "populationDataGridViewTextBoxColumn";
            // 
            // valleyTypeDataGridViewTextBoxColumn
            // 
            this.valleyTypeDataGridViewTextBoxColumn.DataPropertyName = "ValleyType";
            this.valleyTypeDataGridViewTextBoxColumn.HeaderText = "ValleyType";
            this.valleyTypeDataGridViewTextBoxColumn.Name = "valleyTypeDataGridViewTextBoxColumn";
            this.valleyTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ProcessCenter
            // 
            this.ClientSize = new System.Drawing.Size(1193, 865);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProcessCenter";
            this.Load += new System.EventHandler(this.ProcessCenter_Load);
            this.Resize += new System.EventHandler(this.ProcessCenter_Resize);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelTabs.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBoxAlly.ResumeLayout(false);
            this.groupBoxAlly.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBoxLanguage.ResumeLayout(false);
            this.groupBoxLanguage.PerformLayout();
            this.panelOverviewLogins.ResumeLayout(false);
            this.groupBoxOverview.ResumeLayout(false);
            this.groupBoxOverview.PerformLayout();
            this.tabPageRallyPoint.ResumeLayout(false);
            this.panelRallyPointVillage.ResumeLayout(false);
            this.panelRallyPoint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRallyPoint)).EndInit();
            this.tabPageMap.ResumeLayout(false);
            this.panelMapSelection.ResumeLayout(false);
            this.panelMapPopulate.ResumeLayout(false);
            this.groupBoxMapExcluded.ResumeLayout(false);
            this.groupBoxMapExcluded.PerformLayout();
            this.groupBoxMapOases.ResumeLayout(false);
            this.groupBoxMapOases.PerformLayout();
            this.groupBoxMapAlliace.ResumeLayout(false);
            this.groupBoxMapAlliace.PerformLayout();
            this.groupBoxMapFarms.ResumeLayout(false);
            this.groupBoxMapFarms.PerformLayout();
            this.panelMapUpdate.ResumeLayout(false);
            this.groupBoxMapUpdate.ResumeLayout(false);
            this.groupBoxMapUpdate.PerformLayout();
            this.panelMapList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valleyBindingSource)).EndInit();
            this.tabPageBuildQueue.ResumeLayout(false);
            this.panelBuildQueueSelect.ResumeLayout(false);
            this.panelBuildQueueSelect.PerformLayout();
            this.panelBuildQueueList.ResumeLayout(false);
            this.panelBuildQueueHead.ResumeLayout(false);
            this.tabPageBrowser.ResumeLayout(false);
            this.panelBrowserUrl.ResumeLayout(false);
            this.panelBrowserUrl.PerformLayout();
            this.panelBrowser.ResumeLayout(false);
            this.panelHead.ResumeLayout(false);
            this.panelHead.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelMain;
        private Panel panelTabs;
        private TabControl tabControl;
        private TabPage tabPageSettings;
        private TabPage tabPageRallyPoint;
        private Panel panelStatus;
        private Panel panelHead;
        private Button buttonRun;
        private TextBox textBoxStatus;
        private Panel panelRallyPointVillage;
        private Button buttonUpdateRallyPoint;
        private ComboBox comboBoxRallyPointVillages;
        private Panel panelRallyPoint;
        private DataGridView dataGridViewRallyPoint;
        private TabPage tabPageMap;
        private Panel panelMapSelection;
        private CheckBox checkBoxExcludedAlliances;
        private CheckBox checkBoxExcludedPlayers;
        private CheckBox checkBoxUnoccupiedOasis;
        private CheckBox checkBoxWar;
        private CheckBox checkBoxNap;
        private CheckBox checkBoxAlly;
        private Panel panelMapList;
        private Button buttonMapUpdate;
        private DataGridView dataGridViewMap;
        private CheckBox checkBoxFarmsNoProfit;
        private TabPage tabPageBuildQueue;
        private TabPage tabPageReports;
        private TabPage tabPageStatistics;
        private TabPage tabPageMarketPlace;
        private TabPage tabPageBrowser;
        private Panel panelBrowser;
        private WebBrowser webBrowser;
        private Panel panelBrowserUrl;
        private TextBox textBoxBrowserUrl;
        private Button buttonBrowserGo;
        private NotifyIcon notifyIcon;
        private CheckBox checkBoxFarmsMiddleRisk;
        private CheckBox checkBoxFarmsLowRisk;
        private CheckBox checkBoxFarmsHighRish;
        private Label labelMapVillage;
        private ComboBox comboBoxMapVillages;
        private Label labelMapDistance;
        private TextBox textBoxMapDistance;
        private Button buttonMapPopulate;
        private Panel panelOverviewLogins;
        private TextBox textBoxServer;
        private Label labelServer;
        private TextBox textBoxPassword;
        private Label labelPassword;
        private TextBox textBoxUsername;
        private Label labelUsername;
        private Button buttonOwerviewSave;
        private CheckBox checkBoxMapOccupiedOasis;
        private Panel panelMapUpdate;
        private Panel panelMapPopulate;
        private GroupBox groupBoxMapExcluded;
        private GroupBox groupBoxMapOases;
        private GroupBox groupBoxMapAlliace;
        private Label labelDateTime;
        private Panel panel1;
        private GroupBox groupBoxLanguage;
        private Label labelLanguageId;
        private GroupBox groupBoxMapUpdate;
        private GroupBox groupBoxMapFarms;
        private GroupBox groupBoxOverview;
        private ComboBox comboBoxSettingsLanguages;
        private Panel panel2;
        private GroupBox groupBoxAlly;
        private Label labelSettingsAlly;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label labelSettingsAllyId;
        private Label labelSettingsAllyName;
        private Button buttonSettingsNapAdd;
        private Button buttonSettingsWarAdd;
        private Button buttonSettingsAllyAdd;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label labelSettingsWar;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label labelSettingsNap;
        private Panel panelBuildQueueList;
        private Panel panelBuildQueueHead;
        private Button buttonBuildQueueSelect;
        private ComboBox comboBoxBuildQueueVillages;
        private Panel panelBuildQueueSelect;
        private Label labelBuildQueueLevel;
        private Label labelBuildQueueBuilding;
        private Button buttonBuildQueueAdd;
        private ComboBox comboBoxBuildQueueLevel;
        private ComboBox comboBoxBuildQueueBuilding;
        private ListBox listBoxBuildQueues;
        
        //readonly object stateLock = new object();
        private bool botActive;
        private readonly HtmlWeb htmlWeb = new HtmlWeb();
        private HtmlDocument htmlDocument;
        private Settings settings;
        private readonly Account account;
        private readonly Map map;
        private Languages languages;
        private ValleyTypeList valleyTypeList;

        delegate void StringParameterDelegate(string value);
        delegate void SetDataGridViewDataBind(DataGridView field, ArrayList list);
        delegate void SetButtonStatus(Button button, bool enabled);
        delegate void SetComboBoxStatus(ComboBox comboBox);
        delegate void SetComboBoxStatusQueues(ComboBox comboBox, ArrayList list);

        const string SettingsXml = "Settings.xml";
        const string LanguagesXml = "Language.xml";
        const string ValleyTypeListXml = "ValleyTypeList.xml";

        private BindingSource valleyBindingSource;
        private DataGridViewTextBoxColumn VillageId;
        private DataGridViewTextBoxColumn playerDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn allianceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Coordinates;
        private DataGridViewTextBoxColumn populationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valleyTypeDataGridViewTextBoxColumn;
        
    }
}

