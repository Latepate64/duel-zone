using DuelMastersModels;
using DuelMastersModels.Abilities;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class HolyAweEffect : OneShotEffect
    {
        public HolyAweEffect()
        {
        }

        public HolyAweEffect(OneShotEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new HolyAweEffect(this);
        }

        public override void Apply(Game game)
        {
            // Tap all your opponent's creatures in the battle zone.
            var opponent = game.GetOpponent(game.GetPlayer(Controller));
            foreach (var creature in game.BattleZone.Creatures.Where(x => x.Owner == opponent.Id))
            {
                creature.Tapped = true;
            }
        }
    }
}
