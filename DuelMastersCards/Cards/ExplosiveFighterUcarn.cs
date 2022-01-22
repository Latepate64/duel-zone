using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class ExplosiveFighterUcarn : Creature
    {
        public ExplosiveFighterUcarn() : base("Explosive Fighter Ucarn", 5, Civilization.Fire, 9000, Subtype.Dragonoid)
        {
            // When you put this creature into the battle zone, put 2 cards from your mana zone into your graveyard.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingChoiceEffect(ZoneType.ManaZone, ZoneType.Graveyard, new OwnersManaZoneCardFilter(), 2, 2, true)));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
