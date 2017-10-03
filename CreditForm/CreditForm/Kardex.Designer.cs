namespace CreditForm
{
    partial class Kardex
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
            this.dgwKardex = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwKardex)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwKardex
            // 
            this.dgwKardex.AllowUserToAddRows = false;
            this.dgwKardex.AllowUserToDeleteRows = false;
            this.dgwKardex.AllowUserToResizeRows = false;
            this.dgwKardex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwKardex.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwKardex.Location = new System.Drawing.Point(33, 97);
            this.dgwKardex.Name = "dgwKardex";
            this.dgwKardex.Size = new System.Drawing.Size(1009, 483);
            this.dgwKardex.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(33, 24);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(302, 44);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save to Excel";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Kardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 598);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgwKardex);
            this.Name = "Kardex";
            this.Text = "Kardex";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgwKardex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwKardex;
        private System.Windows.Forms.Button btnSave;
    }
}