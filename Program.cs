World world = new(30, 15);
Walls walls1 = Walls.Square(world.width, world.height, new(0, 0), world);
Walls walls2 = Walls.Square(world.width - 8, world.height - 8, new(4, 4), world);
Input input = new();
Snake snake = new(world, 3, new(2, 2), input);
Printer printer = new(world.width, world.height, world);

world.AddObject(walls1);
world.AddObject(walls2);
world.AddObject(snake);

Console.Title = $"{world.width}, {world.height} snake";

while(true)
{
    printer.Print();
    System.Threading.Thread.Sleep(300);
    snake.Move();
}