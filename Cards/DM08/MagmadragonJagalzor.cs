using ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Interfaces;

namespace Cards.DM08
{
    class MagmadragonJagalzor : TurboRushCreature
    {
        public MagmadragonJagalzor() : base("Magmadragon Jagalzor", 6, 6000, Race.VolcanoDragon, Civilization.Fire)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTurboRushAbility(new MagmadragonJagalzorEffect());
        }
    }

    class MagmadragonJagalzorEffect : ContinuousEffect, ISpeedAttackerEffect
    {
        public MagmadragonJagalzorEffect() : base()
        {
        }

        public bool Applies(Creature creature, IGame game)
        {
            return creature.Owner == Controller;
        }

        public override IContinuousEffect Copy()
        {
            return new MagmadragonJagalzorEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone has \"speed attacker.\"";
        }
    }
}
