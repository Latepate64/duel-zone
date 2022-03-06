using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class ToelVizierOfHope : Creature
    {
        public ToelVizierOfHope() : base("Toel, Vizier of Hope", 5, 2000, Common.Subtype.Initiate, Common.Civilization.Light)
        {
            // At the end of each of your turns, you may untap all your creatures in the battle zone.
            Abilities.Add(new AtTheEndOfYourTurnAbility(new ControllerMayUntapCreatureEffect(new OwnersBattleZoneCreatureFilter())));
        }
    }
}
