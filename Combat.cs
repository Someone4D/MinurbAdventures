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

        while(monster.HealthPoints > 0)
        {
            Console.Clear();

            ShowPlayerStatus(player);
            Message();
            ShowMonsterStatus(monster);
            player.HealCharacter(25);

            float damageDealt = monster.DealDamage(player.Attack, monster.Defense);

            Message($"\n\nVocê atacou {monster.Name} e causou {damageDealt} pontos de dano!");

            damageDealt = player.DealDamage(monster.Attack, player.Defense);

            Message($"{monster.Name} atacou {player.Name} e causou {damageDealt} pontos de dano!");
            Console.ReadKey();

            if(player.HealthPoints <= 0)
                GameOver();

        }
        Random random = new Random();
        int gainedExp = random.Next(monster.Experience, monster.MaxExperience);

        player.GainExperience(gainedExp);

        Message($"\n{player.Name} derrotou {monster.Name} e ganhou {gainedExp} de experiência!");
        Message("Pressione uma tecla para continuar...");
        Console.ReadKey();
    }
}