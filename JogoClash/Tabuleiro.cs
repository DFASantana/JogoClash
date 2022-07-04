using System.Globalization;
using System.Linq.Expressions;
using System.Numerics;
using System.Security.Principal;
namespace JogoClash;

public class Tabuleiro
{
    //Tamanho tabuleiro
    private const int tile_countX = 16;
    private const int tile_countY = 16;
    //private tabuleiro[,] casas;
    private string[,] tabuleiro;
    private void Start()
    {
        GenerateTile(1, tile_countX, tile_countY);
    }

    private void GenerateTile(float tilesize, int tileX, int tileY)
    {
        //tabuleiro[][] = new tabuleiro[tileX][tileY];
        for (int x = 0; x < tileX; x++)
        {
            for (int y = 0; y < tileY; y++)
            {
                tabuleiro[x, y] = "X"+y; //GenerateTile(tilesize, x, y);
            }
        }
    }
}