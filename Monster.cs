public class Monster : Character
{
    public MonsterRank Rank { get; set; }

    Monster()
    {
        HealthPoints = MaxHealthPoints;
        ManaPoints = MaxManaPoints;
    }
    public static Monster SpawnMonster(MonsterType monsterType)
    {
        if(monsterType == MonsterType.Crab)
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
            Gold = 0
            };
        }
        else if(monsterType == MonsterType.Slime)
        {
            return new Monster()
            {
            Name = "Crab",
            Class = CharacterClass.Monster,
            Rank = MonsterRank.Normal,
            Level = 3,
            Experience = 30,
            MaxExperience = 35,
            MaxHealthPoints = 90,
            MaxManaPoints = 0,
            Attack = 20,
            Defense = 10,
            Gold = 10
            };
        }
        if(monsterType == MonsterType.AncientDragon)
        {
            return new Monster()
            {
            Name = "Podro the Devourer",
            Class = CharacterClass.Monster,
            Rank = MonsterRank.Boss,
            Level = 1,
            Experience = 1000,
            MaxExperience = 3000,
            MaxHealthPoints = 3000,
            MaxManaPoints = 100,
            Attack = 90,
            Defense = 50,
            Gold = 380
            };
        }
        else
            return null;
    }

    public static Monster SpawnRandomMonster()
    {
        Random random = new Random();
        int probability = random.Next(1, 4);

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
            Gold = 0
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
            Gold = 2
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
            Gold = 5
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