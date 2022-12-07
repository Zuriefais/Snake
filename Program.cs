using Spectre.Console;

int width = 10;
int height = 10;
World world = new();
CellPrinter cellPrinter = new(15, 15, world);
Console.Title = "25*25 tiles snake";

for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        if(x == 0 || x ==  width-1 || y == 0 || y == height-1) {
            world.AddCell(new(x,y), new("#"));
        }
    }
}
AsyncTest();
Snake snake = new(world);
while(true) {
    Input();
}

async void AsyncTest() {

    await Task.Run(
    () => 
    {
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("hi");
        }
    }
    ); 
    
    
}

void Input() {
    ConsoleKeyInfo key = Console.ReadKey();
    if(key.Key == ConsoleKey.W || key.Key == ConsoleKey.A || key.Key == ConsoleKey.S || key.Key == ConsoleKey.D) 
    {
        Walk(key);
        snake.Move();
    }
    else if(key.Key == ConsoleKey.Escape)
    {
        Console.Clear();
        Console.WriteLine("stopping");

        Environment.Exit(0);
    }
}

void Walk(ConsoleKeyInfo key) {
    Dictionary<ConsoleKey, Vector2Int> map = new() 
    {
        {ConsoleKey.W, new(0, -1)},
        {ConsoleKey.A, new(-1, 0)},
        {ConsoleKey.S, new(0, 1)},
        {ConsoleKey.D, new(1, 0)}
    };
    Vector2Int moveDirection;
    map.TryGetValue(key.Key, out moveDirection);
    snake.moveDirection = moveDirection;
}
