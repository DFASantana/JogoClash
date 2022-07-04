using System.Globalization;
using System.Linq.Expressions;
using System.Security.Principal;
namespace JogoClash;

public class Jogador
{
    public String nome;
    public String cor;
    
    /* 6 criaturas */
    public List<Criatura> criaturas = new List<Criatura>();

    public Jogador(string nome, string cor)
    {
        this.nome = nome;
        this.cor = cor;
        
        int posx=1; int posy=0; bool tipo=false; bool hero=false; int uphero=0; //provisorio
        
        for (int i = 0; i < 6; i++)
        
        {
            criaturas.Add(new Criatura(posx, posy, tipo, hero, uphero));
        }
        this.criaturas = criaturas;
    }
}