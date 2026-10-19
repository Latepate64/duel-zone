using TriggeredAbilities;
using OneShotEffects;
using StaticAbilities;

namespace Cards.DM10
{
    sealed class ZeroNemesisShadowOfPanic : EvolutionCreature
    {
        public ZeroNemesisShadowOfPanic() : base("Zero Nemesis, Shadow of Panic", 6, 6000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverAnyOfYourCreaturesAttacksAbility(new OpponentRandomDiscardEffect()));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
