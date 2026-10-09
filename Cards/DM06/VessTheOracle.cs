using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM06
{
    sealed class VessTheOracle : Creature
    {
        public VessTheOracle() : base("Vess, the Oracle", 1, 2000, Interfaces.Race.LightBringer, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
