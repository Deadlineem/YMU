namespace YimUpdater
{
    partial class MainGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBox1 = new PictureBox();
            CloseBtn = new Button();
            minBtn = new Button();
            guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            YimMenu_Tab = new TabPage();
            howToGuide = new Guna.UI2.WinForms.Guna2Button();
            uninstallYimMenu = new Guna.UI2.WinForms.Guna2Button();
            deleteCache = new Guna.UI2.WinForms.Guna2Button();
            downloadYimMenu = new Guna.UI2.WinForms.Guna2Button();
            LuaScripts_Tab = new TabPage();
            Addons_Tab = new TabPage();
            installYimASI = new Guna.UI2.WinForms.Guna2Button();
            installXMLs = new Guna.UI2.WinForms.Guna2Button();
            downloadAnimations = new Guna.UI2.WinForms.Guna2Button();
            HorseMenu_Tab = new TabPage();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            progressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            logoImage = new Guna.UI2.WinForms.Guna2ImageButton();
            programTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            downloadHorseMenu = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2TabControl1.SuspendLayout();
            YimMenu_Tab.SuspendLayout();
            Addons_Tab.SuspendLayout();
            HorseMenu_Tab.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(393, 44);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += TitleBarMouseDown;
            pictureBox1.MouseMove += TitleBarDrag;
            pictureBox1.MouseUp += TitleBarMouseUp;
            // 
            // CloseBtn
            // 
            CloseBtn.BackColor = Color.Transparent;
            CloseBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.closeBtn;
            CloseBtn.BackgroundImageLayout = ImageLayout.Center;
            CloseBtn.FlatAppearance.BorderSize = 0;
            CloseBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            CloseBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            CloseBtn.FlatStyle = FlatStyle.Flat;
            CloseBtn.ForeColor = SystemColors.Desktop;
            CloseBtn.Location = new Point(1002, 4);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(105, 35);
            CloseBtn.TabIndex = 2;
            CloseBtn.UseVisualStyleBackColor = false;
            CloseBtn.Click += CloseBtn_Click;
            CloseBtn.MouseLeave += CloseBtn_Leave;
            CloseBtn.MouseHover += CloseBtn_Hover;
            // 
            // minBtn
            // 
            minBtn.BackColor = Color.Transparent;
            minBtn.BackgroundImage = YimMenu_Updater.Properties.Resources.minBtn;
            minBtn.BackgroundImageLayout = ImageLayout.Center;
            minBtn.FlatAppearance.BorderSize = 0;
            minBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            minBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            minBtn.FlatStyle = FlatStyle.Flat;
            minBtn.Location = new Point(891, 4);
            minBtn.Name = "minBtn";
            minBtn.Size = new Size(105, 35);
            minBtn.TabIndex = 3;
            minBtn.UseVisualStyleBackColor = false;
            minBtn.Click += MinBtn_Click;
            minBtn.MouseLeave += MinBtn_Leave;
            minBtn.MouseHover += MinBtn_Hover;
            // 
            // guna2TabControl1
            // 
            guna2TabControl1.Controls.Add(YimMenu_Tab);
            guna2TabControl1.Controls.Add(LuaScripts_Tab);
            guna2TabControl1.Controls.Add(Addons_Tab);
            guna2TabControl1.Controls.Add(HorseMenu_Tab);
            guna2TabControl1.Controls.Add(tabPage1);
            guna2TabControl1.Controls.Add(tabPage2);
            guna2TabControl1.ItemSize = new Size(173, 40);
            guna2TabControl1.Location = new Point(40, 81);
            guna2TabControl1.Margin = new Padding(0);
            guna2TabControl1.Name = "guna2TabControl1";
            guna2TabControl1.SelectedIndex = 0;
            guna2TabControl1.Size = new Size(1044, 540);
            guna2TabControl1.TabButtonHoverState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonHoverState.FillColor = Color.FromArgb(171, 75, 40);
            guna2TabControl1.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonHoverState.ForeColor = Color.White;
            guna2TabControl1.TabButtonHoverState.InnerColor = Color.FromArgb(200, 50, 50);
            guna2TabControl1.TabButtonIdleState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonIdleState.FillColor = Color.FromArgb(155, 0, 0);
            guna2TabControl1.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            guna2TabControl1.TabButtonIdleState.InnerColor = Color.FromArgb(157, 74, 40);
            guna2TabControl1.TabButtonSelectedState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonSelectedState.FillColor = Color.FromArgb(100, 0, 0);
            guna2TabControl1.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonSelectedState.ForeColor = Color.White;
            guna2TabControl1.TabButtonSelectedState.InnerColor = Color.FromArgb(30, 30, 30);
            guna2TabControl1.TabButtonSize = new Size(173, 40);
            guna2TabControl1.TabIndex = 4;
            guna2TabControl1.TabMenuBackColor = Color.FromArgb(30, 30, 30);
            guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // YimMenu_Tab
            // 
            YimMenu_Tab.BackColor = Color.FromArgb(30, 30, 30);
            YimMenu_Tab.Controls.Add(howToGuide);
            YimMenu_Tab.Controls.Add(uninstallYimMenu);
            YimMenu_Tab.Controls.Add(deleteCache);
            YimMenu_Tab.Controls.Add(downloadYimMenu);
            YimMenu_Tab.ForeColor = SystemColors.Desktop;
            YimMenu_Tab.Location = new Point(4, 44);
            YimMenu_Tab.Name = "YimMenu_Tab";
            YimMenu_Tab.Padding = new Padding(3);
            YimMenu_Tab.Size = new Size(1036, 492);
            YimMenu_Tab.TabIndex = 0;
            YimMenu_Tab.Text = "YimMenu";
            // 
            // howToGuide
            // 
            howToGuide.BorderRadius = 10;
            howToGuide.CustomizableEdges = customizableEdges1;
            howToGuide.DisabledState.BorderColor = Color.DarkGray;
            howToGuide.DisabledState.CustomBorderColor = Color.DarkGray;
            howToGuide.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            howToGuide.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            howToGuide.FillColor = Color.FromArgb(155, 0, 0);
            howToGuide.Font = new Font("Segoe UI", 9F);
            howToGuide.ForeColor = Color.White;
            howToGuide.Location = new Point(509, 6);
            howToGuide.Name = "howToGuide";
            howToGuide.ShadowDecoration.CustomizableEdges = customizableEdges2;
            howToGuide.Size = new Size(155, 45);
            howToGuide.TabIndex = 3;
            howToGuide.Text = "YimMenu How-To";
            howToGuide.Click += howToGuide_Click;
            // 
            // uninstallYimMenu
            // 
            uninstallYimMenu.BorderRadius = 10;
            uninstallYimMenu.CustomizableEdges = customizableEdges3;
            uninstallYimMenu.DisabledState.BorderColor = Color.DarkGray;
            uninstallYimMenu.DisabledState.CustomBorderColor = Color.DarkGray;
            uninstallYimMenu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            uninstallYimMenu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            uninstallYimMenu.FillColor = Color.FromArgb(155, 0, 0);
            uninstallYimMenu.Font = new Font("Segoe UI", 9F);
            uninstallYimMenu.ForeColor = Color.White;
            uninstallYimMenu.Location = new Point(340, 6);
            uninstallYimMenu.Margin = new Padding(6);
            uninstallYimMenu.Name = "uninstallYimMenu";
            uninstallYimMenu.ShadowDecoration.CustomizableEdges = customizableEdges4;
            uninstallYimMenu.Size = new Size(155, 45);
            uninstallYimMenu.TabIndex = 2;
            uninstallYimMenu.Text = "Uninstall YimMenu";
            uninstallYimMenu.Click += uninstallYimMenu_Click;
            // 
            // deleteCache
            // 
            deleteCache.BorderRadius = 10;
            deleteCache.CustomizableEdges = customizableEdges5;
            deleteCache.DisabledState.BorderColor = Color.DarkGray;
            deleteCache.DisabledState.CustomBorderColor = Color.DarkGray;
            deleteCache.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            deleteCache.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            deleteCache.FillColor = Color.FromArgb(155, 0, 0);
            deleteCache.Font = new Font("Segoe UI", 9F);
            deleteCache.ForeColor = Color.White;
            deleteCache.Location = new Point(173, 6);
            deleteCache.Margin = new Padding(6);
            deleteCache.Name = "deleteCache";
            deleteCache.ShadowDecoration.CustomizableEdges = customizableEdges6;
            deleteCache.Size = new Size(155, 45);
            deleteCache.TabIndex = 1;
            deleteCache.Text = "Delete Cache";
            deleteCache.Click += deleteCache_Click;
            // 
            // downloadYimMenu
            // 
            downloadYimMenu.BorderRadius = 10;
            downloadYimMenu.CustomizableEdges = customizableEdges7;
            downloadYimMenu.DisabledState.BorderColor = Color.DarkGray;
            downloadYimMenu.DisabledState.CustomBorderColor = Color.DarkGray;
            downloadYimMenu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            downloadYimMenu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            downloadYimMenu.FillColor = Color.FromArgb(155, 0, 0);
            downloadYimMenu.Font = new Font("Segoe UI", 9F);
            downloadYimMenu.ForeColor = Color.White;
            downloadYimMenu.Location = new Point(6, 6);
            downloadYimMenu.Margin = new Padding(6);
            downloadYimMenu.Name = "downloadYimMenu";
            downloadYimMenu.ShadowDecoration.CustomizableEdges = customizableEdges8;
            downloadYimMenu.Size = new Size(155, 45);
            downloadYimMenu.TabIndex = 0;
            downloadYimMenu.Text = "Download YimMenu";
            downloadYimMenu.Click += downloadYimMenu_Click;
            // 
            // LuaScripts_Tab
            // 
            LuaScripts_Tab.BackColor = Color.FromArgb(30, 30, 30);
            LuaScripts_Tab.Location = new Point(4, 44);
            LuaScripts_Tab.Name = "LuaScripts_Tab";
            LuaScripts_Tab.Size = new Size(1036, 492);
            LuaScripts_Tab.TabIndex = 1;
            LuaScripts_Tab.Text = "Lua Scripts";
            // 
            // Addons_Tab
            // 
            Addons_Tab.BackColor = Color.FromArgb(30, 30, 30);
            Addons_Tab.Controls.Add(installYimASI);
            Addons_Tab.Controls.Add(installXMLs);
            Addons_Tab.Controls.Add(downloadAnimations);
            Addons_Tab.Location = new Point(4, 44);
            Addons_Tab.Name = "Addons_Tab";
            Addons_Tab.Size = new Size(1036, 492);
            Addons_Tab.TabIndex = 2;
            Addons_Tab.Text = "Addons";
            // 
            // installYimASI
            // 
            installYimASI.BorderRadius = 10;
            installYimASI.CustomizableEdges = customizableEdges9;
            installYimASI.DisabledState.BorderColor = Color.DarkGray;
            installYimASI.DisabledState.CustomBorderColor = Color.DarkGray;
            installYimASI.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            installYimASI.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            installYimASI.FillColor = Color.FromArgb(155, 0, 0);
            installYimASI.Font = new Font("Segoe UI", 9F);
            installYimASI.ForeColor = Color.White;
            installYimASI.Location = new Point(340, 6);
            installYimASI.Margin = new Padding(6);
            installYimASI.Name = "installYimASI";
            installYimASI.ShadowDecoration.CustomizableEdges = customizableEdges10;
            installYimASI.Size = new Size(155, 45);
            installYimASI.TabIndex = 3;
            installYimASI.Text = "Install YimASI";
            installYimASI.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            installYimASI.Click += installYimASI_Click;
            // 
            // installXMLs
            // 
            installXMLs.BorderRadius = 10;
            installXMLs.CustomizableEdges = customizableEdges11;
            installXMLs.DisabledState.BorderColor = Color.DarkGray;
            installXMLs.DisabledState.CustomBorderColor = Color.DarkGray;
            installXMLs.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            installXMLs.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            installXMLs.FillColor = Color.FromArgb(155, 0, 0);
            installXMLs.Font = new Font("Segoe UI", 9F);
            installXMLs.ForeColor = Color.White;
            installXMLs.Location = new Point(173, 6);
            installXMLs.Margin = new Padding(6);
            installXMLs.Name = "installXMLs";
            installXMLs.ShadowDecoration.CustomizableEdges = customizableEdges12;
            installXMLs.Size = new Size(155, 45);
            installXMLs.TabIndex = 2;
            installXMLs.Text = "Install XML's";
            installXMLs.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            installXMLs.Click += installXMLs_Click;
            // 
            // downloadAnimations
            // 
            downloadAnimations.BorderRadius = 10;
            downloadAnimations.CustomizableEdges = customizableEdges13;
            downloadAnimations.DisabledState.BorderColor = Color.DarkGray;
            downloadAnimations.DisabledState.CustomBorderColor = Color.DarkGray;
            downloadAnimations.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            downloadAnimations.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            downloadAnimations.FillColor = Color.FromArgb(155, 0, 0);
            downloadAnimations.Font = new Font("Segoe UI", 9F);
            downloadAnimations.ForeColor = Color.White;
            downloadAnimations.Location = new Point(6, 6);
            downloadAnimations.Margin = new Padding(6);
            downloadAnimations.Name = "downloadAnimations";
            downloadAnimations.ShadowDecoration.CustomizableEdges = customizableEdges14;
            downloadAnimations.Size = new Size(155, 45);
            downloadAnimations.TabIndex = 1;
            downloadAnimations.Text = "Install Animations";
            downloadAnimations.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            downloadAnimations.Click += downloadAnimations_Click;
            // 
            // HorseMenu_Tab
            // 
            HorseMenu_Tab.BackColor = Color.FromArgb(30, 30, 30);
            HorseMenu_Tab.Controls.Add(downloadHorseMenu);
            HorseMenu_Tab.Location = new Point(4, 44);
            HorseMenu_Tab.Name = "HorseMenu_Tab";
            HorseMenu_Tab.Size = new Size(1036, 492);
            HorseMenu_Tab.TabIndex = 3;
            HorseMenu_Tab.Text = "HorseMenu";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(30, 30, 30);
            tabPage1.Location = new Point(4, 44);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1036, 492);
            tabPage1.TabIndex = 4;
            tabPage1.Text = "Tools";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(30, 30, 30);
            tabPage2.Location = new Point(4, 44);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(1036, 492);
            tabPage2.TabIndex = 5;
            tabPage2.Text = "Settings";
            // 
            // progressBar1
            // 
            progressBar1.AutoRoundedCorners = true;
            progressBar1.BorderRadius = 10;
            progressBar1.CustomizableEdges = customizableEdges17;
            progressBar1.FillColor = Color.FromArgb(20, 20, 20);
            progressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            progressBar1.Location = new Point(408, 53);
            progressBar1.Name = "progressBar1";
            progressBar1.ProgressColor = Color.FromArgb(155, 0, 0);
            progressBar1.ProgressColor2 = Color.FromArgb(157, 74, 40);
            progressBar1.ShadowDecoration.CustomizableEdges = customizableEdges18;
            progressBar1.ShowText = true;
            progressBar1.Size = new Size(300, 22);
            progressBar1.TabIndex = 4;
            progressBar1.Text = "progressBar1";
            progressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            progressBar1.Visible = false;
            // 
            // logoImage
            // 
            logoImage.BackColor = Color.Transparent;
            logoImage.CheckedState.ImageSize = new Size(64, 64);
            logoImage.HoverState.ImageSize = new Size(64, 64);
            logoImage.Image = YimMenu_Updater.Properties.Resources.icon;
            logoImage.ImageOffset = new Point(0, 0);
            logoImage.ImageRotate = 0F;
            logoImage.Location = new Point(523, -1);
            logoImage.Name = "logoImage";
            logoImage.PressedState.ImageSize = new Size(64, 64);
            logoImage.ShadowDecoration.CustomizableEdges = customizableEdges19;
            logoImage.Size = new Size(71, 53);
            logoImage.TabIndex = 5;
            // 
            // programTitle
            // 
            programTitle.BackColor = Color.FromArgb(155, 0, 0);
            programTitle.BackgroundImageLayout = ImageLayout.None;
            programTitle.Enabled = false;
            programTitle.Font = new Font("Segoe UI", 14.25F);
            programTitle.ForeColor = Color.White;
            programTitle.Location = new Point(60, 12);
            programTitle.Name = "programTitle";
            programTitle.Size = new Size(157, 27);
            programTitle.TabIndex = 6;
            programTitle.Text = "YimMenu Updater";
            // 
            // downloadHorseMenu
            // 
            downloadHorseMenu.BorderRadius = 10;
            downloadHorseMenu.CustomizableEdges = customizableEdges15;
            downloadHorseMenu.DisabledState.BorderColor = Color.DarkGray;
            downloadHorseMenu.DisabledState.CustomBorderColor = Color.DarkGray;
            downloadHorseMenu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            downloadHorseMenu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            downloadHorseMenu.FillColor = Color.FromArgb(155, 0, 0);
            downloadHorseMenu.Font = new Font("Segoe UI", 9F);
            downloadHorseMenu.ForeColor = Color.White;
            downloadHorseMenu.Location = new Point(6, 6);
            downloadHorseMenu.Margin = new Padding(6);
            downloadHorseMenu.Name = "downloadHorseMenu";
            downloadHorseMenu.ShadowDecoration.CustomizableEdges = customizableEdges16;
            downloadHorseMenu.Size = new Size(155, 45);
            downloadHorseMenu.TabIndex = 4;
            downloadHorseMenu.Text = "Download HorseMenu";
            downloadHorseMenu.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            downloadHorseMenu.Click += downloadHorseMenu_Click;
            // 
            // MainGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            BackgroundImage = YimMenu_Updater.Properties.Resources.titlebar_buttons;
            ClientSize = new Size(1118, 628);
            Controls.Add(progressBar1);
            Controls.Add(programTitle);
            Controls.Add(logoImage);
            Controls.Add(guna2TabControl1);
            Controls.Add(minBtn);
            Controls.Add(CloseBtn);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MaximumSize = new Size(1118, 628);
            MinimizeBox = false;
            MinimumSize = new Size(1118, 628);
            Name = "MainGUI";
            ShowIcon = false;
            Text = "MainGUI";
            Load += MainGUI_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2TabControl1.ResumeLayout(false);
            YimMenu_Tab.ResumeLayout(false);
            Addons_Tab.ResumeLayout(false);
            HorseMenu_Tab.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button CloseBtn;
        private Button minBtn;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private TabPage YimMenu_Tab;
        private TabPage LuaScripts_Tab;
        private Guna.UI2.WinForms.Guna2Button downloadYimMenu;
        private Guna.UI2.WinForms.Guna2Button uninstallYimMenu;
        private Guna.UI2.WinForms.Guna2Button deleteCache;
        private Guna.UI2.WinForms.Guna2ImageButton logoImage;
        private Guna.UI2.WinForms.Guna2HtmlLabel programTitle;
        private Guna.UI2.WinForms.Guna2Button howToGuide;
        private TabPage Addons_Tab;
        private Guna.UI2.WinForms.Guna2Button installYimASI;
        private Guna.UI2.WinForms.Guna2Button installXMLs;
        private Guna.UI2.WinForms.Guna2Button downloadAnimations;
        private TabPage HorseMenu_Tab;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar1;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar1;
        private Guna.UI2.WinForms.Guna2Button downloadHorseMenu;
    }
}
