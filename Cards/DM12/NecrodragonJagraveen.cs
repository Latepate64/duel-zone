using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM12
{
    sealed class NecrodragonJagraveen : Creature
    {
        public NecrodragonJagraveen() : base("Necrodragon Jagraveen", 6, 6000, Interfaces.Race.ZombieDragon, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new OneShotEffects.DestroyAfterBattleEffect()));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
