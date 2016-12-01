using Rpg.Interfaces;

namespace Rpg.Classes
{
    public class AttackResult : IAttackResult
    {
        public bool WasHit { get; private set; }
        public int TargetRoll { get; private set; }
        public int ActualRoll { get; private set; }
        public int DamageInflicted { get; private set; }
        public Participant Attacker{ get; private set; }
        public Participant Defender { get; private set; }
        public int AttackRound { get; private set; }

        public AttackResult(
                bool wasHit, 
                int targetRoll, 
                int actualRoll, 
                int damageInflicted,
                Participant attacker,
                Participant defender,
                int round)
        {
            WasHit = wasHit;
            TargetRoll = targetRoll;
            ActualRoll = actualRoll;
            DamageInflicted = damageInflicted;
            Attacker = attacker;
            Defender = defender;
            AttackRound = round;
        }

        public class Participant
        {
            public string Name;
            public int Health;

            public Participant(string name, int health)
            {
                Name = name;
                Health = health;
            }
        }
    }
}