using DuelMastersModels;
using DuelMastersModels.Abilities;

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

        public override void Apply(Duel duel)
        {
            // Tap all your opponent's creatures in the battle zone.
            var opponent = duel.GetOpponent(duel.GetPlayer(Controller));
            foreach (var creature in opponent.BattleZone.Creatures)
            {
                creature.Tapped = true;
            }
        }
    }
}
