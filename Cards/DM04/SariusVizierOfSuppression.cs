using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM04
{
    sealed class SariusVizierOfSuppression : Creature
    {
        public SariusVizierOfSuppression() : base("Sarius, Vizier of Suppression", 2, 3000, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
