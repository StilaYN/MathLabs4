namespace Labs4;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var func = new Function(new float[] { 0, 0, 1 });
        var derivedFunc = new Function(new float[] { 0, 2 });
        float[] x = { 2, 4, 5, 6, 7 };
        float[] y = { 6, 6, 1, -1, 11 };
        for (int i = -2; i < 3; i++)
        {
            Console.WriteLine($"Point 10^{i}");
            for (int j = -1; j > -8; j--)
            {
                var value = (float)Math.Pow(10, i);
                var der = Derivative.FindRight(func, (float)Math.Pow(10, j),value) ;
                Console.WriteLine($"10^{j} {der,20:0.0000000} {derivedFunc.GetValue(value),20:0.0000000} {der-derivedFunc.GetValue(value),20:0.0000000}");
            }
        }

        CubeSplineMethod cubeSplineMethod = new CubeSplineMethod(x, y);
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}