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
        Title("Bem vindo a Minurb Adventures!");
        Message("Selecione uma opção:");
        Message("\n1 - Criar um novo jogo?");
        Message("2 - Continuar");
        
        int option = ChooseOption();

        if(option == '1')
            return CharacterCreation();
        else if(option == '2')
            return LoadPlayer();
        
        return null;
    }

    public static void MainMenu(Player player)
    {
        SavePlayer(player);

        Console.Clear();
        Title($"{player.Name} - HP: {player.HealthPoints}/{player.MaxHealthPoints} MP: {player.ManaPoints}/{player.MaxManaPoints} Level: {player.Level} XP: ({player.Experience}/{player.MaxExperience})", ConsoleColor.Cyan);
        Gold(player.Gold);
        Message("");

        int option = ShowOptions(new List<string>(){"Explorar", "Cidade", "Status", "Inventário"});
        
        if(option == '1')
            Explore(player);
        else if(option == '2')
            City(player);
        else if(option == '3')
            Status(player);
        else if(option == '4')
            Inventory();
        else if(option == '9')
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

        Message("Selecione uma classe: ");
        int option = ShowOptions(new List<string>(){"Warrior", "Mage", "Archer"});
        
        if(option == '1')
            character.Class = CharacterClass.Warrior;
        else if(option == '2')
            character.Class = CharacterClass.Mage;
        else if(option == '3')
            character.Class = CharacterClass.Archer;

        Console.Clear();
        
        Message($"Personagem criado com sucesso.\n\nNome: {character.Name}\nClasse: {character.Class}\nLevel: {character.Level}\n\nPressione uma tecla para continuar...");
        
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