using TriggeredAbilities;
using OneShotEffects;
using Abilities.Static;

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
