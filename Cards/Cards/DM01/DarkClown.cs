using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Common;
using Engine;

namespace Cards.Cards.DM01
{
    class DarkClown : Creature
    {
        public DarkClown() : base("Dark Clown", 4, 6000, Subtype.BrainJacker, Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility(), new CannotAttackCreaturesAbility(), new CannotAttackPlayersAbility(), new WinBattleAbility(new DestroyAreaOfEffect(new TargetFilter()))); // When this creature wins a battle, destroy it.
        }
    }
}
