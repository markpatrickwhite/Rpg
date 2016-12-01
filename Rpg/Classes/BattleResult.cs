using System;
using System.Collections.Generic;
using Rpg.Interfaces;

namespace Rpg.Classes
{
    public class BattleResult
    {
        public BattleResult(IBattleable attacker, IBattleable defender, List<AttackResult> battleLog)
        {
            _round = 0;
            Attacker = attacker;
            Defender = defender;
            BattleLog = battleLog.Count != 0 ? battleLog : new List<AttackResult>();
        }

        private int _round;
        private IBattleable Attacker { get; set; }
        private IBattleable Defender { get; set; }
        private List<AttackResult> BattleLog { get; set; }

        public void DisplayResults()
        {
            LogBegin();

            foreach (var log in BattleLog)
            {
                LogNewRound(log);
                LogAttack(log);
            }

            LogEnd();
        }

        private void LogNewRound(AttackResult log)
        {
            if (log.AttackRound == _round) return;
            LogHealth(log);
            LogRound(log.AttackRound);
            _round = log.AttackRound;
        }

        private void LogBegin()
        {
            Console.WriteLine($"BATTLE BEGINS! ({Attacker.Name} vs. {Defender.Name})");
        }

        private void LogEnd()
        {
            Console.WriteLine();
            Console.WriteLine($"BATTLE END: {(Attacker.IsAlive() ? "Defender" : "Attacker")} is dead; {(Attacker.IsAlive() ? "Attacker" : "Defender")} wins in Round {_round}!");
        }

        private void LogAttack(AttackResult attackResult)
        {
            var damageText = $" and did {attackResult.DamageInflicted} damage to {attackResult.Defender.Name}";
            var logText = $"Attack by {attackResult.Attacker.Name} {(attackResult.WasHit ? "hit" : "missed")} (target: {attackResult.TargetRoll}, roll: {attackResult.ActualRoll}){(attackResult.WasHit ? damageText : string.Empty)}.";
            Console.WriteLine(logText);
        }

        private void LogRound(int round)
        {
            var logText = $" ## Round {round} ##";
            Console.WriteLine();
            Console.WriteLine(logText);
        }

        private static void LogHealth(AttackResult log)
        {
            var healthText = $"Remaining health: {log.Attacker.Name} ({log.Attacker.Health}), {log.Defender.Name} ({log.Defender.Health})";
            Console.WriteLine(healthText);
        }
    }
}