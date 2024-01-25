using static Menu;
using static GameSystem;


public static class Combat
{
    public static void Battle(Player player, Monster monster)
    {
        Console.Clear();

        Message("Você sente uma presença agressiva.");
        Message($"{player.Name} foi emboscado por {monster.Name}\n");

        Console.ReadKey();

        while (true)
        {
            Console.Clear();
            Title("A batalha iniciou!");
            Message();
            Title("Jogador:", ConsoleColor.Green);
            ShowPlayerStatus(player);
            Message();
            Title("Inimigo:", ConsoleColor.Red);
            ShowMonsterStatus(monster);

            Damage damage = monster.DealDamage(player);
            
            if(damage.IsCritical == true)
                Message($"\n\nVocê atingiu um golpe devastador contra {monster.Name} causando {damage.DamageDealt} pontos de dano!", ConsoleColor.Red);
            else
                Message($"\n\nVocê atacou {monster.Name} causando {damage.DamageDealt} pontos de dano!");

            damage = player.DealDamage(monster);

             if(damage.IsCritical == true)
                Message($"\n\n{monster.Name} atingiu um golpe devastador contra você causando {damage.DamageDealt} pontos de dano!", ConsoleColor.Red);
            else
                Message($"\n\n{monster.Name} atacou você causando {damage.DamageDealt} pontos de dano!");

            Console.ReadKey();
        
            if (player.HealthPoints <= 0)
            {
                GameOver();
                player.Dead = true;
                break;
            }
           
            if (monster.HealthPoints <= 0)
            {
                BattleVictory(player, monster);
                break;
            }

        }
    }

    private static void BattleVictory(Player player, Monster monster)
    {
        Random random = new Random();
        int gainedExp = random.Next(monster.Experience, monster.MaxExperience);

        player.GainExperience(gainedExp);
        player.GainGold(monster.Gold);

        Message($"\n{player.Name} derrotou {monster.Name} e ganhou {gainedExp} de experiência e {monster.Gold} Minurbiuns!");
        Message("Pressione uma tecla para continuar...");
        Console.ReadKey();
    }
}