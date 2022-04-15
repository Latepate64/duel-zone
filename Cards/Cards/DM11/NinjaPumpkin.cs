using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM11
{
    class NinjaPumpkin : WaveStrikerCreature
    {
        public NinjaPumpkin() : base("Ninja Pumpkin", 3, 2000, Engine.Subtype.WildVeggies, Engine.Civilization.Nature)
        {
            AddWaveStrikerAbility(new NinjaPumpkinEffect());
        }
    }

    class NinjaPumpkinEffect : ContinuousEffects.ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect, IPowerModifyingEffect
    {
        public NinjaPumpkinEffect() : base(5000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new NinjaPumpkinEffect();
        }

        public void ModifyPower(IGame game)
        {
            GetSourceCard(game).Power += 4000;
        }

        public override string ToString()
        {
            return "This creature gets +4000 power and can't be blocked by any creature that has power 5000 or less.";
        }
    }
}
