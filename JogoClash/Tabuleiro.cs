using System.Globalization;
using System.Linq.Expressions;
using System.Security.Principal;
namespace JogoClash;

public class Tabuleiro
{
    public string [][] tabuleiro;
    //public int x;
    //public int y;

/*
y -> baixo
x -> lado
*/

    public Tabuleiro()
    {
    //String [][] tabuleiro = new string[16][];
    int tx, ty;
        for (tx = 0; tx < 16; tx++)
    {
        for (ty = 0; ty < 16; ty++)
        {
            tabuleiro[tx][ty] = new string(" ");
        }
    }
        this.tabuleiro = tabuleiro;
    }
}