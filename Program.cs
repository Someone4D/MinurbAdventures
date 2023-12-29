using static GameSystem;
using static Menu;

Player player = MainMenu();

// Player player = new Player();
// int exp = 10;

// player = Menu.CharacterCreation();

while(true)
{
    Monster monster = new Monster();
    
    MonsterType chosenMonster = Menu.ShowBattleMenu();
    
    monster.SpawnMonster(chosenMonster);

    Combat.Battle(player, monster);
}



// while(true)
// {
//     exp += 25;
//     Console.Clear();
//     player.GainExperience(exp);
//     Menu.ShowPlayerStatus(player);
//     Console.WriteLine($"\n\nVocê ganhou {exp} de experiência.");
//     Console.ReadKey();
// }