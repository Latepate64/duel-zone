using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM11
{
    class SalivaWorm : WaveStrikerCreature
    {
        public SalivaWorm() : base("Saliva Worm", 3, 2000, Subtype.ParasiteWorm, Civilization.Darkness)
        {
            AddWaveStrikerAbility(new SalivaWormEffect());
        }
    }

    class SalivaWormEffect : ContinuousEffects.StealthEffect, IPowerModifyingEffect
    {
        public SalivaWormEffect() : base(Civilization.Darkness)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SalivaWormEffect();
        }

        public void ModifyPower(IGame game)
        {
            GetSourceCard(game).Power += 4000;
        }

        public override string ToString()
        {
            return "This creature gets +4000 power and has \"Darkness stealth\"";
        }
    }
}
