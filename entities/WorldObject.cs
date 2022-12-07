using Spectre.Console;

public class WorldObject
{
    public List<Cell> cells {get; private set;} = new();
    public Vector2Int position;

    public void AddCell(Cell cell) 
    {
        cells.Add(cell);
    }
    
    public Cell? GetCell(Vector2Int position) 
    {
        Cell? cell = null;
        foreach (var c in cells)
        {
            if(c.position.IsEqual(position)) {
                cell = c;
            }
        }
        return cell;
    }
}