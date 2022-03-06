using Common;

namespace Cards.Cards.DM08
{
    class NecrodragonGiland : Creature
    {
        public NecrodragonGiland() : base("Necrodragon Giland", 4, 6000, Subtype.ZombieDragon, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.DoubleBreakerAbility());

            // When this creature battles, destroy it after the battle.
            AddAbilities(new TriggeredAbilities.BattleAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
