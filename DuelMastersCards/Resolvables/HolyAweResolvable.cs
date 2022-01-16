using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.Resolvables
{
    class HolyAweResolvable : Resolvable
    {
        public HolyAweResolvable()
        {
        }

        public HolyAweResolvable(Resolvable resolvable) : base(resolvable)
        {
        }

        public override Resolvable Copy()
        {
            return new HolyAweResolvable(this);
        }

        public override void Resolve(Duel duel, Decision decision)
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
