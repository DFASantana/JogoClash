using System.ComponentModel.Design;
using System.Globalization;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using JogoClash;

    Console.WriteLine("\nQuantos jogadores?\n" +
                      "2 - Jogadores = 2\n" +
                      "3 - Jogadores = 3\n" +
                      "4 - Jogadores = 4");
    int player = Int16.Parse(Console.ReadLine());
    
    bool p1 = true, p2 = true, p3 = true, p4 = true;
    //"#ff0000"; //vermelho
    //"#00ff00"; //verde
    //"#0000ff"; //azul
    //"#ffff01"; //amarelo
    string jn1="", cor1="", jn2="", cor2="", jn3="", cor3="", jn4="", cor4="";
    string[] color = { "Vermelho", "Verde", "Azul", "Amarelo" };
    int[] q={1,2,3,4};
    
    for (int z = 4; z > player; z--) {q = q.Where(e => e != (z)).ToArray();}
    for (int i = 0; i < player; i++)
    {int start = 0;
        //Console.WriteLine("temos "+String.Join(",", q));//ver
        
        Console.WriteLine("\nInsira Jogador " + (i + 1));
        string n = Console.ReadLine();
        Console.WriteLine("\nEscolha Cor ");
        for (int c = 0; c < color.Length; c++)
        {Console.WriteLine(c+1 +" - " + color[c]);}
        string cor = color[Int16.Parse(Console.ReadLine())-1];
        tenta:
        Random rnd = new Random();
        start = rnd.Next(1, q.Length);
        switch (q[start-1])
        {
            case 1:
                if (p1)
                {jn1 = n; cor1 = cor; p1 = false; break;}
                else {goto tenta;}
            case 2:
                if (p2)
                {jn2 = n; cor2 = cor; p2 = false; break;}
                else {goto tenta;}
            case 3:
                if (p3)
                {jn3 = n; cor3 = cor; p3 = false; break;}
                else
                {goto tenta;}
            case 4:
                if (p4)
                {jn4 = n; cor4 = cor; p4 = false; break;}
                else
                {goto tenta;}
        } q = q.Where(e => e != (q[start-1])).ToArray();
        color = color.Where(e => e != cor).ToArray();
    }

    Jogador j1 = new Jogador( jn1,cor1);
    Jogador j2 = new Jogador( jn2,cor2);
    Jogador j3 = new Jogador( jn3,cor3);
    Jogador j4 = new Jogador( jn4,cor4);

    Console.WriteLine("jogadores " + player);
    Console.WriteLine(j1.nome);
    Console.WriteLine(j2.nome);
    Console.WriteLine(j3.nome);
    Console.WriteLine(j4.nome);
    
    Jogo jogo = new Jogo(player, j1,j2,j3,j4);

    jogo.jogar();
    
    
