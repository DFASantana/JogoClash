using System.Globalization;
using System.Linq.Expressions;
using System.Security.Principal;

namespace JogoClash;
public class Arqueiro
{
    public int defesa;
    public int ataque;
    public int mov;
    public int alc;

    public Arqueiro()
    {
        this.defesa  = 3;
        this.ataque  = 2;
        this.mov = 2;
        this.alc = 3;
    }
}