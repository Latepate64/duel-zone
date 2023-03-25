using Cards;
using Engine;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;

        public CardController(ILogger<CardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CardViewModel> Get()
        {
            List<Card> cards = CardFactory.CreateAll().ToList();
            foreach (var card in cards)
            {
                card.InitializeAbilities();
            }
            return cards.Select(x => new CardViewModel(x));
        }
    }

    public class CardViewModel
    {
        public CardViewModel(Card card)
        {
            CardType = card.CardType.ToString();
            Civilizations = string.Join(" / ", card.Civilizations.Select(x => x.ToString()));
            ManaCost = card.ManaCost;
            Name = card.Name;
            Power = card.PrintedPower.HasValue ? card.PrintedPower.Value.ToString() : string.Empty;
            Races = string.Join(" / ", card.Races.Select(x => x.ToString()));
            RulesText = card.RulesText;
        }

        public string CardType { get; }
        public string Civilizations { get; }
        public int ManaCost { get; }
        public string Name { get; }
        public string Power { get; }
        public string Races { get; }
        public string RulesText { get; }
    }
}