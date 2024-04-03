namespace Labs4;

public class Function:IFunction
{
    private float[] _coefficients;

    public float[] Coefficients => _coefficients;
/// <summary>
/// 
/// </summary>
/// <param name="coefficients">coefficients a in form a + a1x + a2x^2+...anx^n</param>
    public Function(float[] coefficients)
    {
        _coefficients = coefficients;
    }

    public float GetValue(float value)
    {
        float summ = 0;
        for (int i = 0; i < _coefficients.Length; i++)
        {
            summ += _coefficients[i] * (float)Math.Pow(value, i);
        }
        return summ;
    }
}