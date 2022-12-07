using Spectre.Console;

public class Snake: WorldObject
{
    public Vector2Int moveDirection = new(1, 0);
    private World world;

    public Snake(World world, int length, Vector2Int position) {
        this.world = world;
        for (int i = 0; i < length; i++)
        {
            this.cells.Add(
                new(
                    '■',
                    new Style(foreground: new Color(15, 71, 45)),
                    position.Plus(moveDirection.Multiply(i))
                )
            );   
        }
    }

    public void Move() 
    {
        Vector2Int pos = new(cells[0].x + moveDirection.x, cells[0].y + moveDirection.y);
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
            cells.RemoveAt(cells.Count-1);
            cells.Insert(
                0, 
                new(
                    '■',
                    new Style(foreground: new Color(15, 71, 45)),
                    cells[0].position.Plus(moveDirection)
                ));
        }
        foreach(var cell in bodyCells) {
            world.AddCell(cell, new("[green]■[/]"));
        }
    }
}