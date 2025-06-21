using ContinuousEffects;

namespace Cards.DM04
{
    class GulanRiasSpeedGuardian : Engine.Creature
    {
        public GulanRiasSpeedGuardian() : base("Gulan Rias, Speed Guardian", 3, 2000, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Engine.Civilization.Darkness), new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Engine.Civilization.Darkness));
        }
    }
}
