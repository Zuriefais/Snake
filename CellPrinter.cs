public class CellPrinter
{
    private int width;
    private int height;
    private World world;
    public Vector2Int cameraOffset = new(0, 0);

    public CellPrinter(int width, int height, World world)  
    {
        this.width = width;
        this.height = height;
        this.world = world;
        world.onChangeCell += Print;
    }

    public void Print() 
    {
        Console.Clear();
        string printedCells = "";
        for (int y = 0; y < height; y++)
        {
            string printedLine = "";
            for (int x = 0; x < width; x++)
            {
                Vector2Int pos = new(x+cameraOffset.x,y+cameraOffset.y);
                Cell cell;
                if (world.cells.TryGetValue(pos, out cell))
                {
                    printedLine = printedLine+world.cells[pos].printedCell;
                }
                else {
                    printedLine = printedLine+" ";
                }
            }
            printedCells = printedCells+"\n"+printedLine;
        }
        Console.WriteLine(printedCells);
    }
}