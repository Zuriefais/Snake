class Snake
{
    public List<Vector2Int> bodyCells {get; private set;}
    public Vector2Int moveDirection = new(1, 0);
    private World world;

    Snake(World world) {
        this.world = world;
        world.AddCell(new(0,0), new("■"));
        bodyCells = new();
        bodyCells.Add(new Vector2Int(0, 0));
        while (true)
        {
            Move();
        }
    }

    public void Move() 
    {
        Vector2Int pos = new(bodyCells[0].x+moveDirection.x, bodyCells[0].y+moveDirection.y);
        if(world.GetCell(pos).printedCell == "#") 
        {
            Console.Clear();
            Console.WriteLine("You are dead");

            Environment.Exit(0);
        } else if(world.GetCell(pos).printedCell == "⭕") 
        {

        } else
        {
            
        }

    }
}