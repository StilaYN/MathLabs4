namespace Labs4;

public class Spline
{
    private Function _function;
    private float _leftBorder;
    private float _rightBorder;

    public Spline(Function function, float leftBorder, float rightBorder)
    {
        _function = function;
        _leftBorder = leftBorder;
        _rightBorder = rightBorder;
    }

    public float LeftBorder => _leftBorder;

    public float RightBorder => _rightBorder;

    public Function Function => _function;
}