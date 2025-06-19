using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM08
{
    class NecrodragonGiland : Engine.Creature
    {
        public NecrodragonGiland() : base("Necrodragon Giland", 4, 6000, Engine.Race.ZombieDragon, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new TriggeredAbilities.WhenThisCreatureBattlesAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
