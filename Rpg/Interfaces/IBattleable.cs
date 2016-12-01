using Rpg.Classes;

namespace Rpg.Interfaces
{
    public interface IBattleable
    {
        string Name { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        void TakeDamage(int value);
        void HealDamage(int value);
        int CalculateInitiative();
        double CalculateAttackScore();
        double CalculateDefenseScore();
        bool IsAlive();
        AttackResult Attack(IBattleable defender, int roll, int round);
    }
}