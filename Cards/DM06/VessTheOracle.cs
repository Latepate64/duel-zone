using ContinuousEffects;

namespace Cards.DM06
{
    sealed class VessTheOracle : Engine.Creature
    {
        public VessTheOracle() : base("Vess, the Oracle", 1, 2000, Interfaces.Race.LightBringer, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
