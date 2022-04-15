using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM01
{
    class DarkClown : Creature
    {
        public DarkClown() : base("Dark Clown", 4, 6000, Engine.Subtype.BrainJacker, Civilization.Darkness)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
            AddTriggeredAbility(new WhenThisCreatureWinsBattleAbility(new DestroyThisCreatureEffect()));
        }
    }
}
