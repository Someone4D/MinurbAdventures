using static GameSystem;
using static Menu;


Start();

void Start()
{
    Player player = TitleScreen();
    Run(player);
}

void Run(Player player)
{
    while(true)
    {
        MainMenu(player);
    }
}
