using Engine;
using Engine.Abilities;
using Engine.Choices;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM07
{
    class ApocalypseVise : Spell
    {
        public ApocalypseVise() : base("Apocalypse Vise", 7, Civilization.Fire)
        {
            AddSpellAbilities(new ApocalypseViseEffect());
        }
    }

    class ApocalypseViseEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.Destroy(
                source.GetController(game).ChooseCards(new CardChoice(source.GetController(game), ToString(), new ApocalypseViseChoiceMode(), game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id).ToArray())));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new ApocalypseViseEffect();
        }

        public override string ToString()
        {
            return "Destroy any number of your opponent's creatures that have total power 8000 or less.";
        }
    }

    public class ApocalypseViseChoiceMode : ICardChoiceMode
    {
        public bool CanBeChosenAutomatically(IEnumerable<ICard> cards)
        {
            return !cards.Any() || cards.All(x => x.Power > 8000);
        }

        public IEnumerable<ICard> ChooseAutomatically(IEnumerable<ICard> choosableCards)
        {
            return new List<ICard>();
        }

        public bool IsValid(IEnumerable<ICard> chosenCards)
        {
            return chosenCards.Sum(x => x.Power) <= 8000;
        }
    }
}
