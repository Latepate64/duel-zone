using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM11
{
    class NinjaPumpkin : WaveStrikerCreature
    {
        public NinjaPumpkin() : base("Ninja Pumpkin", 3, 2000, Race.WildVeggies, Civilization.Nature)
        {
            AddWaveStrikerAbility(new NinjaPumpkinEffect());
        }
    }

    class NinjaPumpkinEffect : ContinuousEffects.ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect, IPowerModifyingEffect
    {
        public NinjaPumpkinEffect(int blockerMaxPower = 5000) : base(blockerMaxPower)
        {
        }

        public NinjaPumpkinEffect(ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new NinjaPumpkinEffect(this);
        }

        public void ModifyPower()
        {
            Source.Power += 4000;
        }

        public override string ToString()
        {
            return $"This creature gets +4000 power and can't be blocked by any creature that has power {Power} or less.";
        }
    }
}
