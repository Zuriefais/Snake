using System.Text;
using WatsonWebsocket;
using Newtonsoft.Json;

World world = new(30, 15);
Walls walls1 = Walls.Square(world.width, world.height, new(0, 0), world);
Walls walls2 = Walls.Square(world.width - 8, world.height - 8, new(4, 4), world);
Input input = new();
Snake snake = new(world, 3, new(2, 2), input);
Food food = new(world);
Printer printer = new(world.width, world.height, world);

world.AddObject(walls1);
world.AddObject(snake);
world.AddObject(food);

Console.Title = $"{world.width}, {world.height} snake";

JsonConvert.DefaultSettings = () => 
{
    var settings = new JsonSerializerSettings();
    settings.Converters.Add(new Vector2IntConverter());
    settings.Converters.Add(new CellConverter());
    settings.Converters.Add(new WorldObjectConverter());
    return settings;
};

WatsonWsServer server = new WatsonWsServer("localhost");
List<Guid> connectedPlayers = new();
server.MessageReceived += MessageReceived; 
server.ClientConnected += (s, e) => {
    Console.WriteLine("Client connected: " + e.Client.IpPort);
    server.SendAsync(e.Client.Guid, "Спасибо что подключился 👍");
    connectedPlayers.Add(e.Client.Guid);
};
server.ClientDisconnected += (s, e) => {
    Console.WriteLine("Client disconnected: " + e.Client.IpPort);
    connectedPlayers.Remove(e.Client.Guid);
};
server.Start();

Console.WriteLine(JsonConvert.SerializeObject(world.objects[1]));

void MessageReceived(object? sender, MessageReceivedEventArgs args) 
{ 
    string data = Encoding.UTF8.GetString(args.Data);
    Console.WriteLine("Message received from " + args.Client.ToString() + ": " + data);
    if(Encoding.UTF8.GetString(args.Data) == "gameComponentInitialized") {
        SendAllObjects(args.Client.Guid);
    }
    else {
        Console.WriteLine("else");
    }
    Console.WriteLine(connectedPlayers + " " + connectedPlayers.Count());
    foreach (var player in connectedPlayers)
    {
        if(args.Client.Guid != player) {
            server.SendAsync(player, data);
        }
    }
}

void SendAllObjects(Guid target) 
{
    Console.WriteLine(world.objects[0]);
    Console.WriteLine(JsonConvert.SerializeObject(world.objects[0]));
    string objectsJson = JsonConvert.SerializeObject(world.objects);
    Console.WriteLine(objectsJson);
    server.SendAsync(target, objectsJson);
}

while(false)
{
    printer.Print();
    System.Threading.Thread.Sleep(300);
    snake.Move();
}

while (true)
{
    
}