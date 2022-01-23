namespace MultiFaceRec
{
    partial class FormBackup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBackup));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnphuchoi = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnsaoluu = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnfoler = new Bunifu.UI.WinForms.BunifuImageButton();
            this.txtfolder = new Bunifu.UI.WinForms.BunifuTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bunifuSnackbar1 = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnphuchoi);
            this.groupBox1.Controls.Add(this.btnsaoluu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnfoler);
            this.groupBox1.Controls.Add(this.txtfolder);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(780, 550);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu hình hệ thống";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 260);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Phục hồi dữ liệu đã sao lưu vào ngày gần nhất";
            // 
            // btnphuchoi
            // 
            this.btnphuchoi.AllowAnimations = true;
            this.btnphuchoi.AllowMouseEffects = true;
            this.btnphuchoi.AllowToggling = false;
            this.btnphuchoi.AnimationSpeed = 200;
            this.btnphuchoi.AutoGenerateColors = false;
            this.btnphuchoi.AutoRoundBorders = false;
            this.btnphuchoi.AutoSizeLeftIcon = true;
            this.btnphuchoi.AutoSizeRightIcon = true;
            this.btnphuchoi.BackColor = System.Drawing.Color.Transparent;
            this.btnphuchoi.BackColor1 = System.Drawing.Color.LimeGreen;
            this.btnphuchoi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnphuchoi.BackgroundImage")));
            this.btnphuchoi.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnphuchoi.ButtonText = "PHỤC HỒI";
            this.btnphuchoi.ButtonTextMarginLeft = 0;
            this.btnphuchoi.ColorContrastOnClick = 45;
            this.btnphuchoi.ColorContrastOnHover = 45;
            this.btnphuchoi.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnphuchoi.CustomizableEdges = borderEdges3;
            this.btnphuchoi.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnphuchoi.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnphuchoi.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnphuchoi.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnphuchoi.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnphuchoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnphuchoi.ForeColor = System.Drawing.Color.White;
            this.btnphuchoi.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnphuchoi.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnphuchoi.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnphuchoi.IconMarginLeft = 11;
            this.btnphuchoi.IconPadding = 10;
            this.btnphuchoi.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnphuchoi.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnphuchoi.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnphuchoi.IconSize = 25;
            this.btnphuchoi.IdleBorderColor = System.Drawing.Color.LimeGreen;
            this.btnphuchoi.IdleBorderRadius = 1;
            this.btnphuchoi.IdleBorderThickness = 1;
            this.btnphuchoi.IdleFillColor = System.Drawing.Color.LimeGreen;
            this.btnphuchoi.IdleIconLeftImage = null;
            this.btnphuchoi.IdleIconRightImage = null;
            this.btnphuchoi.IndicateFocus = false;
            this.btnphuchoi.Location = new System.Drawing.Point(26, 305);
            this.btnphuchoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnphuchoi.Name = "btnphuchoi";
            this.btnphuchoi.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnphuchoi.OnDisabledState.BorderRadius = 1;
            this.btnphuchoi.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnphuchoi.OnDisabledState.BorderThickness = 1;
            this.btnphuchoi.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnphuchoi.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnphuchoi.OnDisabledState.IconLeftImage = null;
            this.btnphuchoi.OnDisabledState.IconRightImage = null;
            this.btnphuchoi.onHoverState.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnphuchoi.onHoverState.BorderRadius = 1;
            this.btnphuchoi.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnphuchoi.onHoverState.BorderThickness = 1;
            this.btnphuchoi.onHoverState.FillColor = System.Drawing.Color.SeaGreen;
            this.btnphuchoi.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnphuchoi.onHoverState.IconLeftImage = null;
            this.btnphuchoi.onHoverState.IconRightImage = null;
            this.btnphuchoi.OnIdleState.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnphuchoi.OnIdleState.BorderRadius = 1;
            this.btnphuchoi.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnphuchoi.OnIdleState.BorderThickness = 1;
            this.btnphuchoi.OnIdleState.FillColor = System.Drawing.Color.LimeGreen;
            this.btnphuchoi.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnphuchoi.OnIdleState.IconLeftImage = null;
            this.btnphuchoi.OnIdleState.IconRightImage = null;
            this.btnphuchoi.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnphuchoi.OnPressedState.BorderRadius = 1;
            this.btnphuchoi.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnphuchoi.OnPressedState.BorderThickness = 1;
            this.btnphuchoi.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnphuchoi.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnphuchoi.OnPressedState.IconLeftImage = null;
            this.btnphuchoi.OnPressedState.IconRightImage = null;
            this.btnphuchoi.Size = new System.Drawing.Size(112, 32);
            this.btnphuchoi.TabIndex = 12;
            this.btnphuchoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnphuchoi.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnphuchoi.TextMarginLeft = 0;
            this.btnphuchoi.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnphuchoi.UseDefaultRadiusAndThickness = true;
            this.btnphuchoi.Click += new System.EventHandler(this.btnphuchoi_Click);
            // 
            // btnsaoluu
            // 
            this.btnsaoluu.AllowAnimations = true;
            this.btnsaoluu.AllowMouseEffects = true;
            this.btnsaoluu.AllowToggling = false;
            this.btnsaoluu.AnimationSpeed = 200;
            this.btnsaoluu.AutoGenerateColors = false;
            this.btnsaoluu.AutoRoundBorders = false;
            this.btnsaoluu.AutoSizeLeftIcon = true;
            this.btnsaoluu.AutoSizeRightIcon = true;
            this.btnsaoluu.BackColor = System.Drawing.Color.Transparent;
            this.btnsaoluu.BackColor1 = System.Drawing.Color.LimeGreen;
            this.btnsaoluu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnsaoluu.BackgroundImage")));
            this.btnsaoluu.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnsaoluu.ButtonText = "SAO LƯU";
            this.btnsaoluu.ButtonTextMarginLeft = 0;
            this.btnsaoluu.ColorContrastOnClick = 45;
            this.btnsaoluu.ColorContrastOnHover = 45;
            this.btnsaoluu.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.btnsaoluu.CustomizableEdges = borderEdges4;
            this.btnsaoluu.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnsaoluu.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnsaoluu.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnsaoluu.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnsaoluu.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnsaoluu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnsaoluu.ForeColor = System.Drawing.Color.White;
            this.btnsaoluu.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsaoluu.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnsaoluu.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnsaoluu.IconMarginLeft = 11;
            this.btnsaoluu.IconPadding = 10;
            this.btnsaoluu.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsaoluu.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnsaoluu.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnsaoluu.IconSize = 25;
            this.btnsaoluu.IdleBorderColor = System.Drawing.Color.LimeGreen;
            this.btnsaoluu.IdleBorderRadius = 1;
            this.btnsaoluu.IdleBorderThickness = 1;
            this.btnsaoluu.IdleFillColor = System.Drawing.Color.LimeGreen;
            this.btnsaoluu.IdleIconLeftImage = null;
            this.btnsaoluu.IdleIconRightImage = null;
            this.btnsaoluu.IndicateFocus = false;
            this.btnsaoluu.Location = new System.Drawing.Point(26, 131);
            this.btnsaoluu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnsaoluu.Name = "btnsaoluu";
            this.btnsaoluu.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnsaoluu.OnDisabledState.BorderRadius = 1;
            this.btnsaoluu.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnsaoluu.OnDisabledState.BorderThickness = 1;
            this.btnsaoluu.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnsaoluu.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnsaoluu.OnDisabledState.IconLeftImage = null;
            this.btnsaoluu.OnDisabledState.IconRightImage = null;
            this.btnsaoluu.onHoverState.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnsaoluu.onHoverState.BorderRadius = 1;
            this.btnsaoluu.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnsaoluu.onHoverState.BorderThickness = 1;
            this.btnsaoluu.onHoverState.FillColor = System.Drawing.Color.SeaGreen;
            this.btnsaoluu.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnsaoluu.onHoverState.IconLeftImage = null;
            this.btnsaoluu.onHoverState.IconRightImage = null;
            this.btnsaoluu.OnIdleState.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnsaoluu.OnIdleState.BorderRadius = 1;
            this.btnsaoluu.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnsaoluu.OnIdleState.BorderThickness = 1;
            this.btnsaoluu.OnIdleState.FillColor = System.Drawing.Color.LimeGreen;
            this.btnsaoluu.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnsaoluu.OnIdleState.IconLeftImage = null;
            this.btnsaoluu.OnIdleState.IconRightImage = null;
            this.btnsaoluu.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnsaoluu.OnPressedState.BorderRadius = 1;
            this.btnsaoluu.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnsaoluu.OnPressedState.BorderThickness = 1;
            this.btnsaoluu.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnsaoluu.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnsaoluu.OnPressedState.IconLeftImage = null;
            this.btnsaoluu.OnPressedState.IconRightImage = null;
            this.btnsaoluu.Size = new System.Drawing.Size(112, 32);
            this.btnsaoluu.TabIndex = 11;
            this.btnsaoluu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnsaoluu.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnsaoluu.TextMarginLeft = 0;
            this.btnsaoluu.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnsaoluu.UseDefaultRadiusAndThickness = true;
            this.btnsaoluu.Click += new System.EventHandler(this.btnsaoluu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Chọn đường dẫn lưu dữ liệu backup";
            // 
            // btnfoler
            // 
            this.btnfoler.ActiveImage = null;
            this.btnfoler.AllowAnimations = true;
            this.btnfoler.AllowBuffering = false;
            this.btnfoler.AllowToggling = false;
            this.btnfoler.AllowZooming = false;
            this.btnfoler.AllowZoomingOnFocus = false;
            this.btnfoler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnfoler.BackColor = System.Drawing.Color.Transparent;
            this.btnfoler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfoler.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnfoler.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnfoler.ErrorImage")));
            this.btnfoler.FadeWhenInactive = false;
            this.btnfoler.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnfoler.Image = ((System.Drawing.Image)(resources.GetObject("btnfoler.Image")));
            this.btnfoler.ImageActive = null;
            this.btnfoler.ImageLocation = null;
            this.btnfoler.ImageMargin = 40;
            this.btnfoler.ImageSize = new System.Drawing.Size(24, 20);
            this.btnfoler.ImageZoomSize = new System.Drawing.Size(64, 60);
            this.btnfoler.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnfoler.InitialImage")));
            this.btnfoler.Location = new System.Drawing.Point(364, 66);
            this.btnfoler.Name = "btnfoler";
            this.btnfoler.Rotation = 0;
            this.btnfoler.ShowActiveImage = true;
            this.btnfoler.ShowCursorChanges = true;
            this.btnfoler.ShowImageBorders = false;
            this.btnfoler.ShowSizeMarkers = false;
            this.btnfoler.Size = new System.Drawing.Size(64, 60);
            this.btnfoler.TabIndex = 8;
            this.btnfoler.ToolTipText = "";
            this.btnfoler.WaitOnLoad = false;
            this.btnfoler.Zoom = 40;
            this.btnfoler.ZoomSpeed = 10;
            this.btnfoler.Click += new System.EventHandler(this.btnfoler_Click);
            // 
            // txtfolder
            // 
            this.txtfolder.AcceptsReturn = false;
            this.txtfolder.AcceptsTab = false;
            this.txtfolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtfolder.AnimationSpeed = 200;
            this.txtfolder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtfolder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtfolder.BackColor = System.Drawing.Color.Transparent;
            this.txtfolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtfolder.BackgroundImage")));
            this.txtfolder.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtfolder.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtfolder.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtfolder.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtfolder.BorderRadius = 7;
            this.txtfolder.BorderThickness = 1;
            this.txtfolder.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtfolder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfolder.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtfolder.DefaultText = "";
            this.txtfolder.Enabled = false;
            this.txtfolder.FillColor = System.Drawing.Color.White;
            this.txtfolder.HideSelection = true;
            this.txtfolder.IconLeft = null;
            this.txtfolder.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfolder.IconPadding = 10;
            this.txtfolder.IconRight = null;
            this.txtfolder.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfolder.Lines = new string[0];
            this.txtfolder.Location = new System.Drawing.Point(26, 77);
            this.txtfolder.MaxLength = 32767;
            this.txtfolder.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtfolder.Modified = false;
            this.txtfolder.Multiline = false;
            this.txtfolder.Name = "txtfolder";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtfolder.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtfolder.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtfolder.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtfolder.OnIdleState = stateProperties8;
            this.txtfolder.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txtfolder.PasswordChar = '\0';
            this.txtfolder.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtfolder.PlaceholderText = "Đường dẫn";
            this.txtfolder.ReadOnly = false;
            this.txtfolder.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtfolder.SelectedText = "";
            this.txtfolder.SelectionLength = 0;
            this.txtfolder.SelectionStart = 0;
            this.txtfolder.ShortcutsEnabled = true;
            this.txtfolder.Size = new System.Drawing.Size(317, 32);
            this.txtfolder.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtfolder.TabIndex = 7;
            this.txtfolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtfolder.TextMarginBottom = 0;
            this.txtfolder.TextMarginLeft = 3;
            this.txtfolder.TextMarginTop = 0;
            this.txtfolder.TextPlaceholder = "Đường dẫn";
            this.txtfolder.UseSystemPasswordChar = false;
            this.txtfolder.WordWrap = true;
            this.txtfolder.TextChanged += new System.EventHandler(this.bunifuTextBox3_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bunifuSnackbar1
            // 
            this.bunifuSnackbar1.AllowDragging = false;
            this.bunifuSnackbar1.AllowMultipleViews = true;
            this.bunifuSnackbar1.ClickToClose = true;
            this.bunifuSnackbar1.DoubleClickToClose = true;
            this.bunifuSnackbar1.DurationAfterIdle = 3000;
            this.bunifuSnackbar1.ErrorOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.ErrorOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.ErrorOptions.ActionBorderRadius = 1;
            this.bunifuSnackbar1.ErrorOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.bunifuSnackbar1.ErrorOptions.ActionForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.ErrorOptions.BackColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.ErrorOptions.BorderColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.ErrorOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(199)))));
            this.bunifuSnackbar1.ErrorOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuSnackbar1.ErrorOptions.ForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.ErrorOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon")));
            this.bunifuSnackbar1.ErrorOptions.IconLeftMargin = 12;
            this.bunifuSnackbar1.FadeCloseIcon = false;
            this.bunifuSnackbar1.Host = Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner;
            this.bunifuSnackbar1.InformationOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.InformationOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.InformationOptions.ActionBorderRadius = 1;
            this.bunifuSnackbar1.InformationOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.bunifuSnackbar1.InformationOptions.ActionForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.InformationOptions.BackColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.InformationOptions.BorderColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.InformationOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.InformationOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuSnackbar1.InformationOptions.ForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.InformationOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon1")));
            this.bunifuSnackbar1.InformationOptions.IconLeftMargin = 12;
            this.bunifuSnackbar1.Margin = 10;
            this.bunifuSnackbar1.MaximumSize = new System.Drawing.Size(0, 0);
            this.bunifuSnackbar1.MaximumViews = 7;
            this.bunifuSnackbar1.MessageRightMargin = 15;
            this.bunifuSnackbar1.MinimumSize = new System.Drawing.Size(0, 0);
            this.bunifuSnackbar1.ShowBorders = false;
            this.bunifuSnackbar1.ShowCloseIcon = false;
            this.bunifuSnackbar1.ShowIcon = true;
            this.bunifuSnackbar1.ShowShadows = true;
            this.bunifuSnackbar1.SuccessOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.SuccessOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.SuccessOptions.ActionBorderRadius = 1;
            this.bunifuSnackbar1.SuccessOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.bunifuSnackbar1.SuccessOptions.ActionForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.SuccessOptions.BackColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.SuccessOptions.BorderColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.SuccessOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(255)))), ((int)(((byte)(237)))));
            this.bunifuSnackbar1.SuccessOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuSnackbar1.SuccessOptions.ForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.SuccessOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon2")));
            this.bunifuSnackbar1.SuccessOptions.IconLeftMargin = 12;
            this.bunifuSnackbar1.ViewsMargin = 7;
            this.bunifuSnackbar1.WarningOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.WarningOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.WarningOptions.ActionBorderRadius = 1;
            this.bunifuSnackbar1.WarningOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.bunifuSnackbar1.WarningOptions.ActionForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.WarningOptions.BackColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.WarningOptions.BorderColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.WarningOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(143)))));
            this.bunifuSnackbar1.WarningOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuSnackbar1.WarningOptions.ForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.WarningOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon3")));
            this.bunifuSnackbar1.WarningOptions.IconLeftMargin = 12;
            this.bunifuSnackbar1.ZoomCloseIcon = true;
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 550);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormBackup";
            this.Text = "FormBackup";
            this.Load += new System.EventHandler(this.FormBackup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Bunifu.UI.WinForms.BunifuTextBox txtfolder;
        private Bunifu.UI.WinForms.BunifuImageButton btnfoler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnsaoluu;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnphuchoi;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuSnackbar bunifuSnackbar1;
    }
}