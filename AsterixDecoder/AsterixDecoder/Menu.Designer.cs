﻿
namespace AsterixDecoder
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MapViewButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CAT10button = new System.Windows.Forms.Button();
            this.CAT21Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.panelName = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panelSideMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSideMenu.Controls.Add(this.panel2);
            this.panelSideMenu.Controls.Add(this.panel1);
            this.panelSideMenu.Controls.Add(this.button1);
            this.panelSideMenu.Controls.Add(this.LoadFileButton);
            this.panelSideMenu.Controls.Add(this.panelName);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(187, 617);
            this.panelSideMenu.TabIndex = 0;
            this.panelSideMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSideMenu_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MapViewButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 253);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 81);
            this.panel2.TabIndex = 1;
            // 
            // MapViewButton
            // 
            this.MapViewButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MapViewButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MapViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapViewButton.Image = global::AsterixDecoder.Properties.Resources.map;
            this.MapViewButton.Location = new System.Drawing.Point(0, 28);
            this.MapViewButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MapViewButton.Name = "MapViewButton";
            this.MapViewButton.Size = new System.Drawing.Size(187, 53);
            this.MapViewButton.TabIndex = 1;
            this.MapViewButton.Text = "Map View";
            this.MapViewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MapViewButton.UseVisualStyleBackColor = false;
            this.MapViewButton.Click += new System.EventHandler(this.MapViewButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CAT10button);
            this.panel1.Controls.Add(this.CAT21Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 135);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 118);
            this.panel1.TabIndex = 1;
            // 
            // CAT10button
            // 
            this.CAT10button.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CAT10button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CAT10button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CAT10button.Location = new System.Drawing.Point(0, 46);
            this.CAT10button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CAT10button.Name = "CAT10button";
            this.CAT10button.Size = new System.Drawing.Size(187, 36);
            this.CAT10button.TabIndex = 1;
            this.CAT10button.Text = "Table CAT10";
            this.CAT10button.UseVisualStyleBackColor = false;
            this.CAT10button.Click += new System.EventHandler(this.CAT10button_Click);
            // 
            // CAT21Button
            // 
            this.CAT21Button.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CAT21Button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CAT21Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CAT21Button.Location = new System.Drawing.Point(0, 82);
            this.CAT21Button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CAT21Button.Name = "CAT21Button";
            this.CAT21Button.Size = new System.Drawing.Size(187, 36);
            this.CAT21Button.TabIndex = 1;
            this.CAT21Button.Text = "Table CAT21";
            this.CAT21Button.UseVisualStyleBackColor = false;
            this.CAT21Button.Click += new System.EventHandler(this.CAT21Button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 168);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LoadFileButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoadFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadFileButton.Image = global::AsterixDecoder.Properties.Resources.loadfile1;
            this.LoadFileButton.Location = new System.Drawing.Point(0, 90);
            this.LoadFileButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(187, 45);
            this.LoadFileButton.TabIndex = 1;
            this.LoadFileButton.Text = "Load File";
            this.LoadFileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.LoadFileButton.UseVisualStyleBackColor = false;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // panelName
            // 
            this.panelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelName.Location = new System.Drawing.Point(0, 0);
            this.panelName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(187, 90);
            this.panelName.TabIndex = 0;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelChildForm.Controls.Add(this.progressBar1);
            this.panelChildForm.Controls.Add(this.pictureBox1);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.ForeColor = System.Drawing.SystemColors.Control;
            this.panelChildForm.Location = new System.Drawing.Point(187, 0);
            this.panelChildForm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(932, 617);
            this.panelChildForm.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(932, 617);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(337, 469);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(284, 22);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 617);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelSideMenu);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Menu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Menu";
            this.panelSideMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelChildForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button MapViewButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CAT10button;
        private System.Windows.Forms.Button CAT21Button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}