public class CellPrinter
{
    private Dictionary<Vector2Int, Cell> cells = new();
    private int width;
    private int height;
    public Vector2Int cameraOffset = new(0, 0);

    public CellPrinter(int width, int height)  
    {
        this.width = width;
        this.height = height;
    }

    public void ClearCells() 
    {
        cells.Clear();
    }

    public void AddCell(Vector2Int pos, Cell cell) 
    {
        if(!cells.TryAdd(pos, cell))
        {
            cells[pos] = cell;
        }
        Print();
    }

    public Cell GetCell(Vector2Int pos)
    {
        return cells[pos];
        
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
                if (cells.TryGetValue(pos, out cell))
                {
                    printedLine = printedLine+cells[pos].printedCell;
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