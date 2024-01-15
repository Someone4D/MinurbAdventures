using static GameSystem;

//explorar - areas
//cidade - loja
//inventario
//status - distribuir atributos

public static class Menu
{
    public static Player TitleScreen()
    {
        Console.Clear();

        
        List<string> options = new List<string>(){"Novo Jogo", "Continuar", "Sair"};

        string option = ChooseOption(options);

        static string ChooseOption(List<string> options)
        {
            int index = 0;

            while(true)
            {
                Console.Clear();
                Title("Bem vindo a Minurb Adventures!");
                Console.ForegroundColor = ConsoleColor.Gray;

                for (int i = 0; i < options.Count; i++)
                {
                    if (index == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(options[i]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.WriteLine(options[i]);
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.DownArrow)
                    if (index < options.Count - 1)
                        index++;
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    if (index > 0)
                        index--;
                if (keyInfo.Key == ConsoleKey.Enter)
                    return options[index];
            }
        }

        if(option == "Novo Jogo")
            return CharacterCreation();
        else if(option == "Continuar")
            return LoadPlayer();
        else if(option == "Sair")
            return null;

        return null;
    }

    public static void MainMenu(Player player)
    {
        SavePlayer(player);

        Console.Clear();
        Title($"{player.Name} - HP: {player.HealthPoints}/{player.MaxHealthPoints} MP: {player.ManaPoints}/{player.MaxManaPoints} Level: {player.Level} XP: ({player.Experience}/{player.MaxExperience})", ConsoleColor.Cyan);
        Gold(player.Gold); // não aparece mais
        Message("");

        List<string> options = new List<string>(){"Explorar", "Cidade", "Status", "inventário", "DEV OPTION"};

        string option = ChooseOption(options);

        static string ChooseOption(List<string> options)
        {
            int index = 0;

            while(true)
            {
                Console.Clear();

                for (int i = 0; i < options.Count; i++)
                {
                    if (index == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(options[i]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.WriteLine(options[i]);
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.DownArrow)
                    if (index < options.Count - 1)
                        index++;
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    if (index > 0)
                        index--;
                if (keyInfo.Key == ConsoleKey.Enter)
                    return options[index];
            }
    }
        
        if(option == "Explorar")
            Explore(player);
        else if(option == "Cidade")
            City(player);
        else if(option == "Status")
            Status(player);
        else if(option == "inventário")
            Inventory();
        else if(option == "DEV OPTION")
            player.GainExperience(1000);
        
    }

    private static void Inventory()
    {
        throw new NotImplementedException();
    }

    private static void Status(Player player)
    {
        Console.Clear();

        ShowPlayerStatus(player);
        Message("Pressione algo para continuar...");
        
        Console.ReadKey();
    }

    private static void City(Player player)
    {
        Console.Clear();

        player.HealCharacter(player.MaxHealthPoints);
        Message("Você descansa em uma pousada da cidade e recupera suas forças.", ConsoleColor.Blue);
        Message("\nPressione algo para continuar...");

        Console.ReadKey();
    }

    private static void Explore(Player player)
    {
        int area = AreaMenu();
        if(area == '1')
        {
            while(true)
            {
                Console.Clear();

                Title("Floresta", ConsoleColor.Green);
                int opt = ShowOptions(new List<string>(){"Explorar", "Sair"});
                if(opt == '1')
                {
                    Combat.Battle(player, Monster.SpawnRandomMonster());
                    break;
                }
                else
                    break;
            }
            
        }
        else if(area == '2')
        {
            while(true)
            {
                Console.Clear();

                Title("Caverna", ConsoleColor.DarkGray);
                int opt = ShowOptions(new List<string>(){"Explorar", "Sair"});
                if(opt == '1')
                {
                    Combat.Battle(player, Monster.SpawnMonster(MonsterType.AncientDragon));
                    break;
                }
                else
                    break;
            }
            
        }
        
        if(player.Dead == true)
        {
            player.Dead = false;
            player.HealthPoints = 1;
        }
    }

    private static int AreaMenu()
    {
        Console.Clear();
        return ShowOptions(Area.GetAllAreaNames());
    }

    public static int ChooseOption()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        return keyInfo.KeyChar;
    }

    public static Player CharacterCreation()
    {
        Console.Clear();

        Player character = new Player();

        Message("Digite um nome: ");
        character.Name = Console.ReadLine()!;

        Console.Clear();

        Message("Selecione uma classe: ");// não aparece
        
        List<string> options = new List<string>(){"Guerreiro", "Mago", "Arqueiro"};

        string option = ChooseOption(options);

        static string ChooseOption(List<string> options)
        {
                int index = 0;

            while(true)
            {
                Console.Clear();

                for (int i = 0; i < options.Count; i++)
                {
                    if (index == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(options[i]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.WriteLine(options[i]);
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.DownArrow)
                    if (index < options.Count - 1)
                        index++;
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    if (index > 0)
                        index--;
                if (keyInfo.Key == ConsoleKey.Enter)
                    return options[index];
            }
        }
        
        if(option == "Guerreiro")
            character.Class = CharacterClass.Warrior;
        else if(option == "Mago")
            character.Class = CharacterClass.Mage;
        else if(option == "Arqueiro")
            character.Class = CharacterClass.Archer;

        Console.Clear();
        
        Message($"Personagem criado com sucesso.\n\nNome: {character.Name}\nClasse: {option}\nLevel: {character.Level}\n\nPressione uma tecla para continuar...");
        
        Console.ReadKey();

        SavePlayer(character);

        return character;
    }

    public static void ShowPlayerStatus(Player character)
    {
        Message($" Nome: {character.Name}\n Classe: {character.Class}\n Level: {character.Level} ({character.Experience}/{character.MaxExperience})\n Vida: {character.HealthPoints}\n Mana: {character.ManaPoints}\n Ataque: {character.Attack}\n Defesa: {character.Defense} ");
    }
    
    public static void ShowMonsterStatus(Monster monster)
    {
        Message($" Nome: {monster.Name}\n Tipo: {monster.Rank}\n Level: {monster.Level}\n Vida: {monster.HealthPoints}\n Mana: {monster.ManaPoints}\n Ataque: {monster.Attack}\n Defesa: {monster.Defense} ");
    }

    public static MonsterType ShowBattleMenu()
    {
        Console.Clear();

        Message("Selecione um monstro para batalhar:");
        Message($"\n{MonsterType.Crab}\n{MonsterType.Slime}\n{MonsterType.AncientDragon}");
        
        string chosenOption = Console.ReadLine()!;
        if(chosenOption == "0")
            return MonsterType.Crab;
        if(chosenOption == "1")
            return MonsterType.Slime;
        if(chosenOption == "2")
            return MonsterType.AncientDragon;
        else
            return MonsterType.Crab;
    }

    public static void GameOver()
    {
        Console.Clear();

        Title("Você morreu...");
        Message("Pressione uma tecla para continuar");
        Console.ReadKey();
    }

    public static int ShowOptions(List<string> options)
    {
        Message("Escolha uma opção: ");

        int index = 1;

        foreach (var option in options)
        {
            Message($"{index} - " + option);
            index++;
        }

        return ChooseOption();
        
    }
}