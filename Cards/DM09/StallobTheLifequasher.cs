using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM09
{
    class StallobTheLifequasher : Engine.Creature
    {
        public StallobTheLifequasher() : base("Stallob, the Lifequasher", 8, 6000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.DestroyAllCreaturesEffect()));
        }
    }
}
