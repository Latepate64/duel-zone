using Abilities.Static;
using ContinuousEffects.CannotAttack;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01
{
    sealed class BloodySquito : Creature
    {
        public BloodySquito() : base("Bloody Squito", 2, 4000, Interfaces.Race.BrainJacker, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WhenThisCreatureWinsBattleAbility(new DestroyThisCreatureEffect()));
        }
    }
}
