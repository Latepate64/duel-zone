using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM11
{
    sealed class SalivaWorm : WaveStrikerCreature
    {
        public SalivaWorm() : base("Saliva Worm", 3, 2000, Race.ParasiteWorm, Civilization.Darkness)
        {
            AddWaveStrikerAbility(new SalivaWormEffect());
        }
    }

    sealed class SalivaWormEffect : StealthEffect, IPowerModifyingEffect
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

        public void ModifyPower(IGame game)
        {
            (Source as Creature).IncreasePower(4000);
        }

        public override string ToString()
        {
            return $"This creature gets +4000 power and has \"{Civilization} stealth\"";
        }
    }
}
