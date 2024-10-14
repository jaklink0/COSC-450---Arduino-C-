namespace Carduino
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Unlock = new Button();
            Lock = new Button();
            UserInput = new TextBox();
            UserOutput = new Label();
            SuspendLayout();
            // 
            // Unlock
            // 
            Unlock.Location = new Point(288, 40);
            Unlock.Name = "Unlock";
            Unlock.Size = new Size(212, 83);
            Unlock.TabIndex = 0;
            Unlock.Text = "Unlock";
            Unlock.UseVisualStyleBackColor = true;
            Unlock.Click += btnUnlock_Click;
            // 
            // Lock
            // 
            Lock.Location = new Point(288, 153);
            Lock.Name = "Lock";
            Lock.Size = new Size(212, 90);
            Lock.TabIndex = 1;
            Lock.Text = "Lock";
            Lock.UseVisualStyleBackColor = true;
            Lock.Click += btnLock_Click;
            // 
            // UserInput
            // 
            UserInput.Location = new Point(302, 249);
            UserInput.Name = "UserInput";
            UserInput.Size = new Size(175, 23);
            UserInput.TabIndex = 2;
            UserInput.Text = "Enter Password";
            UserInput.TextAlign = HorizontalAlignment.Center;
            UserInput.Enter += UserInput_Enter;
            UserInput.Leave += UserInput_Leave;
            // 
            // UserOutput
            // 
            UserOutput.Location = new Point(191, 275);
            UserOutput.Name = "UserOutput";
            UserOutput.Size = new Size(400, 50);
            UserOutput.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UserOutput);
            Controls.Add(UserInput);
            Controls.Add(Lock);
            Controls.Add(Unlock);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Unlock;
        private Button Lock;
        private TextBox UserInput;
        private Label UserOutput;
    }
}
