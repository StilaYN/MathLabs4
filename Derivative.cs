namespace Labs4;

public class Derivative
{
    public static float FindRight(IFunction func, float step, float value)
    {
        return (func.GetValue(value + step) - func.GetValue(value)) / step;
    }

    public static float FindSymmetrical(IFunction func, float step, float value)
    {
        return (func.GetValue(value + step) - func.GetValue(value-step)) / 2 / step;
    }

    public static float FindSecond(IFunction func, float step, float value)
    {
        return (func.GetValue(value + 2 * step) - 2 * func.GetValue(value) + func.GetValue(value - 2 * step))/4/step/step;
    }
}