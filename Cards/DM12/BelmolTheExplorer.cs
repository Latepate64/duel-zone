using Abilities.Static;
using ContinuousEffects;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM12
{
    sealed class BelmolTheExplorer : Creature
    {
        public BelmolTheExplorer() : base("Belmol, the Explorer", 2, 3500, Interfaces.Race.Gladiator, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureBlocksIfAble());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
