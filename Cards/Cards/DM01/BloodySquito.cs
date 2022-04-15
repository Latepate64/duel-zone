using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class BloodySquito : Creature
    {
        public BloodySquito() : base("Bloody Squito", 2, 4000, Engine.Subtype.BrainJacker, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
            AddTriggeredAbility(new WhenThisCreatureWinsBattleAbility(new DestroyThisCreatureEffect()));
        }
    }
}
