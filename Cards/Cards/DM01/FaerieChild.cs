using ContinuousEffects;

namespace Cards.Cards.DM01
{
    class FaerieChild : Engine.Creature
    {
        public FaerieChild() : base("Faerie Child", 4, 2000, Engine.Race.CyberVirus, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }
    }
}
