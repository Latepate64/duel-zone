using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    class BlackFeatherShadowOfRage : Creature
    {
        public BlackFeatherShadowOfRage() : base("Black Feather, Shadow of Rage", 1, Civilization.Darkness, 3000, Subtype.Ghost)
        {
            // When you put this creature into the battle zone, destroy 1 of your creatures.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingChoiceEffect(new OwnersBattleZoneCreatureFilter(), 1, 1, true, DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.Graveyard)));
        }
    }
}
