public class Player : Character // Player está herdando a classe Character
{
    public string Title { get; set; }

    public void GainGold(int gold)
    {
        Gold += gold;
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
                MaxHealthPoints += 15;
                MaxManaPoints += 5;
                Attack += 3;
                Defense += 5;
                CriticalRate += 90;
            }
            else if (Class == CharacterClass.Mage)
            {
                MaxHealthPoints += 7;
                MaxManaPoints += 15;
                Attack += 7;
                Defense += 3;
            }
            else if(Class == CharacterClass.Archer)
            {
                MaxHealthPoints += 10;
                MaxManaPoints += 10;
                Attack += 5;
                Defense += 5;
            }
            
            HealthPoints = MaxHealthPoints;
            ManaPoints = MaxManaPoints;
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