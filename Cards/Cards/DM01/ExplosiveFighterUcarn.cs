using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class ExplosiveFighterUcarn : Creature
    {
        public ExplosiveFighterUcarn() : base("Explosive Fighter Ucarn", 5, 9000, Engine.Race.Dragonoid, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutCardsFromYourManaZoneIntoYourGraveyard(2)));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
