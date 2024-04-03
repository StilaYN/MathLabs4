namespace Labs4;
using MatrixSolveMethod;
public class CubeSplineMethod
{
    private float[] _xValue;
    private float[] _yValue;
    private Spline[] _splines;

    public CubeSplineMethod(float[] xValue, float[] yValue)
    {
        _xValue = xValue;
        _yValue = yValue;
        _splines = new Spline[xValue.Length - 1];
        FindSplines();
    }

    public float GetValue(float x)
    {
        foreach (var i in _splines)
        {
            if (i.LeftBorder <= x && x <= i.RightBorder)
            {
                return i.Function.GetValue(x-i.LeftBorder);
            }
        }
        throw new ArgumentException("value not in interval");
    }

    public float GetDerivativeValue(float x)
    {
        foreach (var i in _splines)
        {
            if (i.LeftBorder <= x && x <= i.RightBorder)
            {
                return Derivative.FindSymmetrical(i.Function,0.001f,x-i.LeftBorder);
            }
        }
        throw new ArgumentException("value not in interval");
    }

    public float GetSecondDerivativeValue(float x)
    {
        foreach (var i in _splines)
        {
            if (i.LeftBorder <= x && x <= i.RightBorder)
            {
                return Derivative.FindSecond(i.Function,0.01f,x-i.LeftBorder);
            }
        }
        throw new ArgumentException("value not in interval");
    }

    private void FindSplines()
    {
        var splinesCoefficient = FindSplinesCoefficient();
        for (int i = 0; i < splinesCoefficient.GetLength(0); i++)
        {
            _splines[i] = new Spline(new Function(splinesCoefficient[i]), _xValue[i], _xValue[i + 1]);
        }
    }

    private float[][] FindSplinesCoefficient()
    {
        ThreeDiagonalMatrixAlgorithm solver = new ThreeDiagonalMatrixAlgorithm();
        (float[,] coefficient, float[,] yMatrix) = CreateCoefficientMatrix();
        var solve = solver.FindRoot(coefficient, yMatrix);
        float[] cCoefficient = new float[solve.GetLength(0)];
        float[][] splineCoefficient = new float[solve.GetLength(0)-1][];
        for (int i = 0; i < cCoefficient.Length; i++)
        {
            cCoefficient[i] = solve[i, 0];
        }
        for (int i = 0; i < cCoefficient.Length-1; i++)
        {
            var spl = new float[4];
            spl[0] = _yValue[i];
            spl[1] = (_yValue[i+1]-_yValue[i])/(_xValue[i+1]-_xValue[i])-(cCoefficient[i+1]+2*cCoefficient[i])/
                3*(_xValue[i+1]-_xValue[i]);
            spl[2] = cCoefficient[i];
            spl[3] = (cCoefficient[i+1]-cCoefficient[i])/3/(_xValue[i+1]-_xValue[i]);
            splineCoefficient[i] = spl;
        }

        return splineCoefficient;
    }
    private (float[,], float[,]) CreateCoefficientMatrix()
    {
        
        var coefficientMatrix = new float[_xValue.Length,_xValue.Length];
        var yMatrix = new float[_xValue.Length, 1];
        var endIndex = coefficientMatrix.GetLength(0) - 1;
        coefficientMatrix[0, 0] = 1;
        coefficientMatrix[endIndex, endIndex] = 1;
        yMatrix[0, 0] = 0;
        yMatrix[endIndex, 0] = 0;
        
        for (int i = 2; i < coefficientMatrix.GetLength(0); i++)
        {
            coefficientMatrix[i-1, i - 2] = _xValue[i - 2] - _xValue[i-1];
            coefficientMatrix[i-1, i-1] = 2 * (_xValue[i - 2] - _xValue[i-1] + _xValue[i-1] - _xValue[i]);
            coefficientMatrix[i-1, i] = _xValue[i-1] - _xValue[i];
            yMatrix[i-1, 0] = 3 * ((_yValue[i] - _yValue[i-1]) / (_xValue[i-1] - _xValue[i]) -
                                 (_yValue[i-1] - _yValue[i-2]) / (_xValue[i-2] - _xValue[i - 1]));
        }

        return (coefficientMatrix,yMatrix);
    }
    
}