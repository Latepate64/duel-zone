using Abilities.Triggered;
using ContinuousEffects;

namespace Cards.Cards.DM09
{
    class StallobTheLifequasher : Engine.Creature
    {
        public StallobTheLifequasher() : base("Stallob, the Lifequasher", 8, 6000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.DestroyAllCreaturesEffect()));
        }
    }
}
