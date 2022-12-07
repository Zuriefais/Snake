using Spectre.Console;

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
    }

    public void Print() 
    {
        world.ComputeCells();
        AnsiConsole.Clear();
        string printedCells = "";
        for (int y = 0; y < height; y++)
        {
            string printedLine = "";
            for (int x = 0; x < width; x++)
            {
                Vector2Int pos = new(x+cameraOffset.x,y+cameraOffset.y);
                Cell ?cell;
                if (world.cells.TryGetValue(pos, out cell))
                {
                    if(cell != null)
                    printedLine = printedLine + world.cells[pos].printedCell;
                }
                else {
                    printedLine = printedLine+" ";
                }
            }
            printedCells = printedCells+"\n"+printedLine;
        }
        AnsiConsole.MarkupLine(printedCells);
        
    }
}