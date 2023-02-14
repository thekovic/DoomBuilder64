namespace CodeImp.DoomBuilder.Windows
{
    partial class SectorEditForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label labelTag;
            System.Windows.Forms.Label labelSpecial;
            System.Windows.Forms.GroupBox groupfloorceiling;
            System.Windows.Forms.Label labelFloorHeight;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label labelCeilingHeight;
            System.Windows.Forms.GroupBox incdecIntensity;
            System.Windows.Forms.GroupBox coloredLightingInfo;
            this.floorheight = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.ceilingheight = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.sectorheight = new System.Windows.Forms.Label();
            this.sectorheightlabel = new System.Windows.Forms.Label();
            this.floortex = new CodeImp.DoomBuilder.Controls.FlatSelectorControl();
            this.ceilingtex = new CodeImp.DoomBuilder.Controls.FlatSelectorControl();
            this.floorLightDecrease = new System.Windows.Forms.Button();
            this.floorLightIncrease = new System.Windows.Forms.Button();
            this.bottomWallLightDecrease = new System.Windows.Forms.Button();
            this.bottomWallLightIncrease = new System.Windows.Forms.Button();
            this.thingLightDecrease = new System.Windows.Forms.Button();
            this.thingLightIncrease = new System.Windows.Forms.Button();
            this.topWallLightDecrease = new System.Windows.Forms.Button();
            this.topWallLightIncrease = new System.Windows.Forms.Button();
            this.ceilingLightDecrease = new System.Windows.Forms.Button();
            this.ceilingLightIncrease = new System.Windows.Forms.Button();
            this.floorcolor = new CodeImp.DoomBuilder.Controls.ColorControlSector();
            this.lowercolor = new CodeImp.DoomBuilder.Controls.ColorControlSector();
            this.thingcolor = new CodeImp.DoomBuilder.Controls.ColorControlSector();
            this.topcolor = new CodeImp.DoomBuilder.Controls.ColorControlSector();
            this.ceilingcolor = new CodeImp.DoomBuilder.Controls.ColorControlSector();
            this.groupaction = new System.Windows.Forms.GroupBox();
            this.tag = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.newtag = new System.Windows.Forms.Button();
            this.groupeffect = new System.Windows.Forms.GroupBox();
            this.browseeffect = new System.Windows.Forms.Button();
            this.effect = new CodeImp.DoomBuilder.Controls.ActionSelectorControl();
            this.cancel = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.sectorproperties = new System.Windows.Forms.Panel();
            this.lightsPanel = new System.Windows.Forms.Panel();
            this.settingsgroup = new System.Windows.Forms.GroupBox();
            this.flags = new CodeImp.DoomBuilder.Controls.CheckboxArrayControl();
            this.flatSelectorControl2 = new CodeImp.DoomBuilder.Controls.FlatSelectorControl();
            this.flatSelectorControl1 = new CodeImp.DoomBuilder.Controls.FlatSelectorControl();
            this.heightpanel3 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            labelTag = new System.Windows.Forms.Label();
            labelSpecial = new System.Windows.Forms.Label();
            groupfloorceiling = new System.Windows.Forms.GroupBox();
            labelFloorHeight = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            labelCeilingHeight = new System.Windows.Forms.Label();
            incdecIntensity = new System.Windows.Forms.GroupBox();
            coloredLightingInfo = new System.Windows.Forms.GroupBox();
            groupfloorceiling.SuspendLayout();
            incdecIntensity.SuspendLayout();
            coloredLightingInfo.SuspendLayout();
            this.groupaction.SuspendLayout();
            this.groupeffect.SuspendLayout();
            this.sectorproperties.SuspendLayout();
            this.lightsPanel.SuspendLayout();
            this.settingsgroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(271, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 16);
            label1.TabIndex = 15;
            label1.Text = "Floor";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(363, 18);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 16);
            label3.TabIndex = 14;
            label3.Text = "Ceiling";
            label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelTag
            // 
            labelTag.AutoSize = true;
            labelTag.Location = new System.Drawing.Point(69, 26);
            labelTag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelTag.Name = "labelTag";
            labelTag.Size = new System.Drawing.Size(34, 16);
            labelTag.TabIndex = 9;
            labelTag.Text = "Tag:";
            // 
            // labelSpecial
            // 
            labelSpecial.AutoSize = true;
            labelSpecial.Location = new System.Drawing.Point(48, 31);
            labelSpecial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSpecial.Name = "labelSpecial";
            labelSpecial.Size = new System.Drawing.Size(57, 16);
            labelSpecial.TabIndex = 0;
            labelSpecial.Text = "Special:";
            // 
            // groupfloorceiling
            // 
            groupfloorceiling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupfloorceiling.Controls.Add(this.floorheight);
            groupfloorceiling.Controls.Add(this.ceilingheight);
            groupfloorceiling.Controls.Add(this.sectorheight);
            groupfloorceiling.Controls.Add(this.sectorheightlabel);
            groupfloorceiling.Controls.Add(labelFloorHeight);
            groupfloorceiling.Controls.Add(label2);
            groupfloorceiling.Controls.Add(label4);
            groupfloorceiling.Controls.Add(this.floortex);
            groupfloorceiling.Controls.Add(this.ceilingtex);
            groupfloorceiling.Controls.Add(labelCeilingHeight);
            groupfloorceiling.Location = new System.Drawing.Point(9, 8);
            groupfloorceiling.Margin = new System.Windows.Forms.Padding(4);
            groupfloorceiling.Name = "groupfloorceiling";
            groupfloorceiling.Padding = new System.Windows.Forms.Padding(4);
            groupfloorceiling.Size = new System.Drawing.Size(545, 179);
            groupfloorceiling.TabIndex = 0;
            groupfloorceiling.TabStop = false;
            groupfloorceiling.Text = "Floor and Ceiling ";
            // 
            // floorheight
            // 
            this.floorheight.AllowDecimal = false;
            this.floorheight.AllowNegative = true;
            this.floorheight.AllowRelative = true;
            this.floorheight.ButtonStep = 8;
            this.floorheight.Location = new System.Drawing.Point(140, 84);
            this.floorheight.Margin = new System.Windows.Forms.Padding(5);
            this.floorheight.Name = "floorheight";
            this.floorheight.Size = new System.Drawing.Size(110, 27);
            this.floorheight.StepValues = null;
            this.floorheight.TabIndex = 23;
            this.floorheight.WhenTextChanged += new System.EventHandler(this.floorheight_TextChanged);
            // 
            // ceilingheight
            // 
            this.ceilingheight.AllowDecimal = false;
            this.ceilingheight.AllowNegative = true;
            this.ceilingheight.AllowRelative = true;
            this.ceilingheight.ButtonStep = 8;
            this.ceilingheight.Location = new System.Drawing.Point(140, 41);
            this.ceilingheight.Margin = new System.Windows.Forms.Padding(5);
            this.ceilingheight.Name = "ceilingheight";
            this.ceilingheight.Size = new System.Drawing.Size(110, 27);
            this.ceilingheight.StepValues = null;
            this.ceilingheight.TabIndex = 22;
            this.ceilingheight.WhenTextChanged += new System.EventHandler(this.ceilingheight_TextChanged);
            // 
            // sectorheight
            // 
            this.sectorheight.AutoSize = true;
            this.sectorheight.Location = new System.Drawing.Point(141, 134);
            this.sectorheight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sectorheight.Name = "sectorheight";
            this.sectorheight.Size = new System.Drawing.Size(15, 16);
            this.sectorheight.TabIndex = 21;
            this.sectorheight.Text = "0";
            // 
            // sectorheightlabel
            // 
            this.sectorheightlabel.AutoSize = true;
            this.sectorheightlabel.Location = new System.Drawing.Point(40, 134);
            this.sectorheightlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sectorheightlabel.Name = "sectorheightlabel";
            this.sectorheightlabel.Size = new System.Drawing.Size(95, 16);
            this.sectorheightlabel.TabIndex = 20;
            this.sectorheightlabel.Text = "Sector height:";
            // 
            // labelFloorHeight
            // 
            labelFloorHeight.AutoSize = true;
            labelFloorHeight.Location = new System.Drawing.Point(50, 90);
            labelFloorHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelFloorHeight.Name = "labelFloorHeight";
            labelFloorHeight.Size = new System.Drawing.Size(87, 16);
            labelFloorHeight.TabIndex = 17;
            labelFloorHeight.Text = "Floor height:";
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(296, 14);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 20);
            label2.TabIndex = 15;
            label2.Text = "Floor";
            label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(415, 14);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(104, 20);
            label4.TabIndex = 14;
            label4.Text = "Ceiling";
            label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // floortex
            // 
            this.floortex.Location = new System.Drawing.Point(296, 38);
            this.floortex.Margin = new System.Windows.Forms.Padding(5);
            this.floortex.Name = "floortex";
            this.floortex.Size = new System.Drawing.Size(104, 131);
            this.floortex.TabIndex = 2;
            this.floortex.TextureName = "";
            // 
            // ceilingtex
            // 
            this.ceilingtex.Location = new System.Drawing.Point(415, 38);
            this.ceilingtex.Margin = new System.Windows.Forms.Padding(5);
            this.ceilingtex.Name = "ceilingtex";
            this.ceilingtex.Size = new System.Drawing.Size(104, 131);
            this.ceilingtex.TabIndex = 3;
            this.ceilingtex.TextureName = "";
            // 
            // labelCeilingHeight
            // 
            labelCeilingHeight.AutoSize = true;
            labelCeilingHeight.Location = new System.Drawing.Point(41, 48);
            labelCeilingHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelCeilingHeight.Name = "labelCeilingHeight";
            labelCeilingHeight.Size = new System.Drawing.Size(97, 16);
            labelCeilingHeight.TabIndex = 19;
            labelCeilingHeight.Text = "Ceiling height:";
            // 
            // incdecIntensity
            // 
            incdecIntensity.Controls.Add(this.floorLightDecrease);
            incdecIntensity.Controls.Add(this.floorLightIncrease);
            incdecIntensity.Controls.Add(this.bottomWallLightDecrease);
            incdecIntensity.Controls.Add(this.bottomWallLightIncrease);
            incdecIntensity.Controls.Add(this.thingLightDecrease);
            incdecIntensity.Controls.Add(this.thingLightIncrease);
            incdecIntensity.Controls.Add(this.topWallLightDecrease);
            incdecIntensity.Controls.Add(this.topWallLightIncrease);
            incdecIntensity.Controls.Add(this.ceilingLightDecrease);
            incdecIntensity.Controls.Add(this.ceilingLightIncrease);
            incdecIntensity.Location = new System.Drawing.Point(405, 9);
            incdecIntensity.Margin = new System.Windows.Forms.Padding(4);
            incdecIntensity.Name = "incdecIntensity";
            incdecIntensity.Padding = new System.Windows.Forms.Padding(4);
            incdecIntensity.Size = new System.Drawing.Size(140, 209);
            incdecIntensity.TabIndex = 6;
            incdecIntensity.TabStop = false;
            incdecIntensity.Text = "Inc/Dec Intensity";
            // 
            // floorLightDecrease
            // 
            this.floorLightDecrease.Location = new System.Drawing.Point(74, 169);
            this.floorLightDecrease.Margin = new System.Windows.Forms.Padding(4);
            this.floorLightDecrease.Name = "floorLightDecrease";
            this.floorLightDecrease.Size = new System.Drawing.Size(52, 25);
            this.floorLightDecrease.TabIndex = 61;
            this.floorLightDecrease.Text = "-";
            this.floorLightDecrease.UseVisualStyleBackColor = true;
            this.floorLightDecrease.Click += new System.EventHandler(FloorLightDecrease_Click);
            // 
            // floorLightIncrease
            // 
            this.floorLightIncrease.Location = new System.Drawing.Point(14, 169);
            this.floorLightIncrease.Margin = new System.Windows.Forms.Padding(4);
            this.floorLightIncrease.Name = "floorLightIncrease";
            this.floorLightIncrease.Size = new System.Drawing.Size(52, 25);
            this.floorLightIncrease.TabIndex = 60;
            this.floorLightIncrease.Text = "+";
            this.floorLightIncrease.UseVisualStyleBackColor = true;
            this.floorLightIncrease.Click += new System.EventHandler(FloorLightIncrease_Click);
            // 
            // bottomWallLightDecrease
            // 
            this.bottomWallLightDecrease.Location = new System.Drawing.Point(74, 132);
            this.bottomWallLightDecrease.Margin = new System.Windows.Forms.Padding(4);
            this.bottomWallLightDecrease.Name = "bottomWallLightDecrease";
            this.bottomWallLightDecrease.Size = new System.Drawing.Size(52, 25);
            this.bottomWallLightDecrease.TabIndex = 59;
            this.bottomWallLightDecrease.Text = "-";
            this.bottomWallLightDecrease.UseVisualStyleBackColor = true;
            this.bottomWallLightDecrease.Click += new System.EventHandler(BottomWallLightDecrease_Click);
            // 
            // bottomWallLightIncrease
            // 
            this.bottomWallLightIncrease.Location = new System.Drawing.Point(14, 132);
            this.bottomWallLightIncrease.Margin = new System.Windows.Forms.Padding(4);
            this.bottomWallLightIncrease.Name = "bottomWallLightIncrease";
            this.bottomWallLightIncrease.Size = new System.Drawing.Size(52, 25);
            this.bottomWallLightIncrease.TabIndex = 58;
            this.bottomWallLightIncrease.Text = "+";
            this.bottomWallLightIncrease.UseVisualStyleBackColor = true;
            this.bottomWallLightIncrease.Click += new System.EventHandler(BottomWallLightIncrease_Click);
            // 
            // thingLightDecrease
            // 
            this.thingLightDecrease.Location = new System.Drawing.Point(74, 96);
            this.thingLightDecrease.Margin = new System.Windows.Forms.Padding(4);
            this.thingLightDecrease.Name = "thingLightDecrease";
            this.thingLightDecrease.Size = new System.Drawing.Size(52, 25);
            this.thingLightDecrease.TabIndex = 57;
            this.thingLightDecrease.Text = "-";
            this.thingLightDecrease.UseVisualStyleBackColor = true;
            this.thingLightDecrease.Click += new System.EventHandler(ThingLightDecrease_Click);
            // 
            // thingLightIncrease
            // 
            this.thingLightIncrease.Location = new System.Drawing.Point(14, 96);
            this.thingLightIncrease.Margin = new System.Windows.Forms.Padding(4);
            this.thingLightIncrease.Name = "thingLightIncrease";
            this.thingLightIncrease.Size = new System.Drawing.Size(52, 25);
            this.thingLightIncrease.TabIndex = 56;
            this.thingLightIncrease.Text = "+";
            this.thingLightIncrease.UseVisualStyleBackColor = true;
            this.thingLightIncrease.Click += new System.EventHandler(ThingLightIncrease_Click);
            // 
            // topWallLightDecrease
            // 
            this.topWallLightDecrease.Location = new System.Drawing.Point(74, 60);
            this.topWallLightDecrease.Margin = new System.Windows.Forms.Padding(4);
            this.topWallLightDecrease.Name = "topWallLightDecrease";
            this.topWallLightDecrease.Size = new System.Drawing.Size(52, 25);
            this.topWallLightDecrease.TabIndex = 55;
            this.topWallLightDecrease.Text = "-";
            this.topWallLightDecrease.UseVisualStyleBackColor = true;
            this.topWallLightDecrease.Click += new System.EventHandler(TopWallLightDecrease_Click);
            // 
            // topWallLightIncrease
            // 
            this.topWallLightIncrease.Location = new System.Drawing.Point(14, 60);
            this.topWallLightIncrease.Margin = new System.Windows.Forms.Padding(4);
            this.topWallLightIncrease.Name = "topWallLightIncrease";
            this.topWallLightIncrease.Size = new System.Drawing.Size(52, 25);
            this.topWallLightIncrease.TabIndex = 54;
            this.topWallLightIncrease.Text = "+";
            this.topWallLightIncrease.UseVisualStyleBackColor = true;
            this.topWallLightIncrease.Click += new System.EventHandler(TopWallLightIncrease_Click);
            // 
            // ceilingLightDecrease
            // 
            this.ceilingLightDecrease.Location = new System.Drawing.Point(74, 24);
            this.ceilingLightDecrease.Margin = new System.Windows.Forms.Padding(4);
            this.ceilingLightDecrease.Name = "ceilingLightDecrease";
            this.ceilingLightDecrease.Size = new System.Drawing.Size(52, 25);
            this.ceilingLightDecrease.TabIndex = 53;
            this.ceilingLightDecrease.Text = "-";
            this.ceilingLightDecrease.UseVisualStyleBackColor = true;
            this.ceilingLightDecrease.Click += new System.EventHandler(CeilingLightDecrease_Click);
            // 
            // ceilingLightIncrease
            // 
            this.ceilingLightIncrease.Location = new System.Drawing.Point(14, 24);
            this.ceilingLightIncrease.Margin = new System.Windows.Forms.Padding(4);
            this.ceilingLightIncrease.Name = "ceilingLightIncrease";
            this.ceilingLightIncrease.Size = new System.Drawing.Size(52, 25);
            this.ceilingLightIncrease.TabIndex = 52;
            this.ceilingLightIncrease.Text = "+";
            this.ceilingLightIncrease.UseVisualStyleBackColor = true;
            this.ceilingLightIncrease.Click += new System.EventHandler(CeilingLightIncrease_Click);
            // 
            // coloredLightingInfo
            // 
            coloredLightingInfo.Controls.Add(this.floorcolor);
            coloredLightingInfo.Controls.Add(this.lowercolor);
            coloredLightingInfo.Controls.Add(this.thingcolor);
            coloredLightingInfo.Controls.Add(this.topcolor);
            coloredLightingInfo.Controls.Add(this.ceilingcolor);
            coloredLightingInfo.Location = new System.Drawing.Point(0, 9);
            coloredLightingInfo.Margin = new System.Windows.Forms.Padding(4);
            coloredLightingInfo.Name = "coloredLightingInfo";
            coloredLightingInfo.Padding = new System.Windows.Forms.Padding(4);
            coloredLightingInfo.Size = new System.Drawing.Size(368, 209);
            coloredLightingInfo.TabIndex = 5;
            coloredLightingInfo.TabStop = false;
            coloredLightingInfo.Text = "Colored Lighting Info";
            // 
            // floorcolor
            // 
            this.floorcolor.BackColor = System.Drawing.Color.Transparent;
            this.floorcolor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.floorcolor.Label = "Floor:";
            this.floorcolor.Location = new System.Drawing.Point(20, 169);
            this.floorcolor.Margin = new System.Windows.Forms.Padding(5);
            this.floorcolor.MaximumSize = new System.Drawing.Size(12500, 29);
            this.floorcolor.MinimumSize = new System.Drawing.Size(125, 29);
            this.floorcolor.Name = "floorcolor";
            this.floorcolor.Size = new System.Drawing.Size(340, 29);
            this.floorcolor.TabIndex = 6;
            // 
            // lowercolor
            // 
            this.lowercolor.BackColor = System.Drawing.Color.Transparent;
            this.lowercolor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowercolor.Label = "Bottom Half Wall:";
            this.lowercolor.Location = new System.Drawing.Point(20, 132);
            this.lowercolor.Margin = new System.Windows.Forms.Padding(5);
            this.lowercolor.MaximumSize = new System.Drawing.Size(12500, 29);
            this.lowercolor.MinimumSize = new System.Drawing.Size(125, 29);
            this.lowercolor.Name = "lowercolor";
            this.lowercolor.Size = new System.Drawing.Size(340, 29);
            this.lowercolor.TabIndex = 5;
            // 
            // thingcolor
            // 
            this.thingcolor.BackColor = System.Drawing.Color.Transparent;
            this.thingcolor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thingcolor.Label = "Thing:";
            this.thingcolor.Location = new System.Drawing.Point(20, 96);
            this.thingcolor.Margin = new System.Windows.Forms.Padding(5);
            this.thingcolor.MaximumSize = new System.Drawing.Size(12500, 29);
            this.thingcolor.MinimumSize = new System.Drawing.Size(125, 29);
            this.thingcolor.Name = "thingcolor";
            this.thingcolor.Size = new System.Drawing.Size(340, 29);
            this.thingcolor.TabIndex = 4;
            // 
            // topcolor
            // 
            this.topcolor.BackColor = System.Drawing.Color.Transparent;
            this.topcolor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topcolor.Label = "Top Half Wall:";
            this.topcolor.Location = new System.Drawing.Point(20, 60);
            this.topcolor.Margin = new System.Windows.Forms.Padding(5);
            this.topcolor.MaximumSize = new System.Drawing.Size(12500, 29);
            this.topcolor.MinimumSize = new System.Drawing.Size(125, 29);
            this.topcolor.Name = "topcolor";
            this.topcolor.Size = new System.Drawing.Size(340, 29);
            this.topcolor.TabIndex = 3;
            // 
            // ceilingcolor
            // 
            this.ceilingcolor.BackColor = System.Drawing.Color.Transparent;
            this.ceilingcolor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceilingcolor.Label = "Ceiling:";
            this.ceilingcolor.Location = new System.Drawing.Point(20, 24);
            this.ceilingcolor.Margin = new System.Windows.Forms.Padding(5);
            this.ceilingcolor.MaximumSize = new System.Drawing.Size(12500, 29);
            this.ceilingcolor.MinimumSize = new System.Drawing.Size(125, 29);
            this.ceilingcolor.Name = "ceilingcolor";
            this.ceilingcolor.Size = new System.Drawing.Size(340, 29);
            this.ceilingcolor.TabIndex = 2;
            // 
            // groupaction
            // 
            this.groupaction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupaction.Controls.Add(this.tag);
            this.groupaction.Controls.Add(labelTag);
            this.groupaction.Controls.Add(this.newtag);
            this.groupaction.Location = new System.Drawing.Point(9, 492);
            this.groupaction.Margin = new System.Windows.Forms.Padding(4);
            this.groupaction.Name = "groupaction";
            this.groupaction.Padding = new System.Windows.Forms.Padding(4);
            this.groupaction.Size = new System.Drawing.Size(545, 61);
            this.groupaction.TabIndex = 2;
            this.groupaction.TabStop = false;
            this.groupaction.Text = " Identification ";
            // 
            // tag
            // 
            this.tag.AllowDecimal = false;
            this.tag.AllowNegative = false;
            this.tag.AllowRelative = true;
            this.tag.ButtonStep = 1;
            this.tag.Location = new System.Drawing.Point(111, 20);
            this.tag.Margin = new System.Windows.Forms.Padding(5);
            this.tag.Name = "tag";
            this.tag.Size = new System.Drawing.Size(91, 27);
            this.tag.StepValues = null;
            this.tag.TabIndex = 25;
            // 
            // newtag
            // 
            this.newtag.Location = new System.Drawing.Point(218, 21);
            this.newtag.Margin = new System.Windows.Forms.Padding(4);
            this.newtag.Name = "newtag";
            this.newtag.Size = new System.Drawing.Size(95, 29);
            this.newtag.TabIndex = 1;
            this.newtag.Text = "New Tag";
            this.newtag.UseVisualStyleBackColor = true;
            this.newtag.Click += new System.EventHandler(this.newtag_Click);
            // 
            // groupeffect
            // 
            this.groupeffect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupeffect.Controls.Add(this.browseeffect);
            this.groupeffect.Controls.Add(this.effect);
            this.groupeffect.Controls.Add(labelSpecial);
            this.groupeffect.Location = new System.Drawing.Point(9, 425);
            this.groupeffect.Margin = new System.Windows.Forms.Padding(4);
            this.groupeffect.Name = "groupeffect";
            this.groupeffect.Padding = new System.Windows.Forms.Padding(4);
            this.groupeffect.Size = new System.Drawing.Size(545, 60);
            this.groupeffect.TabIndex = 1;
            this.groupeffect.TabStop = false;
            this.groupeffect.Text = " Effects ";
            // 
            // browseeffect
            // 
            this.browseeffect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseeffect.Image = global::CodeImp.DoomBuilder.Properties.Resources.treeview;
            this.browseeffect.Location = new System.Drawing.Point(481, 26);
            this.browseeffect.Margin = new System.Windows.Forms.Padding(4);
            this.browseeffect.Name = "browseeffect";
            this.browseeffect.Padding = new System.Windows.Forms.Padding(0, 0, 1, 4);
            this.browseeffect.Size = new System.Drawing.Size(38, 29);
            this.browseeffect.TabIndex = 1;
            this.browseeffect.Text = " ";
            this.browseeffect.UseVisualStyleBackColor = true;
            this.browseeffect.Click += new System.EventHandler(this.browseeffect_Click);
            // 
            // effect
            // 
            this.effect.BackColor = System.Drawing.Color.Transparent;
            this.effect.Cursor = System.Windows.Forms.Cursors.Default;
            this.effect.Empty = false;
            this.effect.GeneralizedCategories = null;
            this.effect.Location = new System.Drawing.Point(111, 28);
            this.effect.Macro = false;
            this.effect.Margin = new System.Windows.Forms.Padding(5);
            this.effect.Name = "effect";
            this.effect.Size = new System.Drawing.Size(362, 24);
            this.effect.TabIndex = 0;
            this.effect.Value = 402;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(441, 815);
            this.cancel.Margin = new System.Windows.Forms.Padding(4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(140, 31);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // apply
            // 
            this.apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.apply.Location = new System.Drawing.Point(295, 815);
            this.apply.Margin = new System.Windows.Forms.Padding(4);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(140, 31);
            this.apply.TabIndex = 1;
            this.apply.Text = "OK";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // sectorproperties
            // 
            this.sectorproperties.Controls.Add(this.groupeffect);
            this.sectorproperties.Controls.Add(this.lightsPanel);
            this.sectorproperties.Controls.Add(this.settingsgroup);
            this.sectorproperties.Controls.Add(this.groupaction);
            this.sectorproperties.Controls.Add(groupfloorceiling);
            this.sectorproperties.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectorproperties.Location = new System.Drawing.Point(15, 15);
            this.sectorproperties.Margin = new System.Windows.Forms.Padding(4);
            this.sectorproperties.Name = "sectorproperties";
            this.sectorproperties.Padding = new System.Windows.Forms.Padding(4);
            this.sectorproperties.Size = new System.Drawing.Size(561, 740);
            this.sectorproperties.TabIndex = 0;
            this.sectorproperties.Text = "Properties";
            // 
            // lightsPanel
            // 
            this.lightsPanel.Controls.Add(incdecIntensity);
            this.lightsPanel.Controls.Add(coloredLightingInfo);
            this.lightsPanel.Location = new System.Drawing.Point(9, 194);
            this.lightsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.lightsPanel.Name = "lightsPanel";
            this.lightsPanel.Size = new System.Drawing.Size(545, 224);
            this.lightsPanel.TabIndex = 4;
            // 
            // settingsgroup
            // 
            this.settingsgroup.Controls.Add(this.flags);
            this.settingsgroup.Location = new System.Drawing.Point(9, 561);
            this.settingsgroup.Margin = new System.Windows.Forms.Padding(4);
            this.settingsgroup.Name = "settingsgroup";
            this.settingsgroup.Padding = new System.Windows.Forms.Padding(4);
            this.settingsgroup.Size = new System.Drawing.Size(545, 170);
            this.settingsgroup.TabIndex = 3;
            this.settingsgroup.TabStop = false;
            this.settingsgroup.Text = "Settings";
            // 
            // flags
            // 
            this.flags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flags.AutoScroll = true;
            this.flags.Columns = 3;
            this.flags.Location = new System.Drawing.Point(8, 18);
            this.flags.Margin = new System.Windows.Forms.Padding(5);
            this.flags.Name = "flags";
            this.flags.Size = new System.Drawing.Size(530, 145);
            this.flags.TabIndex = 4;
            // 
            // flatSelectorControl2
            // 
            this.flatSelectorControl2.Location = new System.Drawing.Point(271, 37);
            this.flatSelectorControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flatSelectorControl2.Name = "flatSelectorControl2";
            this.flatSelectorControl2.Size = new System.Drawing.Size(83, 105);
            this.flatSelectorControl2.TabIndex = 13;
            this.flatSelectorControl2.TextureName = "";
            // 
            // flatSelectorControl1
            // 
            this.flatSelectorControl1.Location = new System.Drawing.Point(363, 37);
            this.flatSelectorControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flatSelectorControl1.Name = "flatSelectorControl1";
            this.flatSelectorControl1.Size = new System.Drawing.Size(83, 105);
            this.flatSelectorControl1.TabIndex = 12;
            this.flatSelectorControl1.TextureName = "";
            // 
            // heightpanel3
            // 
            this.heightpanel3.BackColor = System.Drawing.Color.Navy;
            this.heightpanel3.Location = new System.Drawing.Point(160, -24);
            this.heightpanel3.Margin = new System.Windows.Forms.Padding(4);
            this.heightpanel3.Name = "heightpanel3";
            this.heightpanel3.Size = new System.Drawing.Size(98, 846);
            this.heightpanel3.TabIndex = 5;
            this.heightpanel3.Visible = false;
            // 
            // SectorEditForm
            // 
            this.AcceptButton = this.apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(596, 856);
            this.Controls.Add(this.sectorproperties);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.heightpanel3);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SectorEditForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Sector";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.SectorEditForm_HelpRequested);
            groupfloorceiling.ResumeLayout(false);
            groupfloorceiling.PerformLayout();
            incdecIntensity.ResumeLayout(false);
            coloredLightingInfo.ResumeLayout(false);
            this.groupaction.ResumeLayout(false);
            this.groupaction.PerformLayout();
            this.groupeffect.ResumeLayout(false);
            this.groupeffect.PerformLayout();
            this.sectorproperties.ResumeLayout(false);
            this.lightsPanel.ResumeLayout(false);
            this.settingsgroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Panel sectorproperties;
        private CodeImp.DoomBuilder.Controls.FlatSelectorControl floortex;
        private CodeImp.DoomBuilder.Controls.FlatSelectorControl ceilingtex;
        private CodeImp.DoomBuilder.Controls.FlatSelectorControl flatSelectorControl2;
        private CodeImp.DoomBuilder.Controls.FlatSelectorControl flatSelectorControl1;
        private System.Windows.Forms.Label sectorheight;
        private CodeImp.DoomBuilder.Controls.ActionSelectorControl effect;
        private System.Windows.Forms.Button newtag;
        private System.Windows.Forms.Button browseeffect;
        private System.Windows.Forms.Label sectorheightlabel;
        private CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox ceilingheight;
        private CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox floorheight;
        private CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox tag;
        private System.Windows.Forms.GroupBox settingsgroup;
        private CodeImp.DoomBuilder.Controls.CheckboxArrayControl flags;
        private System.Windows.Forms.GroupBox groupeffect;
        private System.Windows.Forms.GroupBox groupaction;
        private System.Windows.Forms.Panel lightsPanel;
        private System.Windows.Forms.Button floorLightDecrease;
        private System.Windows.Forms.Button floorLightIncrease;
        private System.Windows.Forms.Button bottomWallLightDecrease;
        private System.Windows.Forms.Button bottomWallLightIncrease;
        private System.Windows.Forms.Button thingLightDecrease;
        private System.Windows.Forms.Button thingLightIncrease;
        private System.Windows.Forms.Button topWallLightDecrease;
        private System.Windows.Forms.Button topWallLightIncrease;
        private System.Windows.Forms.Button ceilingLightDecrease;
        private System.Windows.Forms.Button ceilingLightIncrease;
        private Controls.ColorControlSector floorcolor;
        private Controls.ColorControlSector lowercolor;
        private Controls.ColorControlSector thingcolor;
        private Controls.ColorControlSector topcolor;
        private Controls.ColorControlSector ceilingcolor;
        private System.Windows.Forms.Panel heightpanel3;    // villsa
    }
}
