using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM08
{
    class NecrodragonGiland : Engine.Creature
    {
        public NecrodragonGiland() : base("Necrodragon Giland", 4, 6000, Interfaces.Race.ZombieDragon, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new WhenThisCreatureBattlesAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
