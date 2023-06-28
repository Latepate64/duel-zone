using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM11
{
    class SalivaWorm : WaveStrikerCreature
    {
        public SalivaWorm() : base("Saliva Worm", 3, 2000, Race.ParasiteWorm, Civilization.Darkness)
        {
            AddWaveStrikerAbility(new SalivaWormEffect());
        }
    }

    class SalivaWormEffect : ContinuousEffects.StealthEffect, IPowerModifyingEffect
    {
        public SalivaWormEffect(Civilization civilization = Civilization.Darkness) : base(civilization)
        {
        }

        public SalivaWormEffect(StealthEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SalivaWormEffect(this);
        }

        public void ModifyPower()
        {
            Source.Power += 4000;
        }

        public override string ToString()
        {
            return $"This creature gets +4000 power and has \"{Civilization} stealth\"";
        }
    }
}
