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
            foreach (var creature in game.BattleZone.GetCreatures(game.GetOpponent(Controller)))
            {
                creature.Tapped = true;
            }
        }
    }
}
