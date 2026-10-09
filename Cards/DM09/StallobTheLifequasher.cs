using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM09
{
    sealed class StallobTheLifequasher : Creature
    {
        public StallobTheLifequasher() : base("Stallob, the Lifequasher", 8, 6000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new DoubleBreakerAbility());
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.DestroyAllCreaturesEffect()));
        }
    }
}
