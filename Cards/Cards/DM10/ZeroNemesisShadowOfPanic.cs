using Abilities.Triggered;
using ContinuousEffects;

namespace Cards.Cards.DM10
{
    class ZeroNemesisShadowOfPanic : EvolutionCreature
    {
        public ZeroNemesisShadowOfPanic() : base("Zero Nemesis, Shadow of Panic", 6, 6000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverAnyOfYourCreaturesAttacksAbility(new OneShotEffects.OpponentDiscardsCardAtRandomEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
