using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM01
{
    class UrthPurifyingElemental : Engine.Creature
    {
        public UrthPurifyingElemental() : base("Urth, Purifying Elemental", 6, 6000, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()));
        }
    }
}
