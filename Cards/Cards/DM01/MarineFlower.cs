using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM01
{
    class MarineFlower : Engine.Creature
    {
        public MarineFlower() : base("Marine Flower", 1, 2000, Engine.Race.CyberVirus, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
