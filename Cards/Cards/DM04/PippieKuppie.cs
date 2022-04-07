using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM04
{
    class PippieKuppie : Creature
    {
        public PippieKuppie() : base("Pippie Kuppie", 2, 1000, Subtype.FireBird, Civilization.Fire)
        {
            AddStaticAbilities(new PippieKuppieEffect());
        }
    }

    class PippieKuppieEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public PippieKuppieEffect(PippieKuppieEffect effect) : base(effect)
        {
        }

        public PippieKuppieEffect() : base()
        {
        }

        public override ContinuousEffect Copy()
        {
            return new PippieKuppieEffect(this);
        }

        public override string ToString()
        {
            return "Each Armored Dragon in the battle zone gets +1000 power.";
        }

        public void ModifyPower(IGame game)
        {
            game.BattleZone.Creatures.Where(x => x.HasSubtype(Subtype.ArmoredDragon)).ToList().ForEach(x => x.Power += 1000);
        }
    }
}
