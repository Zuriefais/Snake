using System;
using System.Collections;
using Spectre.Console;

[Serializable]
class Food: WorldObject
{
    public Food(World world): base(world)
    {
        Spawn();
    }

    public Food(World world, Vector2Int pos): base(world)
    {
        cells.Add(new('⦿', new(foreground:  new Color(128, 0, 0)), pos));
        world.debugInfo["food pos"] = cells[0].position.x + ", " + cells[0].position.y;
        RecalculatePosition();
        world.debugInfo["food pos"] = cells[0].position.x + ", " + cells[0].position.y;
        world.debugInfo["food object pos"] = position.x + ", " + position.y;
    }

    private void Spawn() 
    {
        Random random = new();
        Vector2Int pos = new(0, 0);
        pos.x = random.Next(0, world.width);
        pos.y = random.Next(0, world.height);

        List<Cell> wallsCells = world.GetCells(new() {typeof(Walls), typeof(Snake)}, pos.Plus(position));
        world.debugInfo["wallsCells count"] = wallsCells.Count().ToString();
        if(wallsCells.Count() == 0) 
        {
            cells.Add(new('⦿', new(foreground:  new Color(128, 0, 0)), pos));
            world.debugInfo["food pos"] = pos.x + ", " + pos.y;
            RecalculatePosition();
        }
        else 
        {
            Spawn();
        }
    }

    public override void OnDestroy()
    {
        Food newFood = new(world);
        world.AddObject(newFood);
    }
}