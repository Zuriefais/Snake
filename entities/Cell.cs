using Spectre.Console; 

public class Cell
{
    public string printedCell
    { 
        get
        {
            string styleStr = style.ToMarkup();
            return $"[{styleStr}]{symbol}[/]";
        }
    }
    public Vector2Int position;
    public char symbol;
    public Style style;

    public Cell(char symbol, Style style, Vector2Int position) 
    {
        this.symbol = symbol;
        this.style = style;
        this.position = position;
    }
}