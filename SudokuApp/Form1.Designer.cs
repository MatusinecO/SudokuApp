using System.Windows.Forms;
namespace SudokuApp
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button retryButton;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.solveButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.retryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // solveButton
            // 
            this.solveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.solveButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.solveButton.Location = new System.Drawing.Point(584, 409);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(124, 32);
            this.solveButton.TabIndex = 1;
            this.solveButton.Text = "Solve";
            this.solveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.saveButton.Location = new System.Drawing.Point(584, 445);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(124, 32);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.loadButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.loadButton.Location = new System.Drawing.Point(584, 481);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(124, 32);
            this.loadButton.TabIndex = 3;
            this.loadButton.Text = "Load";
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // retryButton
            // 
            this.retryButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.retryButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.retryButton.Location = new System.Drawing.Point(584, 517);
            this.retryButton.Name = "retryButton";
            this.retryButton.Size = new System.Drawing.Size(124, 32);
            this.retryButton.TabIndex = 0;
            this.retryButton.Text = "Retry";
            this.retryButton.Click += new System.EventHandler(this.RetryButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(720, 560);
            this.Controls.Add(this.retryButton);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Sudoku Solver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);


            #endregion
        }
    }
}

