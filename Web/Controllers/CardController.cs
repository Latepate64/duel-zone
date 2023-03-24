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
        public IEnumerable<Card> Get()
        {
            return new Card[]
            {
                new Card("Aqua Vehicle", 2, "Water", string.Empty),
                new Card("Aqua Hulcus", 3, "Water", "When you do, win."),
                new Card("Deadly Fighter Braid Claw", 1, "Fire", "ORGORGOR."),
                new Card("Holy Awe", 6, "Light", "Tapperino."),
            };
        }
    }
}