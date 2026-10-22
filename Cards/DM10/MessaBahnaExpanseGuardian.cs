using StaticAbilities;
using ContinuousEffects;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM10
{
    sealed class MessaBahnaExpanseGuardian : Creature
    {
        public MessaBahnaExpanseGuardian() : base("Messa Bahna, Expanse Guardian", 3, 5000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureBlocksIfAbleEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
