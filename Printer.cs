using Spectre.Console;

public class Printer
{
    private int width;
    private int height;
    private World world;
    public Vector2Int cameraOffset = new(0, 0);

    public Printer(int width, int height, World world)  
    {
        this.width = width;
        this.height = height;
        this.world = world;
    }

    public void Print() 
    {
        if (world.state == World.State.InGame)
        {
            PrintInGame();
        }
        else if(world.state == World.State.Lose)
        {
            PrintLose();
        }
        else if(world.state == World.State.Win)
        {
            PrintWin();
        }
    }

    private void PrintInGame() 
    {
        world.ComputeCells();
        AnsiConsole.Clear();
        string printedCells = "";
        foreach (var message in world.log)
        {
            printedCells = printedCells + "\n" + message;
        }
        foreach (var message in world.debugInfo)
        {
            printedCells = printedCells + "\n" + message.Key + ": " + message.Value;
        }
        for (int y = 0; y < height; y++)
        {
            string printedLine = "";
            for (int x = 0; x < width; x++)
            {
                Vector2Int pos = new(x+cameraOffset.x,y+cameraOffset.y);
                Cell? cell;
                world.cells.TryGetValue(pos, out cell);
                if(cell != null) {
                    printedLine = printedLine + cell.printedCell;
                }
                else {
                    printedLine = printedLine + " ";
                }
            }
            printedCells = printedCells + "\n" + printedLine;
        }
        AnsiConsole.MarkupLine(printedCells);
    }

    private void PrintLose() 
    {
        Console.Clear();
        Console.WriteLine("You are dead");
        Environment.Exit(0);
    }

    private void PrintWin() 
    {
        Console.Clear();
        Console.WriteLine("You win!");
        Environment.Exit(0);
    }
}