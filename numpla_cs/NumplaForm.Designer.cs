namespace numpla
{
    partial class NumplaForm
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
            this.numpla_board = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.numpla_Level = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numpla_NextMove = new System.Windows.Forms.TextBox();
            this.numpla_numbers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numpla_buttonUndo = new System.Windows.Forms.Button();
            this.numpla_buttonRestart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numpla_buttonStart10 = new System.Windows.Forms.Button();
            this.numpla_buttonStart20 = new System.Windows.Forms.Button();
            this.numpla_buttonStart30 = new System.Windows.Forms.Button();
            this.numpla_buttonStart40 = new System.Windows.Forms.Button();
            this.numpla_buttonStart50 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numpla_board)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numpla_numbers)).BeginInit();
            this.SuspendLayout();
            // 
            // numpla_board
            // 
            this.numpla_board.AllowUserToAddRows = false;
            this.numpla_board.AllowUserToDeleteRows = false;
            this.numpla_board.AllowUserToResizeColumns = false;
            this.numpla_board.AllowUserToResizeRows = false;
            this.numpla_board.ColumnHeadersHeight = 40;
            this.numpla_board.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.numpla_board.ColumnHeadersVisible = false;
            this.numpla_board.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.numpla_board.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.numpla_board.GridColor = System.Drawing.SystemColors.Control;
            this.numpla_board.Location = new System.Drawing.Point(0, 0);
            this.numpla_board.MultiSelect = false;
            this.numpla_board.Name = "numpla_board";
            this.numpla_board.ReadOnly = true;
            this.numpla_board.RowHeadersVisible = false;
            this.numpla_board.RowHeadersWidth = 40;
            this.numpla_board.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.numpla_board.RowTemplate.Height = 27;
            this.numpla_board.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numpla_board.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.numpla_board.ShowCellToolTips = false;
            this.numpla_board.Size = new System.Drawing.Size(610, 610);
            this.numpla_board.TabIndex = 0;
            this.numpla_board.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Numpla_board_CellClick);
            this.numpla_board.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.numpla_board_CellPainting);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "1";
            this.Column1.MinimumWidth = 40;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "2";
            this.Column2.MinimumWidth = 40;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 40;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "3";
            this.Column3.MinimumWidth = 40;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 40;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "4";
            this.Column4.MinimumWidth = 40;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 40;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "5";
            this.Column5.MinimumWidth = 40;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 40;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "6";
            this.Column6.MinimumWidth = 40;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 40;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "7";
            this.Column7.MinimumWidth = 40;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 40;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "8";
            this.Column8.MinimumWidth = 40;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 40;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "9";
            this.Column9.MinimumWidth = 40;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.label1.Location = new System.Drawing.Point(160, 621);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "次の手";
            // 
            // numpla_Level
            // 
            this.numpla_Level.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.numpla_Level.Location = new System.Drawing.Point(74, 618);
            this.numpla_Level.Name = "numpla_Level";
            this.numpla_Level.ReadOnly = true;
            this.numpla_Level.Size = new System.Drawing.Size(80, 23);
            this.numpla_Level.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.label2.Location = new System.Drawing.Point(0, 621);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "難易度";
            // 
            // numpla_NextMove
            // 
            this.numpla_NextMove.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.numpla_NextMove.Location = new System.Drawing.Point(225, 618);
            this.numpla_NextMove.Name = "numpla_NextMove";
            this.numpla_NextMove.ReadOnly = true;
            this.numpla_NextMove.Size = new System.Drawing.Size(46, 23);
            this.numpla_NextMove.TabIndex = 4;
            // 
            // numpla_numbers
            // 
            this.numpla_numbers.AllowUserToAddRows = false;
            this.numpla_numbers.AllowUserToDeleteRows = false;
            this.numpla_numbers.AllowUserToResizeColumns = false;
            this.numpla_numbers.AllowUserToResizeRows = false;
            this.numpla_numbers.ColumnHeadersHeight = 34;
            this.numpla_numbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.numpla_numbers.ColumnHeadersVisible = false;
            this.numpla_numbers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.numpla_numbers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.numpla_numbers.Location = new System.Drawing.Point(0, 649);
            this.numpla_numbers.MultiSelect = false;
            this.numpla_numbers.Name = "numpla_numbers";
            this.numpla_numbers.ReadOnly = true;
            this.numpla_numbers.RowHeadersVisible = false;
            this.numpla_numbers.RowHeadersWidth = 62;
            this.numpla_numbers.RowTemplate.Height = 27;
            this.numpla_numbers.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numpla_numbers.Size = new System.Drawing.Size(610, 34);
            this.numpla_numbers.TabIndex = 5;
            this.numpla_numbers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Numpla_numbers_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "1";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "2";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "3";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "4";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 40;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "5";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "6";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 40;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "7";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 40;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "8";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 40;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "9";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 40;
            // 
            // numpla_buttonUndo
            // 
            this.numpla_buttonUndo.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.numpla_buttonUndo.Location = new System.Drawing.Point(0, 689);
            this.numpla_buttonUndo.Name = "numpla_buttonUndo";
            this.numpla_buttonUndo.Size = new System.Drawing.Size(60, 37);
            this.numpla_buttonUndo.TabIndex = 6;
            this.numpla_buttonUndo.Text = "戻る";
            this.numpla_buttonUndo.UseVisualStyleBackColor = true;
            this.numpla_buttonUndo.Click += new System.EventHandler(this.Numpla_buttonUndo_Click);
            // 
            // numpla_buttonRestart
            // 
            this.numpla_buttonRestart.Font = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numpla_buttonRestart.Location = new System.Drawing.Point(66, 689);
            this.numpla_buttonRestart.Name = "numpla_buttonRestart";
            this.numpla_buttonRestart.Size = new System.Drawing.Size(88, 37);
            this.numpla_buttonRestart.TabIndex = 7;
            this.numpla_buttonRestart.Text = "初めから";
            this.numpla_buttonRestart.UseVisualStyleBackColor = true;
            this.numpla_buttonRestart.Click += new System.EventHandler(this.Numpla_buttonRestart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.label3.Location = new System.Drawing.Point(157, 698);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "開始➡";
            // 
            // numpla_buttonStart10
            // 
            this.numpla_buttonStart10.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.numpla_buttonStart10.Location = new System.Drawing.Point(225, 689);
            this.numpla_buttonStart10.Name = "numpla_buttonStart10";
            this.numpla_buttonStart10.Size = new System.Drawing.Size(58, 37);
            this.numpla_buttonStart10.TabIndex = 9;
            this.numpla_buttonStart10.Text = "入門";
            this.numpla_buttonStart10.UseVisualStyleBackColor = true;
            this.numpla_buttonStart10.Click += new System.EventHandler(this.Numpla_buttonStart10_Click);
            // 
            // numpla_buttonStart20
            // 
            this.numpla_buttonStart20.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.numpla_buttonStart20.Location = new System.Drawing.Point(289, 689);
            this.numpla_buttonStart20.Name = "numpla_buttonStart20";
            this.numpla_buttonStart20.Size = new System.Drawing.Size(58, 37);
            this.numpla_buttonStart20.TabIndex = 10;
            this.numpla_buttonStart20.Text = "簡単";
            this.numpla_buttonStart20.UseVisualStyleBackColor = true;
            this.numpla_buttonStart20.Click += new System.EventHandler(this.Numpla_buttonStart20_Click);
            // 
            // numpla_buttonStart30
            // 
            this.numpla_buttonStart30.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.numpla_buttonStart30.Location = new System.Drawing.Point(353, 689);
            this.numpla_buttonStart30.Name = "numpla_buttonStart30";
            this.numpla_buttonStart30.Size = new System.Drawing.Size(58, 37);
            this.numpla_buttonStart30.TabIndex = 11;
            this.numpla_buttonStart30.Text = "普通";
            this.numpla_buttonStart30.UseVisualStyleBackColor = true;
            this.numpla_buttonStart30.Click += new System.EventHandler(this.Numpla_buttonStart30_Click);
            // 
            // numpla_buttonStart40
            // 
            this.numpla_buttonStart40.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.numpla_buttonStart40.Location = new System.Drawing.Point(417, 689);
            this.numpla_buttonStart40.Name = "numpla_buttonStart40";
            this.numpla_buttonStart40.Size = new System.Drawing.Size(71, 37);
            this.numpla_buttonStart40.TabIndex = 12;
            this.numpla_buttonStart40.Text = "難しい";
            this.numpla_buttonStart40.UseVisualStyleBackColor = true;
            this.numpla_buttonStart40.Click += new System.EventHandler(this.Numpla_buttonStart40_Click);
            // 
            // numpla_buttonStart50
            // 
            this.numpla_buttonStart50.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.numpla_buttonStart50.Location = new System.Drawing.Point(494, 689);
            this.numpla_buttonStart50.Name = "numpla_buttonStart50";
            this.numpla_buttonStart50.Size = new System.Drawing.Size(58, 37);
            this.numpla_buttonStart50.TabIndex = 13;
            this.numpla_buttonStart50.Text = "達人";
            this.numpla_buttonStart50.UseVisualStyleBackColor = true;
            this.numpla_buttonStart50.Click += new System.EventHandler(this.Numpla_buttonStart50_Click);
            // 
            // NumplaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 734);
            this.Controls.Add(this.numpla_buttonStart50);
            this.Controls.Add(this.numpla_buttonStart40);
            this.Controls.Add(this.numpla_buttonStart30);
            this.Controls.Add(this.numpla_buttonStart20);
            this.Controls.Add(this.numpla_buttonStart10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numpla_buttonRestart);
            this.Controls.Add(this.numpla_buttonUndo);
            this.Controls.Add(this.numpla_numbers);
            this.Controls.Add(this.numpla_NextMove);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numpla_Level);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numpla_board);
            this.Name = "NumplaForm";
            this.Text = "ナンプレ";
            this.Load += new System.EventHandler(this.Numpla_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numpla_board)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numpla_numbers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView numpla_board;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numpla_Level;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numpla_NextMove;
        private System.Windows.Forms.DataGridView numpla_numbers;
        private System.Windows.Forms.Button numpla_buttonUndo;
        private System.Windows.Forms.Button numpla_buttonRestart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button numpla_buttonStart10;
        private System.Windows.Forms.Button numpla_buttonStart20;
        private System.Windows.Forms.Button numpla_buttonStart30;
        private System.Windows.Forms.Button numpla_buttonStart40;
        private System.Windows.Forms.Button numpla_buttonStart50;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}