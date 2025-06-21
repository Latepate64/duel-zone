using ContinuousEffects;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01
{
    class BloodySquito : Engine.Creature
    {
        public BloodySquito() : base("Bloody Squito", 2, 4000, Interfaces.Race.BrainJacker, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WhenThisCreatureWinsBattleAbility(new DestroyThisCreatureEffect()));
        }
    }
}
