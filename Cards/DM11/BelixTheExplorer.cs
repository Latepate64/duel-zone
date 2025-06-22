using ContinuousEffects;
using TriggeredAbilities;

namespace Cards.DM11
{
    sealed class BelixTheExplorer : Engine.Creature
    {
        public BelixTheExplorer() : base("Belix, the Explorer", 2, 3000, Interfaces.Race.Gladiator, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnSpellFromYourManaZoneToYourHandEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
