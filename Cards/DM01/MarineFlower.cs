using ContinuousEffects;

namespace Cards.DM01
{
    class MarineFlower : Engine.Creature
    {
        public MarineFlower() : base("Marine Flower", 1, 2000, Interfaces.Race.CyberVirus, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
