using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM08
{
    sealed class NecrodragonGiland : Creature
    {
        public NecrodragonGiland() : base("Necrodragon Giland", 4, 6000, Interfaces.Race.ZombieDragon, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new DoubleBreakerAbility());
            AddTriggeredAbility(new WhenThisCreatureBattlesAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
