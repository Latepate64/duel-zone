using TriggeredAbilities;
using ContinuousEffects;
using OneShotEffects;

namespace Cards.DM10
{
    class ZeroNemesisShadowOfPanic : EvolutionCreature
    {
        public ZeroNemesisShadowOfPanic() : base("Zero Nemesis, Shadow of Panic", 6, 6000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverAnyOfYourCreaturesAttacksAbility(new OpponentRandomDiscardEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
