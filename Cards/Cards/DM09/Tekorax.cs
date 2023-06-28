using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM09
{
    class Tekorax : Creature
    {
        public Tekorax() : base("Tekorax", 5, 3000, Race.SeaHacker, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new TekoraxEffect());
        }
    }

    class TekoraxEffect : OneShotEffect
    {
        public TekoraxEffect()
        {
        }

        public TekoraxEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            var cards = Applier.Opponent.ShieldZone.Cards.ToArray();
            if (cards.Any())
            {
                Applier.Look(Applier.Opponent, cards);
                Applier.Opponent.Unreveal(cards);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new TekoraxEffect(this);
        }

        public override string ToString()
        {
            return "Look at your opponent's shields. Then put them back where they were.";
        }
    }
}
