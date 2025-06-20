using ContinuousEffects;
using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM11
{
    class HeavyweightDragon : Creature
    {
        public HeavyweightDragon() : base("Heavyweight Dragon", 7, 9000, Race.ArmoredDragon, Civilization.Fire)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddAbilities(new TapAbility(new HeavyweightDragonEffect()));
        }
    }

    class HeavyweightDragonEffect : CreatureSelectionEffect
    {
        public HeavyweightDragonEffect() : base(0, 2, true)
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

        protected override void Apply(IGame game, IAbility source, params Creature[] cards)
        {
            if (cards.Sum(x => x.Power) < (Ability.Source as Creature).Power)
            {
                game.Destroy(source, cards);
            }
        }

        protected override IEnumerable<Creature> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(x => x.Tapped);
        }
    }
}
