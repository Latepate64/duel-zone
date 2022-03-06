using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class PoisonousMushroom : Creature
    {
        public PoisonousMushroom() : base("Poisonous Mushroom", 2, 1000, Common.Subtype.BalloonMushroom, Common.Civilization.Nature)
        {
            // When you put this creature into the battle zone, you may put 1 card from your hand into your mana zone.
            Abilities.Add(new PutIntoPlayAbility(new FromHandIntoManaZoneEffect(new OwnersHandCardFilter(), 0, 1, true)));
        }
    }
}
