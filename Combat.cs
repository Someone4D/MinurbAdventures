public static class Combat
{
    public static void Battle(Player player, Monster monster)
    {
        Console.Clear();

        Console.WriteLine("Você sente uma presença agressiva.");
        Console.WriteLine($"{player.Name} foi emboscado por {monster.Name}\n");
        
        Console.ReadKey();

        while(monster.HealthPoints > 0)
        {
            Console.Clear();

            Menu.ShowPlayerStatus(player);
            Console.WriteLine();
            Menu.ShowMonsterStatus(monster);

            float damageDealt = monster.DealDamage(player.Attack, monster.Defense);

            Console.WriteLine($"\n\nVocê atacou {monster.Name} e causou {damageDealt} pontos de dano!");

            damageDealt = player.DealDamage(monster.Attack, player.Defense);

            Console.WriteLine($"{monster.Name} atacou {player.Name} e causou {damageDealt} pontos de dano!");
            Console.ReadKey();

        }
        Random random = new Random();
        int gainedExp = random.Next(monster.Experience, monster.MaxExperience);

        player.GainExperience(gainedExp);

        Console.WriteLine($"\n{player.Name} derrotou {monster.Name} e ganhou {gainedExp} de experiência!");
        Console.WriteLine("Pressione uma tecla para continuar...");
        Console.ReadKey();
    }
}