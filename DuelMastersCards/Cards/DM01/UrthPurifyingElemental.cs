using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    public class UrthPurifyingElemental : Creature
    {
        public UrthPurifyingElemental() : base("Urth, Purifying Elemental", 6, Civilization.Light, 6000, Subtype.AngelCommand)
        {
            Abilities.Add(new DoubleBreakerAbility());
            // At the end of each of your turns, you may untap this creature.
            Abilities.Add(new AtTheEndOfYourTurnAbility(new ControllerMayUntapCreatureEffect(new TargetFilter())));
        }
    }
}
