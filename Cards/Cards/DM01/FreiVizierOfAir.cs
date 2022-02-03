using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class FreiVizierOfAir : Creature
    {
        public FreiVizierOfAir() : base("Frei, Vizier of Air", 4, Common.Civilization.Light, 3000, Common.Subtype.Initiate)
        {
            // At the end of each of your turns, you may untap this creature.
            Abilities.Add(new AtTheEndOfYourTurnAbility(new ControllerMayUntapCreatureEffect(new TargetFilter())));
        }
    }
}
