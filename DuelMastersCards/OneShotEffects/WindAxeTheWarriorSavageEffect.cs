using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class WindAxeTheWarriorSavageEffect : OneShotEffect
    {
        public WindAxeTheWarriorSavageEffect() : base()
        {
        }

        public WindAxeTheWarriorSavageEffect(WindAxeTheWarriorSavageEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new WindAxeTheWarriorSavageEffect(this);
        }

        public override void Apply(Game game)
        {
            // Destroy one of your opponent's creatures that has "blocker."
            var controller = game.GetPlayer(Controller);
            var blocker = new List<Card>();
            var blockers = game.BattleZone.GetChoosableCreatures(game, game.GetOpponent(Controller)).Where(c => c.Abilities.OfType<BlockerAbility>().Any());
            if (blockers.Any())
            {
                var decision = controller.Choose(new GuidSelection(controller.Id, blockers, 1, 1));
                blocker = decision.Decision.Select(x => game.GetCard(x)).ToList();
                game.Destroy(blocker);
            }

            // Then put the top card of your deck into your mana zone.
            controller.PutFromTopOfDeckIntoManaZone(game);
        }
    }
}
