using ContinuousEffects;

namespace Cards.DM04
{
    sealed class GulanRiasSpeedGuardian : Creature
    {
        public GulanRiasSpeedGuardian() : base("Gulan Rias, Speed Guardian", 3, 2000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Interfaces.Civilization.Darkness), new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Interfaces.Civilization.Darkness));
        }
    }
}
