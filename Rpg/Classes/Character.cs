using Rpg.Interfaces;

namespace Rpg.Classes
{
    public class Character : IBattleable
    {
        public Character(string name)
        {
            MaxHealth = 10;
            Health = MaxHealth;
            Name = name;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public int CalculateInitiative()
        {
            return 0;
        }
        public double CalculateAttackScore()
        {
            return 0.0;
        }
        public double CalculateDefenseScore()
        {
            return 0.0;
        }

        public bool IsAlive() { return Health > 0; }
        public void TakeDamage(int value) { Health -= value; }
        public void HealDamage(int value)
        {
            var newHealth = Health + value;
            Health = (newHealth <= MaxHealth) ? newHealth : MaxHealth;
        }

        public AttackResult Attack(IBattleable defender, int roll, int round)
        {
            const int damage = 1;
            const int baseRoll = 50;
            var target = baseRoll + (int)(CalculateAttackScore() - defender.CalculateDefenseScore());
            var result = (roll <= target);
            if (result) { defender.TakeDamage(damage); }
            return new AttackResult(
                            result, target, roll, damage, 
                            new AttackResult.Participant(Name, Health), 
                            new AttackResult.Participant(defender.Name, defender.Health), 
                            round);
        }
    }
}