using ContinuousEffects;

namespace Cards.DM01
{
    sealed class FaerieChild : Creature
    {
        public FaerieChild() : base("Faerie Child", 4, 2000, Interfaces.Race.CyberVirus, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
