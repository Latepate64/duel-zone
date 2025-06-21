using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM04
{
    class ReBilSeekerOfArchery : Creature
    {
        public ReBilSeekerOfArchery() : base("Re Bil, Seeker of Archery", 7, 6000, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ReBilEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }

    class ReBilEffect : EachOtherCivilizationCreaturePowerEffect
    {
        public ReBilEffect(EachOtherCivilizationCreaturePowerEffect effect) : base(effect)
        {
        }

        public ReBilEffect() : base(Civilization.Light, 2000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ReBilEffect(this);
        }
    }
}
