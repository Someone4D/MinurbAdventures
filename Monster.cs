public class Monster : Character
{
    public MonsterRank Rank { get; set; }
    public void SpawnMonster(MonsterType monsterType)
    {
        if(monsterType == MonsterType.Crab)
        {
            Name = "Crab";
            Class = CharacterClass.Monster;
            Rank = MonsterRank.Normal;
            Level = 1;
            Experience = 10;
            MaxExperience = 15;
            MaxHealthPoints = 30;
            MaxManaPoints = 0;
            Attack = 10;
            Defense = 2;
            HealthPoints = MaxHealthPoints;
            ManaPoints = MaxManaPoints;
        }
        else if(monsterType == MonsterType.Slime)
        {
            Name = "Slime";
            Class = CharacterClass.Monster;
            Rank = MonsterRank.Normal;
            Level = 3;
            Experience = 20;
            MaxExperience = 25;
            MaxHealthPoints = 50;
            MaxManaPoints = 10;
            Attack = 12;
            Defense = 5;
            HealthPoints = MaxHealthPoints;
            ManaPoints = MaxManaPoints;
        }
        if(monsterType == MonsterType.AncientDragon)
        {
            Name = "Podro the Devourer";
            Class = CharacterClass.Monster;
            Rank = MonsterRank.Boss;
            Level = 20;
            Experience = 1000;
            MaxExperience = 1500;
            MaxHealthPoints = 600;
            MaxManaPoints = 200;
            Attack = 69;
            Defense = 50;
            HealthPoints = MaxHealthPoints;
            ManaPoints = MaxManaPoints;
        }
    }

    public static Monster SpawnRandomMonster()
    {
        Random random = new Random();
        int probability = random.Next(1, 3);

        if(probability == 1)
        {
            return new Monster()
            {
            Name = "Crab",
            Class = CharacterClass.Monster,
            Rank = MonsterRank.Normal,
            Level = 1,
            Experience = 10,
            MaxExperience = 15,
            MaxHealthPoints = 30,
            MaxManaPoints = 0,
            Attack = 10,
            Defense = 2,
            HealthPoints = 30,
            ManaPoints = 0,
            };
        }
        else if(probability == 2)
        {
            return new Monster()
            {
            Name = "Shiny Crab",
            Class = CharacterClass.Monster,
            Rank = MonsterRank.Unique,
            Level = 2,
            Experience = 10,
            MaxExperience = 50,
            MaxHealthPoints = 70,
            MaxManaPoints = 0,
            Attack = 12,
            Defense = 5,
            HealthPoints = 70,
            ManaPoints = 0,
            };   
        }
        else if(probability == 3)
        {
            return new Monster()
            {
            Name = "Crablicious",
            Class = CharacterClass.Monster,
            Rank = MonsterRank.Boss,
            Level = 5,
            Experience = 100,
            MaxExperience = 150,
            MaxHealthPoints = 300,
            MaxManaPoints = 150,
            Attack = 15,
            Defense = 8,
            HealthPoints = 300,
            ManaPoints = 150,
            };   
        }
        else
        {
            return null;
        }
    }
}


public enum MonsterType
{
    Crab,
    Slime,
    Spider,
    AncientDragon,
    OldGod
}

public enum MonsterRank
{
    Normal,
    Elite,
    Unique,
    Boss
}