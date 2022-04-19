using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class DeklowazTheTerminator : Creature
    {
        public DeklowazTheTerminator() : base("Deklowaz, the Terminator", 6, 5000, Race.SpiritQuartz, Civilization.Darkness, Civilization.Fire)
        {
            AddTapAbility(new DeklowazTheTerminatorEffect());
        }
    }

    class DeklowazTheTerminatorEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            new OneShotEffects.DestroyMaxPowerAreaOfEffect(3000).Apply(game, source);
            var cards = source.GetOpponent(game).Hand.Cards;
            if (cards.Any())
            {
                source.GetController(game).Look(source.GetOpponent(game), game, cards.ToArray());
                source.GetOpponent(game).Discard(source, game, cards.Where(x => x.Power.HasValue && x.Power <= 3000).ToArray());
                source.GetOpponent(game).Unreveal(cards);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new DeklowazTheTerminatorEffect();
        }

        public override string ToString()
        {
            return "Destroy all creatures that have power 3000 or less. Then look at your opponent's hand. He discards all creatures from it that have power 3000 or less.";
        }
    }
}
