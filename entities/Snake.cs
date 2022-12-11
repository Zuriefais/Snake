using Spectre.Console;

public class Snake: WorldObject
{
    public Vector2Int moveDirection = new(1, 0);

    public Snake(World world, int length, Vector2Int pos, Input input) {
        this.world = world;
        for (int i = 0; i < length; i++)
        {
            this.cells.Add(
                new(
                    '■',
                    new Style(foreground: new Color(15, 71, 45)),
                    moveDirection.Multiply(i)
                )
            );   
        }
        position = pos;

        input.onW += delegate { SetMoveDir(new(0, -1)); };
        input.onA += delegate { SetMoveDir(new(-1, 0)); };
        input.onS += delegate { SetMoveDir(new(0, 1)); };
        input.onD += delegate { SetMoveDir(new(1, 0)); };
    }

    private void SetMoveDir(Vector2Int vec) 
    {
        if (!vec.reversed.IsEqual(moveDirection))
        {
            moveDirection = vec;
        }
    }

    public void Move() 
    {
        Vector2Int pos = cells[cells.Count-1].position.Plus(moveDirection).Plus(this.position);
        world.debugInfo["snakeHeadPosition"] = pos.x + ", " + pos.y;
        List<Cell> nextCells = world.GetCells(new() {typeof(Walls), typeof(Snake)}, pos);
        if(nextCells.Count != 0) 
        {   
            world.state = World.State.Lose;
        }
        else
        {
            cells.Add(
                new(
                    '■',
                    new Style(foreground: new Color(15, 71, 45)),
                    cells[cells.Count-1].position.Plus(moveDirection)
            ));
            cells.RemoveAt(0);
        }
        world.debugInfo["snakePosition"] = position.x + ", " + position.y;
        RecalculatePosition();
    }
}