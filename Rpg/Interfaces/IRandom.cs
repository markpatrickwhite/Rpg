namespace Rpg.Interfaces
{
    public interface IRandom
    {
        int GetNextInteger(int min, int max);
        int RollInitiative();
        int RollAttack();
    }
}