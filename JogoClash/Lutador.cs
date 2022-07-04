using System.Globalization;
using System.Linq.Expressions;
using System.Security.Principal;

namespace JogoClash;
public class Lutador
{
    public int defesa;
    public int ataque;
    public int mov;
    public int alc;

    public Lutador()
    {
        this.defesa  = 3;
        this.ataque  = 5;
        this.mov = 3;
        this.alc = 1;
    }
}