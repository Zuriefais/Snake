public abstract class WorldObject
{
    public List<Cell> cells {get; private set;} = new();
    public Vector2Int position;
    public World world;

    public WorldObject(World world) 
    {
        this.world = world;
    }

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

    public virtual void RemoveCell(Vector2Int position)
    {
        for (int i = 0; i < cells.Count; i++)
        {
            if(cells[i].position.IsEqual(position))
            {
                cells.RemoveAt(i);
            }
        }   
    }

    public void RecalculatePosition() {
        Vector2Int objPosDif = new(int.MaxValue, int.MaxValue);
        foreach (var cell in cells)
        {
            Vector2Int pos = cell.position;
            if (pos.x < objPosDif.x) 
            {
                objPosDif.x = pos.x;
            }
            if (pos.y < objPosDif.y) 
            {
                objPosDif.y = pos.y;
            }
        }
        Vector2Int newObjPos = position.Plus(objPosDif);
        world.debugInfo["objPosDif"] = objPosDif.x + ", " + objPosDif.y;
        foreach (var cell in cells)
        {
            cell.position = cell.position.Minus(objPosDif);
        }
        position = newObjPos;
        world.debugInfo["snakePositionAfterRecalc"] = position.x + ", " + position.y;
    }
}