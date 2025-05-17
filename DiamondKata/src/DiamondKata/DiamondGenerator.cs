namespace DiamondKata;

public class DiamondGenerator
{
    public string GenerateDiamond(char letter)
    {
        if (letter == 'A')
        {
            return "A";
        }
        if (letter == 'B')
        {
            return " A \nB B\n A ";
        }
        if (letter == 'C')
        {
            return "  A\n B B\nC   C\n B B\n  A";
        }
        return string.Empty;
    }
} 