using static GameSystem;

public static class Menu
{
    public static Player MainMenu()
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
            return null;
        
        return null;
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
        MainMenu();
    }
}