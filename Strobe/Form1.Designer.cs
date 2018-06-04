namespace Strobe
{
    partial class mainForm
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
            this.settingsBox = new System.Windows.Forms.GroupBox();
            this.hornCharBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.onlyLFSCheckBox = new System.Windows.Forms.CheckBox();
            this.lightCheckBox = new System.Windows.Forms.CheckBox();
            this.hornCheckBox = new System.Windows.Forms.CheckBox();
            this.randomCheckBox = new System.Windows.Forms.CheckBox();
            this.outputText = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.triggerBox = new System.Windows.Forms.GroupBox();
            this.scrollLockRadio = new System.Windows.Forms.RadioButton();
            this.capsLockRadio = new System.Windows.Forms.RadioButton();
            this.numLockRadio = new System.Windows.Forms.RadioButton();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.infoCaller = new System.Windows.Forms.Label();
            this.reverseLockBox = new System.Windows.Forms.CheckBox();
            this.settingsBox.SuspendLayout();
            this.triggerBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsBox
            // 
            this.settingsBox.Controls.Add(this.hornCharBox);
            this.settingsBox.Controls.Add(this.label2);
            this.settingsBox.Controls.Add(this.onlyLFSCheckBox);
            this.settingsBox.Controls.Add(this.lightCheckBox);
            this.settingsBox.Controls.Add(this.hornCheckBox);
            this.settingsBox.Controls.Add(this.randomCheckBox);
            this.settingsBox.Location = new System.Drawing.Point(-1, 28);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Size = new System.Drawing.Size(290, 109);
            this.settingsBox.TabIndex = 0;
            this.settingsBox.TabStop = false;
            this.settingsBox.Text = "Settings";
            // 
            // hornCharBox
            // 
            this.hornCharBox.Location = new System.Drawing.Point(243, 17);
            this.hornCharBox.Name = "hornCharBox";
            this.hornCharBox.Size = new System.Drawing.Size(33, 20);
            this.hornCharBox.TabIndex = 7;
            this.hornCharBox.Text = "B";
            this.hornCharBox.TextChanged += new System.EventHandler(this.hornCharBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Key for Horn:";
            // 
            // onlyLFSCheckBox
            // 
            this.onlyLFSCheckBox.AutoSize = true;
            this.onlyLFSCheckBox.Checked = true;
            this.onlyLFSCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onlyLFSCheckBox.Location = new System.Drawing.Point(13, 88);
            this.onlyLFSCheckBox.Name = "onlyLFSCheckBox";
            this.onlyLFSCheckBox.Size = new System.Drawing.Size(80, 17);
            this.onlyLFSCheckBox.TabIndex = 3;
            this.onlyLFSCheckBox.Text = "Only in LFS";
            this.onlyLFSCheckBox.UseVisualStyleBackColor = true;
            // 
            // lightCheckBox
            // 
            this.lightCheckBox.AutoSize = true;
            this.lightCheckBox.Checked = true;
            this.lightCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lightCheckBox.Location = new System.Drawing.Point(13, 65);
            this.lightCheckBox.Name = "lightCheckBox";
            this.lightCheckBox.Size = new System.Drawing.Size(72, 17);
            this.lightCheckBox.TabIndex = 2;
            this.lightCheckBox.Text = "Use lights";
            this.lightCheckBox.UseVisualStyleBackColor = true;
            // 
            // hornCheckBox
            // 
            this.hornCheckBox.AutoSize = true;
            this.hornCheckBox.Checked = true;
            this.hornCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hornCheckBox.Location = new System.Drawing.Point(13, 42);
            this.hornCheckBox.Name = "hornCheckBox";
            this.hornCheckBox.Size = new System.Drawing.Size(69, 17);
            this.hornCheckBox.TabIndex = 1;
            this.hornCheckBox.Text = "Use horn";
            this.hornCheckBox.UseVisualStyleBackColor = true;
            // 
            // randomCheckBox
            // 
            this.randomCheckBox.AutoSize = true;
            this.randomCheckBox.Checked = true;
            this.randomCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.randomCheckBox.Location = new System.Drawing.Point(13, 19);
            this.randomCheckBox.Name = "randomCheckBox";
            this.randomCheckBox.Size = new System.Drawing.Size(98, 17);
            this.randomCheckBox.TabIndex = 0;
            this.randomCheckBox.Text = "Random strobe";
            this.randomCheckBox.UseVisualStyleBackColor = true;
            // 
            // outputText
            // 
            this.outputText.AutoSize = true;
            this.outputText.Location = new System.Drawing.Point(12, 9);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(28, 13);
            this.outputText.TabIndex = 1;
            this.outputText.Text = "Text";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(18, 455);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(76, 20);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(100, 455);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(76, 20);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(199, 451);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(78, 28);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "lfs-ttl.lt";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // triggerBox
            // 
            this.triggerBox.Controls.Add(this.scrollLockRadio);
            this.triggerBox.Controls.Add(this.capsLockRadio);
            this.triggerBox.Controls.Add(this.numLockRadio);
            this.triggerBox.Location = new System.Drawing.Point(-1, 139);
            this.triggerBox.Name = "triggerBox";
            this.triggerBox.Size = new System.Drawing.Size(290, 45);
            this.triggerBox.TabIndex = 6;
            this.triggerBox.TabStop = false;
            this.triggerBox.Text = "Activation Key";
            // 
            // scrollLockRadio
            // 
            this.scrollLockRadio.AutoSize = true;
            this.scrollLockRadio.Location = new System.Drawing.Point(199, 19);
            this.scrollLockRadio.Name = "scrollLockRadio";
            this.scrollLockRadio.Size = new System.Drawing.Size(75, 17);
            this.scrollLockRadio.TabIndex = 2;
            this.scrollLockRadio.TabStop = true;
            this.scrollLockRadio.Text = "ScrollLock";
            this.scrollLockRadio.UseVisualStyleBackColor = true;
            // 
            // capsLockRadio
            // 
            this.capsLockRadio.AutoSize = true;
            this.capsLockRadio.Location = new System.Drawing.Point(104, 19);
            this.capsLockRadio.Name = "capsLockRadio";
            this.capsLockRadio.Size = new System.Drawing.Size(73, 17);
            this.capsLockRadio.TabIndex = 1;
            this.capsLockRadio.TabStop = true;
            this.capsLockRadio.Text = "CapsLock";
            this.capsLockRadio.UseVisualStyleBackColor = true;
            // 
            // numLockRadio
            // 
            this.numLockRadio.AutoSize = true;
            this.numLockRadio.Checked = true;
            this.numLockRadio.Location = new System.Drawing.Point(13, 19);
            this.numLockRadio.Name = "numLockRadio";
            this.numLockRadio.Size = new System.Drawing.Size(71, 17);
            this.numLockRadio.TabIndex = 0;
            this.numLockRadio.TabStop = true;
            this.numLockRadio.Text = "NumLock";
            this.numLockRadio.UseVisualStyleBackColor = true;
            // 
            // dataTable
            // 
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Location = new System.Drawing.Point(12, 214);
            this.dataTable.Name = "dataTable";
            this.dataTable.Size = new System.Drawing.Size(263, 233);
            this.dataTable.TabIndex = 7;
            this.dataTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTable_CellEndEdit);
            this.dataTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTable_CellValueChanged);
            // 
            // infoCaller
            // 
            this.infoCaller.AutoSize = true;
            this.infoCaller.Location = new System.Drawing.Point(240, 9);
            this.infoCaller.Name = "infoCaller";
            this.infoCaller.Size = new System.Drawing.Size(35, 13);
            this.infoCaller.TabIndex = 8;
            this.infoCaller.Text = "About";
            this.infoCaller.Click += new System.EventHandler(this.infoCaller_Click);
            // 
            // reverseLockBox
            // 
            this.reverseLockBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.reverseLockBox.AutoSize = true;
            this.reverseLockBox.Checked = true;
            this.reverseLockBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.reverseLockBox.Location = new System.Drawing.Point(60, 190);
            this.reverseLockBox.Name = "reverseLockBox";
            this.reverseLockBox.Size = new System.Drawing.Size(80, 17);
            this.reverseLockBox.TabIndex = 9;
            this.reverseLockBox.Text = "checkBox1";
            this.reverseLockBox.UseVisualStyleBackColor = true;
            this.reverseLockBox.CheckedChanged += new System.EventHandler(this.reverseLockBox_CheckedChanged);
            this.reverseLockBox.VisibleChanged += new System.EventHandler(this.reverseLockBox_VisibleChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 480);
            this.Controls.Add(this.reverseLockBox);
            this.Controls.Add(this.infoCaller);
            this.Controls.Add(this.dataTable);
            this.Controls.Add(this.triggerBox);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.settingsBox);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "LFS Strobe";
            this.Shown += new System.EventHandler(this.mainForm_Shown);
            this.settingsBox.ResumeLayout(false);
            this.settingsBox.PerformLayout();
            this.triggerBox.ResumeLayout(false);
            this.triggerBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox settingsBox;
        private System.Windows.Forms.TextBox hornCharBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox onlyLFSCheckBox;
        private System.Windows.Forms.CheckBox lightCheckBox;
        private System.Windows.Forms.CheckBox hornCheckBox;
        private System.Windows.Forms.CheckBox randomCheckBox;
        private System.Windows.Forms.Label outputText;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox triggerBox;
        private System.Windows.Forms.RadioButton scrollLockRadio;
        private System.Windows.Forms.RadioButton capsLockRadio;
        private System.Windows.Forms.RadioButton numLockRadio;
        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.Label infoCaller;
        private System.Windows.Forms.CheckBox reverseLockBox;
    }
}

