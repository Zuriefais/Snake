public class World {
    public List<WorldObject> objects {get; private set;} = new();
    public Dictionary<Vector2Int, Cell?> cells {get; private set;} = new();
    public int width {get; private set;}
    public int height {get; private set;}

    public World(int width, int height) 
    {
        this.width = width;
        this.height = height;
    }

    public void ComputeCells()
    {
        cells.Clear();
        foreach (var obj in objects)
        {
            foreach (var cell in obj.cells)
            {
                Vector2Int pos = new(
                    obj.position.x + cell.position.x,
                    obj.position.y + cell.position.y
                );
                cells.Add(pos, cell);
            }
        }
    }

    public bool IsEmpty(Vector2Int position) 
    {
        bool isEmpty = true;
        foreach (var obj in objects)
        {
            Vector2Int positionLocal = position.Minus(obj.position);
            foreach (var cell in obj.cells)
            {
                if(obj.GetCell(positionLocal) != null) {
                    isEmpty = false;
                }
            }
        }
        return isEmpty;
    }

    public void AddObject(WorldObject obj) 
    {
        objects.Add(obj);
    }
}