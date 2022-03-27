using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class ExplosiveFighterUcarn : Creature
    {
        public ExplosiveFighterUcarn() : base("Explosive Fighter Ucarn", 5, 9000, Common.Subtype.Dragonoid, Common.Civilization.Fire)
        {
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new PutCardsFromYourManaZoneIntoYourGraveyard(2)), new DoubleBreakerAbility());
        }
    }
}
