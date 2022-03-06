using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class ExplosiveFighterUcarn : Creature
    {
        public ExplosiveFighterUcarn() : base("Explosive Fighter Ucarn", 5, 9000, Common.Subtype.Dragonoid, Common.Civilization.Fire)
        {
            // When you put this creature into the battle zone, put 2 cards from your mana zone into your graveyard.
            AddAbilities(new PutIntoPlayAbility(new ManaBurnEffect(new OwnersManaZoneCardFilter(), 2, 2, true)), new DoubleBreakerAbility());
        }
    }
}
