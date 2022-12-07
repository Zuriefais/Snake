class Snake
{
    public List<Vector2Int> bodyCells {get; private set;}
    public Vector2Int moveDirection = new(1, 0);
    private World world;

    public Snake(World world) {
        this.world = world;
        world.AddCell(new(0,0), new("[green]■[/]"));
        bodyCells = new();
        bodyCells.Add(new Vector2Int(0, 3));
        bodyCells.Add(new Vector2Int(-1, 3));
        world.AddCell(new(-1, -2), new("⭕"));
    }

    public void Move() 
    {
        List<Vector2Int> cellsToDell = new();
        Vector2Int pos = new(bodyCells[0].x+moveDirection.x, bodyCells[0].y+moveDirection.y);
        if(world.GetCell(pos).printedCell == "#") 
        {
            Console.Clear();
            Console.WriteLine("You are dead");

            Environment.Exit(0);
        } 
        else if(world.GetCell(pos).printedCell == "⭕") 
        {
            bodyCells.Insert(0,new());
        } 
        else
        {
            List<Vector2Int> newBodyCells = new();
            newBodyCells.Add(new(bodyCells[0].x + moveDirection.x, bodyCells[0].y + moveDirection.y));
            foreach (var bodyCell in bodyCells)
            {
                if(bodyCell.x != bodyCells[0].x & bodyCell.y != bodyCells[0].y) {
                    newBodyCells.Add(bodyCell);
                }
            }
            bodyCells = newBodyCells;
        }
        foreach (var item in cellsToDell)
        {
            world.AddCell(item, new(" "));
        }
        foreach(var cell in bodyCells) {
            world.AddCell(cell, new("[green]■[/]"));
        }
    }
}