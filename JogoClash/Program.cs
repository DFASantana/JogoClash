using System.Globalization;
using System.Linq.Expressions;
using System.Security.Principal;
using JogoClash;

Console.WriteLine("\nInsira Jogador 1 e cor");
Jogador j1 = new Jogador(Console.ReadLine(),Console.ReadLine());
Console.WriteLine("\nInsira Jogador 2 e cor");
Jogador j2 = new Jogador( Console.ReadLine(),Console.ReadLine());
Jogo jogo = new Jogo(j1,j2);

jogo.jogar();