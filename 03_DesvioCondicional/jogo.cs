using System;
using System.Collections.Generic;

namespace JogoSoldados
{
    class Player
    {
        public int Id { get; private set; }
        public int Soldiers { get; set; }

        public Player(int id)
        {
            Id = id;
            Soldiers = 0;
        }

        public bool Alive
        {
            get { return Soldiers > 0; }
        }
    }

    class Program
    {
        static Random rng = new Random();

        static int RollD6()
        {
            // Retorna de 1 a 6
            return rng.Next(1, 7);
        }

        static int SumRolls(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += RollD6();
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== Jogo de Soldados (2 a 4 jogadores) - C# 4 ===");
            int nPlayers = AskPlayers(2, 4);

            // cria jogadores
            List<Player> players = new List<Player>();
            for (int i = 1; i <= nPlayers; i++)
                players.Add(new Player(i));

            // Rodada inicial: cada jogador define soldados iniciais (1d6)
            Console.WriteLine();
            Console.WriteLine("-- Rodada Inicial: definindo soldados --");
            for (int i = 0; i < players.Count; i++)
            {
                Player p = players[i];
                p.Soldiers = RollD6();
                Console.WriteLine("Jogador " + p.Id + " inicia com " + p.Soldiers + " soldados.");
            }

            int round = 1;
            while (CountAlive(players) > 1)
            {
                Console.WriteLine();
                Console.WriteLine("=== Rodada " + round + " ===");

                // lista de vivos
                List<Player> alive = GetAlive(players);
                if (alive.Count <= 1) break;

                // escolhe atacante aleatório entre vivos
                Player attacker = PickAttacker(alive);

                // escolhe defensor aleatório diferente do atacante
                List<Player> targets = new List<Player>();
                for (int i = 0; i < alive.Count; i++)
                {
                    if (alive[i].Id != attacker.Id)
                        targets.Add(alive[i]);
                }
                if (targets.Count == 0) break;

                Player defender = targets[rng.Next(targets.Count)];

                // quantos soldados atacam (1..6, limitado ao que o atacante tem)
                int attackTroops = RollD6();
                if (attackTroops > attacker.Soldiers) attackTroops = attacker.Soldiers;

                if (attackTroops <= 0)
                {
                    Console.WriteLine("Jogador " + attacker.Id + " não tem tropas para atacar.");
                    round++;
                    continue;
                }

                // defesa usa até o mesmo nº (ou o que tiver)
                int defendTroops = defender.Soldiers < attackTroops ? defender.Soldiers : attackTroops;

                // força aleatória (cada soldado rola 1d6)
                int attackPower = SumRolls(attackTroops);
                int defensePower = defendTroops > 0 ? SumRolls(defendTroops) : 0;

                Console.WriteLine("Atacante: J" + attacker.Id + " envia " + attackTroops + " tropas (força " + attackPower + ").");
                Console.WriteLine("Defensor: J" + defender.Id + " defende com " + defendTroops + " tropas (força " + defensePower + ").");

                if (attackPower > defensePower)
                {
                    defender.Soldiers -= attackTroops;
                    if (defender.Soldiers < 0) defender.Soldiers = 0;
                    Console.WriteLine("Resultado: Ataque VENCEU. J" + defender.Id + " perde " + attackTroops + " soldados.");
                }
                else if (defensePower > attackPower)
                {
                    attacker.Soldiers -= attackTroops;
                    if (attacker.Soldiers < 0) attacker.Soldiers = 0;
                    Console.WriteLine("Resultado: Defesa SEGURA. J" + attacker.Id + " perde " + attackTroops + " soldados.");
                }
                else
                {
                    // Empate: cada lado perde 1 se tiver
                    if (attacker.Soldiers > 0) attacker.Soldiers -= 1;
                    if (defender.Soldiers > 0) defender.Soldiers -= 1;
                    Console.WriteLine("Resultado: EMPATE. J" + attacker.Id + " e J" + defender.Id + " perdem 1 soldado cada.");
                }

                // status
                for (int i = 0; i < players.Count; i++)
                {
                    Player p = players[i];
                    Console.WriteLine(" - J" + p.Id + ": " + p.Soldiers + " soldados " + (p.Alive ? "" : "(ELIMINADO)"));
                }

                round++;

                // Pausa opcional entre rodadas:
                // Console.WriteLine("Pressione qualquer tecla para a próxima rodada...");
                // Console.ReadKey(true);
            }

            Player winner = FirstAlive(players);
            Console.WriteLine();
            Console.WriteLine("=== Fim de Jogo ===");
            if (winner != null)
                Console.WriteLine("Vencedor: Jogador " + winner.Id + " com " + winner.Soldiers + " soldados!");
            else
                Console.WriteLine("Todos foram eliminados (empate geral!).");

            // Evita fechar imediatamente
            // Console.WriteLine("Pressione Enter para sair...");
            // Console.ReadLine();
        }

        static int AskPlayers(int min, int max)
        {
            while (true)
            {
                Console.Write("Quantos jogadores (" + min + "-" + max + ")? ");
                string s = Console.ReadLine();
                int n;
                if (int.TryParse(s, out n) && n >= min && n <= max)
                    return n;

                Console.WriteLine("Valor inválido.");
            }
        }

        static Player PickAttacker(List<Player> alive)
        {
            // Sorteio direto entre os vivos
            int idx = rng.Next(alive.Count);
            return alive[idx];
        }

        static int CountAlive(List<Player> players)
        {
            int count = 0;
            for (int i = 0; i < players.Count; i++)
                if (players[i].Alive) count++;
            return count;
        }

        static List<Player> GetAlive(List<Player> players)
        {
            List<Player> alive = new List<Player>();
            for (int i = 0; i < players.Count; i++)
                if (players[i].Alive) alive.Add(players[i]);
            return alive;
        }

        static Player FirstAlive(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
                if (players[i].Alive) return players[i];
            return null;
        }
    }
}
