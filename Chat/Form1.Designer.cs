
namespace Chat
{
    partial class Form1
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
            this.typeBox = new System.Windows.Forms.TextBox();
            this.chatBox = new System.Windows.Forms.ListBox();
            this.connectToServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // typeBox
            // 
            this.typeBox.Location = new System.Drawing.Point(46, 402);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(446, 20);
            this.typeBox.TabIndex = 0;
            // 
            // chatBox
            // 
            this.chatBox.FormattingEnabled = true;
            this.chatBox.Location = new System.Drawing.Point(46, 102);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(446, 238);
            this.chatBox.TabIndex = 1;
            this.chatBox.SelectedIndexChanged += new System.EventHandler(this.chatBox_SelectedIndexChanged);
            // 
            // connectToServer
            // 
            this.connectToServer.Location = new System.Drawing.Point(520, 40);
            this.connectToServer.Name = "connectToServer";
            this.connectToServer.Size = new System.Drawing.Size(114, 43);
            this.connectToServer.TabIndex = 2;
            this.connectToServer.Text = "Connect";
            this.connectToServer.UseVisualStyleBackColor = true;
            this.connectToServer.Click += new System.EventHandler(this.connectToServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.connectToServer);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.typeBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox typeBox;
        private System.Windows.Forms.ListBox chatBox;
        private System.Windows.Forms.Button connectToServer;
    }
}

