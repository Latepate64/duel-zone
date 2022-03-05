using Common;

namespace Cards.Cards.DM08
{
    public class NecrodragonGiland : Creature
    {
        public NecrodragonGiland() : base("Necrodragon Giland", 4, Civilization.Darkness, 6000, Subtype.ZombieDragon)
        {
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());

            // When this creature battles, destroy it after the battle.
            Abilities.Add(new TriggeredAbilities.BattleAbility(new OneShotEffects.DestroyAfterBattleEffect()));
        }
    }
}
