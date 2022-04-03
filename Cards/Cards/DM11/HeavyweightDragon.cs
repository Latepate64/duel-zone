using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class HeavyweightDragon : Creature
    {
        public HeavyweightDragon() : base("Heavyweight Dragon", 7, 9000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddDoubleBreakerAbility();
            AddTapAbility(new HeavyweightDragonEffect());
        }
    }

    class HeavyweightDragonEffect : OneShotEffects.CardSelectionEffect
    {
        public HeavyweightDragonEffect() : base(new CardFilters.OpponentsBattleZoneChoosableCreatureFilter(), 0, 2, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new HeavyweightDragonEffect();
        }

        public override string ToString()
        {
            return "Choose up to 2 of your opponent's tapped creatures in the battle zone. If they have total power less than this creature's power, destroy them.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            if (cards.Sum(x => x.Power) < game.GetCard(source.Source).Power)
            {
                game.Destroy(cards);
            }
        }
    }
}
