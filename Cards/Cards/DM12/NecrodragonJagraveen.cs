using Common;

namespace Cards.Cards.DM12
{
    class NecrodragonJagraveen : Creature
    {
        public NecrodragonJagraveen() : base("Necrodragon Jagraveen", 6, 6000, Engine.Subtype.ZombieDragon, Civilization.Darkness)
        {
            AddBlockerAbility();
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureBlocksAbility(new OneShotEffects.DestroyAfterBattleEffect()));
            AddDoubleBreakerAbility();
        }
    }
}
