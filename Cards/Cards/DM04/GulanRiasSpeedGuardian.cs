using Common;

namespace Cards.Cards.DM04
{
    class GulanRiasSpeedGuardian : Creature
    {
        public GulanRiasSpeedGuardian() : base("Gulan Rias, Speed Guardian", 3, 2000, Subtype.Guardian, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.ThisCreatureCannotBeAttackedByCivilizationCreaturesAbility(Civilization.Darkness), new StaticAbilities.UnblockableAbility(new CardFilters.OpponentsBattleZoneCivilizationCreatureFilter(Civilization.Darkness)));
        }
    }
}
