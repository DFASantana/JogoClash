namespace JogoClash;

public class Sorte
{
    public int player;
 
    public Sorte(int player)
    {   
        Random rnd = new Random();
        int start = rnd.Next(1, player);}
}