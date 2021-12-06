﻿
namespace AsterixDecoder
{
    partial class Map
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEliminate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.txtlongitude = new System.Windows.Forms.TextBox();
            this.txtlatitude = new System.Windows.Forms.TextBox();
            this.btnRoute = new System.Windows.Forms.Button();
            this.btnPolygon = new System.Windows.Forms.Button();
            this.btnSat = new System.Windows.Forms.Button();
            this.btnOriginal = new System.Windows.Forms.Button();
            this.btnRelieve = new System.Windows.Forms.Button();
            this.trackZoom = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.horaFin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timeButton = new System.Windows.Forms.Button();
            this.minFin = new System.Windows.Forms.TextBox();
            this.segFin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.segInicio = new System.Windows.Forms.TextBox();
            this.minInicio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.horaInicio = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SearchId = new System.Windows.Forms.Button();
            this.x2 = new System.Windows.Forms.Button();
            this.x3 = new System.Windows.Forms.Button();
            this.x1 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.viewAll = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PlayPause = new System.Windows.Forms.Button();
            this.spnbtn = new System.Windows.Forms.Button();
            this.earthbtn = new System.Windows.Forms.Button();
            this.catabtn = new System.Windows.Forms.Button();
            this.pratbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(13, 14);
            this.gMapControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(1139, 610);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
            this.gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(1206, 665);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnEliminate
            // 
            this.btnEliminate.FlatAppearance.BorderSize = 0;
            this.btnEliminate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnEliminate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminate.ForeColor = System.Drawing.Color.Black;
            this.btnEliminate.Location = new System.Drawing.Point(1324, 665);
            this.btnEliminate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminate.Name = "btnEliminate";
            this.btnEliminate.Size = new System.Drawing.Size(95, 28);
            this.btnEliminate.TabIndex = 2;
            this.btnEliminate.Text = "Eliminate";
            this.btnEliminate.UseVisualStyleBackColor = true;
            this.btnEliminate.Click += new System.EventHandler(this.btnEliminate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(852, 642);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(852, 690);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Longitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(997, 688);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Longitude";
            // 
            // txtdescription
            // 
            this.txtdescription.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtdescription.Location = new System.Drawing.Point(855, 664);
            this.txtdescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(100, 22);
            this.txtdescription.TabIndex = 7;
            // 
            // txtlongitude
            // 
            this.txtlongitude.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtlongitude.Location = new System.Drawing.Point(1000, 710);
            this.txtlongitude.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtlongitude.Name = "txtlongitude";
            this.txtlongitude.Size = new System.Drawing.Size(100, 22);
            this.txtlongitude.TabIndex = 8;
            // 
            // txtlatitude
            // 
            this.txtlatitude.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtlatitude.Location = new System.Drawing.Point(855, 710);
            this.txtlatitude.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtlatitude.Name = "txtlatitude";
            this.txtlatitude.Size = new System.Drawing.Size(100, 22);
            this.txtlatitude.TabIndex = 9;
            // 
            // btnRoute
            // 
            this.btnRoute.FlatAppearance.BorderSize = 0;
            this.btnRoute.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoute.ForeColor = System.Drawing.Color.Black;
            this.btnRoute.Location = new System.Drawing.Point(1210, 714);
            this.btnRoute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRoute.Name = "btnRoute";
            this.btnRoute.Size = new System.Drawing.Size(95, 30);
            this.btnRoute.TabIndex = 13;
            this.btnRoute.Text = "Route";
            this.btnRoute.UseVisualStyleBackColor = true;
            this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
            // 
            // btnPolygon
            // 
            this.btnPolygon.FlatAppearance.BorderSize = 0;
            this.btnPolygon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnPolygon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPolygon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPolygon.ForeColor = System.Drawing.Color.Black;
            this.btnPolygon.Location = new System.Drawing.Point(1324, 714);
            this.btnPolygon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(95, 30);
            this.btnPolygon.TabIndex = 14;
            this.btnPolygon.Text = "Polygon";
            this.btnPolygon.UseVisualStyleBackColor = true;
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // btnSat
            // 
            this.btnSat.FlatAppearance.BorderSize = 0;
            this.btnSat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnSat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSat.Location = new System.Drawing.Point(15, 634);
            this.btnSat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSat.Name = "btnSat";
            this.btnSat.Size = new System.Drawing.Size(88, 39);
            this.btnSat.TabIndex = 15;
            this.btnSat.Text = "Satellite";
            this.btnSat.UseVisualStyleBackColor = true;
            this.btnSat.Click += new System.EventHandler(this.btnSat_Click);
            // 
            // btnOriginal
            // 
            this.btnOriginal.FlatAppearance.BorderSize = 0;
            this.btnOriginal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnOriginal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOriginal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOriginal.Location = new System.Drawing.Point(109, 629);
            this.btnOriginal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOriginal.Name = "btnOriginal";
            this.btnOriginal.Size = new System.Drawing.Size(91, 39);
            this.btnOriginal.TabIndex = 16;
            this.btnOriginal.Text = "Normal";
            this.btnOriginal.UseVisualStyleBackColor = true;
            this.btnOriginal.Click += new System.EventHandler(this.btnOriginal_Click);
            // 
            // btnRelieve
            // 
            this.btnRelieve.FlatAppearance.BorderSize = 0;
            this.btnRelieve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnRelieve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelieve.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelieve.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRelieve.Location = new System.Drawing.Point(206, 629);
            this.btnRelieve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRelieve.Name = "btnRelieve";
            this.btnRelieve.Size = new System.Drawing.Size(120, 39);
            this.btnRelieve.TabIndex = 17;
            this.btnRelieve.Text = "Topography";
            this.btnRelieve.UseVisualStyleBackColor = true;
            this.btnRelieve.Click += new System.EventHandler(this.btnRelieve_Click);
            // 
            // trackZoom
            // 
            this.trackZoom.Location = new System.Drawing.Point(412, 629);
            this.trackZoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackZoom.Maximum = 25;
            this.trackZoom.Name = "trackZoom";
            this.trackZoom.Size = new System.Drawing.Size(296, 56);
            this.trackZoom.TabIndex = 18;
            this.trackZoom.ValueChanged += new System.EventHandler(this.trackZoom_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(332, 634);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Zoom:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // horaFin
            // 
            this.horaFin.Location = new System.Drawing.Point(1241, 65);
            this.horaFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.horaFin.Name = "horaFin";
            this.horaFin.Size = new System.Drawing.Size(28, 22);
            this.horaFin.TabIndex = 25;
            this.horaFin.Text = "08";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1275, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = ":";
            // 
            // timeButton
            // 
            this.timeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeButton.Location = new System.Drawing.Point(1248, 97);
            this.timeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeButton.Name = "timeButton";
            this.timeButton.Size = new System.Drawing.Size(130, 33);
            this.timeButton.TabIndex = 27;
            this.timeButton.Text = "Search Time";
            this.timeButton.UseVisualStyleBackColor = true;
            this.timeButton.Click += new System.EventHandler(this.timeButton_Click);
            // 
            // minFin
            // 
            this.minFin.Location = new System.Drawing.Point(1296, 65);
            this.minFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.minFin.Name = "minFin";
            this.minFin.Size = new System.Drawing.Size(29, 22);
            this.minFin.TabIndex = 28;
            this.minFin.Text = "00";
            // 
            // segFin
            // 
            this.segFin.Location = new System.Drawing.Point(1349, 65);
            this.segFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.segFin.Name = "segFin";
            this.segFin.Size = new System.Drawing.Size(27, 22);
            this.segFin.TabIndex = 29;
            this.segFin.Text = "02";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1335, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = ":";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(1171, 136);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar2.Maximum = 30;
            this.trackBar2.Minimum = -30;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(284, 56);
            this.trackBar2.TabIndex = 31;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1335, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 17);
            this.label7.TabIndex = 36;
            this.label7.Text = ":";
            // 
            // segInicio
            // 
            this.segInicio.Location = new System.Drawing.Point(1349, 33);
            this.segInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.segInicio.Name = "segInicio";
            this.segInicio.Size = new System.Drawing.Size(27, 22);
            this.segInicio.TabIndex = 35;
            this.segInicio.Text = "00";
            // 
            // minInicio
            // 
            this.minInicio.Location = new System.Drawing.Point(1296, 33);
            this.minInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.minInicio.Name = "minInicio";
            this.minInicio.Size = new System.Drawing.Size(29, 22);
            this.minInicio.TabIndex = 34;
            this.minInicio.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1275, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = ":";
            // 
            // horaInicio
            // 
            this.horaInicio.Location = new System.Drawing.Point(1241, 33);
            this.horaInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.horaInicio.Name = "horaInicio";
            this.horaInicio.Size = new System.Drawing.Size(28, 22);
            this.horaInicio.TabIndex = 32;
            this.horaInicio.Text = "08";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(752, 638);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 21);
            this.checkBox1.TabIndex = 37;
            this.checkBox1.Text = "SMR";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(752, 665);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(67, 21);
            this.checkBox2.TabIndex = 38;
            this.checkBox2.Text = "MLAT";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // SearchId
            // 
            this.SearchId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SearchId.Location = new System.Drawing.Point(974, 656);
            this.SearchId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchId.Name = "SearchId";
            this.SearchId.Size = new System.Drawing.Size(82, 30);
            this.SearchId.TabIndex = 39;
            this.SearchId.Text = "Search Id";
            this.SearchId.UseVisualStyleBackColor = true;
            this.SearchId.Click += new System.EventHandler(this.SearchId_Click);
            // 
            // x2
            // 
            this.x2.Location = new System.Drawing.Point(1324, 206);
            this.x2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(36, 28);
            this.x2.TabIndex = 41;
            this.x2.Text = "x2";
            this.x2.UseVisualStyleBackColor = true;
            this.x2.Click += new System.EventHandler(this.x2_Click);
            // 
            // x3
            // 
            this.x3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.x3.Location = new System.Drawing.Point(1380, 206);
            this.x3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.x3.Name = "x3";
            this.x3.Size = new System.Drawing.Size(43, 28);
            this.x3.TabIndex = 42;
            this.x3.Text = "x3";
            this.x3.UseVisualStyleBackColor = true;
            this.x3.Click += new System.EventHandler(this.x3_Click);
            // 
            // x1
            // 
            this.x1.Location = new System.Drawing.Point(1262, 206);
            this.x1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(43, 28);
            this.x1.TabIndex = 43;
            this.x1.Text = "x1";
            this.x1.UseVisualStyleBackColor = true;
            this.x1.Click += new System.EventHandler(this.x1_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(752, 689);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(67, 21);
            this.checkBox3.TabIndex = 44;
            this.checkBox3.Text = "ADSB";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // viewAll
            // 
            this.viewAll.Location = new System.Drawing.Point(1063, 656);
            this.viewAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.viewAll.Name = "viewAll";
            this.viewAll.Size = new System.Drawing.Size(82, 30);
            this.viewAll.TabIndex = 45;
            this.viewAll.Text = "View All";
            this.viewAll.UseVisualStyleBackColor = true;
            this.viewAll.Click += new System.EventHandler(this.viewAll_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(752, 714);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(85, 21);
            this.checkBox4.TabIndex = 46;
            this.checkBox4.Text = "View Old";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(95)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.GhostWhite;
            this.dataGridView1.Location = new System.Drawing.Point(1191, 253);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(252, 405);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectRegister);
            // 
            // PlayPause
            // 
            this.PlayPause.Image = ((System.Drawing.Image)(resources.GetObject("PlayPause.Image")));
            this.PlayPause.Location = new System.Drawing.Point(1191, 206);
            this.PlayPause.Margin = new System.Windows.Forms.Padding(4);
            this.PlayPause.Name = "PlayPause";
            this.PlayPause.Size = new System.Drawing.Size(48, 28);
            this.PlayPause.TabIndex = 40;
            this.PlayPause.Text = "⏸️";
            this.PlayPause.UseVisualStyleBackColor = true;
            this.PlayPause.Click += new System.EventHandler(this.PlayPause_Click);
            // 
            // spnbtn
            // 
            this.spnbtn.FlatAppearance.BorderSize = 0;
            this.spnbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.spnbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.spnbtn.Image = global::AsterixDecoder.Properties.Resources.spain1;
            this.spnbtn.Location = new System.Drawing.Point(612, 686);
            this.spnbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spnbtn.Name = "spnbtn";
            this.spnbtn.Size = new System.Drawing.Size(53, 50);
            this.spnbtn.TabIndex = 24;
            this.spnbtn.UseVisualStyleBackColor = true;
            this.spnbtn.Click += new System.EventHandler(this.spnbtn_Click);
            // 
            // earthbtn
            // 
            this.earthbtn.FlatAppearance.BorderSize = 0;
            this.earthbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.earthbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.earthbtn.Image = global::AsterixDecoder.Properties.Resources.earth1;
            this.earthbtn.Location = new System.Drawing.Point(494, 686);
            this.earthbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.earthbtn.Name = "earthbtn";
            this.earthbtn.Size = new System.Drawing.Size(51, 50);
            this.earthbtn.TabIndex = 23;
            this.earthbtn.UseVisualStyleBackColor = true;
            this.earthbtn.Click += new System.EventHandler(this.earthbtn_Click);
            // 
            // catabtn
            // 
            this.catabtn.FlatAppearance.BorderSize = 0;
            this.catabtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.catabtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.catabtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.catabtn.Image = global::AsterixDecoder.Properties.Resources.catalunya22;
            this.catabtn.Location = new System.Drawing.Point(551, 686);
            this.catabtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.catabtn.Name = "catabtn";
            this.catabtn.Size = new System.Drawing.Size(53, 50);
            this.catabtn.TabIndex = 22;
            this.catabtn.UseVisualStyleBackColor = true;
            this.catabtn.Click += new System.EventHandler(this.catabtn_Click);
            // 
            // pratbtn
            // 
            this.pratbtn.FlatAppearance.BorderSize = 0;
            this.pratbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.pratbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pratbtn.Image = global::AsterixDecoder.Properties.Resources.airport2;
            this.pratbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pratbtn.Location = new System.Drawing.Point(439, 686);
            this.pratbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pratbtn.Name = "pratbtn";
            this.pratbtn.Size = new System.Drawing.Size(51, 50);
            this.pratbtn.TabIndex = 21;
            this.pratbtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pratbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.pratbtn.UseVisualStyleBackColor = true;
            this.pratbtn.Click += new System.EventHandler(this.pratbtn_Click);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(95)))));
            this.ClientSize = new System.Drawing.Size(1476, 890);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.viewAll);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.x3);
            this.Controls.Add(this.x2);
            this.Controls.Add(this.PlayPause);
            this.Controls.Add(this.SearchId);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.segInicio);
            this.Controls.Add(this.minInicio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.horaInicio);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.segFin);
            this.Controls.Add(this.minFin);
            this.Controls.Add(this.timeButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.horaFin);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.spnbtn);
            this.Controls.Add(this.earthbtn);
            this.Controls.Add(this.catabtn);
            this.Controls.Add(this.pratbtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackZoom);
            this.Controls.Add(this.btnRelieve);
            this.Controls.Add(this.btnOriginal);
            this.Controls.Add(this.btnSat);
            this.Controls.Add(this.btnPolygon);
            this.Controls.Add(this.btnRoute);
            this.Controls.Add(this.txtlatitude);
            this.Controls.Add(this.txtlongitude);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gMapControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Map";
            this.Text = "Map";
            this.Load += new System.EventHandler(this.Map_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEliminate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.TextBox txtlongitude;
        private System.Windows.Forms.TextBox txtlatitude;
        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.Button btnPolygon;
        private System.Windows.Forms.Button btnSat;
        private System.Windows.Forms.Button btnOriginal;
        private System.Windows.Forms.Button btnRelieve;
        private System.Windows.Forms.TrackBar trackZoom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button catabtn;
        private System.Windows.Forms.Button earthbtn;
        public System.Windows.Forms.Button pratbtn;
        private System.Windows.Forms.Button spnbtn;
        private System.Windows.Forms.TextBox horaFin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button timeButton;
        private System.Windows.Forms.TextBox minFin;
        private System.Windows.Forms.TextBox segFin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox segInicio;
        private System.Windows.Forms.TextBox minInicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox horaInicio;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button SearchId;
        private System.Windows.Forms.Button PlayPause;
        private System.Windows.Forms.Button x2;
        private System.Windows.Forms.Button x3;
        private System.Windows.Forms.Button x1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button viewAll;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}