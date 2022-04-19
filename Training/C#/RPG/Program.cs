int heroHP = 10;
int monsterHP = 10;

Random diceRoll = new Random();

Console.WriteLine("The hero and a monster meet in battle!");

do
{
    Console.WriteLine("The Hero attacks!");
    int damageValue = diceRoll.Next(1, 11);
    monsterHP -= damageValue;
    Console.WriteLine($"Monster takes {damageValue} damage. Health is now at {monsterHP}");
        if (monsterHP <= 0)
            continue;
    
    Console.WriteLine("The Monster attacks!");
    int damageValues = diceRoll.Next(1, 11);
    heroHP -= damageValues;
    Console.WriteLine($"Hero takes {damageValues} damage. Health is now at {heroHP}");
        if (heroHP <= 0)
            continue;
            
}while (heroHP > 0 && monsterHP > 0);
if (heroHP <= 0)
    Console.WriteLine("The Monster defeats the Hero? Wait...what a terrible story...");
else
    Console.WriteLine("The Hero defeats the Monster! Time to move onto the next battle!");