using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM11
{
    class BelixTheExplorer : Creature
    {
        public BelixTheExplorer() : base("Belix, the Explorer", 2, 3000, Engine.Race.Gladiator, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnSpellFromYourManaZoneToYourHandEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
