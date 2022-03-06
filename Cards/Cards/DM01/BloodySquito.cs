using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Common;
using Engine;

namespace Cards.Cards.DM01
{
    class BloodySquito : Creature
    {
        public BloodySquito() : base("Bloody Squito", 2, Civilization.Darkness, 4000, Subtype.BrainJacker)
        {
            AddAbilities(new BlockerAbility(), new CannotAttackCreaturesAbility(), new CannotAttackPlayersAbility(), new WinBattleAbility(new DestroyAreaOfEffect(new TargetFilter()))); // When this creature wins a battle, destroy it.
        }
    }
}
