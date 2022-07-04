using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Xml.Serialization;

namespace JogoClash;
public class Criatura //: Jogador
{
    public int posx;
    public int posy;
    public Boolean tipo;
    public Boolean hero;
    public int uphero;
    
    
    public int defesa;
    public int ataque;
    public int mov;
    public int alc;
    public Criatura(int posx, int posy, Boolean tipo, Boolean hero, int uphero)
    {
        this.posx  = posx;
        this.posy  = posy;

        if (tipo) //Lutador
        {
            this.ataque = 3;
            this.defesa = 5;
            this.mov = 3;
            this.alc = 1;
        }
        else //Arqueiro
        {
            this.ataque = 2;
            this.defesa = 3;
            this.mov = 2;
            this.alc = 3;
        }

        if (hero)
        {
            switch (uphero)
            {
            case 1:
                this.ataque += 1;
                break;
            case 2:
                this.defesa += 1;
                break;
            case 3:
                this.mov += 1;
                break;
            case 4:
                this.alc += 1;
                break;
            }
        }
        
    }
}