using ContinuousEffects;

namespace Cards.DM01
{
    sealed class CandyDrop : Creature
    {
        public CandyDrop() : base("Candy Drop", 3, 1000, Interfaces.Race.CyberVirus, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
