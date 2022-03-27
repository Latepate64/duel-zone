using Common;

namespace Cards.StaticAbilities
{
    class EachOtherCivilizationCreaturePowerAbility : Engine.Abilities.StaticAbility
    {
        public EachOtherCivilizationCreaturePowerAbility(Civilization civilization, int power) : base(new ContinuousEffects.EachOtherCivilizationCreaturePowerEffect(civilization, power))
        {
        }
    }
}