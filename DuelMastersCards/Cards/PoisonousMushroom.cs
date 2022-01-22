using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class PoisonousMushroom : Creature
    {
        public PoisonousMushroom() : base("Poisonous Mushroom", 2, Civilization.Nature, 1000, Subtype.BalloonMushroom)
        {
            // When you put this creature into the battle zone, you may put 1 card from your hand into your mana zone.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingEffect(ZoneType.Hand, ZoneType.ManaZone, 0, 1, true, new OwnersHandCardFilter())));
        }
    }
}
