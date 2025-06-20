using ContinuousEffects;

namespace Cards.Cards.DM06
{
    class VessTheOracle : Engine.Creature
    {
        public VessTheOracle() : base("Vess, the Oracle", 1, 2000, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
