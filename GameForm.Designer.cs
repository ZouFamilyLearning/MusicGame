namespace MusicGame
{
    partial class GameForm
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
            this.Update = new System.Windows.Forms.Timer(this.components);
            this.Jump = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Update
            // 
            this.Update.Enabled = true;
            this.Update.Interval = 30;
            this.Update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // Jump
            // 
            this.Jump.Location = new System.Drawing.Point(310, 324);
            this.Jump.Name = "Jump";
            this.Jump.Size = new System.Drawing.Size(75, 23);
            this.Jump.TabIndex = 0;
            this.Jump.Text = "JUMP";
            this.Jump.UseVisualStyleBackColor = true;
            this.Jump.Click += new System.EventHandler(this.Jump_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Jump);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Update;
        private System.Windows.Forms.Button Jump;
    }
}