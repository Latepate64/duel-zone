using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;
using TriggeredAbilities;

namespace Cards.DM11
{
    sealed class BelixTheExplorer : Creature
    {
        public BelixTheExplorer() : base("Belix, the Explorer", 2, 3000, Interfaces.Race.Gladiator, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnSpellFromYourManaZoneToYourHandEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
