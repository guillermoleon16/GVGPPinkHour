namespace GVGPPinkHour
{
    /// <summary>
    /// Main form of the 2048 agent
    /// </summary>
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.StopPlayingButton = new System.Windows.Forms.Button();
            this.SetVisionButton = new System.Windows.Forms.Button();
            this.StartPlayingButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.StepButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.BlocksContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.upArrow = new System.Windows.Forms.PictureBox();
            this.rightArrow = new System.Windows.Forms.PictureBox();
            this.leftArrow = new System.Windows.Forms.PictureBox();
            this.downArrow = new System.Windows.Forms.PictureBox();
            this.zButton = new System.Windows.Forms.PictureBox();
            this.EXState = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IDStep = new System.Windows.Forms.Button();
            this.EStep = new System.Windows.Forms.Button();
            this.PStep = new System.Windows.Forms.Button();
            this.IDState = new System.Windows.Forms.PictureBox();
            this.PLState = new System.Windows.Forms.PictureBox();
            this.MetricContainer = new System.Windows.Forms.TableLayoutPanel();
            this.RewardLabel = new System.Windows.Forms.Label();
            this.GameSelector = new System.Windows.Forms.ComboBox();
            this.SaveFileCheckBox = new System.Windows.Forms.CheckBox();
            this.SeeTree = new System.Windows.Forms.Button();
            this.CBLimitLabel = new System.Windows.Forms.Label();
            this.CBLimitTrackBar = new System.Windows.Forms.TrackBar();
            this.SeeCB = new System.Windows.Forms.Button();
            this.FigureContainer = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.FigureSelector1 = new System.Windows.Forms.ComboBox();
            this.FigureSelector2 = new System.Windows.Forms.ComboBox();
            this.Figure1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Figure2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ButtonContainer = new System.Windows.Forms.TableLayoutPanel();
            this.BlocksContainer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EXState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLState)).BeginInit();
            this.MetricContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CBLimitTrackBar)).BeginInit();
            this.FigureContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Figure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Figure2)).BeginInit();
            this.ButtonContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // StopPlayingButton
            // 
            this.StopPlayingButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopPlayingButton.Location = new System.Drawing.Point(389, 5);
            this.StopPlayingButton.Name = "StopPlayingButton";
            this.StopPlayingButton.Size = new System.Drawing.Size(120, 22);
            this.StopPlayingButton.TabIndex = 4;
            this.StopPlayingButton.Text = "Stop Playing";
            this.StopPlayingButton.UseVisualStyleBackColor = true;
            this.StopPlayingButton.Click += new System.EventHandler(this.StopPlayingButton_Click);
            // 
            // SetVisionButton
            // 
            this.SetVisionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetVisionButton.Location = new System.Drawing.Point(5, 5);
            this.SetVisionButton.Name = "SetVisionButton";
            this.SetVisionButton.Size = new System.Drawing.Size(120, 22);
            this.SetVisionButton.TabIndex = 5;
            this.SetVisionButton.Text = "Set Vision";
            this.SetVisionButton.UseVisualStyleBackColor = true;
            this.SetVisionButton.Click += new System.EventHandler(this.SetVisionButton_Click);
            // 
            // StartPlayingButton
            // 
            this.StartPlayingButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartPlayingButton.Location = new System.Drawing.Point(133, 5);
            this.StartPlayingButton.Name = "StartPlayingButton";
            this.StartPlayingButton.Size = new System.Drawing.Size(120, 22);
            this.StartPlayingButton.TabIndex = 7;
            this.StartPlayingButton.Text = "Start Playing";
            this.StartPlayingButton.UseVisualStyleBackColor = true;
            this.StartPlayingButton.Click += new System.EventHandler(this.StartPlayingButton_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(12, 12);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 13);
            this.timeLabel.TabIndex = 15;
            // 
            // StepButton
            // 
            this.StepButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StepButton.Location = new System.Drawing.Point(517, 5);
            this.StepButton.Name = "StepButton";
            this.StepButton.Size = new System.Drawing.Size(121, 22);
            this.StepButton.TabIndex = 25;
            this.StepButton.Text = "Step by Step";
            this.StepButton.UseVisualStyleBackColor = true;
            this.StepButton.Click += new System.EventHandler(this.StepButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PauseButton.Location = new System.Drawing.Point(261, 5);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(120, 22);
            this.PauseButton.TabIndex = 26;
            this.PauseButton.Text = "Pause Playing";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // BlocksContainer
            // 
            this.BlocksContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.BlocksContainer.ColumnCount = 3;
            this.BlocksContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.BlocksContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.BlocksContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.BlocksContainer.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.BlocksContainer.Controls.Add(this.label2, 0, 1);
            this.BlocksContainer.Controls.Add(this.label4, 1, 1);
            this.BlocksContainer.Controls.Add(this.label5, 2, 1);
            this.BlocksContainer.Controls.Add(this.IDStep, 0, 2);
            this.BlocksContainer.Controls.Add(this.EStep, 1, 2);
            this.BlocksContainer.Controls.Add(this.PStep, 2, 2);
            this.BlocksContainer.Controls.Add(this.IDState, 0, 0);
            this.BlocksContainer.Controls.Add(this.PLState, 2, 0);
            this.BlocksContainer.Location = new System.Drawing.Point(12, 12);
            this.BlocksContainer.Name = "BlocksContainer";
            this.BlocksContainer.RowCount = 3;
            this.BlocksContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.BlocksContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.BlocksContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.BlocksContainer.Size = new System.Drawing.Size(643, 222);
            this.BlocksContainer.TabIndex = 27;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.upArrow, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rightArrow, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.leftArrow, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.downArrow, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.zButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.EXState, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(217, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 146);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // upArrow
            // 
            this.upArrow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.upArrow.Image = global::GVGPPinkHour.Properties.Resources.upArrow;
            this.upArrow.Location = new System.Drawing.Point(74, 11);
            this.upArrow.Name = "upArrow";
            this.upArrow.Size = new System.Drawing.Size(50, 50);
            this.upArrow.TabIndex = 0;
            this.upArrow.TabStop = false;
            // 
            // rightArrow
            // 
            this.rightArrow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rightArrow.Image = global::GVGPPinkHour.Properties.Resources.rightArrow;
            this.rightArrow.Location = new System.Drawing.Point(141, 84);
            this.rightArrow.Name = "rightArrow";
            this.rightArrow.Size = new System.Drawing.Size(50, 50);
            this.rightArrow.TabIndex = 2;
            this.rightArrow.TabStop = false;
            // 
            // leftArrow
            // 
            this.leftArrow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leftArrow.Image = global::GVGPPinkHour.Properties.Resources.leftArrow;
            this.leftArrow.Location = new System.Drawing.Point(8, 84);
            this.leftArrow.Name = "leftArrow";
            this.leftArrow.Size = new System.Drawing.Size(50, 50);
            this.leftArrow.TabIndex = 1;
            this.leftArrow.TabStop = false;
            // 
            // downArrow
            // 
            this.downArrow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.downArrow.Image = global::GVGPPinkHour.Properties.Resources.downArrow;
            this.downArrow.Location = new System.Drawing.Point(74, 84);
            this.downArrow.Name = "downArrow";
            this.downArrow.Size = new System.Drawing.Size(50, 50);
            this.downArrow.TabIndex = 3;
            this.downArrow.TabStop = false;
            // 
            // zButton
            // 
            this.zButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.zButton.Image = global::GVGPPinkHour.Properties.Resources.z;
            this.zButton.Location = new System.Drawing.Point(8, 11);
            this.zButton.Name = "zButton";
            this.zButton.Size = new System.Drawing.Size(50, 50);
            this.zButton.TabIndex = 4;
            this.zButton.TabStop = false;
            // 
            // EXState
            // 
            this.EXState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EXState.Location = new System.Drawing.Point(135, 3);
            this.EXState.Name = "EXState";
            this.EXState.Size = new System.Drawing.Size(62, 67);
            this.EXState.TabIndex = 5;
            this.EXState.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Identifier";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(292, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Executer";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(510, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Planner";
            // 
            // IDStep
            // 
            this.IDStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDStep.Location = new System.Drawing.Point(4, 190);
            this.IDStep.Name = "IDStep";
            this.IDStep.Size = new System.Drawing.Size(206, 28);
            this.IDStep.TabIndex = 5;
            this.IDStep.Text = "Step";
            this.IDStep.UseVisualStyleBackColor = true;
            this.IDStep.Click += new System.EventHandler(this.IDStep_Click);
            // 
            // EStep
            // 
            this.EStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EStep.Location = new System.Drawing.Point(217, 190);
            this.EStep.Name = "EStep";
            this.EStep.Size = new System.Drawing.Size(207, 28);
            this.EStep.TabIndex = 6;
            this.EStep.Text = "Step";
            this.EStep.UseVisualStyleBackColor = true;
            this.EStep.Click += new System.EventHandler(this.EStep_Click);
            // 
            // PStep
            // 
            this.PStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PStep.Location = new System.Drawing.Point(431, 190);
            this.PStep.Name = "PStep";
            this.PStep.Size = new System.Drawing.Size(208, 28);
            this.PStep.TabIndex = 7;
            this.PStep.Text = "Auto Off";
            this.PStep.UseVisualStyleBackColor = true;
            this.PStep.Click += new System.EventHandler(this.PStep_Click);
            // 
            // IDState
            // 
            this.IDState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDState.Location = new System.Drawing.Point(4, 4);
            this.IDState.Name = "IDState";
            this.IDState.Size = new System.Drawing.Size(206, 146);
            this.IDState.TabIndex = 9;
            this.IDState.TabStop = false;
            // 
            // PLState
            // 
            this.PLState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PLState.Location = new System.Drawing.Point(431, 4);
            this.PLState.Name = "PLState";
            this.PLState.Size = new System.Drawing.Size(208, 146);
            this.PLState.TabIndex = 10;
            this.PLState.TabStop = false;
            // 
            // MetricContainer
            // 
            this.MetricContainer.ColumnCount = 4;
            this.MetricContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MetricContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MetricContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MetricContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MetricContainer.Controls.Add(this.RewardLabel, 3, 0);
            this.MetricContainer.Controls.Add(this.GameSelector, 0, 0);
            this.MetricContainer.Controls.Add(this.SaveFileCheckBox, 3, 1);
            this.MetricContainer.Controls.Add(this.SeeTree, 1, 0);
            this.MetricContainer.Controls.Add(this.CBLimitLabel, 0, 1);
            this.MetricContainer.Controls.Add(this.CBLimitTrackBar, 1, 1);
            this.MetricContainer.Controls.Add(this.SeeCB, 2, 0);
            this.MetricContainer.Location = new System.Drawing.Point(12, 594);
            this.MetricContainer.Name = "MetricContainer";
            this.MetricContainer.RowCount = 2;
            this.MetricContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MetricContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MetricContainer.Size = new System.Drawing.Size(643, 81);
            this.MetricContainer.TabIndex = 28;
            // 
            // RewardLabel
            // 
            this.RewardLabel.AutoSize = true;
            this.RewardLabel.Location = new System.Drawing.Point(483, 0);
            this.RewardLabel.Name = "RewardLabel";
            this.RewardLabel.Size = new System.Drawing.Size(47, 13);
            this.RewardLabel.TabIndex = 24;
            this.RewardLabel.Text = "CB Size:";
            // 
            // GameSelector
            // 
            this.GameSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameSelector.FormattingEnabled = true;
            this.GameSelector.Items.AddRange(new object[] {
            "2048",
            "Jelly Escape",
            "Pink Hour"});
            this.GameSelector.Location = new System.Drawing.Point(3, 3);
            this.GameSelector.Name = "GameSelector";
            this.GameSelector.Size = new System.Drawing.Size(154, 21);
            this.GameSelector.TabIndex = 25;
            this.GameSelector.SelectedIndexChanged += new System.EventHandler(this.GameSelector_SelectedIndexChanged);
            // 
            // SaveFileCheckBox
            // 
            this.SaveFileCheckBox.AutoSize = true;
            this.SaveFileCheckBox.Location = new System.Drawing.Point(483, 43);
            this.SaveFileCheckBox.Name = "SaveFileCheckBox";
            this.SaveFileCheckBox.Size = new System.Drawing.Size(119, 17);
            this.SaveFileCheckBox.TabIndex = 26;
            this.SaveFileCheckBox.Text = "Save Results in File";
            this.SaveFileCheckBox.UseVisualStyleBackColor = true;
            this.SaveFileCheckBox.CheckStateChanged += new System.EventHandler(this.SaveFileCheckBox_CheckStateChanged);
            // 
            // SeeTree
            // 
            this.SeeTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SeeTree.Location = new System.Drawing.Point(163, 3);
            this.SeeTree.Name = "SeeTree";
            this.SeeTree.Size = new System.Drawing.Size(154, 34);
            this.SeeTree.TabIndex = 27;
            this.SeeTree.Text = "See Game Tree";
            this.SeeTree.UseVisualStyleBackColor = true;
            this.SeeTree.Click += new System.EventHandler(this.SeeTree_Click);
            // 
            // CBLimitLabel
            // 
            this.CBLimitLabel.AutoSize = true;
            this.CBLimitLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBLimitLabel.Location = new System.Drawing.Point(3, 40);
            this.CBLimitLabel.Name = "CBLimitLabel";
            this.CBLimitLabel.Size = new System.Drawing.Size(154, 41);
            this.CBLimitLabel.TabIndex = 28;
            this.CBLimitLabel.Text = "Case Base Size Limit: ";
            // 
            // CBLimitTrackBar
            // 
            this.MetricContainer.SetColumnSpan(this.CBLimitTrackBar, 2);
            this.CBLimitTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBLimitTrackBar.LargeChange = 100;
            this.CBLimitTrackBar.Location = new System.Drawing.Point(163, 43);
            this.CBLimitTrackBar.Maximum = 10000;
            this.CBLimitTrackBar.Minimum = 100;
            this.CBLimitTrackBar.Name = "CBLimitTrackBar";
            this.CBLimitTrackBar.Size = new System.Drawing.Size(314, 35);
            this.CBLimitTrackBar.SmallChange = 100;
            this.CBLimitTrackBar.TabIndex = 29;
            this.CBLimitTrackBar.TickFrequency = 100;
            this.CBLimitTrackBar.Value = 100;
            this.CBLimitTrackBar.Scroll += new System.EventHandler(this.CBLimitTrackBar_Scroll);
            // 
            // SeeCB
            // 
            this.SeeCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SeeCB.Location = new System.Drawing.Point(323, 3);
            this.SeeCB.Name = "SeeCB";
            this.SeeCB.Size = new System.Drawing.Size(154, 34);
            this.SeeCB.TabIndex = 30;
            this.SeeCB.Text = "See Case Base";
            this.SeeCB.UseVisualStyleBackColor = true;
            this.SeeCB.Click += new System.EventHandler(this.SeeCB_Click);
            // 
            // FigureContainer
            // 
            this.FigureContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FigureContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.FigureContainer.ColumnCount = 2;
            this.FigureContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FigureContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FigureContainer.Controls.Add(this.label6, 0, 0);
            this.FigureContainer.Controls.Add(this.FigureSelector1, 0, 1);
            this.FigureContainer.Controls.Add(this.FigureSelector2, 1, 1);
            this.FigureContainer.Controls.Add(this.Figure1, 0, 2);
            this.FigureContainer.Controls.Add(this.Figure2, 1, 2);
            this.FigureContainer.Location = new System.Drawing.Point(12, 278);
            this.FigureContainer.Name = "FigureContainer";
            this.FigureContainer.RowCount = 3;
            this.FigureContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.FigureContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.FigureContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.FigureContainer.Size = new System.Drawing.Size(643, 310);
            this.FigureContainer.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.FigureContainer.SetColumnSpan(this.label6, 2);
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(282, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Data Figures";
            // 
            // FigureSelector1
            // 
            this.FigureSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FigureSelector1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FigureSelector1.FormattingEnabled = true;
            this.FigureSelector1.Items.AddRange(new object[] {
            "CB Size vs. Iteration",
            "Completion Time vs. Iteration",
            "Valid vs. Iteration",
            "CB Size vs. Time",
            "Valid vs. Time"});
            this.FigureSelector1.Location = new System.Drawing.Point(5, 37);
            this.FigureSelector1.Name = "FigureSelector1";
            this.FigureSelector1.Size = new System.Drawing.Size(312, 21);
            this.FigureSelector1.TabIndex = 1;
            // 
            // FigureSelector2
            // 
            this.FigureSelector2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FigureSelector2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FigureSelector2.FormattingEnabled = true;
            this.FigureSelector2.Items.AddRange(new object[] {
            "CB Size vs. Iteration",
            "Completion Time vs. Iteration",
            "Valid vs. Iteration",
            "CB Size vs. Time",
            "Valid vs. Time"});
            this.FigureSelector2.Location = new System.Drawing.Point(325, 37);
            this.FigureSelector2.Name = "FigureSelector2";
            this.FigureSelector2.Size = new System.Drawing.Size(313, 21);
            this.FigureSelector2.TabIndex = 2;
            // 
            // Figure1
            // 
            chartArea1.Name = "ChartArea1";
            this.Figure1.ChartAreas.Add(chartArea1);
            this.Figure1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Figure1.Location = new System.Drawing.Point(5, 69);
            this.Figure1.Name = "Figure1";
            this.Figure1.Size = new System.Drawing.Size(312, 236);
            this.Figure1.TabIndex = 3;
            this.Figure1.Text = "chart1";
            // 
            // Figure2
            // 
            chartArea2.Name = "ChartArea1";
            this.Figure2.ChartAreas.Add(chartArea2);
            this.Figure2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Figure2.Location = new System.Drawing.Point(325, 69);
            this.Figure2.Name = "Figure2";
            this.Figure2.Size = new System.Drawing.Size(313, 236);
            this.Figure2.TabIndex = 4;
            this.Figure2.Text = "chart2";
            // 
            // ButtonContainer
            // 
            this.ButtonContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.ButtonContainer.ColumnCount = 5;
            this.ButtonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ButtonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ButtonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ButtonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ButtonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ButtonContainer.Controls.Add(this.SetVisionButton, 0, 0);
            this.ButtonContainer.Controls.Add(this.StartPlayingButton, 1, 0);
            this.ButtonContainer.Controls.Add(this.PauseButton, 2, 0);
            this.ButtonContainer.Controls.Add(this.StopPlayingButton, 3, 0);
            this.ButtonContainer.Controls.Add(this.StepButton, 4, 0);
            this.ButtonContainer.Location = new System.Drawing.Point(12, 240);
            this.ButtonContainer.Name = "ButtonContainer";
            this.ButtonContainer.RowCount = 1;
            this.ButtonContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonContainer.Size = new System.Drawing.Size(643, 32);
            this.ButtonContainer.TabIndex = 30;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 687);
            this.Controls.Add(this.ButtonContainer);
            this.Controls.Add(this.FigureContainer);
            this.Controls.Add(this.MetricContainer);
            this.Controls.Add(this.BlocksContainer);
            this.Controls.Add(this.timeLabel);
            this.MaximumSize = new System.Drawing.Size(683, 726);
            this.MinimumSize = new System.Drawing.Size(683, 726);
            this.Name = "Form1";
            this.Text = "Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BlocksContainer.ResumeLayout(false);
            this.BlocksContainer.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.upArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EXState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLState)).EndInit();
            this.MetricContainer.ResumeLayout(false);
            this.MetricContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CBLimitTrackBar)).EndInit();
            this.FigureContainer.ResumeLayout(false);
            this.FigureContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Figure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Figure2)).EndInit();
            this.ButtonContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox upArrow;
        private System.Windows.Forms.PictureBox leftArrow;
        private System.Windows.Forms.PictureBox rightArrow;
        private System.Windows.Forms.PictureBox downArrow;
        private System.Windows.Forms.Button StopPlayingButton;
        private System.Windows.Forms.Button SetVisionButton;
        private System.Windows.Forms.Button StartPlayingButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button StepButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.TableLayoutPanel BlocksContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button IDStep;
        private System.Windows.Forms.Button EStep;
        private System.Windows.Forms.Button PStep;
        private System.Windows.Forms.TableLayoutPanel MetricContainer;
        private System.Windows.Forms.TableLayoutPanel FigureContainer;
        private System.Windows.Forms.TableLayoutPanel ButtonContainer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox FigureSelector1;
        private System.Windows.Forms.ComboBox FigureSelector2;
        private System.Windows.Forms.DataVisualization.Charting.Chart Figure1;
        private System.Windows.Forms.DataVisualization.Charting.Chart Figure2;
        private System.Windows.Forms.PictureBox zButton;
        private System.Windows.Forms.ComboBox GameSelector;
        private System.Windows.Forms.PictureBox IDState;
        private System.Windows.Forms.CheckBox SaveFileCheckBox;
        private System.Windows.Forms.Label RewardLabel;
        private System.Windows.Forms.Button SeeTree;
        private System.Windows.Forms.Label CBLimitLabel;
        private System.Windows.Forms.TrackBar CBLimitTrackBar;
        private System.Windows.Forms.Button SeeCB;
        private System.Windows.Forms.PictureBox PLState;
        private System.Windows.Forms.PictureBox EXState;
    }
}

