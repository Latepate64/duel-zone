using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM04
{
    class GulanRiasSpeedGuardian : Creature
    {
        public GulanRiasSpeedGuardian() : base("Gulan Rias, Speed Guardian", 3, 2000, Engine.Subtype.Guardian, Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Civilization.Darkness), new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Civilization.Darkness));
        }
    }
}
