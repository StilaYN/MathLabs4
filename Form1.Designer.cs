namespace Labs4;

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
        formsPlot1 = new ScottPlot.WinForms.FormsPlot();
        LagrangeButton = new RadioButton();
        NewtonButton = new RadioButton();
        SquareButton = new RadioButton();
        button2 = new Button();
        SuspendLayout();
        // 
        // formsPlot1
        // 
        formsPlot1.DisplayScale = 1.5F;
        formsPlot1.Location = new Point(10, 39);
        formsPlot1.Margin = new Padding(2);
        formsPlot1.Name = "formsPlot1";
        formsPlot1.Size = new Size(1144, 681);
        formsPlot1.TabIndex = 0;
        formsPlot1.Load += formsPlot1_Load;
        // 
        // LagrangeButton
        // 
        LagrangeButton.AutoSize = true;
        LagrangeButton.Location = new Point(1246, 174);
        LagrangeButton.Margin = new Padding(2);
        LagrangeButton.Name = "LagrangeButton";
        LagrangeButton.Size = new Size(82, 24);
        LagrangeButton.TabIndex = 1;
        LagrangeButton.TabStop = true;
        LagrangeButton.Text = "Сплайн";
        LagrangeButton.UseVisualStyleBackColor = true;
        LagrangeButton.CheckedChanged += LagrangeButton_CheckedChanged;
        // 
        // NewtonButton
        // 
        NewtonButton.AutoSize = true;
        NewtonButton.Location = new Point(1246, 215);
        NewtonButton.Margin = new Padding(2);
        NewtonButton.Name = "NewtonButton";
        NewtonButton.Size = new Size(125, 24);
        NewtonButton.TabIndex = 2;
        NewtonButton.TabStop = true;
        NewtonButton.Text = "Производная";
        NewtonButton.UseVisualStyleBackColor = true;
        NewtonButton.CheckedChanged += NewtonButton_CheckedChanged;
        // 
        // SquareButton
        // 
        SquareButton.AutoSize = true;
        SquareButton.Location = new Point(1246, 258);
        SquareButton.Margin = new Padding(2);
        SquareButton.Name = "SquareButton";
        SquareButton.Size = new Size(176, 24);
        SquareButton.TabIndex = 3;
        SquareButton.TabStop = true;
        SquareButton.Text = "Вторая производная";
        SquareButton.UseVisualStyleBackColor = true;
        SquareButton.CheckedChanged += SquareButton_CheckedChanged;
        // 
        // button2
        // 
        button2.Location = new Point(1250, 342);
        button2.Name = "button2";
        button2.Size = new Size(94, 29);
        button2.TabIndex = 10;
        button2.Text = "clear";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1491, 819);
        Controls.Add(button2);
        Controls.Add(SquareButton);
        Controls.Add(NewtonButton);
        Controls.Add(LagrangeButton);
        Controls.Add(formsPlot1);
        Margin = new Padding(2);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ScottPlot.WinForms.FormsPlot formsPlot1;
        private RadioButton LagrangeButton;
        private RadioButton NewtonButton;
        private RadioButton SquareButton;
        private Button button2;

    }