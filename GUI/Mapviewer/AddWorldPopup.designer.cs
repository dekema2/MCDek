﻿namespace MCDek.Gui.MapEditor
{
    partial class AddWorldPopup {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && (components != null) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lPreview = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.cAccess = new System.Windows.Forms.ComboBox();
            this.cBuild = new System.Windows.Forms.ComboBox();
            this.lName = new System.Windows.Forms.Label();
            this.lAccess = new System.Windows.Forms.Label();
            this.lBuild = new System.Windows.Forms.Label();
            this.tName = new System.Windows.Forms.TextBox();
            this.bPreviewPrev = new System.Windows.Forms.Button();
            this.bPreviewNext = new System.Windows.Forms.Button();
            this.xHidden = new System.Windows.Forms.CheckBox();
            this.fileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tStatus1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.previewLayout = new System.Windows.Forms.TableLayoutPanel();
            this.preview = new MCDek.Gui.CustomPictureBox();
            this.bSavePreview = new System.Windows.Forms.Button();
            this.lMapFileOptions = new System.Windows.Forms.Label();
            this.lCreateMap = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.tabTerrain = new System.Windows.Forms.TabPage();
            this.cTheme = new System.Windows.Forms.ComboBox();
            this.lTheme = new System.Windows.Forms.Label();
            this.bGenerate = new System.Windows.Forms.Button();
            this.xAdvanced = new System.Windows.Forms.CheckBox();
            this.nSeed = new System.Windows.Forms.NumericUpDown();
            this.xSeed = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gBeaches = new System.Windows.Forms.GroupBox();
            this.lBeachExtent = new System.Windows.Forms.Label();
            this.nBeachExtent = new System.Windows.Forms.NumericUpDown();
            this.nBeachHeight = new System.Windows.Forms.NumericUpDown();
            this.lBeachHeightUnits = new System.Windows.Forms.Label();
            this.lBeachExtentUnits = new System.Windows.Forms.Label();
            this.lBeachHeight = new System.Windows.Forms.Label();
            this.gCliffs = new System.Windows.Forms.GroupBox();
            this.lCliffThreshold = new System.Windows.Forms.Label();
            this.sCliffThreshold = new System.Windows.Forms.TrackBar();
            this.lCliffThresholdUnits = new System.Windows.Forms.Label();
            this.xCliffSmoothing = new System.Windows.Forms.CheckBox();
            this.gSnow = new System.Windows.Forms.GroupBox();
            this.lSnowAltitude = new System.Windows.Forms.Label();
            this.nSnowAltitude = new System.Windows.Forms.NumericUpDown();
            this.nSnowTransition = new System.Windows.Forms.NumericUpDown();
            this.lSnowAltitudeUnits = new System.Windows.Forms.Label();
            this.lSnowTransition = new System.Windows.Forms.Label();
            this.lSnowTransitionUnits = new System.Windows.Forms.Label();
            this.gTrees = new System.Windows.Forms.GroupBox();
            this.lTreeSpacing = new System.Windows.Forms.Label();
            this.nTreeSpacing = new System.Windows.Forms.NumericUpDown();
            this.lTreeSpacingVariation = new System.Windows.Forms.Label();
            this.nTreeSpacingVariation = new System.Windows.Forms.NumericUpDown();
            this.lTreeSpacingUnits = new System.Windows.Forms.Label();
            this.lTreeHeight = new System.Windows.Forms.Label();
            this.nTreeHeight = new System.Windows.Forms.NumericUpDown();
            this.lTreeHeightVariation = new System.Windows.Forms.Label();
            this.nTreeHeightVariation = new System.Windows.Forms.NumericUpDown();
            this.lTreeHeightUnits = new System.Windows.Forms.Label();
            this.gCaves = new System.Windows.Forms.GroupBox();
            this.lCaveDensity = new System.Windows.Forms.Label();
            this.sCaveDensity = new System.Windows.Forms.TrackBar();
            this.lCaveSize = new System.Windows.Forms.Label();
            this.sCaveSize = new System.Windows.Forms.TrackBar();
            this.xCaveWater = new System.Windows.Forms.CheckBox();
            this.xCaveLava = new System.Windows.Forms.CheckBox();
            this.lCaveDensityDisplay = new System.Windows.Forms.Label();
            this.lCaveSizeDisplay = new System.Windows.Forms.Label();
            this.gHeightmapCreation = new System.Windows.Forms.GroupBox();
            this.lDetailSize = new System.Windows.Forms.Label();
            this.lRoughness = new System.Windows.Forms.Label();
            this.lMatchWaterCoverageDisplay = new System.Windows.Forms.Label();
            this.sRoughness = new System.Windows.Forms.TrackBar();
            this.xMarbledMode = new System.Windows.Forms.CheckBox();
            this.xLayeredHeightmap = new System.Windows.Forms.CheckBox();
            this.sWaterCoverage = new System.Windows.Forms.TrackBar();
            this.xMatchWaterCoverage = new System.Windows.Forms.CheckBox();
            this.lFeatureSizeDisplay = new System.Windows.Forms.Label();
            this.lRoughnessDisplay = new System.Windows.Forms.Label();
            this.sFeatureScale = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lDetailSizeDisplay = new System.Windows.Forms.Label();
            this.sDetailScale = new System.Windows.Forms.TrackBar();
            this.xInvert = new System.Windows.Forms.CheckBox();
            this.xDelayBias = new System.Windows.Forms.CheckBox();
            this.sBelowFunc = new System.Windows.Forms.TrackBar();
            this.sAboveFunc = new System.Windows.Forms.TrackBar();
            this.lAboveFuncUnits = new System.Windows.Forms.Label();
            this.lBelowFuncUnits = new System.Windows.Forms.Label();
            this.lAboveFunc = new System.Windows.Forms.Label();
            this.lBelowFunc = new System.Windows.Forms.Label();
            this.gTerrainFeatures = new System.Windows.Forms.GroupBox();
            this.sBias = new System.Windows.Forms.TrackBar();
            this.lBias = new System.Windows.Forms.Label();
            this.lBiasDisplay = new System.Windows.Forms.Label();
            this.nRaisedCorners = new System.Windows.Forms.NumericUpDown();
            this.lRaisedCorners = new System.Windows.Forms.Label();
            this.lMidpoint = new System.Windows.Forms.Label();
            this.cMidpoint = new System.Windows.Forms.ComboBox();
            this.nLoweredCorners = new System.Windows.Forms.NumericUpDown();
            this.lLoweredCorners = new System.Windows.Forms.Label();
            this.gMapSize = new System.Windows.Forms.GroupBox();
            this.nWidthY = new System.Windows.Forms.NumericUpDown();
            this.nHeight = new System.Windows.Forms.NumericUpDown();
            this.lX2 = new System.Windows.Forms.Label();
            this.lDim = new System.Windows.Forms.Label();
            this.lX1 = new System.Windows.Forms.Label();
            this.lMaxDepthUnits = new System.Windows.Forms.Label();
            this.lMaxDepth = new System.Windows.Forms.Label();
            this.lMaxHeightUnits = new System.Windows.Forms.Label();
            this.lMaxHeight = new System.Windows.Forms.Label();
            this.nWidthX = new System.Windows.Forms.NumericUpDown();
            this.nMaxHeight = new System.Windows.Forms.NumericUpDown();
            this.nMaxDepth = new System.Windows.Forms.NumericUpDown();
            this.lWaterLevelLabel = new System.Windows.Forms.Label();
            this.nWaterLevel = new System.Windows.Forms.NumericUpDown();
            this.xWaterLevel = new System.Windows.Forms.CheckBox();
            this.lMaxDepthVariationUnits = new System.Windows.Forms.Label();
            this.lMaxHeightVariationUnits = new System.Windows.Forms.Label();
            this.nMaxHeightVariation = new System.Windows.Forms.NumericUpDown();
            this.nMaxDepthVariation = new System.Windows.Forms.NumericUpDown();
            this.gTemplates = new System.Windows.Forms.GroupBox();
            this.bSaveTemplate = new System.Windows.Forms.Button();
            this.bBrowseTemplate = new System.Windows.Forms.Button();
            this.lUseTemplate = new System.Windows.Forms.Label();
            this.cTemplates = new System.Windows.Forms.ComboBox();
            this.gGenOptions = new System.Windows.Forms.GroupBox();
            this.xCaves = new System.Windows.Forms.CheckBox();
            this.xWater = new System.Windows.Forms.CheckBox();
            this.xFloodBarrier = new System.Windows.Forms.CheckBox();
            this.xAddSnow = new System.Windows.Forms.CheckBox();
            this.xAddTrees = new System.Windows.Forms.CheckBox();
            this.xAddBeaches = new System.Windows.Forms.CheckBox();
            this.xOre = new System.Windows.Forms.CheckBox();
            this.xAddRuins = new System.Windows.Forms.CheckBox();
            this.xAddCliffs = new System.Windows.Forms.CheckBox();
            this.tabHeightmap = new System.Windows.Forms.TabPage();
            this.lHeightmapComingSoon = new System.Windows.Forms.Label();
            this.tabFlatgrass = new System.Windows.Forms.TabPage();
            this.nFlatgrassDimY = new System.Windows.Forms.NumericUpDown();
            this.nFlatgrassDimH = new System.Windows.Forms.NumericUpDown();
            this.lFlatgrassX2 = new System.Windows.Forms.Label();
            this.lFlatgrassDimensions = new System.Windows.Forms.Label();
            this.lFlatgrassX1 = new System.Windows.Forms.Label();
            this.nFlatgrassDimX = new System.Windows.Forms.NumericUpDown();
            this.bFlatgrassGenerate = new System.Windows.Forms.Button();
            this.tabCopy = new System.Windows.Forms.TabPage();
            this.cWorld = new System.Windows.Forms.ComboBox();
            this.bShow = new System.Windows.Forms.Button();
            this.lWorldToCopy = new System.Windows.Forms.Label();
            this.tCopyInfo = new System.Windows.Forms.TextBox();
            this.tabLoad = new System.Windows.Forms.TabPage();
            this.bBrowseFile = new System.Windows.Forms.Button();
            this.tFile = new System.Windows.Forms.TextBox();
            this.tLoadFileInfo = new System.Windows.Forms.TextBox();
            this.lFile = new System.Windows.Forms.Label();
            this.lFormatList = new System.Windows.Forms.Label();
            this.bBrowseFolder = new System.Windows.Forms.Button();
            this.tFolder = new System.Windows.Forms.TextBox();
            this.lFolder = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabExisting = new System.Windows.Forms.TabPage();
            this.tExistingMapInfo = new System.Windows.Forms.TextBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.statusStrip.SuspendLayout();
            this.previewLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            this.tabTerrain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSeed)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.gBeaches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nBeachExtent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBeachHeight)).BeginInit();
            this.gCliffs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sCliffThreshold)).BeginInit();
            this.gSnow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSnowAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSnowTransition)).BeginInit();
            this.gTrees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTreeSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTreeSpacingVariation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTreeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTreeHeightVariation)).BeginInit();
            this.gCaves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sCaveDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCaveSize)).BeginInit();
            this.gHeightmapCreation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sRoughness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sWaterCoverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sFeatureScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sDetailScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sBelowFunc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAboveFunc)).BeginInit();
            this.gTerrainFeatures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sBias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRaisedCorners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLoweredCorners)).BeginInit();
            this.gMapSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nWidthY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWidthX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWaterLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxHeightVariation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxDepthVariation)).BeginInit();
            this.gTemplates.SuspendLayout();
            this.gGenOptions.SuspendLayout();
            this.tabHeightmap.SuspendLayout();
            this.tabFlatgrass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nFlatgrassDimY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFlatgrassDimH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFlatgrassDimX)).BeginInit();
            this.tabCopy.SuspendLayout();
            this.tabLoad.SuspendLayout();
            this.tabExisting.SuspendLayout();
            this.tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // lPreview
            // 
            this.lPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lPreview.AutoSize = true;
            this.lPreview.Location = new System.Drawing.Point(250, 487);
            this.lPreview.Name = "lPreview";
            this.lPreview.Size = new System.Drawing.Size(54, 28);
            this.lPreview.TabIndex = 16;
            this.lPreview.Text = "Preview";
            this.lPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bOK.Location = new System.Drawing.Point(766, 533);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(100, 25);
            this.bOK.TabIndex = 7;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(872, 533);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(100, 25);
            this.bCancel.TabIndex = 8;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // cAccess
            // 
            this.cAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cAccess.FormattingEnabled = true;
            this.cAccess.Location = new System.Drawing.Point(113, 38);
            this.cAccess.Name = "cAccess";
            this.cAccess.Size = new System.Drawing.Size(113, 21);
            this.cAccess.TabIndex = 1;
            this.cAccess.SelectedIndexChanged += new System.EventHandler(this.cAccess_SelectedIndexChanged);
            // 
            // cBuild
            // 
            this.cBuild.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBuild.FormattingEnabled = true;
            this.cBuild.Location = new System.Drawing.Point(113, 65);
            this.cBuild.Name = "cBuild";
            this.cBuild.Size = new System.Drawing.Size(113, 21);
            this.cBuild.TabIndex = 2;
            this.cBuild.SelectedIndexChanged += new System.EventHandler(this.cBuild_SelectedIndexChanged);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(43, 15);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(64, 13);
            this.lName.TabIndex = 21;
            this.lName.Text = "World name";
            // 
            // lAccess
            // 
            this.lAccess.AutoSize = true;
            this.lAccess.Location = new System.Drawing.Point(13, 42);
            this.lAccess.Name = "lAccess";
            this.lAccess.Size = new System.Drawing.Size(94, 13);
            this.lAccess.TabIndex = 22;
            this.lAccess.Text = "Access permission";
            // 
            // lBuild
            // 
            this.lBuild.AutoSize = true;
            this.lBuild.Location = new System.Drawing.Point(25, 68);
            this.lBuild.Name = "lBuild";
            this.lBuild.Size = new System.Drawing.Size(82, 13);
            this.lBuild.TabIndex = 23;
            this.lBuild.Text = "Build permission";
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(113, 12);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(113, 20);
            this.tName.TabIndex = 0;
            this.tName.Validating += new System.ComponentModel.CancelEventHandler(this.tName_Validating);
            this.tName.Validated += new System.EventHandler(this.tName_Validated);
            // 
            // bPreviewPrev
            // 
            this.bPreviewPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bPreviewPrev.Location = new System.Drawing.Point(222, 490);
            this.bPreviewPrev.Name = "bPreviewPrev";
            this.bPreviewPrev.Size = new System.Drawing.Size(22, 22);
            this.bPreviewPrev.TabIndex = 0;
            this.bPreviewPrev.Text = "<";
            this.bPreviewPrev.UseVisualStyleBackColor = true;
            this.bPreviewPrev.Click += new System.EventHandler(this.bPreviewPrev_Click);
            // 
            // bPreviewNext
            // 
            this.bPreviewNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bPreviewNext.Location = new System.Drawing.Point(310, 490);
            this.bPreviewNext.Name = "bPreviewNext";
            this.bPreviewNext.Size = new System.Drawing.Size(22, 22);
            this.bPreviewNext.TabIndex = 1;
            this.bPreviewNext.Text = ">";
            this.bPreviewNext.UseVisualStyleBackColor = true;
            this.bPreviewNext.Click += new System.EventHandler(this.bPreviewNext_Click);
            // 
            // xHidden
            // 
            this.xHidden.AutoSize = true;
            this.xHidden.Location = new System.Drawing.Point(247, 41);
            this.xHidden.Name = "xHidden";
            this.xHidden.Size = new System.Drawing.Size(132, 17);
            this.xHidden.TabIndex = 3;
            this.xHidden.Text = "Hide from the world list";
            this.xHidden.UseVisualStyleBackColor = true;
            this.xHidden.CheckedChanged += new System.EventHandler(this.xHidden_CheckedChanged);
            // 
            // fileBrowser
            // 
            this.fileBrowser.Filter = "Minecraft Maps|*.fcm;*.lvl;*.dat;*.mclevel;*.gz;*.map;*.meta;*.mine";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.tStatus1,
            this.tStatus2});
            this.statusStrip.Location = new System.Drawing.Point(0, 561);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(984, 22);
            this.statusStrip.TabIndex = 29;
            this.statusStrip.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            // 
            // tStatus1
            // 
            this.tStatus1.Name = "tStatus1";
            this.tStatus1.Size = new System.Drawing.Size(43, 17);
            this.tStatus1.Text = "status1";
            // 
            // tStatus2
            // 
            this.tStatus2.Name = "tStatus2";
            this.tStatus2.Size = new System.Drawing.Size(43, 17);
            this.tStatus2.Text = "status2";
            // 
            // previewLayout
            // 
            this.previewLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.previewLayout.ColumnCount = 3;
            this.previewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.previewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.previewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.previewLayout.Controls.Add(this.bPreviewPrev, 0, 1);
            this.previewLayout.Controls.Add(this.bPreviewNext, 2, 1);
            this.previewLayout.Controls.Add(this.lPreview, 1, 1);
            this.previewLayout.Controls.Add(this.preview, 0, 0);
            this.previewLayout.Location = new System.Drawing.Point(417, 12);
            this.previewLayout.Name = "previewLayout";
            this.previewLayout.RowCount = 2;
            this.previewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.previewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.previewLayout.Size = new System.Drawing.Size(555, 515);
            this.previewLayout.TabIndex = 6;
            // 
            // preview
            // 
            this.preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.preview.BackColor = System.Drawing.Color.Black;
            this.previewLayout.SetColumnSpan(this.preview, 3);
            this.preview.Location = new System.Drawing.Point(3, 3);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(549, 481);
            this.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.preview.TabIndex = 17;
            this.preview.TabStop = false;
            // 
            // bSavePreview
            // 
            this.bSavePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSavePreview.Enabled = false;
            this.bSavePreview.Location = new System.Drawing.Point(417, 533);
            this.bSavePreview.Name = "bSavePreview";
            this.bSavePreview.Size = new System.Drawing.Size(125, 25);
            this.bSavePreview.TabIndex = 6;
            this.bSavePreview.Text = "Save Preview Image...";
            this.bSavePreview.UseVisualStyleBackColor = true;
            this.bSavePreview.Click += new System.EventHandler(this.bSavePreview_Click);
            // 
            // lMapFileOptions
            // 
            this.lMapFileOptions.AutoSize = true;
            this.lMapFileOptions.Location = new System.Drawing.Point(9, 92);
            this.lMapFileOptions.Name = "lMapFileOptions";
            this.lMapFileOptions.Size = new System.Drawing.Size(47, 13);
            this.lMapFileOptions.TabIndex = 55;
            this.lMapFileOptions.Text = "Map file:";
            // 
            // lCreateMap
            // 
            this.lCreateMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lCreateMap.AutoSize = true;
            this.lCreateMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCreateMap.ForeColor = System.Drawing.Color.Red;
            this.lCreateMap.Location = new System.Drawing.Point(610, 539);
            this.lCreateMap.Name = "lCreateMap";
            this.lCreateMap.Size = new System.Drawing.Size(150, 13);
            this.lCreateMap.TabIndex = 56;
            this.lCreateMap.Text = "Create a map to continue";
            // 
            // folderBrowser
            // 
            this.folderBrowser.Description = "Find the folder where your Myne / MyneCraft / Hydebuild / iCraft map is located.";
            // 
            // tabTerrain
            // 
            this.tabTerrain.BackColor = System.Drawing.SystemColors.Window;
            this.tabTerrain.Controls.Add(this.flowLayoutPanel1);
            this.tabTerrain.Controls.Add(this.xSeed);
            this.tabTerrain.Controls.Add(this.nSeed);
            this.tabTerrain.Controls.Add(this.xAdvanced);
            this.tabTerrain.Controls.Add(this.bGenerate);
            this.tabTerrain.Controls.Add(this.lTheme);
            this.tabTerrain.Controls.Add(this.cTheme);
            this.tabTerrain.Location = new System.Drawing.Point(4, 22);
            this.tabTerrain.Name = "tabTerrain";
            this.tabTerrain.Padding = new System.Windows.Forms.Padding(3);
            this.tabTerrain.Size = new System.Drawing.Size(391, 424);
            this.tabTerrain.TabIndex = 5;
            this.tabTerrain.Text = "Generator";
            this.tabTerrain.UseVisualStyleBackColor = true;
            // 
            // cTheme
            // 
            this.cTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cTheme.Location = new System.Drawing.Point(281, 6);
            this.cTheme.Name = "cTheme";
            this.cTheme.Size = new System.Drawing.Size(87, 21);
            this.cTheme.TabIndex = 3;
            // 
            // lTheme
            // 
            this.lTheme.AutoSize = true;
            this.lTheme.Location = new System.Drawing.Point(235, 9);
            this.lTheme.Name = "lTheme";
            this.lTheme.Size = new System.Drawing.Size(40, 13);
            this.lTheme.TabIndex = 19;
            this.lTheme.Text = "Theme";
            // 
            // bGenerate
            // 
            this.bGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGenerate.Location = new System.Drawing.Point(6, 6);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(95, 47);
            this.bGenerate.TabIndex = 0;
            this.bGenerate.Text = "Generate";
            this.bGenerate.UseVisualStyleBackColor = true;
            this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // xAdvanced
            // 
            this.xAdvanced.AutoSize = true;
            this.xAdvanced.Location = new System.Drawing.Point(107, 22);
            this.xAdvanced.Name = "xAdvanced";
            this.xAdvanced.Size = new System.Drawing.Size(75, 17);
            this.xAdvanced.TabIndex = 1;
            this.xAdvanced.Text = "Advanced";
            this.xAdvanced.UseVisualStyleBackColor = true;
            this.xAdvanced.CheckedChanged += new System.EventHandler(this.xAdvanced_CheckedChanged);
            // 
            // nSeed
            // 
            this.nSeed.Enabled = false;
            this.nSeed.Location = new System.Drawing.Point(281, 33);
            this.nSeed.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nSeed.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nSeed.Name = "nSeed";
            this.nSeed.Size = new System.Drawing.Size(87, 20);
            this.nSeed.TabIndex = 7;
            // 
            // xSeed
            // 
            this.xSeed.AutoSize = true;
            this.xSeed.Location = new System.Drawing.Point(224, 34);
            this.xSeed.Name = "xSeed";
            this.xSeed.Size = new System.Drawing.Size(51, 17);
            this.xSeed.TabIndex = 6;
            this.xSeed.Text = "Seed";
            this.xSeed.UseVisualStyleBackColor = true;
            this.xSeed.CheckedChanged += new System.EventHandler(this.xSeed_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.gGenOptions);
            this.flowLayoutPanel1.Controls.Add(this.gTemplates);
            this.flowLayoutPanel1.Controls.Add(this.gMapSize);
            this.flowLayoutPanel1.Controls.Add(this.gTerrainFeatures);
            this.flowLayoutPanel1.Controls.Add(this.gHeightmapCreation);
            this.flowLayoutPanel1.Controls.Add(this.gCaves);
            this.flowLayoutPanel1.Controls.Add(this.gTrees);
            this.flowLayoutPanel1.Controls.Add(this.gSnow);
            this.flowLayoutPanel1.Controls.Add(this.gCliffs);
            this.flowLayoutPanel1.Controls.Add(this.gBeaches);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 59);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(391, 365);
            this.flowLayoutPanel1.TabIndex = 57;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // gBeaches
            // 
            this.gBeaches.Controls.Add(this.lBeachHeight);
            this.gBeaches.Controls.Add(this.lBeachExtentUnits);
            this.gBeaches.Controls.Add(this.lBeachHeightUnits);
            this.gBeaches.Controls.Add(this.nBeachHeight);
            this.gBeaches.Controls.Add(this.nBeachExtent);
            this.gBeaches.Controls.Add(this.lBeachExtent);
            this.gBeaches.Location = new System.Drawing.Point(3, 926);
            this.gBeaches.Name = "gBeaches";
            this.gBeaches.Size = new System.Drawing.Size(362, 48);
            this.gBeaches.TabIndex = 76;
            this.gBeaches.TabStop = false;
            this.gBeaches.Text = "Beaches";
            this.gBeaches.Visible = false;
            // 
            // lBeachExtent
            // 
            this.lBeachExtent.AutoSize = true;
            this.lBeachExtent.Location = new System.Drawing.Point(40, 23);
            this.lBeachExtent.Name = "lBeachExtent";
            this.lBeachExtent.Size = new System.Drawing.Size(37, 13);
            this.lBeachExtent.TabIndex = 65;
            this.lBeachExtent.Text = "Extent";
            // 
            // nBeachExtent
            // 
            this.nBeachExtent.Location = new System.Drawing.Point(83, 19);
            this.nBeachExtent.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nBeachExtent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nBeachExtent.Name = "nBeachExtent";
            this.nBeachExtent.Size = new System.Drawing.Size(54, 20);
            this.nBeachExtent.TabIndex = 63;
            this.nBeachExtent.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // nBeachHeight
            // 
            this.nBeachHeight.Location = new System.Drawing.Point(260, 21);
            this.nBeachHeight.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nBeachHeight.Name = "nBeachHeight";
            this.nBeachHeight.Size = new System.Drawing.Size(54, 20);
            this.nBeachHeight.TabIndex = 64;
            this.nBeachHeight.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lBeachHeightUnits
            // 
            this.lBeachHeightUnits.AutoSize = true;
            this.lBeachHeightUnits.Location = new System.Drawing.Point(320, 23);
            this.lBeachHeightUnits.Name = "lBeachHeightUnits";
            this.lBeachHeightUnits.Size = new System.Drawing.Size(38, 13);
            this.lBeachHeightUnits.TabIndex = 67;
            this.lBeachHeightUnits.Text = "blocks";
            // 
            // lBeachExtentUnits
            // 
            this.lBeachExtentUnits.AutoSize = true;
            this.lBeachExtentUnits.Location = new System.Drawing.Point(143, 23);
            this.lBeachExtentUnits.Name = "lBeachExtentUnits";
            this.lBeachExtentUnits.Size = new System.Drawing.Size(38, 13);
            this.lBeachExtentUnits.TabIndex = 68;
            this.lBeachExtentUnits.Text = "blocks";
            // 
            // lBeachHeight
            // 
            this.lBeachHeight.AutoSize = true;
            this.lBeachHeight.Location = new System.Drawing.Point(216, 23);
            this.lBeachHeight.Name = "lBeachHeight";
            this.lBeachHeight.Size = new System.Drawing.Size(38, 13);
            this.lBeachHeight.TabIndex = 69;
            this.lBeachHeight.Text = "Height";
            // 
            // gCliffs
            // 
            this.gCliffs.Controls.Add(this.xCliffSmoothing);
            this.gCliffs.Controls.Add(this.lCliffThresholdUnits);
            this.gCliffs.Controls.Add(this.sCliffThreshold);
            this.gCliffs.Controls.Add(this.lCliffThreshold);
            this.gCliffs.Location = new System.Drawing.Point(3, 861);
            this.gCliffs.Name = "gCliffs";
            this.gCliffs.Size = new System.Drawing.Size(362, 59);
            this.gCliffs.TabIndex = 23;
            this.gCliffs.TabStop = false;
            this.gCliffs.Text = "Cliffs";
            this.gCliffs.Visible = false;
            // 
            // lCliffThreshold
            // 
            this.lCliffThreshold.AutoSize = true;
            this.lCliffThreshold.Location = new System.Drawing.Point(43, 24);
            this.lCliffThreshold.Name = "lCliffThreshold";
            this.lCliffThreshold.Size = new System.Drawing.Size(54, 13);
            this.lCliffThreshold.TabIndex = 72;
            this.lCliffThreshold.Text = "Threshold";
            // 
            // sCliffThreshold
            // 
            this.sCliffThreshold.AutoSize = false;
            this.sCliffThreshold.LargeChange = 20;
            this.sCliffThreshold.Location = new System.Drawing.Point(103, 19);
            this.sCliffThreshold.Maximum = 200;
            this.sCliffThreshold.Minimum = 20;
            this.sCliffThreshold.Name = "sCliffThreshold";
            this.sCliffThreshold.Size = new System.Drawing.Size(110, 27);
            this.sCliffThreshold.TabIndex = 73;
            this.sCliffThreshold.TickFrequency = 10;
            this.sCliffThreshold.Value = 100;
            this.sCliffThreshold.ValueChanged += new System.EventHandler(this.sCliffThreshold_ValueChanged);
            // 
            // lCliffThresholdUnits
            // 
            this.lCliffThresholdUnits.AutoSize = true;
            this.lCliffThresholdUnits.Location = new System.Drawing.Point(213, 23);
            this.lCliffThresholdUnits.Name = "lCliffThresholdUnits";
            this.lCliffThresholdUnits.Size = new System.Drawing.Size(33, 13);
            this.lCliffThresholdUnits.TabIndex = 74;
            this.lCliffThresholdUnits.Text = "100%";
            // 
            // xCliffSmoothing
            // 
            this.xCliffSmoothing.AutoSize = true;
            this.xCliffSmoothing.Location = new System.Drawing.Point(260, 23);
            this.xCliffSmoothing.Name = "xCliffSmoothing";
            this.xCliffSmoothing.Size = new System.Drawing.Size(74, 17);
            this.xCliffSmoothing.TabIndex = 75;
            this.xCliffSmoothing.Text = "Smoothed";
            this.xCliffSmoothing.UseVisualStyleBackColor = true;
            // 
            // gSnow
            // 
            this.gSnow.Controls.Add(this.lSnowTransitionUnits);
            this.gSnow.Controls.Add(this.lSnowTransition);
            this.gSnow.Controls.Add(this.lSnowAltitudeUnits);
            this.gSnow.Controls.Add(this.nSnowTransition);
            this.gSnow.Controls.Add(this.nSnowAltitude);
            this.gSnow.Controls.Add(this.lSnowAltitude);
            this.gSnow.Location = new System.Drawing.Point(3, 810);
            this.gSnow.Name = "gSnow";
            this.gSnow.Size = new System.Drawing.Size(362, 45);
            this.gSnow.TabIndex = 24;
            this.gSnow.TabStop = false;
            this.gSnow.Text = "Snowy Mountains";
            this.gSnow.Visible = false;
            // 
            // lSnowAltitude
            // 
            this.lSnowAltitude.AutoSize = true;
            this.lSnowAltitude.Location = new System.Drawing.Point(6, 21);
            this.lSnowAltitude.Name = "lSnowAltitude";
            this.lSnowAltitude.Size = new System.Drawing.Size(71, 13);
            this.lSnowAltitude.TabIndex = 65;
            this.lSnowAltitude.Text = "Snow altitude";
            // 
            // nSnowAltitude
            // 
            this.nSnowAltitude.Location = new System.Drawing.Point(83, 19);
            this.nSnowAltitude.Maximum = new decimal(new int[] {
            2032,
            0,
            0,
            0});
            this.nSnowAltitude.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nSnowAltitude.Name = "nSnowAltitude";
            this.nSnowAltitude.Size = new System.Drawing.Size(54, 20);
            this.nSnowAltitude.TabIndex = 63;
            this.nSnowAltitude.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // nSnowTransition
            // 
            this.nSnowTransition.Location = new System.Drawing.Point(258, 19);
            this.nSnowTransition.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nSnowTransition.Name = "nSnowTransition";
            this.nSnowTransition.Size = new System.Drawing.Size(54, 20);
            this.nSnowTransition.TabIndex = 64;
            this.nSnowTransition.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lSnowAltitudeUnits
            // 
            this.lSnowAltitudeUnits.AutoSize = true;
            this.lSnowAltitudeUnits.Location = new System.Drawing.Point(143, 21);
            this.lSnowAltitudeUnits.Name = "lSnowAltitudeUnits";
            this.lSnowAltitudeUnits.Size = new System.Drawing.Size(38, 13);
            this.lSnowAltitudeUnits.TabIndex = 67;
            this.lSnowAltitudeUnits.Text = "blocks";
            // 
            // lSnowTransition
            // 
            this.lSnowTransition.AutoSize = true;
            this.lSnowTransition.Location = new System.Drawing.Point(217, 21);
            this.lSnowTransition.Name = "lSnowTransition";
            this.lSnowTransition.Size = new System.Drawing.Size(35, 13);
            this.lSnowTransition.TabIndex = 68;
            this.lSnowTransition.Text = "Dither";
            // 
            // lSnowTransitionUnits
            // 
            this.lSnowTransitionUnits.AutoSize = true;
            this.lSnowTransitionUnits.Location = new System.Drawing.Point(318, 21);
            this.lSnowTransitionUnits.Name = "lSnowTransitionUnits";
            this.lSnowTransitionUnits.Size = new System.Drawing.Size(38, 13);
            this.lSnowTransitionUnits.TabIndex = 69;
            this.lSnowTransitionUnits.Text = "blocks";
            // 
            // gTrees
            // 
            this.gTrees.Controls.Add(this.lTreeHeightUnits);
            this.gTrees.Controls.Add(this.nTreeHeightVariation);
            this.gTrees.Controls.Add(this.lTreeHeightVariation);
            this.gTrees.Controls.Add(this.nTreeHeight);
            this.gTrees.Controls.Add(this.lTreeHeight);
            this.gTrees.Controls.Add(this.lTreeSpacingUnits);
            this.gTrees.Controls.Add(this.nTreeSpacingVariation);
            this.gTrees.Controls.Add(this.lTreeSpacingVariation);
            this.gTrees.Controls.Add(this.nTreeSpacing);
            this.gTrees.Controls.Add(this.lTreeSpacing);
            this.gTrees.Location = new System.Drawing.Point(3, 730);
            this.gTrees.Name = "gTrees";
            this.gTrees.Size = new System.Drawing.Size(362, 74);
            this.gTrees.TabIndex = 12;
            this.gTrees.TabStop = false;
            this.gTrees.Text = "Trees";
            this.gTrees.Visible = false;
            // 
            // lTreeSpacing
            // 
            this.lTreeSpacing.AutoSize = true;
            this.lTreeSpacing.Location = new System.Drawing.Point(6, 21);
            this.lTreeSpacing.Name = "lTreeSpacing";
            this.lTreeSpacing.Size = new System.Drawing.Size(69, 13);
            this.lTreeSpacing.TabIndex = 59;
            this.lTreeSpacing.Text = "Tree spacing";
            // 
            // nTreeSpacing
            // 
            this.nTreeSpacing.Location = new System.Drawing.Point(83, 19);
            this.nTreeSpacing.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nTreeSpacing.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nTreeSpacing.Name = "nTreeSpacing";
            this.nTreeSpacing.Size = new System.Drawing.Size(54, 20);
            this.nTreeSpacing.TabIndex = 0;
            this.nTreeSpacing.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // lTreeSpacingVariation
            // 
            this.lTreeSpacingVariation.AutoSize = true;
            this.lTreeSpacingVariation.Location = new System.Drawing.Point(143, 21);
            this.lTreeSpacingVariation.Name = "lTreeSpacingVariation";
            this.lTreeSpacingVariation.Size = new System.Drawing.Size(21, 13);
            this.lTreeSpacingVariation.TabIndex = 60;
            this.lTreeSpacingVariation.Text = "+/-";
            // 
            // nTreeSpacingVariation
            // 
            this.nTreeSpacingVariation.Location = new System.Drawing.Point(170, 19);
            this.nTreeSpacingVariation.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nTreeSpacingVariation.Name = "nTreeSpacingVariation";
            this.nTreeSpacingVariation.Size = new System.Drawing.Size(54, 20);
            this.nTreeSpacingVariation.TabIndex = 1;
            this.nTreeSpacingVariation.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lTreeSpacingUnits
            // 
            this.lTreeSpacingUnits.AutoSize = true;
            this.lTreeSpacingUnits.Location = new System.Drawing.Point(230, 21);
            this.lTreeSpacingUnits.Name = "lTreeSpacingUnits";
            this.lTreeSpacingUnits.Size = new System.Drawing.Size(38, 13);
            this.lTreeSpacingUnits.TabIndex = 62;
            this.lTreeSpacingUnits.Text = "blocks";
            // 
            // lTreeHeight
            // 
            this.lTreeHeight.AutoSize = true;
            this.lTreeHeight.Location = new System.Drawing.Point(14, 47);
            this.lTreeHeight.Name = "lTreeHeight";
            this.lTreeHeight.Size = new System.Drawing.Size(61, 13);
            this.lTreeHeight.TabIndex = 64;
            this.lTreeHeight.Text = "Tree height";
            // 
            // nTreeHeight
            // 
            this.nTreeHeight.Location = new System.Drawing.Point(83, 45);
            this.nTreeHeight.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nTreeHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nTreeHeight.Name = "nTreeHeight";
            this.nTreeHeight.Size = new System.Drawing.Size(54, 20);
            this.nTreeHeight.TabIndex = 2;
            this.nTreeHeight.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // lTreeHeightVariation
            // 
            this.lTreeHeightVariation.AutoSize = true;
            this.lTreeHeightVariation.Location = new System.Drawing.Point(143, 47);
            this.lTreeHeightVariation.Name = "lTreeHeightVariation";
            this.lTreeHeightVariation.Size = new System.Drawing.Size(21, 13);
            this.lTreeHeightVariation.TabIndex = 65;
            this.lTreeHeightVariation.Text = "+/-";
            // 
            // nTreeHeightVariation
            // 
            this.nTreeHeightVariation.Location = new System.Drawing.Point(170, 45);
            this.nTreeHeightVariation.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nTreeHeightVariation.Name = "nTreeHeightVariation";
            this.nTreeHeightVariation.Size = new System.Drawing.Size(54, 20);
            this.nTreeHeightVariation.TabIndex = 3;
            this.nTreeHeightVariation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lTreeHeightUnits
            // 
            this.lTreeHeightUnits.AutoSize = true;
            this.lTreeHeightUnits.Location = new System.Drawing.Point(230, 47);
            this.lTreeHeightUnits.Name = "lTreeHeightUnits";
            this.lTreeHeightUnits.Size = new System.Drawing.Size(38, 13);
            this.lTreeHeightUnits.TabIndex = 67;
            this.lTreeHeightUnits.Text = "blocks";
            // 
            // gCaves
            // 
            this.gCaves.Controls.Add(this.lCaveSizeDisplay);
            this.gCaves.Controls.Add(this.lCaveDensityDisplay);
            this.gCaves.Controls.Add(this.xCaveLava);
            this.gCaves.Controls.Add(this.xCaveWater);
            this.gCaves.Controls.Add(this.sCaveSize);
            this.gCaves.Controls.Add(this.lCaveSize);
            this.gCaves.Controls.Add(this.sCaveDensity);
            this.gCaves.Controls.Add(this.lCaveDensity);
            this.gCaves.Location = new System.Drawing.Point(3, 633);
            this.gCaves.Name = "gCaves";
            this.gCaves.Size = new System.Drawing.Size(362, 91);
            this.gCaves.TabIndex = 22;
            this.gCaves.TabStop = false;
            this.gCaves.Text = "Caves";
            this.gCaves.Visible = false;
            // 
            // lCaveDensity
            // 
            this.lCaveDensity.AutoSize = true;
            this.lCaveDensity.Location = new System.Drawing.Point(24, 23);
            this.lCaveDensity.Name = "lCaveDensity";
            this.lCaveDensity.Size = new System.Drawing.Size(68, 13);
            this.lCaveDensity.TabIndex = 60;
            this.lCaveDensity.Text = "Cave density";
            // 
            // sCaveDensity
            // 
            this.sCaveDensity.AutoSize = false;
            this.sCaveDensity.LargeChange = 25;
            this.sCaveDensity.Location = new System.Drawing.Point(98, 22);
            this.sCaveDensity.Maximum = 500;
            this.sCaveDensity.Minimum = 50;
            this.sCaveDensity.Name = "sCaveDensity";
            this.sCaveDensity.Size = new System.Drawing.Size(116, 27);
            this.sCaveDensity.TabIndex = 61;
            this.sCaveDensity.TickFrequency = 50;
            this.sCaveDensity.Value = 200;
            this.sCaveDensity.ValueChanged += new System.EventHandler(this.sCaveDensity_ValueChanged);
            // 
            // lCaveSize
            // 
            this.lCaveSize.AutoSize = true;
            this.lCaveSize.Location = new System.Drawing.Point(39, 57);
            this.lCaveSize.Name = "lCaveSize";
            this.lCaveSize.Size = new System.Drawing.Size(53, 13);
            this.lCaveSize.TabIndex = 62;
            this.lCaveSize.Text = "Cave size";
            // 
            // sCaveSize
            // 
            this.sCaveSize.AutoSize = false;
            this.sCaveSize.LargeChange = 25;
            this.sCaveSize.Location = new System.Drawing.Point(98, 55);
            this.sCaveSize.Maximum = 250;
            this.sCaveSize.Minimum = 50;
            this.sCaveSize.Name = "sCaveSize";
            this.sCaveSize.Size = new System.Drawing.Size(116, 27);
            this.sCaveSize.TabIndex = 63;
            this.sCaveSize.TickFrequency = 50;
            this.sCaveSize.Value = 100;
            this.sCaveSize.ValueChanged += new System.EventHandler(this.sCaveSize_ValueChanged);
            // 
            // xCaveWater
            // 
            this.xCaveWater.AutoSize = true;
            this.xCaveWater.Location = new System.Drawing.Point(260, 22);
            this.xCaveWater.Name = "xCaveWater";
            this.xCaveWater.Size = new System.Drawing.Size(96, 17);
            this.xCaveWater.TabIndex = 64;
            this.xCaveWater.Text = "Flooded caves";
            this.xCaveWater.UseVisualStyleBackColor = true;
            // 
            // xCaveLava
            // 
            this.xCaveLava.AutoSize = true;
            this.xCaveLava.Location = new System.Drawing.Point(260, 56);
            this.xCaveLava.Name = "xCaveLava";
            this.xCaveLava.Size = new System.Drawing.Size(82, 17);
            this.xCaveLava.TabIndex = 65;
            this.xCaveLava.Text = "Lava caves";
            this.xCaveLava.UseVisualStyleBackColor = true;
            // 
            // lCaveDensityDisplay
            // 
            this.lCaveDensityDisplay.AutoSize = true;
            this.lCaveDensityDisplay.Location = new System.Drawing.Point(213, 23);
            this.lCaveDensityDisplay.Name = "lCaveDensityDisplay";
            this.lCaveDensityDisplay.Size = new System.Drawing.Size(33, 13);
            this.lCaveDensityDisplay.TabIndex = 67;
            this.lCaveDensityDisplay.Text = "200%";
            // 
            // lCaveSizeDisplay
            // 
            this.lCaveSizeDisplay.AutoSize = true;
            this.lCaveSizeDisplay.Location = new System.Drawing.Point(213, 57);
            this.lCaveSizeDisplay.Name = "lCaveSizeDisplay";
            this.lCaveSizeDisplay.Size = new System.Drawing.Size(33, 13);
            this.lCaveSizeDisplay.TabIndex = 68;
            this.lCaveSizeDisplay.Text = "100%";
            // 
            // gHeightmapCreation
            // 
            this.gHeightmapCreation.Controls.Add(this.lBelowFunc);
            this.gHeightmapCreation.Controls.Add(this.lAboveFunc);
            this.gHeightmapCreation.Controls.Add(this.lBelowFuncUnits);
            this.gHeightmapCreation.Controls.Add(this.lAboveFuncUnits);
            this.gHeightmapCreation.Controls.Add(this.sAboveFunc);
            this.gHeightmapCreation.Controls.Add(this.sBelowFunc);
            this.gHeightmapCreation.Controls.Add(this.xDelayBias);
            this.gHeightmapCreation.Controls.Add(this.xInvert);
            this.gHeightmapCreation.Controls.Add(this.sDetailScale);
            this.gHeightmapCreation.Controls.Add(this.lDetailSizeDisplay);
            this.gHeightmapCreation.Controls.Add(this.label5);
            this.gHeightmapCreation.Controls.Add(this.sFeatureScale);
            this.gHeightmapCreation.Controls.Add(this.lRoughnessDisplay);
            this.gHeightmapCreation.Controls.Add(this.lFeatureSizeDisplay);
            this.gHeightmapCreation.Controls.Add(this.xMatchWaterCoverage);
            this.gHeightmapCreation.Controls.Add(this.sWaterCoverage);
            this.gHeightmapCreation.Controls.Add(this.xLayeredHeightmap);
            this.gHeightmapCreation.Controls.Add(this.xMarbledMode);
            this.gHeightmapCreation.Controls.Add(this.sRoughness);
            this.gHeightmapCreation.Controls.Add(this.lMatchWaterCoverageDisplay);
            this.gHeightmapCreation.Controls.Add(this.lRoughness);
            this.gHeightmapCreation.Controls.Add(this.lDetailSize);
            this.gHeightmapCreation.Location = new System.Drawing.Point(3, 401);
            this.gHeightmapCreation.Name = "gHeightmapCreation";
            this.gHeightmapCreation.Size = new System.Drawing.Size(362, 226);
            this.gHeightmapCreation.TabIndex = 11;
            this.gHeightmapCreation.TabStop = false;
            this.gHeightmapCreation.Text = "Heightmap Creation";
            this.gHeightmapCreation.Visible = false;
            // 
            // lDetailSize
            // 
            this.lDetailSize.AutoSize = true;
            this.lDetailSize.Location = new System.Drawing.Point(21, 22);
            this.lDetailSize.Name = "lDetailSize";
            this.lDetailSize.Size = new System.Drawing.Size(71, 13);
            this.lDetailSize.TabIndex = 23;
            this.lDetailSize.Text = "Feature scale";
            // 
            // lRoughness
            // 
            this.lRoughness.AutoSize = true;
            this.lRoughness.Location = new System.Drawing.Point(31, 87);
            this.lRoughness.Name = "lRoughness";
            this.lRoughness.Size = new System.Drawing.Size(61, 13);
            this.lRoughness.TabIndex = 25;
            this.lRoughness.Text = "Roughness";
            // 
            // lMatchWaterCoverageDisplay
            // 
            this.lMatchWaterCoverageDisplay.AutoSize = true;
            this.lMatchWaterCoverageDisplay.Location = new System.Drawing.Point(314, 129);
            this.lMatchWaterCoverageDisplay.Name = "lMatchWaterCoverageDisplay";
            this.lMatchWaterCoverageDisplay.Size = new System.Drawing.Size(27, 13);
            this.lMatchWaterCoverageDisplay.TabIndex = 33;
            this.lMatchWaterCoverageDisplay.Text = "50%";
            // 
            // sRoughness
            // 
            this.sRoughness.AutoSize = false;
            this.sRoughness.Location = new System.Drawing.Point(98, 85);
            this.sRoughness.Maximum = 80;
            this.sRoughness.Minimum = 20;
            this.sRoughness.Name = "sRoughness";
            this.sRoughness.Size = new System.Drawing.Size(116, 27);
            this.sRoughness.TabIndex = 4;
            this.sRoughness.TickFrequency = 10;
            this.sRoughness.Value = 50;
            this.sRoughness.ValueChanged += new System.EventHandler(this.sRoughness_ValueChanged);
            // 
            // xMarbledMode
            // 
            this.xMarbledMode.AutoSize = true;
            this.xMarbledMode.Location = new System.Drawing.Point(281, 18);
            this.xMarbledMode.Name = "xMarbledMode";
            this.xMarbledMode.Size = new System.Drawing.Size(64, 17);
            this.xMarbledMode.TabIndex = 2;
            this.xMarbledMode.Text = "Marbled";
            this.xMarbledMode.UseVisualStyleBackColor = true;
            // 
            // xLayeredHeightmap
            // 
            this.xLayeredHeightmap.AutoSize = true;
            this.xLayeredHeightmap.Location = new System.Drawing.Point(281, 41);
            this.xLayeredHeightmap.Name = "xLayeredHeightmap";
            this.xLayeredHeightmap.Size = new System.Drawing.Size(48, 17);
            this.xLayeredHeightmap.TabIndex = 3;
            this.xLayeredHeightmap.Text = "Cliffs";
            this.xLayeredHeightmap.UseVisualStyleBackColor = true;
            // 
            // sWaterCoverage
            // 
            this.sWaterCoverage.AutoSize = false;
            this.sWaterCoverage.Enabled = false;
            this.sWaterCoverage.Location = new System.Drawing.Point(145, 124);
            this.sWaterCoverage.Maximum = 100;
            this.sWaterCoverage.Name = "sWaterCoverage";
            this.sWaterCoverage.Size = new System.Drawing.Size(163, 27);
            this.sWaterCoverage.TabIndex = 6;
            this.sWaterCoverage.TickFrequency = 10;
            this.sWaterCoverage.Value = 50;
            this.sWaterCoverage.ValueChanged += new System.EventHandler(this.sWaterCoverage_ValueChanged);
            // 
            // xMatchWaterCoverage
            // 
            this.xMatchWaterCoverage.AutoSize = true;
            this.xMatchWaterCoverage.Location = new System.Drawing.Point(6, 125);
            this.xMatchWaterCoverage.Name = "xMatchWaterCoverage";
            this.xMatchWaterCoverage.Size = new System.Drawing.Size(133, 17);
            this.xMatchWaterCoverage.TabIndex = 5;
            this.xMatchWaterCoverage.Text = "Match water coverage";
            this.xMatchWaterCoverage.UseVisualStyleBackColor = true;
            this.xMatchWaterCoverage.CheckedChanged += new System.EventHandler(this.xMatchWaterCoverage_CheckedChanged);
            // 
            // lFeatureSizeDisplay
            // 
            this.lFeatureSizeDisplay.AutoSize = true;
            this.lFeatureSizeDisplay.Location = new System.Drawing.Point(215, 22);
            this.lFeatureSizeDisplay.Name = "lFeatureSizeDisplay";
            this.lFeatureSizeDisplay.Size = new System.Drawing.Size(25, 13);
            this.lFeatureSizeDisplay.TabIndex = 35;
            this.lFeatureSizeDisplay.Text = "1×1";
            // 
            // lRoughnessDisplay
            // 
            this.lRoughnessDisplay.AutoSize = true;
            this.lRoughnessDisplay.Location = new System.Drawing.Point(216, 87);
            this.lRoughnessDisplay.Name = "lRoughnessDisplay";
            this.lRoughnessDisplay.Size = new System.Drawing.Size(27, 13);
            this.lRoughnessDisplay.TabIndex = 34;
            this.lRoughnessDisplay.Text = "50%";
            // 
            // sFeatureScale
            // 
            this.sFeatureScale.AutoSize = false;
            this.sFeatureScale.Location = new System.Drawing.Point(98, 19);
            this.sFeatureScale.Maximum = 7;
            this.sFeatureScale.Minimum = -1;
            this.sFeatureScale.Name = "sFeatureScale";
            this.sFeatureScale.Size = new System.Drawing.Size(116, 27);
            this.sFeatureScale.TabIndex = 0;
            this.sFeatureScale.Value = 2;
            this.sFeatureScale.ValueChanged += new System.EventHandler(this.sFeatureSize_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Detail scale";
            // 
            // lDetailSizeDisplay
            // 
            this.lDetailSizeDisplay.AutoSize = true;
            this.lDetailSizeDisplay.Location = new System.Drawing.Point(216, 55);
            this.lDetailSizeDisplay.Name = "lDetailSizeDisplay";
            this.lDetailSizeDisplay.Size = new System.Drawing.Size(25, 13);
            this.lDetailSizeDisplay.TabIndex = 38;
            this.lDetailSizeDisplay.Text = "1×1";
            // 
            // sDetailScale
            // 
            this.sDetailScale.AutoSize = false;
            this.sDetailScale.Location = new System.Drawing.Point(98, 52);
            this.sDetailScale.Maximum = 7;
            this.sDetailScale.Minimum = -1;
            this.sDetailScale.Name = "sDetailScale";
            this.sDetailScale.Size = new System.Drawing.Size(116, 27);
            this.sDetailScale.TabIndex = 1;
            this.sDetailScale.Value = 7;
            this.sDetailScale.ValueChanged += new System.EventHandler(this.sDetailSize_ValueChanged);
            // 
            // xInvert
            // 
            this.xInvert.AutoSize = true;
            this.xInvert.Location = new System.Drawing.Point(281, 64);
            this.xInvert.Name = "xInvert";
            this.xInvert.Size = new System.Drawing.Size(53, 17);
            this.xInvert.TabIndex = 39;
            this.xInvert.Text = "Invert";
            this.xInvert.UseVisualStyleBackColor = true;
            // 
            // xDelayBias
            // 
            this.xDelayBias.AutoSize = true;
            this.xDelayBias.Location = new System.Drawing.Point(281, 87);
            this.xDelayBias.Name = "xDelayBias";
            this.xDelayBias.Size = new System.Drawing.Size(75, 17);
            this.xDelayBias.TabIndex = 40;
            this.xDelayBias.Text = "Delay bias";
            this.xDelayBias.UseVisualStyleBackColor = true;
            // 
            // sBelowFunc
            // 
            this.sBelowFunc.AutoSize = false;
            this.sBelowFunc.LargeChange = 50;
            this.sBelowFunc.Location = new System.Drawing.Point(145, 190);
            this.sBelowFunc.Maximum = 600;
            this.sBelowFunc.Name = "sBelowFunc";
            this.sBelowFunc.Size = new System.Drawing.Size(163, 27);
            this.sBelowFunc.SmallChange = 20;
            this.sBelowFunc.TabIndex = 42;
            this.sBelowFunc.TickFrequency = 20;
            this.sBelowFunc.Value = 300;
            this.sBelowFunc.ValueChanged += new System.EventHandler(this.sBelowFunc_ValueChanged);
            // 
            // sAboveFunc
            // 
            this.sAboveFunc.AutoSize = false;
            this.sAboveFunc.LargeChange = 50;
            this.sAboveFunc.Location = new System.Drawing.Point(145, 157);
            this.sAboveFunc.Maximum = 600;
            this.sAboveFunc.Name = "sAboveFunc";
            this.sAboveFunc.Size = new System.Drawing.Size(163, 27);
            this.sAboveFunc.SmallChange = 20;
            this.sAboveFunc.TabIndex = 43;
            this.sAboveFunc.TickFrequency = 20;
            this.sAboveFunc.Value = 300;
            this.sAboveFunc.ValueChanged += new System.EventHandler(this.sAboveFunc_ValueChanged);
            // 
            // lAboveFuncUnits
            // 
            this.lAboveFuncUnits.AutoSize = true;
            this.lAboveFuncUnits.Location = new System.Drawing.Point(314, 159);
            this.lAboveFuncUnits.Name = "lAboveFuncUnits";
            this.lAboveFuncUnits.Size = new System.Drawing.Size(42, 13);
            this.lAboveFuncUnits.TabIndex = 44;
            this.lAboveFuncUnits.Text = "100.0%";
            // 
            // lBelowFuncUnits
            // 
            this.lBelowFuncUnits.AutoSize = true;
            this.lBelowFuncUnits.Location = new System.Drawing.Point(314, 193);
            this.lBelowFuncUnits.Name = "lBelowFuncUnits";
            this.lBelowFuncUnits.Size = new System.Drawing.Size(42, 13);
            this.lBelowFuncUnits.TabIndex = 45;
            this.lBelowFuncUnits.Text = "100.0%";
            // 
            // lAboveFunc
            // 
            this.lAboveFunc.AutoSize = true;
            this.lAboveFunc.Location = new System.Drawing.Point(57, 159);
            this.lAboveFunc.Name = "lAboveFunc";
            this.lAboveFunc.Size = new System.Drawing.Size(82, 13);
            this.lAboveFunc.TabIndex = 46;
            this.lAboveFunc.Text = "Land steepness";
            // 
            // lBelowFunc
            // 
            this.lBelowFunc.AutoSize = true;
            this.lBelowFunc.Location = new System.Drawing.Point(26, 193);
            this.lBelowFunc.Name = "lBelowFunc";
            this.lBelowFunc.Size = new System.Drawing.Size(113, 13);
            this.lBelowFunc.TabIndex = 47;
            this.lBelowFunc.Text = "Underwater steepness";
            // 
            // gTerrainFeatures
            // 
            this.gTerrainFeatures.Controls.Add(this.lLoweredCorners);
            this.gTerrainFeatures.Controls.Add(this.nLoweredCorners);
            this.gTerrainFeatures.Controls.Add(this.cMidpoint);
            this.gTerrainFeatures.Controls.Add(this.lMidpoint);
            this.gTerrainFeatures.Controls.Add(this.lRaisedCorners);
            this.gTerrainFeatures.Controls.Add(this.nRaisedCorners);
            this.gTerrainFeatures.Controls.Add(this.lBiasDisplay);
            this.gTerrainFeatures.Controls.Add(this.lBias);
            this.gTerrainFeatures.Controls.Add(this.sBias);
            this.gTerrainFeatures.Location = new System.Drawing.Point(3, 311);
            this.gTerrainFeatures.Name = "gTerrainFeatures";
            this.gTerrainFeatures.Size = new System.Drawing.Size(362, 84);
            this.gTerrainFeatures.TabIndex = 10;
            this.gTerrainFeatures.TabStop = false;
            this.gTerrainFeatures.Text = "Feature Bias";
            this.gTerrainFeatures.Visible = false;
            // 
            // sBias
            // 
            this.sBias.AutoSize = false;
            this.sBias.LargeChange = 10;
            this.sBias.Location = new System.Drawing.Point(59, 19);
            this.sBias.Maximum = 100;
            this.sBias.Name = "sBias";
            this.sBias.Size = new System.Drawing.Size(116, 27);
            this.sBias.TabIndex = 0;
            this.sBias.TickFrequency = 20;
            this.sBias.ValueChanged += new System.EventHandler(this.sBias_ValueChanged);
            // 
            // lBias
            // 
            this.lBias.AutoSize = true;
            this.lBias.Location = new System.Drawing.Point(26, 21);
            this.lBias.Name = "lBias";
            this.lBias.Size = new System.Drawing.Size(27, 13);
            this.lBias.TabIndex = 50;
            this.lBias.Text = "Bias";
            // 
            // lBiasDisplay
            // 
            this.lBiasDisplay.AutoSize = true;
            this.lBiasDisplay.Location = new System.Drawing.Point(178, 21);
            this.lBiasDisplay.Name = "lBiasDisplay";
            this.lBiasDisplay.Size = new System.Drawing.Size(21, 13);
            this.lBiasDisplay.TabIndex = 57;
            this.lBiasDisplay.Text = "0%";
            // 
            // nRaisedCorners
            // 
            this.nRaisedCorners.Enabled = false;
            this.nRaisedCorners.Location = new System.Drawing.Point(299, 19);
            this.nRaisedCorners.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nRaisedCorners.Name = "nRaisedCorners";
            this.nRaisedCorners.Size = new System.Drawing.Size(54, 20);
            this.nRaisedCorners.TabIndex = 2;
            this.nRaisedCorners.ValueChanged += new System.EventHandler(this.nRaisedCorners_ValueChanged);
            // 
            // lRaisedCorners
            // 
            this.lRaisedCorners.AutoSize = true;
            this.lRaisedCorners.Location = new System.Drawing.Point(215, 21);
            this.lRaisedCorners.Name = "lRaisedCorners";
            this.lRaisedCorners.Size = new System.Drawing.Size(78, 13);
            this.lRaisedCorners.TabIndex = 61;
            this.lRaisedCorners.Text = "Raised corners";
            // 
            // lMidpoint
            // 
            this.lMidpoint.AutoSize = true;
            this.lMidpoint.Location = new System.Drawing.Point(6, 57);
            this.lMidpoint.Name = "lMidpoint";
            this.lMidpoint.Size = new System.Drawing.Size(47, 13);
            this.lMidpoint.TabIndex = 64;
            this.lMidpoint.Text = "Midpoint";
            // 
            // cMidpoint
            // 
            this.cMidpoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cMidpoint.Enabled = false;
            this.cMidpoint.FormattingEnabled = true;
            this.cMidpoint.Items.AddRange(new object[] {
            "Lowered",
            "Neutral",
            "Raised"});
            this.cMidpoint.Location = new System.Drawing.Point(66, 54);
            this.cMidpoint.Name = "cMidpoint";
            this.cMidpoint.Size = new System.Drawing.Size(101, 21);
            this.cMidpoint.TabIndex = 1;
            // 
            // nLoweredCorners
            // 
            this.nLoweredCorners.Enabled = false;
            this.nLoweredCorners.Location = new System.Drawing.Point(299, 55);
            this.nLoweredCorners.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nLoweredCorners.Name = "nLoweredCorners";
            this.nLoweredCorners.Size = new System.Drawing.Size(54, 20);
            this.nLoweredCorners.TabIndex = 65;
            this.nLoweredCorners.ValueChanged += new System.EventHandler(this.nLoweredCorners_ValueChanged);
            // 
            // lLoweredCorners
            // 
            this.lLoweredCorners.AutoSize = true;
            this.lLoweredCorners.Location = new System.Drawing.Point(207, 57);
            this.lLoweredCorners.Name = "lLoweredCorners";
            this.lLoweredCorners.Size = new System.Drawing.Size(86, 13);
            this.lLoweredCorners.TabIndex = 66;
            this.lLoweredCorners.Text = "Lowered corners";
            // 
            // gMapSize
            // 
            this.gMapSize.Controls.Add(this.nMaxDepthVariation);
            this.gMapSize.Controls.Add(this.nMaxHeightVariation);
            this.gMapSize.Controls.Add(this.lMaxHeightVariationUnits);
            this.gMapSize.Controls.Add(this.lMaxDepthVariationUnits);
            this.gMapSize.Controls.Add(this.xWaterLevel);
            this.gMapSize.Controls.Add(this.nWaterLevel);
            this.gMapSize.Controls.Add(this.lWaterLevelLabel);
            this.gMapSize.Controls.Add(this.nMaxDepth);
            this.gMapSize.Controls.Add(this.nMaxHeight);
            this.gMapSize.Controls.Add(this.nWidthX);
            this.gMapSize.Controls.Add(this.lMaxHeight);
            this.gMapSize.Controls.Add(this.lMaxHeightUnits);
            this.gMapSize.Controls.Add(this.lMaxDepth);
            this.gMapSize.Controls.Add(this.lMaxDepthUnits);
            this.gMapSize.Controls.Add(this.lX1);
            this.gMapSize.Controls.Add(this.lDim);
            this.gMapSize.Controls.Add(this.lX2);
            this.gMapSize.Controls.Add(this.nHeight);
            this.gMapSize.Controls.Add(this.nWidthY);
            this.gMapSize.Location = new System.Drawing.Point(3, 158);
            this.gMapSize.Name = "gMapSize";
            this.gMapSize.Size = new System.Drawing.Size(362, 147);
            this.gMapSize.TabIndex = 9;
            this.gMapSize.TabStop = false;
            this.gMapSize.Text = "Dimensions";
            // 
            // nWidthY
            // 
            this.nWidthY.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nWidthY.Location = new System.Drawing.Point(159, 19);
            this.nWidthY.Maximum = new decimal(new int[] {
            2032,
            0,
            0,
            0});
            this.nWidthY.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nWidthY.Name = "nWidthY";
            this.nWidthY.Size = new System.Drawing.Size(54, 20);
            this.nWidthY.TabIndex = 1;
            this.nWidthY.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nWidthY.ValueChanged += new System.EventHandler(this.MapDimensionChanged);
            // 
            // nHeight
            // 
            this.nHeight.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nHeight.Location = new System.Drawing.Point(238, 19);
            this.nHeight.Maximum = new decimal(new int[] {
            2032,
            0,
            0,
            0});
            this.nHeight.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nHeight.Name = "nHeight";
            this.nHeight.Size = new System.Drawing.Size(54, 20);
            this.nHeight.TabIndex = 2;
            this.nHeight.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nHeight.ValueChanged += new System.EventHandler(this.nHeight_ValueChanged);
            // 
            // lX2
            // 
            this.lX2.AutoSize = true;
            this.lX2.Location = new System.Drawing.Point(219, 21);
            this.lX2.Name = "lX2";
            this.lX2.Size = new System.Drawing.Size(13, 13);
            this.lX2.TabIndex = 6;
            this.lX2.Text = "×";
            // 
            // lDim
            // 
            this.lDim.AutoSize = true;
            this.lDim.Location = new System.Drawing.Point(13, 21);
            this.lDim.Name = "lDim";
            this.lDim.Size = new System.Drawing.Size(61, 13);
            this.lDim.TabIndex = 3;
            this.lDim.Text = "Dimensions";
            // 
            // lX1
            // 
            this.lX1.AutoSize = true;
            this.lX1.Location = new System.Drawing.Point(140, 21);
            this.lX1.Name = "lX1";
            this.lX1.Size = new System.Drawing.Size(13, 13);
            this.lX1.TabIndex = 5;
            this.lX1.Text = "×";
            // 
            // lMaxDepthUnits
            // 
            this.lMaxDepthUnits.AutoSize = true;
            this.lMaxDepthUnits.Location = new System.Drawing.Point(140, 80);
            this.lMaxDepthUnits.Name = "lMaxDepthUnits";
            this.lMaxDepthUnits.Size = new System.Drawing.Size(21, 13);
            this.lMaxDepthUnits.TabIndex = 44;
            this.lMaxDepthUnits.Text = "+/-";
            // 
            // lMaxDepth
            // 
            this.lMaxDepth.AutoSize = true;
            this.lMaxDepth.Location = new System.Drawing.Point(17, 80);
            this.lMaxDepth.Name = "lMaxDepth";
            this.lMaxDepth.Size = new System.Drawing.Size(57, 13);
            this.lMaxDepth.TabIndex = 42;
            this.lMaxDepth.Text = "Max depth";
            // 
            // lMaxHeightUnits
            // 
            this.lMaxHeightUnits.AutoSize = true;
            this.lMaxHeightUnits.Location = new System.Drawing.Point(140, 54);
            this.lMaxHeightUnits.Name = "lMaxHeightUnits";
            this.lMaxHeightUnits.Size = new System.Drawing.Size(21, 13);
            this.lMaxHeightUnits.TabIndex = 41;
            this.lMaxHeightUnits.Text = "+/-";
            // 
            // lMaxHeight
            // 
            this.lMaxHeight.AutoSize = true;
            this.lMaxHeight.Location = new System.Drawing.Point(10, 54);
            this.lMaxHeight.Name = "lMaxHeight";
            this.lMaxHeight.Size = new System.Drawing.Size(64, 13);
            this.lMaxHeight.TabIndex = 40;
            this.lMaxHeight.Text = "Peak height";
            // 
            // nWidthX
            // 
            this.nWidthX.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nWidthX.Location = new System.Drawing.Point(80, 19);
            this.nWidthX.Maximum = new decimal(new int[] {
            2032,
            0,
            0,
            0});
            this.nWidthX.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nWidthX.Name = "nWidthX";
            this.nWidthX.Size = new System.Drawing.Size(54, 20);
            this.nWidthX.TabIndex = 0;
            this.nWidthX.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nWidthX.ValueChanged += new System.EventHandler(this.MapDimensionChanged);
            // 
            // nMaxHeight
            // 
            this.nMaxHeight.Location = new System.Drawing.Point(80, 52);
            this.nMaxHeight.Maximum = new decimal(new int[] {
            2032,
            0,
            0,
            0});
            this.nMaxHeight.Name = "nMaxHeight";
            this.nMaxHeight.Size = new System.Drawing.Size(54, 20);
            this.nMaxHeight.TabIndex = 3;
            this.nMaxHeight.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // nMaxDepth
            // 
            this.nMaxDepth.Location = new System.Drawing.Point(80, 78);
            this.nMaxDepth.Maximum = new decimal(new int[] {
            2032,
            0,
            0,
            0});
            this.nMaxDepth.Name = "nMaxDepth";
            this.nMaxDepth.Size = new System.Drawing.Size(54, 20);
            this.nMaxDepth.TabIndex = 4;
            this.nMaxDepth.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // lWaterLevelLabel
            // 
            this.lWaterLevelLabel.AutoSize = true;
            this.lWaterLevelLabel.Location = new System.Drawing.Point(212, 123);
            this.lWaterLevelLabel.Name = "lWaterLevelLabel";
            this.lWaterLevelLabel.Size = new System.Drawing.Size(38, 13);
            this.lWaterLevelLabel.TabIndex = 47;
            this.lWaterLevelLabel.Text = "blocks";
            // 
            // nWaterLevel
            // 
            this.nWaterLevel.Location = new System.Drawing.Point(152, 121);
            this.nWaterLevel.Name = "nWaterLevel";
            this.nWaterLevel.Size = new System.Drawing.Size(54, 20);
            this.nWaterLevel.TabIndex = 45;
            this.nWaterLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // xWaterLevel
            // 
            this.xWaterLevel.AutoSize = true;
            this.xWaterLevel.Location = new System.Drawing.Point(31, 122);
            this.xWaterLevel.Name = "xWaterLevel";
            this.xWaterLevel.Size = new System.Drawing.Size(115, 17);
            this.xWaterLevel.TabIndex = 48;
            this.xWaterLevel.Text = "Custom water level";
            this.xWaterLevel.UseVisualStyleBackColor = true;
            this.xWaterLevel.CheckedChanged += new System.EventHandler(this.xWaterLevel_CheckedChanged);
            // 
            // lMaxDepthVariationUnits
            // 
            this.lMaxDepthVariationUnits.AutoSize = true;
            this.lMaxDepthVariationUnits.Location = new System.Drawing.Point(227, 80);
            this.lMaxDepthVariationUnits.Name = "lMaxDepthVariationUnits";
            this.lMaxDepthVariationUnits.Size = new System.Drawing.Size(38, 13);
            this.lMaxDepthVariationUnits.TabIndex = 52;
            this.lMaxDepthVariationUnits.Text = "blocks";
            // 
            // lMaxHeightVariationUnits
            // 
            this.lMaxHeightVariationUnits.AutoSize = true;
            this.lMaxHeightVariationUnits.Location = new System.Drawing.Point(227, 54);
            this.lMaxHeightVariationUnits.Name = "lMaxHeightVariationUnits";
            this.lMaxHeightVariationUnits.Size = new System.Drawing.Size(38, 13);
            this.lMaxHeightVariationUnits.TabIndex = 51;
            this.lMaxHeightVariationUnits.Text = "blocks";
            // 
            // nMaxHeightVariation
            // 
            this.nMaxHeightVariation.Location = new System.Drawing.Point(167, 52);
            this.nMaxHeightVariation.Maximum = new decimal(new int[] {
            2032,
            0,
            0,
            0});
            this.nMaxHeightVariation.Name = "nMaxHeightVariation";
            this.nMaxHeightVariation.Size = new System.Drawing.Size(54, 20);
            this.nMaxHeightVariation.TabIndex = 49;
            this.nMaxHeightVariation.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nMaxDepthVariation
            // 
            this.nMaxDepthVariation.Location = new System.Drawing.Point(167, 78);
            this.nMaxDepthVariation.Maximum = new decimal(new int[] {
            2032,
            0,
            0,
            0});
            this.nMaxDepthVariation.Name = "nMaxDepthVariation";
            this.nMaxDepthVariation.Size = new System.Drawing.Size(54, 20);
            this.nMaxDepthVariation.TabIndex = 50;
            // 
            // gTemplates
            // 
            this.gTemplates.Controls.Add(this.cTemplates);
            this.gTemplates.Controls.Add(this.lUseTemplate);
            this.gTemplates.Controls.Add(this.bBrowseTemplate);
            this.gTemplates.Controls.Add(this.bSaveTemplate);
            this.gTemplates.Location = new System.Drawing.Point(3, 100);
            this.gTemplates.Name = "gTemplates";
            this.gTemplates.Size = new System.Drawing.Size(362, 52);
            this.gTemplates.TabIndex = 21;
            this.gTemplates.TabStop = false;
            this.gTemplates.Text = "Templates";
            // 
            // bSaveTemplate
            // 
            this.bSaveTemplate.Location = new System.Drawing.Point(292, 19);
            this.bSaveTemplate.Name = "bSaveTemplate";
            this.bSaveTemplate.Size = new System.Drawing.Size(64, 23);
            this.bSaveTemplate.TabIndex = 0;
            this.bSaveTemplate.Text = "Save";
            this.bSaveTemplate.UseVisualStyleBackColor = true;
            this.bSaveTemplate.Click += new System.EventHandler(this.bSaveTemplate_Click);
            // 
            // bBrowseTemplate
            // 
            this.bBrowseTemplate.Location = new System.Drawing.Point(222, 19);
            this.bBrowseTemplate.Name = "bBrowseTemplate";
            this.bBrowseTemplate.Size = new System.Drawing.Size(64, 23);
            this.bBrowseTemplate.TabIndex = 1;
            this.bBrowseTemplate.Text = "Browse";
            this.bBrowseTemplate.UseVisualStyleBackColor = true;
            this.bBrowseTemplate.Click += new System.EventHandler(this.bBrowseTemplate_Click);
            // 
            // lUseTemplate
            // 
            this.lUseTemplate.AutoSize = true;
            this.lUseTemplate.Location = new System.Drawing.Point(23, 24);
            this.lUseTemplate.Name = "lUseTemplate";
            this.lUseTemplate.Size = new System.Drawing.Size(69, 13);
            this.lUseTemplate.TabIndex = 3;
            this.lUseTemplate.Text = "Use template";
            // 
            // cTemplates
            // 
            this.cTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cTemplates.FormattingEnabled = true;
            this.cTemplates.Location = new System.Drawing.Point(98, 21);
            this.cTemplates.Name = "cTemplates";
            this.cTemplates.Size = new System.Drawing.Size(116, 21);
            this.cTemplates.TabIndex = 4;
            this.cTemplates.SelectedIndexChanged += new System.EventHandler(this.cTemplates_SelectedIndexChanged);
            // 
            // gGenOptions
            // 
            this.gGenOptions.Controls.Add(this.xAddCliffs);
            this.gGenOptions.Controls.Add(this.xAddRuins);
            this.gGenOptions.Controls.Add(this.xOre);
            this.gGenOptions.Controls.Add(this.xAddBeaches);
            this.gGenOptions.Controls.Add(this.xAddTrees);
            this.gGenOptions.Controls.Add(this.xAddSnow);
            this.gGenOptions.Controls.Add(this.xFloodBarrier);
            this.gGenOptions.Controls.Add(this.xWater);
            this.gGenOptions.Controls.Add(this.xCaves);
            this.gGenOptions.Location = new System.Drawing.Point(3, 3);
            this.gGenOptions.Name = "gGenOptions";
            this.gGenOptions.Size = new System.Drawing.Size(362, 91);
            this.gGenOptions.TabIndex = 22;
            this.gGenOptions.TabStop = false;
            this.gGenOptions.Text = "Optional Modules";
            // 
            // xCaves
            // 
            this.xCaves.AutoSize = true;
            this.xCaves.Location = new System.Drawing.Point(13, 65);
            this.xCaves.Name = "xCaves";
            this.xCaves.Size = new System.Drawing.Size(56, 17);
            this.xCaves.TabIndex = 23;
            this.xCaves.Text = "Caves";
            this.xCaves.UseVisualStyleBackColor = true;
            this.xCaves.CheckedChanged += new System.EventHandler(this.xCaves_CheckedChanged);
            // 
            // xWater
            // 
            this.xWater.AutoSize = true;
            this.xWater.Checked = true;
            this.xWater.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xWater.Location = new System.Drawing.Point(13, 42);
            this.xWater.Name = "xWater";
            this.xWater.Size = new System.Drawing.Size(55, 17);
            this.xWater.TabIndex = 20;
            this.xWater.Text = "Water";
            this.xWater.UseVisualStyleBackColor = true;
            this.xWater.CheckedChanged += new System.EventHandler(this.xWater_CheckedChanged);
            // 
            // xFloodBarrier
            // 
            this.xFloodBarrier.AutoSize = true;
            this.xFloodBarrier.Location = new System.Drawing.Point(254, 65);
            this.xFloodBarrier.Name = "xFloodBarrier";
            this.xFloodBarrier.Size = new System.Drawing.Size(84, 17);
            this.xFloodBarrier.TabIndex = 4;
            this.xFloodBarrier.Text = "Flood barrier";
            this.xFloodBarrier.UseVisualStyleBackColor = true;
            this.xFloodBarrier.CheckedChanged += new System.EventHandler(this.xFloodBarrier_CheckedChanged);
            // 
            // xAddSnow
            // 
            this.xAddSnow.AutoSize = true;
            this.xAddSnow.Location = new System.Drawing.Point(110, 42);
            this.xAddSnow.Name = "xAddSnow";
            this.xAddSnow.Size = new System.Drawing.Size(109, 17);
            this.xAddSnow.TabIndex = 24;
            this.xAddSnow.Text = "Snowy mountains";
            this.xAddSnow.UseVisualStyleBackColor = true;
            this.xAddSnow.CheckedChanged += new System.EventHandler(this.xAddSnow_CheckedChanged);
            // 
            // xAddTrees
            // 
            this.xAddTrees.AutoSize = true;
            this.xAddTrees.Checked = true;
            this.xAddTrees.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xAddTrees.Location = new System.Drawing.Point(13, 19);
            this.xAddTrees.Name = "xAddTrees";
            this.xAddTrees.Size = new System.Drawing.Size(53, 17);
            this.xAddTrees.TabIndex = 5;
            this.xAddTrees.Text = "Trees";
            this.xAddTrees.UseVisualStyleBackColor = true;
            this.xAddTrees.CheckedChanged += new System.EventHandler(this.xAddTrees_CheckedChanged);
            // 
            // xAddBeaches
            // 
            this.xAddBeaches.AutoSize = true;
            this.xAddBeaches.Location = new System.Drawing.Point(110, 19);
            this.xAddBeaches.Name = "xAddBeaches";
            this.xAddBeaches.Size = new System.Drawing.Size(68, 17);
            this.xAddBeaches.TabIndex = 58;
            this.xAddBeaches.Text = "Beaches";
            this.xAddBeaches.UseVisualStyleBackColor = true;
            this.xAddBeaches.CheckedChanged += new System.EventHandler(this.xAddBeaches_CheckedChanged);
            // 
            // xOre
            // 
            this.xOre.AutoSize = true;
            this.xOre.Location = new System.Drawing.Point(110, 65);
            this.xOre.Name = "xOre";
            this.xOre.Size = new System.Drawing.Size(71, 17);
            this.xOre.TabIndex = 67;
            this.xOre.Text = "Ore veins";
            this.xOre.UseVisualStyleBackColor = true;
            // 
            // xAddRuins
            // 
            this.xAddRuins.AutoSize = true;
            this.xAddRuins.Enabled = false;
            this.xAddRuins.Location = new System.Drawing.Point(254, 19);
            this.xAddRuins.Name = "xAddRuins";
            this.xAddRuins.Size = new System.Drawing.Size(53, 17);
            this.xAddRuins.TabIndex = 68;
            this.xAddRuins.Text = "Ruins";
            this.xAddRuins.UseVisualStyleBackColor = true;
            // 
            // xAddCliffs
            // 
            this.xAddCliffs.AutoSize = true;
            this.xAddCliffs.Location = new System.Drawing.Point(254, 42);
            this.xAddCliffs.Name = "xAddCliffs";
            this.xAddCliffs.Size = new System.Drawing.Size(48, 17);
            this.xAddCliffs.TabIndex = 69;
            this.xAddCliffs.Text = "Cliffs";
            this.xAddCliffs.UseVisualStyleBackColor = true;
            this.xAddCliffs.CheckedChanged += new System.EventHandler(this.xAddCliffs_CheckedChanged);
            // 
            // tabHeightmap
            // 
            this.tabHeightmap.Controls.Add(this.lHeightmapComingSoon);
            this.tabHeightmap.Location = new System.Drawing.Point(4, 22);
            this.tabHeightmap.Name = "tabHeightmap";
            this.tabHeightmap.Padding = new System.Windows.Forms.Padding(3);
            this.tabHeightmap.Size = new System.Drawing.Size(391, 424);
            this.tabHeightmap.TabIndex = 4;
            this.tabHeightmap.Text = "Heightmap";
            this.tabHeightmap.UseVisualStyleBackColor = true;
            // 
            // lHeightmapComingSoon
            // 
            this.lHeightmapComingSoon.AutoSize = true;
            this.lHeightmapComingSoon.Location = new System.Drawing.Point(157, 14);
            this.lHeightmapComingSoon.Name = "lHeightmapComingSoon";
            this.lHeightmapComingSoon.Size = new System.Drawing.Size(68, 13);
            this.lHeightmapComingSoon.TabIndex = 0;
            this.lHeightmapComingSoon.Text = "Coming soon";
            // 
            // tabFlatgrass
            // 
            this.tabFlatgrass.Controls.Add(this.bFlatgrassGenerate);
            this.tabFlatgrass.Controls.Add(this.nFlatgrassDimX);
            this.tabFlatgrass.Controls.Add(this.lFlatgrassX1);
            this.tabFlatgrass.Controls.Add(this.lFlatgrassDimensions);
            this.tabFlatgrass.Controls.Add(this.lFlatgrassX2);
            this.tabFlatgrass.Controls.Add(this.nFlatgrassDimH);
            this.tabFlatgrass.Controls.Add(this.nFlatgrassDimY);
            this.tabFlatgrass.Location = new System.Drawing.Point(4, 22);
            this.tabFlatgrass.Name = "tabFlatgrass";
            this.tabFlatgrass.Padding = new System.Windows.Forms.Padding(3);
            this.tabFlatgrass.Size = new System.Drawing.Size(391, 424);
            this.tabFlatgrass.TabIndex = 3;
            this.tabFlatgrass.Text = "Flatgrass";
            this.tabFlatgrass.UseVisualStyleBackColor = true;
            // 
            // nFlatgrassDimY
            // 
            this.nFlatgrassDimY.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nFlatgrassDimY.Location = new System.Drawing.Point(232, 23);
            this.nFlatgrassDimY.Maximum = new decimal(new int[] {
            2032,
            0,
            0,
            0});
            this.nFlatgrassDimY.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nFlatgrassDimY.Name = "nFlatgrassDimY";
            this.nFlatgrassDimY.Size = new System.Drawing.Size(54, 20);
            this.nFlatgrassDimY.TabIndex = 2;
            this.nFlatgrassDimY.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // nFlatgrassDimH
            // 
            this.nFlatgrassDimH.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nFlatgrassDimH.Location = new System.Drawing.Point(311, 23);
            this.nFlatgrassDimH.Maximum = new decimal(new int[] {
            2032,
            0,
            0,
            0});
            this.nFlatgrassDimH.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nFlatgrassDimH.Name = "nFlatgrassDimH";
            this.nFlatgrassDimH.Size = new System.Drawing.Size(54, 20);
            this.nFlatgrassDimH.TabIndex = 3;
            this.nFlatgrassDimH.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // lFlatgrassX2
            // 
            this.lFlatgrassX2.AutoSize = true;
            this.lFlatgrassX2.Location = new System.Drawing.Point(292, 25);
            this.lFlatgrassX2.Name = "lFlatgrassX2";
            this.lFlatgrassX2.Size = new System.Drawing.Size(13, 13);
            this.lFlatgrassX2.TabIndex = 12;
            this.lFlatgrassX2.Text = "×";
            // 
            // lFlatgrassDimensions
            // 
            this.lFlatgrassDimensions.AutoSize = true;
            this.lFlatgrassDimensions.Location = new System.Drawing.Point(86, 25);
            this.lFlatgrassDimensions.Name = "lFlatgrassDimensions";
            this.lFlatgrassDimensions.Size = new System.Drawing.Size(61, 13);
            this.lFlatgrassDimensions.TabIndex = 10;
            this.lFlatgrassDimensions.Text = "Dimensions";
            // 
            // lFlatgrassX1
            // 
            this.lFlatgrassX1.AutoSize = true;
            this.lFlatgrassX1.Location = new System.Drawing.Point(213, 25);
            this.lFlatgrassX1.Name = "lFlatgrassX1";
            this.lFlatgrassX1.Size = new System.Drawing.Size(13, 13);
            this.lFlatgrassX1.TabIndex = 2;
            this.lFlatgrassX1.Text = "×";
            // 
            // nFlatgrassDimX
            // 
            this.nFlatgrassDimX.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nFlatgrassDimX.Location = new System.Drawing.Point(153, 23);
            this.nFlatgrassDimX.Maximum = new decimal(new int[] {
            2032,
            0,
            0,
            0});
            this.nFlatgrassDimX.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nFlatgrassDimX.Name = "nFlatgrassDimX";
            this.nFlatgrassDimX.Size = new System.Drawing.Size(54, 20);
            this.nFlatgrassDimX.TabIndex = 1;
            this.nFlatgrassDimX.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // bFlatgrassGenerate
            // 
            this.bFlatgrassGenerate.Location = new System.Drawing.Point(6, 6);
            this.bFlatgrassGenerate.Name = "bFlatgrassGenerate";
            this.bFlatgrassGenerate.Size = new System.Drawing.Size(74, 50);
            this.bFlatgrassGenerate.TabIndex = 0;
            this.bFlatgrassGenerate.Text = "Generate";
            this.bFlatgrassGenerate.UseVisualStyleBackColor = true;
            this.bFlatgrassGenerate.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // tabCopy
            // 
            this.tabCopy.Controls.Add(this.tCopyInfo);
            this.tabCopy.Controls.Add(this.lWorldToCopy);
            this.tabCopy.Controls.Add(this.bShow);
            this.tabCopy.Controls.Add(this.cWorld);
            this.tabCopy.Location = new System.Drawing.Point(4, 22);
            this.tabCopy.Name = "tabCopy";
            this.tabCopy.Padding = new System.Windows.Forms.Padding(3);
            this.tabCopy.Size = new System.Drawing.Size(391, 424);
            this.tabCopy.TabIndex = 2;
            this.tabCopy.Text = "Copy World";
            this.tabCopy.UseVisualStyleBackColor = true;
            // 
            // cWorld
            // 
            this.cWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cWorld.FormattingEnabled = true;
            this.cWorld.Location = new System.Drawing.Point(85, 7);
            this.cWorld.Name = "cWorld";
            this.cWorld.Size = new System.Drawing.Size(214, 21);
            this.cWorld.TabIndex = 0;
            this.cWorld.SelectedIndexChanged += new System.EventHandler(this.cWorld_SelectedIndexChanged);
            // 
            // bShow
            // 
            this.bShow.Location = new System.Drawing.Point(305, 6);
            this.bShow.Name = "bShow";
            this.bShow.Size = new System.Drawing.Size(74, 23);
            this.bShow.TabIndex = 1;
            this.bShow.Text = "Show";
            this.bShow.UseVisualStyleBackColor = true;
            this.bShow.Click += new System.EventHandler(this.bShow_Click);
            // 
            // lWorldToCopy
            // 
            this.lWorldToCopy.AutoSize = true;
            this.lWorldToCopy.Location = new System.Drawing.Point(6, 11);
            this.lWorldToCopy.Name = "lWorldToCopy";
            this.lWorldToCopy.Size = new System.Drawing.Size(73, 13);
            this.lWorldToCopy.TabIndex = 24;
            this.lWorldToCopy.Text = "World to copy";
            // 
            // tCopyInfo
            // 
            this.tCopyInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCopyInfo.Location = new System.Drawing.Point(6, 34);
            this.tCopyInfo.Multiline = true;
            this.tCopyInfo.Name = "tCopyInfo";
            this.tCopyInfo.ReadOnly = true;
            this.tCopyInfo.Size = new System.Drawing.Size(373, 100);
            this.tCopyInfo.TabIndex = 2;
            // 
            // tabLoad
            // 
            this.tabLoad.Controls.Add(this.label3);
            this.tabLoad.Controls.Add(this.label2);
            this.tabLoad.Controls.Add(this.lFolder);
            this.tabLoad.Controls.Add(this.tFolder);
            this.tabLoad.Controls.Add(this.tLoadFileInfo);
            this.tabLoad.Controls.Add(this.tFile);
            this.tabLoad.Controls.Add(this.bBrowseFolder);
            this.tabLoad.Controls.Add(this.lFormatList);
            this.tabLoad.Controls.Add(this.lFile);
            this.tabLoad.Controls.Add(this.bBrowseFile);
            this.tabLoad.Location = new System.Drawing.Point(4, 22);
            this.tabLoad.Name = "tabLoad";
            this.tabLoad.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoad.Size = new System.Drawing.Size(391, 424);
            this.tabLoad.TabIndex = 1;
            this.tabLoad.Text = "Load File";
            this.tabLoad.UseVisualStyleBackColor = true;
            // 
            // bBrowseFile
            // 
            this.bBrowseFile.Location = new System.Drawing.Point(311, 79);
            this.bBrowseFile.Name = "bBrowseFile";
            this.bBrowseFile.Size = new System.Drawing.Size(74, 23);
            this.bBrowseFile.TabIndex = 1;
            this.bBrowseFile.Text = "Browse";
            this.bBrowseFile.UseVisualStyleBackColor = true;
            this.bBrowseFile.Click += new System.EventHandler(this.bBrowseFile_Click);
            // 
            // tFile
            // 
            this.tFile.Location = new System.Drawing.Point(72, 81);
            this.tFile.Name = "tFile";
            this.tFile.ReadOnly = true;
            this.tFile.Size = new System.Drawing.Size(233, 20);
            this.tFile.TabIndex = 0;
            // 
            // tLoadFileInfo
            // 
            this.tLoadFileInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tLoadFileInfo.Location = new System.Drawing.Point(3, 198);
            this.tLoadFileInfo.Multiline = true;
            this.tLoadFileInfo.Name = "tLoadFileInfo";
            this.tLoadFileInfo.ReadOnly = true;
            this.tLoadFileInfo.Size = new System.Drawing.Size(379, 100);
            this.tLoadFileInfo.TabIndex = 2;
            // 
            // lFile
            // 
            this.lFile.AutoSize = true;
            this.lFile.Location = new System.Drawing.Point(6, 84);
            this.lFile.Name = "lFile";
            this.lFile.Size = new System.Drawing.Size(47, 13);
            this.lFile.TabIndex = 7;
            this.lFile.Text = "Load file";
            // 
            // lFormatList
            // 
            this.lFormatList.AutoSize = true;
            this.lFormatList.Location = new System.Drawing.Point(6, 3);
            this.lFormatList.Name = "lFormatList";
            this.lFormatList.Size = new System.Drawing.Size(278, 65);
            this.lFormatList.TabIndex = 8;
            this.lFormatList.Text = "Supported file formats:\r\n- fCraft and SpaceCraft (.fcm)\r\n- MCSharp and MCZall (.l" +
                "vl)\r\n- Original/vanilla (.dat, .mine)\r\n- Survival Indev (.mclevel) - does not su" +
                "pport infinite maps";
            // 
            // bBrowseFolder
            // 
            this.bBrowseFolder.Location = new System.Drawing.Point(311, 157);
            this.bBrowseFolder.Name = "bBrowseFolder";
            this.bBrowseFolder.Size = new System.Drawing.Size(74, 23);
            this.bBrowseFolder.TabIndex = 10;
            this.bBrowseFolder.Text = "Browse";
            this.bBrowseFolder.UseVisualStyleBackColor = true;
            this.bBrowseFolder.Click += new System.EventHandler(this.bBrowseFolder_Click);
            // 
            // tFolder
            // 
            this.tFolder.Location = new System.Drawing.Point(72, 160);
            this.tFolder.Name = "tFolder";
            this.tFolder.ReadOnly = true;
            this.tFolder.Size = new System.Drawing.Size(233, 20);
            this.tFolder.TabIndex = 9;
            // 
            // lFolder
            // 
            this.lFolder.AutoSize = true;
            this.lFolder.Location = new System.Drawing.Point(6, 163);
            this.lFolder.Name = "lFolder";
            this.lFolder.Size = new System.Drawing.Size(60, 13);
            this.lFolder.TabIndex = 11;
            this.lFolder.Text = "Load folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Supported folder formats:\r\n- Myne, MyneCraft, Hyvebuilt, iCraft";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 52);
            this.label3.TabIndex = 13;
            this.label3.Text = "\r\n- MinerCPP and LuaCraft (.dat)\r\n- D3 (.map) - resets spawnpoint\r\n- JTE\'s (.gz)";
            // 
            // tabExisting
            // 
            this.tabExisting.Controls.Add(this.tExistingMapInfo);
            this.tabExisting.Location = new System.Drawing.Point(4, 22);
            this.tabExisting.Name = "tabExisting";
            this.tabExisting.Padding = new System.Windows.Forms.Padding(3);
            this.tabExisting.Size = new System.Drawing.Size(391, 424);
            this.tabExisting.TabIndex = 0;
            this.tabExisting.Text = "Existing Map";
            this.tabExisting.UseVisualStyleBackColor = true;
            // 
            // tExistingMapInfo
            // 
            this.tExistingMapInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tExistingMapInfo.Location = new System.Drawing.Point(6, 6);
            this.tExistingMapInfo.Multiline = true;
            this.tExistingMapInfo.Name = "tExistingMapInfo";
            this.tExistingMapInfo.ReadOnly = true;
            this.tExistingMapInfo.Size = new System.Drawing.Size(373, 412);
            this.tExistingMapInfo.TabIndex = 0;
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tabs.Controls.Add(this.tabExisting);
            this.tabs.Controls.Add(this.tabLoad);
            this.tabs.Controls.Add(this.tabCopy);
            this.tabs.Controls.Add(this.tabFlatgrass);
            this.tabs.Controls.Add(this.tabHeightmap);
            this.tabs.Controls.Add(this.tabTerrain);
            this.tabs.Location = new System.Drawing.Point(12, 108);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(399, 450);
            this.tabs.TabIndex = 5;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // AddWorldPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 583);
            this.Controls.Add(this.lCreateMap);
            this.Controls.Add(this.lMapFileOptions);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.bSavePreview);
            this.Controls.Add(this.previewLayout);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.xHidden);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.lBuild);
            this.Controls.Add(this.lAccess);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.cBuild);
            this.Controls.Add(this.cAccess);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Name = "AddWorldPopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add World";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddWorldPopup_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.previewLayout.ResumeLayout(false);
            this.previewLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            this.tabTerrain.ResumeLayout(false);
            this.tabTerrain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSeed)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gBeaches.ResumeLayout(false);
            this.gBeaches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nBeachExtent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBeachHeight)).EndInit();
            this.gCliffs.ResumeLayout(false);
            this.gCliffs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sCliffThreshold)).EndInit();
            this.gSnow.ResumeLayout(false);
            this.gSnow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSnowAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSnowTransition)).EndInit();
            this.gTrees.ResumeLayout(false);
            this.gTrees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTreeSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTreeSpacingVariation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTreeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTreeHeightVariation)).EndInit();
            this.gCaves.ResumeLayout(false);
            this.gCaves.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sCaveDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCaveSize)).EndInit();
            this.gHeightmapCreation.ResumeLayout(false);
            this.gHeightmapCreation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sRoughness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sWaterCoverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sFeatureScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sDetailScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sBelowFunc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAboveFunc)).EndInit();
            this.gTerrainFeatures.ResumeLayout(false);
            this.gTerrainFeatures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sBias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRaisedCorners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLoweredCorners)).EndInit();
            this.gMapSize.ResumeLayout(false);
            this.gMapSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nWidthY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWidthX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWaterLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxHeightVariation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxDepthVariation)).EndInit();
            this.gTemplates.ResumeLayout(false);
            this.gTemplates.PerformLayout();
            this.gGenOptions.ResumeLayout(false);
            this.gGenOptions.PerformLayout();
            this.tabHeightmap.ResumeLayout(false);
            this.tabHeightmap.PerformLayout();
            this.tabFlatgrass.ResumeLayout(false);
            this.tabFlatgrass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nFlatgrassDimY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFlatgrassDimH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFlatgrassDimX)).EndInit();
            this.tabCopy.ResumeLayout(false);
            this.tabCopy.PerformLayout();
            this.tabLoad.ResumeLayout(false);
            this.tabLoad.PerformLayout();
            this.tabExisting.ResumeLayout(false);
            this.tabExisting.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lPreview;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ComboBox cAccess;
        private System.Windows.Forms.ComboBox cBuild;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lAccess;
        private System.Windows.Forms.Label lBuild;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.Button bPreviewPrev;
        private System.Windows.Forms.Button bPreviewNext;
        private System.Windows.Forms.CheckBox xHidden;
        private System.Windows.Forms.OpenFileDialog fileBrowser;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel tStatus1;
        private System.Windows.Forms.ToolStripStatusLabel tStatus2;
        private System.Windows.Forms.TableLayoutPanel previewLayout;
        private System.Windows.Forms.Button bSavePreview;
        private CustomPictureBox preview;
        private System.Windows.Forms.Label lMapFileOptions;
        private System.Windows.Forms.Label lCreateMap;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.TabPage tabTerrain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox gGenOptions;
        private System.Windows.Forms.CheckBox xAddCliffs;
        private System.Windows.Forms.CheckBox xAddRuins;
        private System.Windows.Forms.CheckBox xOre;
        private System.Windows.Forms.CheckBox xAddBeaches;
        private System.Windows.Forms.CheckBox xAddTrees;
        private System.Windows.Forms.CheckBox xAddSnow;
        private System.Windows.Forms.CheckBox xFloodBarrier;
        private System.Windows.Forms.CheckBox xWater;
        private System.Windows.Forms.CheckBox xCaves;
        private System.Windows.Forms.GroupBox gTemplates;
        private System.Windows.Forms.ComboBox cTemplates;
        private System.Windows.Forms.Label lUseTemplate;
        private System.Windows.Forms.Button bBrowseTemplate;
        private System.Windows.Forms.Button bSaveTemplate;
        private System.Windows.Forms.GroupBox gMapSize;
        private System.Windows.Forms.NumericUpDown nMaxDepthVariation;
        private System.Windows.Forms.NumericUpDown nMaxHeightVariation;
        private System.Windows.Forms.Label lMaxHeightVariationUnits;
        private System.Windows.Forms.Label lMaxDepthVariationUnits;
        private System.Windows.Forms.CheckBox xWaterLevel;
        private System.Windows.Forms.NumericUpDown nWaterLevel;
        private System.Windows.Forms.Label lWaterLevelLabel;
        private System.Windows.Forms.NumericUpDown nMaxDepth;
        private System.Windows.Forms.NumericUpDown nMaxHeight;
        private System.Windows.Forms.NumericUpDown nWidthX;
        private System.Windows.Forms.Label lMaxHeight;
        private System.Windows.Forms.Label lMaxHeightUnits;
        private System.Windows.Forms.Label lMaxDepth;
        private System.Windows.Forms.Label lMaxDepthUnits;
        private System.Windows.Forms.Label lX1;
        private System.Windows.Forms.Label lDim;
        private System.Windows.Forms.Label lX2;
        private System.Windows.Forms.NumericUpDown nHeight;
        private System.Windows.Forms.NumericUpDown nWidthY;
        private System.Windows.Forms.GroupBox gTerrainFeatures;
        private System.Windows.Forms.Label lLoweredCorners;
        private System.Windows.Forms.NumericUpDown nLoweredCorners;
        private System.Windows.Forms.ComboBox cMidpoint;
        private System.Windows.Forms.Label lMidpoint;
        private System.Windows.Forms.Label lRaisedCorners;
        private System.Windows.Forms.NumericUpDown nRaisedCorners;
        private System.Windows.Forms.Label lBiasDisplay;
        private System.Windows.Forms.Label lBias;
        private System.Windows.Forms.TrackBar sBias;
        private System.Windows.Forms.GroupBox gHeightmapCreation;
        private System.Windows.Forms.Label lBelowFunc;
        private System.Windows.Forms.Label lAboveFunc;
        private System.Windows.Forms.Label lBelowFuncUnits;
        private System.Windows.Forms.Label lAboveFuncUnits;
        private System.Windows.Forms.TrackBar sAboveFunc;
        private System.Windows.Forms.TrackBar sBelowFunc;
        private System.Windows.Forms.CheckBox xDelayBias;
        private System.Windows.Forms.CheckBox xInvert;
        private System.Windows.Forms.TrackBar sDetailScale;
        private System.Windows.Forms.Label lDetailSizeDisplay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar sFeatureScale;
        private System.Windows.Forms.Label lRoughnessDisplay;
        private System.Windows.Forms.Label lFeatureSizeDisplay;
        private System.Windows.Forms.CheckBox xMatchWaterCoverage;
        private System.Windows.Forms.TrackBar sWaterCoverage;
        private System.Windows.Forms.CheckBox xLayeredHeightmap;
        private System.Windows.Forms.CheckBox xMarbledMode;
        private System.Windows.Forms.TrackBar sRoughness;
        private System.Windows.Forms.Label lMatchWaterCoverageDisplay;
        private System.Windows.Forms.Label lRoughness;
        private System.Windows.Forms.Label lDetailSize;
        private System.Windows.Forms.GroupBox gCaves;
        private System.Windows.Forms.Label lCaveSizeDisplay;
        private System.Windows.Forms.Label lCaveDensityDisplay;
        private System.Windows.Forms.CheckBox xCaveLava;
        private System.Windows.Forms.CheckBox xCaveWater;
        private System.Windows.Forms.TrackBar sCaveSize;
        private System.Windows.Forms.Label lCaveSize;
        private System.Windows.Forms.TrackBar sCaveDensity;
        private System.Windows.Forms.Label lCaveDensity;
        private System.Windows.Forms.GroupBox gTrees;
        private System.Windows.Forms.Label lTreeHeightUnits;
        private System.Windows.Forms.NumericUpDown nTreeHeightVariation;
        private System.Windows.Forms.Label lTreeHeightVariation;
        private System.Windows.Forms.NumericUpDown nTreeHeight;
        private System.Windows.Forms.Label lTreeHeight;
        private System.Windows.Forms.Label lTreeSpacingUnits;
        private System.Windows.Forms.NumericUpDown nTreeSpacingVariation;
        private System.Windows.Forms.Label lTreeSpacingVariation;
        private System.Windows.Forms.NumericUpDown nTreeSpacing;
        private System.Windows.Forms.Label lTreeSpacing;
        private System.Windows.Forms.GroupBox gSnow;
        private System.Windows.Forms.Label lSnowTransitionUnits;
        private System.Windows.Forms.Label lSnowTransition;
        private System.Windows.Forms.Label lSnowAltitudeUnits;
        private System.Windows.Forms.NumericUpDown nSnowTransition;
        private System.Windows.Forms.NumericUpDown nSnowAltitude;
        private System.Windows.Forms.Label lSnowAltitude;
        private System.Windows.Forms.GroupBox gCliffs;
        private System.Windows.Forms.CheckBox xCliffSmoothing;
        private System.Windows.Forms.Label lCliffThresholdUnits;
        private System.Windows.Forms.TrackBar sCliffThreshold;
        private System.Windows.Forms.Label lCliffThreshold;
        private System.Windows.Forms.GroupBox gBeaches;
        private System.Windows.Forms.Label lBeachHeight;
        private System.Windows.Forms.Label lBeachExtentUnits;
        private System.Windows.Forms.Label lBeachHeightUnits;
        private System.Windows.Forms.NumericUpDown nBeachHeight;
        private System.Windows.Forms.NumericUpDown nBeachExtent;
        private System.Windows.Forms.Label lBeachExtent;
        private System.Windows.Forms.CheckBox xSeed;
        private System.Windows.Forms.NumericUpDown nSeed;
        private System.Windows.Forms.CheckBox xAdvanced;
        private System.Windows.Forms.Button bGenerate;
        private System.Windows.Forms.Label lTheme;
        private System.Windows.Forms.ComboBox cTheme;
        private System.Windows.Forms.TabPage tabHeightmap;
        private System.Windows.Forms.Label lHeightmapComingSoon;
        private System.Windows.Forms.TabPage tabFlatgrass;
        private System.Windows.Forms.Button bFlatgrassGenerate;
        private System.Windows.Forms.NumericUpDown nFlatgrassDimX;
        private System.Windows.Forms.Label lFlatgrassX1;
        private System.Windows.Forms.Label lFlatgrassDimensions;
        private System.Windows.Forms.Label lFlatgrassX2;
        private System.Windows.Forms.NumericUpDown nFlatgrassDimH;
        private System.Windows.Forms.NumericUpDown nFlatgrassDimY;
        private System.Windows.Forms.TabPage tabCopy;
        private System.Windows.Forms.TextBox tCopyInfo;
        private System.Windows.Forms.Label lWorldToCopy;
        private System.Windows.Forms.Button bShow;
        private System.Windows.Forms.ComboBox cWorld;
        private System.Windows.Forms.TabPage tabLoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lFolder;
        private System.Windows.Forms.TextBox tFolder;
        private System.Windows.Forms.TextBox tLoadFileInfo;
        private System.Windows.Forms.TextBox tFile;
        private System.Windows.Forms.Button bBrowseFolder;
        private System.Windows.Forms.Label lFormatList;
        private System.Windows.Forms.Label lFile;
        private System.Windows.Forms.Button bBrowseFile;
        private System.Windows.Forms.TabPage tabExisting;
        private System.Windows.Forms.TextBox tExistingMapInfo;
        private System.Windows.Forms.TabControl tabs;
    }
}