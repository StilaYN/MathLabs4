
using ScottPlot;
using ScottPlot.Plottables;

namespace Labs4
{
    public partial class Form1 : Form
    {
        private float[] x = { 2, 4, 5, 6, 7 };
        private float[] y = { 6, 6, 1, -1, 11 };
        private bool flag = false;
        private float _leftBorder = -1f;
        private float _rightBorder = 7f;
        private CubeSplineMethod _spline;

        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        
            _spline = new CubeSplineMethod(x, y);

            //formsPlot1.Plot.Clear();
            //List<double> xs = new List<double>();
            //List<double> ys = new List<double>();

            //for (double xi = -1; xi <= 7; xi += 0.01)
            //{
            //    double interpolatedValue = LagrangeInterpolation.LagrangeBasis(x, y, x.Length, xi);
            //    xs.Add(xi);
            //    ys.Add(interpolatedValue);
            //}

            //formsPlot1.Plot.Add.Scatter(xs, ys, ScottPlot.Color.FromHex("#FA0E0E"));
            //formsPlot1.Refresh();

        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void PowerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Проверяем, была ли нажата клавиша Enter
            if (e.KeyCode == Keys.Enter)
            {

                // Вызываем метод, который обычно вызывается при изменении RadioButton
                SquareButton_CheckedChanged(sender, e);

                // Останавливаем дальнейшую обработку нажатия клавиши Enter
                e.SuppressKeyPress = true;
            }
        }

        private void LagrangeButton_CheckedChanged(object sender, EventArgs e)
        {

            /*flag = true;*/
            if (LagrangeButton.Checked)
            {
                List<float> xs = new List<float>();
                List<float> ys = new List<float>();
                for (float xi = 2; xi <= 7; xi += 0.01f)
                {
                    float interpolatedValue = _spline.GetValue(xi);
                    xs.Add(xi);
                    ys.Add(interpolatedValue);
                }


                var sp1 = formsPlot1.Plot.Add.Scatter(xs, ys, ScottPlot.Color.FromHex("#FA0E0E"));
                sp1.Label = "Сплайн";
                sp1.LineWidth = 1;

                sp1.MarkerSize = 2;
                formsPlot1.Plot.ShowLegend();
                formsPlot1.Plot.Add.Markers(x, y, ScottPlot.MarkerShape.FilledCircle, 10,
                    ScottPlot.Color.FromHex("#FF00EC"));
                formsPlot1.Plot.Axes.AutoScale();
                formsPlot1.Refresh();
            }

        }

        private void NewtonButton_CheckedChanged(object sender, EventArgs e)
        {
            if (NewtonButton.Checked)
            {
                /*flag = true;*/
                List<float> xs1 = new List<float>();
                List<float> ys1 = new List<float>();
                for (float xi = 2; xi <= 7; xi += 0.01f)
                {
                    float interpolatedValue = _spline.GetDerivativeValue(xi);
                    xs1.Add(xi);
                    ys1.Add(interpolatedValue);

                }


                var sp1 = formsPlot1.Plot.Add.Scatter(xs1, ys1, ScottPlot.Color.FromHex("#0049FF"));
                sp1.Label = "Производная";
                sp1.LineWidth = 1;
                sp1.MarkerSize = 2;
                formsPlot1.Plot.ShowLegend();

                formsPlot1.Plot.Add.Markers(x, y, ScottPlot.MarkerShape.FilledCircle, 10,
                    ScottPlot.Color.FromHex("#FF00EC"));
                formsPlot1.Plot.Axes.AutoScale();
                formsPlot1.Refresh();
            }
        }

        private void SquareButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SquareButton.Checked)
            {
                // int power = 1;
                // if (PowerTextBox.Text != "")
                // {
                //     power = int.Parse(PowerTextBox.Text);
                // }

                List<float> xs1 = new List<float>();
                List<float> ys1 = new List<float>();


                float[] xx = { 2, 4, 5, 6, 7 };
                float[] yy = { 6, 6, 1, -1, 11 };

                //SmoothingMethod smoothing = new SmoothingMethod(xx, yy, power);
                
                for (float xi = 2; xi <= 7; xi += 0.01f)
                {
                    float interpolatedValue = _spline.GetSecondDerivativeValue(xi);
                    xs1.Add(xi);
                    ys1.Add(interpolatedValue);

                }
                var sp1 = formsPlot1.Plot.Add.Scatter(xs1, ys1, ScottPlot.Color.FromHex("0AD52F"));
                sp1.Label = "Вторая производная";
                sp1.LineWidth = 1;
                sp1.MarkerSize = 2;
                formsPlot1.Plot.ShowLegend();
                //formsPlot1.Plot.Add.Scatter(xs1, ys1, ScottPlot.Color.FromHex("#0AD52F"));

                formsPlot1.Plot.Add.Markers(x, y, ScottPlot.MarkerShape.FilledCircle, 10,
                    ScottPlot.Color.FromHex("#FF00EC"));
                formsPlot1.Plot.Axes.AutoScale();
                formsPlot1.Refresh();
            }

        }


        private void DrawGraphic(List<float> xs1, List<float> ys1, ScottPlot.Color color, string label = "")
        {
            var sp1 = formsPlot1.Plot.Add.Scatter(xs1, ys1, color);
            sp1.Label = label;
            sp1.LineWidth = 2;
            sp1.MarkerSize = 5;
            formsPlot1.Plot.ShowLegend();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            formsPlot1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //     float[] coef = new float[5];
        //     coef[0] = float.Parse(textBox1.Text);
        //     coef[1] = float.Parse(textBox2.Text);
        //     coef[2] = float.Parse(textBox3.Text);
        //     coef[3] = float.Parse(textBox4.Text);
        //     coef[4] = float.Parse(textBox5.Text);
        //     int power = 1;
        //     SmoothingMethod smoothing = new SmoothingMethod(x, y, 3);
        //     if (PowerTextBox.Text != "")
        //     {
        //         power = int.Parse(PowerTextBox.Text);
        //     }
        //
        //     List<float> xs1 = new List<float>();
        //     List<float> ys1 = new List<float>();
        //
        //     formsPlot1.Plot.Clear();
        //     for (float xi = 0; xi <= 8; xi += 0.05f)
        //     {
        //         float interpolatedValue = smoothing.GetFunctionValue(xi, power, coef);
        //         xs1.Add(xi);
        //         ys1.Add(interpolatedValue);
        //
        //     }
        //
        //     DrawGraphic(xs1, ys1, ScottPlot.Colors.Black, "Степень 4 MathCad");
        //     formsPlot1.Plot.Add.Markers(x, y, ScottPlot.MarkerShape.FilledCircle, 10,
        //         ScottPlot.Color.FromHex("#FF00EC"));
        //     formsPlot1.Plot.Axes.AutoScale();
        //     formsPlot1.Refresh();
        //
        }
    }
}