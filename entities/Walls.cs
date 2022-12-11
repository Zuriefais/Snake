using Spectre.Console;

public class Walls: WorldObject
{
    public Walls(Type type, int width, int height, Vector2Int pos, World world) 
    {
        this.world = world;
        switch(type) 
        {
            case Type.Square:
                GenerateSquare(width, height);
                break;
            case Type.Corners:
                GenerateCorners(width, height);
                break;
        }
        position = pos;
    }

    public static Walls Square(int width, int height, Vector2Int pos, World world) 
    {
        return new(Type.Square, width, height, pos, world);
    }

    public static Walls Corners(int width, int height, Vector2Int pos, World world) 
    {
        return new(Type.Corners, width, height, pos, world);
    }

    private void GenerateSquare(int width, int height) 
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if(x == 0 || x ==  width-1 || y == 0 || y == height-1) 
                {
                    this.AddCell(new Cell(
                        '#',
                        new(foreground: Color.Blue),
                        new(x, y)
                    ));
                }
            }
        }
    }

    private void GenerateCorners(int width, int height) 
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if(x == 0 || x == width-1 || y == 0 || y == height-1) 
                {
                    this.AddCell(new Cell(
                        '#',
                        new(foreground: Color.Blue),
                        new(x, y)
                    ));
                }
            }
        }
    }

    public enum Type
    {
        Square,
        Corners
    }
}