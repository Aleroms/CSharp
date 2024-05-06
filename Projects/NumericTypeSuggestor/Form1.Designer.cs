namespace NumericTypeSuggestor
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
            MinValueLabel = new Label();
            MaxValueLabel = new Label();
            TypeLabel = new Label();
            SuggestedTypeLabel = new Label();
            MinInputField = new TextBox();
            MaxInputField = new TextBox();
            IntegralCheckbox = new CheckBox();
            PreciseCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // MinValueLabel
            // 
            MinValueLabel.AutoSize = true;
            MinValueLabel.Font = new Font("Segoe UI", 16F);
            MinValueLabel.Location = new Point(94, 29);
            MinValueLabel.Name = "MinValueLabel";
            MinValueLabel.Size = new Size(113, 30);
            MinValueLabel.TabIndex = 0;
            MinValueLabel.Text = "Min Value:";
            // 
            // MaxValueLabel
            // 
            MaxValueLabel.AutoSize = true;
            MaxValueLabel.Font = new Font("Segoe UI", 16F);
            MaxValueLabel.Location = new Point(90, 75);
            MaxValueLabel.Name = "MaxValueLabel";
            MaxValueLabel.Size = new Size(117, 30);
            MaxValueLabel.TabIndex = 0;
            MaxValueLabel.Text = "Max Value:";
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            TypeLabel.Location = new Point(49, 228);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(158, 25);
            TypeLabel.TabIndex = 0;
            TypeLabel.Text = "Suggested Type:";
            TypeLabel.Click += label4_Click;
            // 
            // SuggestedTypeLabel
            // 
            SuggestedTypeLabel.AutoSize = true;
            SuggestedTypeLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            SuggestedTypeLabel.Location = new Point(229, 228);
            SuggestedTypeLabel.Name = "SuggestedTypeLabel";
            SuggestedTypeLabel.Size = new Size(161, 25);
            SuggestedTypeLabel.TabIndex = 0;
            SuggestedTypeLabel.Text = "not enough data";
            SuggestedTypeLabel.Click += label4_Click;
            // 
            // MinInputField
            // 
            MinInputField.Location = new Point(229, 38);
            MinInputField.Name = "MinInputField";
            MinInputField.Size = new Size(446, 23);
            MinInputField.TabIndex = 2;
            MinInputField.TextChanged += InputField_TextChanged;
            MinInputField.KeyPress += InputField_KeyPress;
            // 
            // MaxInputField
            // 
            MaxInputField.Location = new Point(229, 82);
            MaxInputField.Name = "MaxInputField";
            MaxInputField.Size = new Size(446, 23);
            MaxInputField.TabIndex = 2;
            MaxInputField.TextChanged += InputField_TextChanged;
            MaxInputField.KeyPress += InputField_KeyPress;
            // 
            // IntegralCheckbox
            // 
            IntegralCheckbox.AutoSize = true;
            IntegralCheckbox.CheckAlign = ContentAlignment.MiddleRight;
            IntegralCheckbox.Checked = true;
            IntegralCheckbox.CheckState = CheckState.Checked;
            IntegralCheckbox.Font = new Font("Segoe UI", 16F);
            IntegralCheckbox.Location = new Point(73, 126);
            IntegralCheckbox.Name = "IntegralCheckbox";
            IntegralCheckbox.Size = new Size(167, 34);
            IntegralCheckbox.TabIndex = 3;
            IntegralCheckbox.Text = "Integral Only?";
            IntegralCheckbox.UseVisualStyleBackColor = true;
            IntegralCheckbox.CheckedChanged += IntegralChecked;
            // 
            // PreciseCheckbox
            // 
            PreciseCheckbox.AutoSize = true;
            PreciseCheckbox.CheckAlign = ContentAlignment.MiddleRight;
            PreciseCheckbox.Font = new Font("Segoe UI", 16F);
            PreciseCheckbox.Location = new Point(45, 176);
            PreciseCheckbox.Name = "PreciseCheckbox";
            PreciseCheckbox.Size = new Size(195, 34);
            PreciseCheckbox.TabIndex = 3;
            PreciseCheckbox.Text = "Must Be Precise?";
            PreciseCheckbox.UseVisualStyleBackColor = true;
            PreciseCheckbox.Visible = false;
            PreciseCheckbox.CheckedChanged += PreciseCheckbox_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(800, 298);
            Controls.Add(PreciseCheckbox);
            Controls.Add(IntegralCheckbox);
            Controls.Add(MaxInputField);
            Controls.Add(MinInputField);
            Controls.Add(SuggestedTypeLabel);
            Controls.Add(TypeLabel);
            Controls.Add(MaxValueLabel);
            Controls.Add(MinValueLabel);
            Name = "Form1";
            Text = "C# Numeric Type Suggestor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MinValueLabel;
        private Label MaxValueLabel;
        private Label TypeLabel;
        private Label SuggestedTypeLabel;
        private TextBox MinInputField;
        private TextBox MaxInputField;
        private CheckBox IntegralCheckbox;
        private CheckBox PreciseCheckbox;
    }
}
