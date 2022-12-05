public class World {
    public Dictionary<Vector2Int, Cell> cells {get; private set;} = new();
    public Vector2Int cameraOffset = new(0, 0);
    public delegate void MethodContainer();
    public MethodContainer? onChangeCell;

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
        onChangeCell();
    }

    public Cell GetCell(Vector2Int pos)
    {
        Cell cell;
        if(!cells.TryGetValue(pos, out cell))
        {
            cell = new(" ");
        }
        return cell;
        
    }
}