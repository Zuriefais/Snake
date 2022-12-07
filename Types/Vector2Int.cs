public struct Vector2Int
{
    public int x;
    public int y;

    public Vector2Int(int x, int y) 
    {
        this.x = x;
        this.y = y;
    }

    public Vector2Int Plus(Vector2Int vec) 
    {
        return new(
            x + vec.x,
            y + vec.y
        );
    }

    public Vector2Int Minus(Vector2Int vec) 
    {
        return new(
            x - vec.x,
            y - vec.y
        );
    }

    public Vector2Int Multiply(Vector2Int vec) 
    {
        return new(
            x * vec.x,
            y * vec.y
        );
    }

    public Vector2Int Multiply(int coefficient) 
    {
        return new(
            x * coefficient,
            y * coefficient
        );
    }

    public bool IsEqual(Vector2Int vec) 
    {
        return vec.x == x & vec.y == y;
    }
}