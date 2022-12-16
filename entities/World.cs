public class World {
    public List<WorldObject> objects {get; private set;} = new();
    public Dictionary<Vector2Int, Cell?> cells {get; private set;} = new();
    public int width {get; private set;}
    public int height {get; private set;}
    public State state = State.InGame;

    public List<string> log = new();
    public Dictionary<string, string> debugInfo = new();

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
                if (!cells.TryAdd(pos, cell))
                {
                    cells[pos] = cell;
                }
            }
        }
    }

    public WorldObject? GetObject(Type type)
    {
        foreach (var obj in objects)
        {
            if(obj.GetType() == type) {
                return obj;
            }
        }
        return null;
    }

    public void DestroyObject(WorldObject worldObject)
    {
        worldObject.OnDestroy();
        objects.Remove(worldObject);
    }

    public List<Cell> GetCells(List<Type> worldObjectType, Vector2Int pos) 
    {
        List<Cell> cells = new();
        foreach (var obj in objects)
        {
            foreach (var type in worldObjectType)
            {
                if (obj.GetType() == type)
                {
                    Vector2Int localPos = pos.Minus(obj.position);
                    Cell? cell = obj.GetCell(localPos);
                    if (cell != null)
                    {
                        cells.Add(cell);
                    }
                }
            }
            
        }
        return cells;
    }

    public void AddObject(WorldObject obj) 
    {
        obj.world = this;
        objects.Add(obj);
    }

    public enum State
    {
        InGame,
        Lose,
        Win
    }
}