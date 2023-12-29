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
            return new Player()
            {
                Name = "MindBlank",
                Class = CharacterClass.Warrior,
                Level = 1,
                Experience = 0,
                MaxExperience = 100,
                MaxHealthPoints = 100,
                MaxManaPoints = 100,
                Attack = 10,
                Defense = 5,
                HealthPoints = 100,
                ManaPoints = 100,
                Dead = false,
            };
        
        return null;
    }

    public static void MainMenu(Player player)
    {
        Console.Clear();
        Title($"{player.Name} - HP: {player.HealthPoints}/{player.MaxHealthPoints} MP: {player.ManaPoints}/{player.MaxManaPoints} Level: {player.Level} ({player.Experience}/{player.MaxExperience})");
        Gold(player.Gold);

        int option = ShowOptions(new List<string>(){"Explorar", "Cidade", "Status", "Inventário"});
        
        if(option == '1')
            Explore(player);
        else if(option == '2')
            City();
        else if(option == '3')
            Status(player);
        else if(option == '4')
            Inventory();
    }

    private static void Inventory()
    {
        throw new NotImplementedException();
    }

    private static void Status(Player player)
    {
        ShowPlayerStatus(player);
    }

    private static void City()
    {
        throw new NotImplementedException();
    }

    private static void Explore(Player player)
    {
        int area = AreaMenu();
        if(area == '1')
        {
            while(true)
            {
                Console.Clear();

                Title("Forest");
                int opt = ShowOptions(new List<string>(){"Explorar", "Sair"});
                if(opt == 1)
                    Combat.Battle(player, Monster.SpawnRandomMonster());
                else
                    break;
            }
            
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
        Message("1 - Warrior\n2 - Mage\n3 - Archer\n");

        int option = ChooseOption();

        if(option == '1')
            character.Class = CharacterClass.Warrior;
        else if(option == '2')
            character.Class = CharacterClass.Mage;
        else if(option == '3')
            character.Class = CharacterClass.Archer;

        Console.Clear();
        
        Message($"Personagem criado com sucesso.\n\nNome: {character.Name}\nClasse: {character.Class}\nLevel: {character.Level}\n\nPressione uma tecla para continuar...");
        
        Console.ReadKey();

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
        TitleScreen();
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