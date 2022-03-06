using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    class UrthPurifyingElemental : Creature
    {
        public UrthPurifyingElemental() : base("Urth, Purifying Elemental", 6, 6000, Common.Subtype.AngelCommand, Common.Civilization.Light)
        {
            Abilities.Add(new DoubleBreakerAbility());
            // At the end of each of your turns, you may untap this creature.
            Abilities.Add(new AtTheEndOfYourTurnAbility(new ControllerMayUntapCreatureEffect(new TargetFilter())));
        }
    }
}
