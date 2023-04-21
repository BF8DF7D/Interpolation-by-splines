namespace Program
{
    partial class FormSpline
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FunctionChooseFile = new System.Windows.Forms.Button();
            this.RadioEXP = new System.Windows.Forms.RadioButton();
            this.RadioSIN = new System.Windows.Forms.RadioButton();
            this.RadioABS = new System.Windows.Forms.RadioButton();
            this.NodesY = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.NodesSpline = new System.Windows.Forms.Button();
            this.NodesChooseFile = new System.Windows.Forms.Button();
            this.NodesX = new System.Windows.Forms.TextBox();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DeviationBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.formsPlot1);
            this.splitContainer.Size = new System.Drawing.Size(800, 450);
            this.splitContainer.SplitterDistance = 266;
            this.splitContainer.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeviationBox);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.NodesY);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.NodesSpline);
            this.groupBox1.Controls.Add(this.NodesX);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 267);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ИНТЕРПОЛЯЦИЯ СПЛАЙНАМИ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FunctionChooseFile);
            this.groupBox2.Controls.Add(this.RadioEXP);
            this.groupBox2.Controls.Add(this.RadioSIN);
            this.groupBox2.Controls.Add(this.RadioABS);
            this.groupBox2.Controls.Add(this.NodesChooseFile);
            this.groupBox2.Location = new System.Drawing.Point(8, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 116);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Способ расчёта";
            // 
            // FunctionChooseFile
            // 
            this.FunctionChooseFile.Location = new System.Drawing.Point(93, 16);
            this.FunctionChooseFile.Name = "FunctionChooseFile";
            this.FunctionChooseFile.Size = new System.Drawing.Size(133, 43);
            this.FunctionChooseFile.TabIndex = 3;
            this.FunctionChooseFile.Text = "Выбор аргумнтов функции";
            this.FunctionChooseFile.UseVisualStyleBackColor = true;
            this.FunctionChooseFile.Click += new System.EventHandler(this.FunctionChoose);
            // 
            // RadioEXP
            // 
            this.RadioEXP.AutoSize = true;
            this.RadioEXP.Location = new System.Drawing.Point(6, 42);
            this.RadioEXP.Name = "RadioEXP";
            this.RadioEXP.Size = new System.Drawing.Size(81, 17);
            this.RadioEXP.TabIndex = 2;
            this.RadioEXP.Text = "Y = EXP(-X)";
            this.RadioEXP.UseVisualStyleBackColor = true;
            this.RadioEXP.CheckedChanged += new System.EventHandler(this.RadioChecked);
            // 
            // RadioSIN
            // 
            this.RadioSIN.AutoSize = true;
            this.RadioSIN.Location = new System.Drawing.Point(6, 65);
            this.RadioSIN.Name = "RadioSIN";
            this.RadioSIN.Size = new System.Drawing.Size(75, 17);
            this.RadioSIN.TabIndex = 1;
            this.RadioSIN.Text = "Y = SIN(X)";
            this.RadioSIN.UseVisualStyleBackColor = true;
            // 
            // RadioABS
            // 
            this.RadioABS.AutoSize = true;
            this.RadioABS.Checked = true;
            this.RadioABS.Location = new System.Drawing.Point(6, 19);
            this.RadioABS.Name = "RadioABS";
            this.RadioABS.Size = new System.Drawing.Size(78, 17);
            this.RadioABS.TabIndex = 0;
            this.RadioABS.TabStop = true;
            this.RadioABS.Text = "Y = ABS(X)";
            this.RadioABS.UseVisualStyleBackColor = true;
            // 
            // NodesY
            // 
            this.NodesY.Location = new System.Drawing.Point(25, 208);
            this.NodesY.Name = "NodesY";
            this.NodesY.ReadOnly = true;
            this.NodesY.Size = new System.Drawing.Size(215, 20);
            this.NodesY.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 208);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(13, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "Y";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 182);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(13, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "X";
            // 
            // NodesSpline
            // 
            this.NodesSpline.Location = new System.Drawing.Point(8, 152);
            this.NodesSpline.Name = "NodesSpline";
            this.NodesSpline.Size = new System.Drawing.Size(232, 24);
            this.NodesSpline.TabIndex = 2;
            this.NodesSpline.Text = "Расчитать полином";
            this.NodesSpline.UseVisualStyleBackColor = true;
            this.NodesSpline.Click += new System.EventHandler(this.CalculateNodesSpline);
            // 
            // NodesChooseFile
            // 
            this.NodesChooseFile.Location = new System.Drawing.Point(93, 65);
            this.NodesChooseFile.Name = "NodesChooseFile";
            this.NodesChooseFile.Size = new System.Drawing.Size(133, 40);
            this.NodesChooseFile.TabIndex = 1;
            this.NodesChooseFile.Text = "Выбрать узлов интерполяции";
            this.NodesChooseFile.UseVisualStyleBackColor = true;
            this.NodesChooseFile.Click += new System.EventHandler(this.ChooseFile);
            // 
            // NodesX
            // 
            this.NodesX.Location = new System.Drawing.Point(25, 182);
            this.NodesX.Name = "NodesX";
            this.NodesX.Size = new System.Drawing.Size(215, 20);
            this.NodesX.TabIndex = 0;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(0, 0);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(526, 446);
            this.formsPlot1.TabIndex = 0;
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 234);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Макс.Отклон.";
            // 
            // DeviationBox
            // 
            this.DeviationBox.Location = new System.Drawing.Point(87, 234);
            this.DeviationBox.Name = "DeviationBox";
            this.DeviationBox.ReadOnly = true;
            this.DeviationBox.Size = new System.Drawing.Size(153, 20);
            this.DeviationBox.TabIndex = 8;
            // 
            // FormSpline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer);
            this.Name = "FormSpline";
            this.Text = "Сплайны";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NodesY;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button NodesSpline;
        private System.Windows.Forms.Button NodesChooseFile;
        private System.Windows.Forms.TextBox NodesX;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button FunctionChooseFile;
        private System.Windows.Forms.RadioButton RadioEXP;
        private System.Windows.Forms.RadioButton RadioSIN;
        private System.Windows.Forms.RadioButton RadioABS;
        private System.Windows.Forms.TextBox DeviationBox;
        private System.Windows.Forms.TextBox textBox1;
    }
}

