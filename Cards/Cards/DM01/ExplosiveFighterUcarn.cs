using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    public class ExplosiveFighterUcarn : Creature
    {
        public ExplosiveFighterUcarn() : base("Explosive Fighter Ucarn", 5, Common.Civilization.Fire, 9000, Common.Subtype.Dragonoid)
        {
            // When you put this creature into the battle zone, put 2 cards from your mana zone into your graveyard.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ManaBurnEffect(new OwnersManaZoneCardFilter(), 2, 2, true)));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
