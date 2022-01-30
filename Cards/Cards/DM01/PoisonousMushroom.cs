using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;
using Engine.Zones;

namespace Cards.Cards.DM01
{
    public class PoisonousMushroom : Creature
    {
        public PoisonousMushroom() : base("Poisonous Mushroom", 2, Civilization.Nature, 1000, Subtype.BalloonMushroom)
        {
            // When you put this creature into the battle zone, you may put 1 card from your hand into your mana zone.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingChoiceEffect(new OwnersHandCardFilter(), 0, 1, true, ZoneType.Hand, ZoneType.ManaZone)));
        }
    }
}
