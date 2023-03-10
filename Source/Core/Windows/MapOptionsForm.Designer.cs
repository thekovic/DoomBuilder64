namespace CodeImp.DoomBuilder.Windows
{
    partial class MapOptionsForm
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.GroupBox panelsettings;
            System.Windows.Forms.Label label4;
            this.levelname = new System.Windows.Forms.TextBox();
            this.config = new System.Windows.Forms.ComboBox();
            this.apply = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.panelres = new System.Windows.Forms.GroupBox();
            this.strictpatches = new System.Windows.Forms.CheckBox();
            this.datalocations = new CodeImp.DoomBuilder.Controls.ResourceListEditor();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            panelsettings = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            panelsettings.SuspendLayout();
            this.panelres.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(239, 76);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(90, 14);
            label3.TabIndex = 9;
            label3.Text = "example:  MAP01";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(58, 76);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 14);
            label2.TabIndex = 7;
            label2.Text = "Level name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(18, 34);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(105, 14);
            label1.TabIndex = 5;
            label1.Text = "Game Configuration:";
            // 
            // panelsettings
            // 
            panelsettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            panelsettings.Controls.Add(label3);
            panelsettings.Controls.Add(this.levelname);
            panelsettings.Controls.Add(label2);
            panelsettings.Controls.Add(this.config);
            panelsettings.Controls.Add(label1);
            panelsettings.Location = new System.Drawing.Point(12, 12);
            panelsettings.Name = "panelsettings";
            panelsettings.Size = new System.Drawing.Size(397, 118);
            panelsettings.TabIndex = 0;
            panelsettings.TabStop = false;
            panelsettings.Text = " Settings ";
            // 
            // levelname
            // 
            this.levelname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.levelname.Location = new System.Drawing.Point(129, 73);
            this.levelname.Name = "levelname";
            this.levelname.Size = new System.Drawing.Size(94, 20);
            this.levelname.TabIndex = 1;
            this.levelname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.levelname_KeyPress);
            // 
            // config
            // 
            this.config.DropDownHeight = 206;
            this.config.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.config.FormattingEnabled = true;
            this.config.IntegralHeight = false;
            this.config.Location = new System.Drawing.Point(129, 31);
            this.config.Name = "config";
            this.config.Size = new System.Drawing.Size(213, 22);
            this.config.TabIndex = 0;
            this.config.SelectedIndexChanged += new System.EventHandler(this.config_SelectedIndexChanged);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(15, 190);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(312, 28);
            label4.TabIndex = 17;
            label4.Text = "Drag items to change order (lower items override higher items).\r\nGrayed items are" +
                " loaded according to the game configuration.";
            // 
            // apply
            // 
            this.apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.apply.Location = new System.Drawing.Point(179, 392);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(112, 25);
            this.apply.TabIndex = 2;
            this.apply.Text = "OK";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(297, 392);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(112, 25);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // panelres
            // 
            this.panelres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelres.Controls.Add(this.strictpatches);
            this.panelres.Controls.Add(this.datalocations);
            this.panelres.Controls.Add(label4);
            this.panelres.Location = new System.Drawing.Point(12, 141);
            this.panelres.Name = "panelres";
            this.panelres.Size = new System.Drawing.Size(397, 230);
            this.panelres.TabIndex = 1;
            this.panelres.TabStop = false;
            this.panelres.Text = " Resources ";
            // 
            // strictpatches
            // 
            this.strictpatches.AutoSize = true;
            this.strictpatches.Location = new System.Drawing.Point(15, 27);
            this.strictpatches.Name = "strictpatches";
            this.strictpatches.Size = new System.Drawing.Size(352, 18);
            this.strictpatches.TabIndex = 20;
            this.strictpatches.Text = "Strictly load patches between P_START and P_END only for this file";
            this.strictpatches.UseVisualStyleBackColor = true;
            // 
            // datalocations
            // 
            this.datalocations.DialogOffset = new System.Drawing.Point(40, 20);
            this.datalocations.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datalocations.Location = new System.Drawing.Point(15, 57);
            this.datalocations.Name = "datalocations";
            this.datalocations.Size = new System.Drawing.Size(368, 130);
            this.datalocations.TabIndex = 0;
            // 
            // MapOptionsForm
            // 
            this.AcceptButton = this.apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(421, 429);
            this.Controls.Add(this.panelres);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.apply);
            this.Controls.Add(panelsettings);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapOptionsForm";
            this.Opacity = 0;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Map Options";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.MapOptionsForm_HelpRequested);
            panelsettings.ResumeLayout(false);
            panelsettings.PerformLayout();
            this.panelres.ResumeLayout(false);
            this.panelres.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox levelname;
        private System.Windows.Forms.ComboBox config;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.GroupBox panelres;
        private CodeImp.DoomBuilder.Controls.ResourceListEditor datalocations;
        private System.Windows.Forms.CheckBox strictpatches;


    }
}