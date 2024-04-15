using System.ComponentModel;

namespace Tic_tac_toe.Forms;

partial class History
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        this.GameHistryArea = new System.Windows.Forms.TextBox();
        this.B_back = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // GameHistryArea
        // 
        this.GameHistryArea.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.GameHistryArea.Location = new System.Drawing.Point(3, 4);
        this.GameHistryArea.Margin = new System.Windows.Forms.Padding(4);
        this.GameHistryArea.Multiline = true;
        this.GameHistryArea.Name = "GameHistryArea";
        this.GameHistryArea.Size = new System.Drawing.Size(1177, 534);
        this.GameHistryArea.TabIndex = 0;
        // 
        // B_back
        // 
        this.B_back.Location = new System.Drawing.Point(1207, 4);
        this.B_back.Margin = new System.Windows.Forms.Padding(4);
        this.B_back.Name = "B_back";
        this.B_back.Size = new System.Drawing.Size(100, 38);
        this.B_back.TabIndex = 1;
        this.B_back.Text = "Back";
        this.B_back.UseVisualStyleBackColor = true;
        this.B_back.Click += new System.EventHandler(this.B_back_Click);
        // 
        // History
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1320, 554);
        this.Controls.Add(this.B_back);
        this.Controls.Add(this.GameHistryArea);
        this.Margin = new System.Windows.Forms.Padding(4);
        this.Name = "History";
        this.Text = "History";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Button B_back;

    private System.Windows.Forms.TextBox GameHistryArea;

    #endregion
}