using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class ScreamSlicerShadowOfFearEffect : OneShotEffect
    {
        public ScreamSlicerShadowOfFearEffect()
        {
        }

        public ScreamSlicerShadowOfFearEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            var creatures = Game.BattleZone.Creatures.Where(x => x.Power == Game.BattleZone.Creatures.Min(x => x.Power.Value) && Applier.CanChoose(x));
            Game.Destroy(Ability, Applier.ChooseCard(creatures, ToString()));
        }

        public override IOneShotEffect Copy()
        {
            return new ScreamSlicerShadowOfFearEffect(this);
        }

        public override string ToString()
        {
            return "Destroy the creature that has the least power in the battle zone. If there's a tie, you choose from among the tied creatures.";
        }
    }
}
