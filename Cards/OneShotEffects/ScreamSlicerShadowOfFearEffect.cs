using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class ScreamSlicerShadowOfFearEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var controller = source.GetController(game);
            var creatures = game.BattleZone.Creatures.Where(x => x.Power == game.BattleZone.Creatures.Min(x => x.Power.Value) && controller.CanChoose(x, game));
            game.Destroy(source, controller.ChooseCard(creatures, ToString()));
        }

        public override IOneShotEffect Copy()
        {
            return new ScreamSlicerShadowOfFearEffect();
        }

        public override string ToString()
        {
            return "Destroy the creature that has the least power in the battle zone. If there's a tie, you choose from among the tied creatures.";
        }
    }
}
