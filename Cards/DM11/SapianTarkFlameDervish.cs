using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM11
{
    class SapianTarkFlameDervish : WaveStrikerCreature
    {
        public SapianTarkFlameDervish() : base("Sapian Tark, Flame Dervish", 3, 2000, Race.Dragonoid, Civilization.Fire)
        {
            AddWaveStrikerAbility(new SapianTarkFlameDervishEffect());
        }
    }

    class SapianTarkFlameDervishEffect : ThisCreatureCanAttackUntappedCreaturesEffect, IPowerModifyingEffect
    {
        public override IContinuousEffect Copy()
        {
            return new SapianTarkFlameDervishEffect();
        }

        public void ModifyPower(IGame game)
        {
            (Source as Creature).IncreasePower(4000);
        }

        public override string ToString()
        {
            return "This creature gets +4000 power and can attack untapped creatures.";
        }
    }
}
