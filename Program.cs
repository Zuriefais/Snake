Console.WriteLine("enter width: ");
int width = 10;
Console.WriteLine("enter height: ");
int height = 10;
World world = new();
CellPrinter cellPrinter = new(20, 20, world);

for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        if(x == 0 || x ==  width-1 || y == 0 || y == height-1) {
            world.AddCell(new(x,y), new("#"));
        }
    }
}
Vector2Int snakePosition = new(width/2, height/2);
world.AddCell(snakePosition, new("0"));
void Input() {
    ConsoleKeyInfo key = Console.ReadKey();
    if(key.Key == ConsoleKey.W || key.Key == ConsoleKey.A || key.Key == ConsoleKey.S || key.Key == ConsoleKey.D) 
    {
        Walk(key);
    }
    else if(key.Key == ConsoleKey.Escape)
    {
        Environment.Exit(0);
    }
}

void Walk(ConsoleKeyInfo key) {
    Dictionary<ConsoleKey, Vector2Int> map = new() 
    {
        {ConsoleKey.W, new(0,1)},
        {ConsoleKey.A, new(-1,0)},
        {ConsoleKey.S, new(0,-1)},
        {ConsoleKey.D, new(1,0)}
    };
    Vector2Int moveDirection;
    map.TryGetValue(key.Key, out moveDirection);
    cellPrinter.cameraOffset = new(cellPrinter.cameraOffset.x + moveDirection.x, cellPrinter.cameraOffset.y + moveDirection.y);
    world.AddCell(snakePosition, new(" "));
    snakePosition = new(snakePosition.x + moveDirection.x, snakePosition.y + moveDirection.y);
    if(world.GetCell(snakePosition).printedCell == "#") 
    {
        Console.Clear();
        Console.WriteLine("You Died!!!");
        System.Threading.Thread.Sleep(500);
        Environment.Exit(0);
    }
    world.AddCell(snakePosition, new("0"));
}

while(true) {
    Input();
} 
