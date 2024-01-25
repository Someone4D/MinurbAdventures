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


        List<string> options = new List<string>() { "Novo Jogo", "Continuar", "Sair" };

        string option = ChooseOption(options, "Bem vindo ao Minurb Adventures!", "Selecione uma opção para continuar...\n");

        if (option == "Novo Jogo")
            return CharacterCreation();
        else if (option == "Continuar")
            return LoadPlayer();
        else if (option == "Sair")
            return null;

        return null;
    }

    public static void MainMenu(Player player)
    {
        SavePlayer(player);

        Console.Clear();

        Message("");

        List<string> options = new List<string>() { "Explorar", "Cidade", "Status", "inventário", "DEV OPTION" };

        string option = ChooseOption(options, "Minurb Adventures", "", player);

        if (option == "Explorar")
            Explore(player);
        else if (option == "Cidade")
            City(player);
        else if (option == "Status")
            Status(player);
        else if (option == "Inventário")
            Inventory();
        else if (option == "DEV OPTION")
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
        string area = AreaMenu();
        if (area == Area.AreaName.Forest.ToString())
        {
            while (true)
            {
                Console.Clear();

                string opt = ChooseOption(new List<string>() { "Explorar", "Sair" }, "Floresta", "Você se encontra no centro da floresta\n");
                if (opt == "Explorar")
                    Combat.Battle(player, Monster.SpawnRandomMonster());

                break;
            }

        }
        else if (area == Area.AreaName.Cavern.ToString())
        {
            while (true)
            {
                Console.Clear();

                string opt = ChooseOption(new List<string>() { "Explorar", "Sair" }, "Caverna", "Você se encontra em uma caverna escura e húmida\n");
                if (opt == "Explorar")
                    Combat.Battle(player, Monster.SpawnMonster(MonsterType.AncientDragon));

                break;
            }

        }

        if (player.Dead == true)
        {
            player.Dead = false;
            player.HealthPoints = 1;
        }
    }

    private static string AreaMenu()
    {
        Console.Clear();
        return ChooseOption(Area.GetAllAreaNames());
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

        List<string> options = new List<string>() { "Guerreiro", "Mago", "Arqueiro","[REDACTED]" };

        string option = ChooseOption(options, "Selecione uma classe: ");

        if (option == "Guerreiro")
            character.Class = CharacterClass.Warrior;
        else if (option == "Mago")
            character.Class = CharacterClass.Mage;
        else if (option == "Arqueiro")
            character.Class = CharacterClass.Archer;
        else if (option == "[REDACTED]")
            character.Class = CharacterClass.Overlord;

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
        if (chosenOption == "0")
            return MonsterType.Crab;
        if (chosenOption == "1")
            return MonsterType.Slime;
        if (chosenOption == "2")
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

    public static string ChooseOption(List<string> options, string title = "", string description = "", Player player = null)
    {
        int index = 0;

        while (true)
        {
            Console.Clear();

            if (title != "")
            {
                Title(title);
                Message(description);
            }

            if (player != null)
            {
                Title($"{player.Name} - HP: {player.HealthPoints}/{player.MaxHealthPoints} MP: {player.ManaPoints}/{player.MaxManaPoints} Level: {player.Level} XP: ({player.Experience}/{player.MaxExperience})", ConsoleColor.Green);
                Gold(player.Gold);
                Message();
            }

            for (int i = 0; i < options.Count; i++)
            {
                if (index == i)
                {
                    Message(options[i], ConsoleColor.Cyan);
                }
                else
                {
                    Message(options[i]);
                }
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                index++;
                if (index >= options.Count)
                    index = 0;
            }
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                index--;
                if (index < 0)
                    index = options.Count - 1;
            }
            if (keyInfo.Key == ConsoleKey.Enter)
                return options[index];
        }
    }



}