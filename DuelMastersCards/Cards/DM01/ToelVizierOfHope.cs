using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    class ToelVizierOfHope : Creature
    {
        public ToelVizierOfHope() : base("Toel, Vizier of Hope", 5, Civilization.Light, 2000, Subtype.Initiate)
        {
            // At the end of each of your turns, you may untap all your creatures in the battle zone.
            Abilities.Add(new AtTheEndOfYourTurnAbility(new ControllerMayUntapCreatureEffect(new OwnersBattleZoneCreatureFilter())));
        }
    }
}
