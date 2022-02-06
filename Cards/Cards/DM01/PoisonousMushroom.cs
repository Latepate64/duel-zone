using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    public class PoisonousMushroom : Creature
    {
        public PoisonousMushroom() : base("Poisonous Mushroom", 2, Common.Civilization.Nature, 1000, Common.Subtype.BalloonMushroom)
        {
            // When you put this creature into the battle zone, you may put 1 card from your hand into your mana zone.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new FromHandIntoManaZoneEffect(new OwnersHandCardFilter(), 0, 1, true)));
        }
    }
}
