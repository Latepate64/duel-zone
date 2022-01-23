using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using System.Linq;

namespace DuelMastersCards.ContinuousEffects
{
    public class BolshackDragonEffect : PowerAttackerEffect
    {
        public CardFilter MultiplierFilter { get; }

        public BolshackDragonEffect(CardFilter multiplierFilter) : base(new TargetFilter(), new Indefinite(), 0)
        {
            MultiplierFilter = multiplierFilter;
        }

        public BolshackDragonEffect(BolshackDragonEffect effect) : base(effect)
        {
            MultiplierFilter = effect.MultiplierFilter.Copy();
        }

        public override int GetPower(Game game)
        {
            //this creature gets +1000 power for each fire card in your graveyard.
            return game.GetPlayer(Controller).Graveyard.Cards.Where(x => MultiplierFilter.Applies(x, game, game.GetPlayer(Controller))).Count() * 1000;
        }
    }
}
