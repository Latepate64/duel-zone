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
        public ApocalypseViseEffect()
        {
        }

        public ApocalypseViseEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.Destroy(
                Ability,
                Controller.ChooseCards(
                    new CardChoice(Controller, ToString(), new ApocalypseViseChoiceMode(), game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).ToArray())
                    ).ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new ApocalypseViseEffect(this);
        }

        public override string ToString()
        {
            return "Destroy any number of your opponent's creatures that have total power 8000 or less.";
        }
    }

    public class ApocalypseViseChoiceMode : ICardChoiceMode
    {
        public bool CanBeChosenAutomatically(IEnumerable<Card> cards)
        {
            return !cards.Any() || cards.All(x => x.Power > 8000);
        }

        public IEnumerable<Card> ChooseAutomatically(IEnumerable<Card> choosableCards)
        {
            return new List<Card>();
        }

        public bool IsValid(IEnumerable<Card> chosenCards)
        {
            return chosenCards.Sum(x => x.Power) <= 8000;
        }
    }
}
