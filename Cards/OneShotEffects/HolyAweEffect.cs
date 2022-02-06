using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class HolyAweEffect : OneShotEffect
    {
        public HolyAweEffect()
        {
        }

        public HolyAweEffect(OneShotEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new HolyAweEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            game.GetPlayer(source.Owner).Tap(game, game.BattleZone.GetCreatures(game.GetOpponent(source.Owner)).ToArray());
        }

        public override string ToString()
        {
            return "tap all your opponent's creatures in the battle zone.";
        }
    }
}
