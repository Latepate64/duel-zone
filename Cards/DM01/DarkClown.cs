using ContinuousEffects;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01
{
    sealed class DarkClown : Engine.Creature
    {
        public DarkClown() : base("Dark Clown", 4, 6000, Interfaces.Race.BrainJacker, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WhenThisCreatureWinsBattleAbility(new DestroyThisCreatureEffect()));
        }
    }
}
