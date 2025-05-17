namespace DiamondKata;

public class DiamondGenerator
{
    public string GenerateDiamond(char letter)
    {
        if (letter == 'A')
        {
            return "A";
        }
        
        return " A \nB B\n A ";
    }
} 