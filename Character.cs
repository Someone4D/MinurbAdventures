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
        HealthPoints = MaxHealthPoints;
        ManaPoints = MaxManaPoints;
        Dead = false;
    }

    public float DealDamage(float attack, float defense)
    {
        Random random = new Random();

        float damage = (attack - defense) + random.Next(1, 10);

        if(attack < defense)
            damage = 0;

        HealthPoints -= Convert.ToInt32(damage);
        
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