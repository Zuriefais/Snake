Console.WriteLine("enter width: ");
int width = 10;
Console.WriteLine("enter height: ");
int height = 10;
CellPrinter cellPrinter = new(20, 20);
for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        if(x == 0 || x ==  width-1 || y == 0 || y == height-1) {
            cellPrinter.AddCell(new(x,y), new("#"));
        }
    }
}
Vector2Int snakePosition = new(width/2, height/2);
cellPrinter.AddCell(snakePosition, new("0"));
cellPrinter.Print();
while(true) {
    ConsoleKeyInfo key = Console.ReadKey();
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
    cellPrinter.AddCell(snakePosition, new(" "));
    snakePosition = new(snakePosition.x + moveDirection.x, snakePosition.y + moveDirection.y);
    cellPrinter.AddCell(snakePosition, new("0"));
} 
