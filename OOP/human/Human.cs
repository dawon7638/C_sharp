class Human
{
    // Fields for Human
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    private int Health;

    public int myHealth
    {
        get { return Health; }
    }


    public Human(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        Health = 100;
    }

    public Human(string name, int strength, int intelligence, int dexterity, int health)
    {
        Name = name;
        Strength = strength;
        Intelligence = intelligence;
        Dexterity = dexterity;
        Health = health;
    }

    public int Attack(Human target)
    {
        int dmg = this.Strength * 5;
        target.Health -= dmg;
        return target.Health;
    }
}

