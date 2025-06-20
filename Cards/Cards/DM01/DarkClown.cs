using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Abilities.Triggered;
using ContinuousEffects;

namespace Cards.Cards.DM01
{
    class DarkClown : Engine.Creature
    {
        public DarkClown() : base("Dark Clown", 4, 6000, Engine.Race.BrainJacker, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WhenThisCreatureWinsBattleAbility(new DestroyThisCreatureEffect()));
        }
    }
}
