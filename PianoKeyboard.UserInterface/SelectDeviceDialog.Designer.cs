using System.Windows.Forms;

namespace PianoKeyboard.UserInterface
{
    partial class SelectDeviceDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDeviceDialog));
            this.deviceSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CommitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deviceSelector
            // 
            this.deviceSelector.FormattingEnabled = true;
            this.deviceSelector.Location = new System.Drawing.Point(21, 55);
            this.deviceSelector.Name = "deviceSelector";
            this.deviceSelector.Size = new System.Drawing.Size(320, 28);
            this.deviceSelector.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Keyboard wählen";
            // 
            // CommitButton
            // 
            this.CommitButton.Location = new System.Drawing.Point(266, 97);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(75, 34);
            this.CommitButton.TabIndex = 2;
            this.CommitButton.Text = "Wählen";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButtonOnClick);
            // 
            // SelectDeviceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 143);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deviceSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectDeviceDialog";
            this.Text = "Keyboard auswählen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox deviceSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CommitButton;
    }
}

