using System.Collections.Generic;
using Rpg.Interfaces;

namespace Rpg.Classes
{
    public class Battle : IBattle
    {
        private int _round;
        private IBattleable _attacker;
        private IBattleable _defender;
        private readonly IRandom _randomDice;
        private List<AttackResult> _log;
        public Battle(IRandom randomDice, IBattleable attacker, IBattleable defender)
        {
            _round = 0;
            _attacker = attacker;
            _defender = defender;
            _randomDice = randomDice;
            _log = new List<AttackResult>();
        }
        public BattleResult Resolve()
        {
            while (_attacker.IsAlive() && _defender.IsAlive())
            {
                _round++;
                if (AttackerHasInitiative())
                {
                    ResolveAttackPhase(_attacker, _defender);
                }
                else
                {
                    ResolveAttackPhase(_defender, _attacker);
                }
            }
            return new BattleResult(_attacker, _defender, _log);
        }

        private void ResolveAttackPhase(IBattleable a, IBattleable b)
        {
            ResolveAttack(a, b);
            if (b.IsAlive()) { ResolveAttack(b, a); }
        }

        private void ResolveAttack(IBattleable a, IBattleable b)
        {
            var attackResult = a.Attack(b, _randomDice.RollAttack(), _round);
            _log.Add(attackResult);
        }

        private bool AttackerHasInitiative()
        {
            var attackerInitiative = _attacker.CalculateInitiative() + _randomDice.RollInitiative();
            var defenderInitiative = _defender.CalculateInitiative() + _randomDice.RollInitiative();
            return (attackerInitiative > defenderInitiative);
        }
    }
}