public class Player : Character // Player está herdando a classe Character
{
    public string Title { get; set; }

    public Player()
    {
        
    }

    public void GainExperience(int xp)
    {
        Experience += xp;
        LevelUp();
    }

    public void LevelUp()
    {
        if(Experience >= MaxExperience)
        {
            Level++;
            Experience -= MaxExperience;
            MaxExperience = Convert.ToInt32(MaxExperience * 1.1f);

            if(Class == CharacterClass.Warrior)
            {
                HealthPoints += 3;
                ManaPoints += 2;
                Attack += 2;
                Defense += 3;
            }
            else if (Class == CharacterClass.Mage)
            {
                HealthPoints += 2;
                ManaPoints += 4;
                Attack += 3;
                Defense += 1;
            }
            else if(Class == CharacterClass.Archer)
            {
                HealthPoints += 3;
                ManaPoints += 3;
                Attack += 2;
                Defense += 2;
            }
            
            HealthPoints = MaxHealthPoints;
        }
    }
}


    public enum CharacterClass
    {
        None,
        Warrior,
        Mage,
        Archer,
        Monster
    }