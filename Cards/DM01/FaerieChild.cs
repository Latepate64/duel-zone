using ContinuousEffects;

namespace Cards.DM01
{
    class FaerieChild : Engine.Creature
    {
        public FaerieChild() : base("Faerie Child", 4, 2000, Interfaces.Race.CyberVirus, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
