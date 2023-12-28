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