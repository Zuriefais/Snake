public class Input
{
    public delegate void MethodContainer();
    public event MethodContainer? onW;
    public event MethodContainer? onA;
    public event MethodContainer? onS;
    public event MethodContainer? onD;

    public Input() 
    {
        InputAsync();
    }

    private async void InputAsync() 
    {
        Task consoleKeyTask = Task.Run(() => { MonitorKeyPress(); });
        await consoleKeyTask;
    }

    private void MonitorKeyPress() 
    {
        ConsoleKeyInfo cki = new ConsoleKeyInfo();
        while (true)
        {
            cki = Console.ReadKey(true);
            Dictionary<ConsoleKey, MethodContainer?> map = new() 
            {
                {ConsoleKey.W, onW},
                {ConsoleKey.A, onA},
                {ConsoleKey.S, onS},
                {ConsoleKey.D, onD}
            };
            MethodContainer? con;
            if(cki.Key == ConsoleKey.Escape) 
            {
                Environment.Exit(0);
            }
            else
            {
                map.TryGetValue(cki.Key, out con);
                if(con != null) con();
            }
             
        }
    }
}