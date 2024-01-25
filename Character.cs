using System.Reflection.Metadata;

public class Character
{
    //basic informations
    public string Name { get; set; }
    public CharacterClass Class { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int MaxExperience {get; set;}
    public int Gold {get; set;}
    public int HealthPoints { get; set; }
    public int MaxHealthPoints { get; set; }
    public int ManaPoints { get; set; }
    public int MaxManaPoints { get; set; }
    public float Attack { get; set; }
    public float CriticalRate { get; set; }
    public float CriticalDamage { get; set; }
    public float Defense { get; set; }
    public bool Dead {get; set;}
    
    public Character()//CONSTRUTOR
    {
        Name = "No name"; //ReadLine funciona, sou um genio
        Class = CharacterClass.None;
        Level = 1;
        Experience = 0; //Redundante blablabla - Guilherme, Pedro 2023
        MaxExperience = 100;
        MaxHealthPoints = 100;
        MaxManaPoints = 100;
        Attack = 10;
        Defense = 5;
        CriticalRate = 5;
        CriticalDamage = 2.0f;
        HealthPoints = MaxHealthPoints;
        ManaPoints = MaxManaPoints;
        Dead = false;
    }

    public Damage DealDamage(Character character)
    {
        Random random = new Random();

        Damage damage = new Damage();
        damage.DamageDealt = (character.Attack - Defense) + random.Next(1, 10);
        
        float criticalSuccess = random.Next(0, 101);

        if(character.CriticalRate >= criticalSuccess)
        {
            damage.DamageDealt *= character.CriticalDamage;
            damage.IsCritical = true;
        }

        if(character.Attack < Defense)
            damage.DamageDealt = 0;

        HealthPoints -= Convert.ToInt32(damage.DamageDealt);
        
        if(HealthPoints <= 0)
        {
            Dead = true;
            HealthPoints = 0;
        }

        return damage;
    }

    public void HealCharacter(int healPoints)
    {
        HealthPoints += healPoints;
        if(HealthPoints >= MaxHealthPoints)
            HealthPoints = MaxHealthPoints;
    }

}