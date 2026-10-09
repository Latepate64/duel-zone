using Abilities.Static;
using ContinuousEffects.CannotAttack;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01
{
    sealed class DarkClown : Creature
    {
        public DarkClown() : base("Dark Clown", 4, 6000, Interfaces.Race.BrainJacker, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WhenThisCreatureWinsBattleAbility(new DestroyThisCreatureEffect()));
        }
    }
}
