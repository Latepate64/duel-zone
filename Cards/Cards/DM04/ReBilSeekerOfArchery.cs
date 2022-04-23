using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class ReBilSeekerOfArchery : Creature
    {
        public ReBilSeekerOfArchery() : base("Re Bil, Seeker of Archery", 7, 6000, Engine.Race.MechaThunder, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ReBilEffect());
            AddDoubleBreakerAbility();
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
