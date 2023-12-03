namespace FolderManager
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.unzip = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tag1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tag2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tag3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.open = new System.Windows.Forms.DataGridViewButtonColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "搜尋 : ";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("新細明體", 12F);
            this.textBox1.Location = new System.Drawing.Point(79, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(733, 27);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(837, 18);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(78, 27);
            this.search.TabIndex = 2;
            this.search.Text = "搜尋";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(942, 18);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(78, 27);
            this.refresh.TabIndex = 3;
            this.refresh.Text = "刷新";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // unzip
            // 
            this.unzip.Location = new System.Drawing.Point(1051, 18);
            this.unzip.Name = "unzip";
            this.unzip.Size = new System.Drawing.Size(78, 27);
            this.unzip.TabIndex = 4;
            this.unzip.Text = "Unzip";
            this.unzip.UseVisualStyleBackColor = true;
            this.unzip.Visible = false;
            this.unzip.Click += new System.EventHandler(this.unzip_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.picture,
            this.name,
            this.Tag1,
            this.Tag2,
            this.Tag3,
            this.open,
            this.edit,
            this.delete});
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1117, 571);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // picture
            // 
            this.picture.HeaderText = "封面";
            this.picture.Image = ((System.Drawing.Image)(resources.GetObject("picture.Image")));
            this.picture.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.picture.MinimumWidth = 304;
            this.picture.Name = "picture";
            this.picture.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.picture.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.picture.Width = 320;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 200;
            this.name.Name = "name";
            this.name.Width = 280;
            // 
            // Tag1
            // 
            this.Tag1.HeaderText = "Tag1";
            this.Tag1.Name = "Tag1";
            this.Tag1.Width = 60;
            // 
            // Tag2
            // 
            this.Tag2.HeaderText = "Tag2";
            this.Tag2.Name = "Tag2";
            this.Tag2.Width = 60;
            // 
            // Tag3
            // 
            this.Tag3.HeaderText = "Tag3";
            this.Tag3.Name = "Tag3";
            this.Tag3.Width = 60;
            // 
            // open
            // 
            this.open.HeaderText = "開啟";
            this.open.Name = "open";
            this.open.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.open.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.open.Width = 60;
            // 
            // edit
            // 
            this.edit.HeaderText = "編輯";
            this.edit.Name = "edit";
            this.edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.edit.Width = 60;
            // 
            // delete
            // 
            this.delete.HeaderText = "刪除";
            this.delete.Name = "delete";
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.delete.Width = 60;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 651);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.unzip);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.search);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "MangaManager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button unzip;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag3;
        private System.Windows.Forms.DataGridViewButtonColumn open;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}

