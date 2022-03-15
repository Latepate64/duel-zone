using Common;

namespace Cards.Cards.DM04
{
    class GalklifeDragon : Creature
    {
        public GalklifeDragon() : base("Galklife Dragon", 7, 6000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.DestroyAreaOfEffect(new CardFilters.OpponentsBattleZoneMaxPowerCivilizationCreatureFilter(4000, Civilization.Light))), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
