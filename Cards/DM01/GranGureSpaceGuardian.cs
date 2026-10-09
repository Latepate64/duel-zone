using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM01
{
    sealed class GranGureSpaceGuardian : Creature
    {
        public GranGureSpaceGuardian() : base("Gran Gure, Space Guardian", 6, 9000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
