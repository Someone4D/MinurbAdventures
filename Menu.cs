public static class Menu
{
    public static Player CharacterCreation()
    {
        Player character = new Player();

        Console.Write("Digite um nome: ");
        character.Name = Console.ReadLine()!;

        Console.Clear();

        Console.WriteLine("Selecione uma classe: ");
        Console.WriteLine("Warrior\nMage\nArcher\n");
        
        string chosenClass = Console.ReadLine()!.ToLower();
        
        Console.Clear();

        if(chosenClass == "warrior" || chosenClass == "1")
            character.Class = CharacterClass.Warrior;
        else if(chosenClass == "mage" || chosenClass == "2")
            character.Class = CharacterClass.Mage;
        else if(chosenClass == "archer" || chosenClass == "3")
            character.Class = CharacterClass.Archer;
        
        Console.WriteLine($"Personagem criado com sucesso.\n\nNome: {character.Name}\nClasse: {character.Class}\nLevel: {character.Level}\n\nPressione uma tecla para continuar...");
        
        Console.ReadKey();

        return character;
    }

    public static void ShowPlayerStatus(Player character)
    {
        Console.WriteLine($" Nome: {character.Name}\n Classe: {character.Class}\n Level: {character.Level} ({character.Experience}/{character.MaxExperience})\n Vida: {character.HealthPoints}\n Mana: {character.ManaPoints}\n Ataque: {character.Attack}\n Defesa: {character.Defense} ");
    }
    
    public static void ShowMonsterStatus(Monster monster)
    {
        Console.WriteLine($" Nome: {monster.Name}\n Tipo: {monster.Rank}\n Level: {monster.Level}\n Vida: {monster.HealthPoints}\n Mana: {monster.ManaPoints}\n Ataque: {monster.Attack}\n Defesa: {monster.Defense} ");
    }

    public static MonsterType ShowBattleMenu()
    {
        Console.Clear();

        Console.WriteLine("Selecione um monstro para batalhar:");
        Console.WriteLine($"\n{MonsterType.Crab}\n{MonsterType.Slime}\n{MonsterType.AncientDragon}");
        
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
}