using System.Formats.Asn1;
using System.Globalization;
using System.Linq.Expressions;
using System.Security.Principal;
namespace JogoClash;

public class Jogo
{
    private Jogador jogador1;
    private Jogador jogador2;
    //private List<Criatura> criaturas;

    public Jogo(Jogador jogador1, Jogador jogador2)
    {
        this.jogador1 = jogador1;
        this.jogador2 = jogador2;
    }

    public void jogar()
    {

    String [][] tabuleiro = new string[16][];
    int tx, ty;
    for (tx = 0; tx < 16; tx++)
        {
            for (ty = 0; ty < 16; ty++)
            {
                tabuleiro[tx][ty] = new string(" ");
            }
        }
   
        int round = 1;

        st:
        Console.WriteLine("\nQuem inicia o Jogo?\n" +
                          "0 - Escolha à sorte\n" +
                          "1 - Jogador 1\n" +
                          "2 - Jogador 2");
        int start = Int16.Parse(Console.ReadLine());

        if (start == 0)
        {
            Random rnd = new Random();
            start = rnd.Next(1, 2);
        }
        else if (start != 1 && start != 2)
        {
            goto st;
        }

        //joga:
        int x = jogador1.criaturas.Count;
        int y = jogador2.criaturas.Count;
        Random rj = new Random();
        string vence = jogador1.nome;

        for (int i = 0; i < 1000; i++)
        {
            if (x > 0 && y > 0)
            {Console.WriteLine("\n*************" +
                               "\n  Round " + round + "\n" +
                               "*************");
                if (start == 1) //Jogador 1 ATK
                {
                    int jx = x;
                    Console.WriteLine(jogador1.nome + " (" + x + " Criaturas) VS " + jogador2.nome + " (" + y + " Criaturas)"
                        +"\n*******************************************************");
                    for (int a1 = 0; a1 < jx && y>0; a1++)
                    {
                        int pj1 = rj.Next(x);
                        int pj2 = rj.Next(y);
                        int atk1 = (jogador1.criaturas[pj1].ataque);
                        int def1 = (jogador1.criaturas[pj1].defesa);
                        int atk2 = (jogador2.criaturas[pj2].ataque);
                        int def2 = (jogador2.criaturas[pj2].defesa);

                        Console.WriteLine("\t ATK " + atk1 + " DEF " + def1 + " --VS-> ATK " + atk2 + " DEF " + def2);
                        def2 = def2-atk1;
                        jogador2.criaturas[pj2].defesa = def2;//para gravar o dano recebido
                        if (def2 > 0)
                        {
                            Console.WriteLine("** " + jogador2.nome + " defendeu e contra-ataca **");
                            Console.WriteLine("\t ATK " + atk1 + " DEF " + def1 + " <-VS-- ATK " + atk2 + " DEF " + def2);
                            def1 = def1 - atk2;
                            jogador1.criaturas[pj1].defesa = def1;//para gravar o dano recebido
                            if (def1 > 0)
                            {
                                Console.WriteLine("* Sem MORTES *   ATK " + atk1 + " DEF " + def1 + " / ATK " + atk2 +
                                                  " DEF " + def2+ "\n");
                            }
                            else
                            {
                                Console.WriteLine("* " + jogador1.nome + " perdeu 1 Criatura *   ATK " + atk1 + " DEF " +
                                                  def1 + " / ATK " + atk2 + " DEF " + def2 + "\n");
                                jogador1.criaturas.RemoveAt(pj1);
                                x--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("* " + jogador2.nome + " perdeu 1 Criatura *   ATK " + atk1 + " DEF " + def1 +
                                              " / ATK " + atk2 + " DEF " + def2 + "\n");
                            jogador2.criaturas.RemoveAt(pj2);
                            y--;
                        }Thread.Sleep(4000);
                    }round++;
                    start = 2;
                }
                else if (start == 2) // Jogador 2 a ATK
                {
                    int jy = y;
                    Console.WriteLine(jogador2.nome + " (" + y + " Criaturas) VS " + jogador1.nome + " (" + x + " Criaturas)"
                                      +"\n*******************************************************");
                    for (int b1 = 0; b1 < jy && x>0; b1++)
                    {
                        int pj1 = rj.Next(x);
                        int pj2 = rj.Next(y);
                        int atk1 = (jogador1.criaturas[pj1].ataque);
                        int def1 = (jogador1.criaturas[pj1].defesa);
                        int atk2 = (jogador2.criaturas[pj2].ataque);
                        int def2 = (jogador2.criaturas[pj2].defesa);

                        Console.WriteLine("\t ATK " + atk2 + " DEF " + def2 + " --VS-> ATK " + atk1 + " DEF " + def1);
                        def1 = def1-atk2;
                        jogador1.criaturas[pj1].defesa = def1;//para gravar o dano recebido
                        if (def1 > 0)
                        {
                            Console.WriteLine("** " + jogador1.nome + " defendeu e contra-ataca **");
                            Console.WriteLine("\t ATK " + atk2 + " DEF " + def2 + " <-VS-- ATK " + atk1 + " DEF " + def1);
                            def2 = def2 - atk1;
                            jogador2.criaturas[pj2].defesa = def2;//para gravar o dano recebido
                            if (def2 > 0)
                            {
                                Console.WriteLine("* Sem MORTES *   ATK " + atk2 + " DEF " + def2 + " / ATK " + atk1 +
                                                  " DEF " + def1+ "\n");
                            }
                            else
                            {
                                Console.WriteLine("* " + jogador2.nome + " perdeu 1 Criatura *   ATK " + atk2 + " DEF " +
                                                  def2 + " / ATK " + atk1 + " DEF " + def1 + "\n");
                                jogador2.criaturas.RemoveAt(pj2);
                                y--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("* " + jogador1.nome + " perdeu 1 Criatura *   ATK " + atk2 + " DEF " + def2 +
                                              " / ATK " + atk1 + " DEF " + def1 + "\n");
                            jogador1.criaturas.RemoveAt(pj1);
                            x--;
                        }Thread.Sleep(4000);
                    } round++;
                    start = 1;
                }
            }else {break;}
        }
        if (x<y){vence = jogador2.nome;}
        else if (x == y) { vence = "*Ninguem*";}
        Console.WriteLine("************************" +
                          "\n  {0} Ganhou\n" +
                          "************************",vence);
        //Environment.Exit(0);
    }
}