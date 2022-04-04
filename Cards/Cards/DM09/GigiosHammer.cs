using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class GigiosHammer : Creature
    {
        public GigiosHammer() : base("Gigio's Hammer", 3, 2000, Subtype.Xenoparts, Civilization.Fire)
        {
            AddTapAbility(new GigiosHammerOneShotEffect());
        }
    }

    class GigiosHammerOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new GigiosHammerContinuousEffect(source.GetController(game).ChooseRace()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new GigiosHammerOneShotEffect();
        }

        public override string ToString()
        {
            return "Choose a race. Each creature of that race attacks this turn if able and gets \"power attacker +4000\" until the end of the turn.";
        }
    }

    class GigiosHammerContinuousEffect : ContinuousEffect, IAttacksIfAbleEffect, IAbilityAddingEffect
    {
        private readonly Subtype _subtype;

        public GigiosHammerContinuousEffect(GigiosHammerContinuousEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
        }

        public GigiosHammerContinuousEffect(Subtype subtype) : base(new CardFilters.BattleZoneSubtypeCreatureFilter(subtype), new Durations.UntilTheEndOfTheTurn())
        {
            _subtype = subtype;
        }

        public void AddAbility(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.AddGrantedAbility(new StaticAbilities.PowerAttackerAbility(4000)));
        }

        public override IContinuousEffect Copy()
        {
            return new GigiosHammerContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"Each {_subtype} of that race attacks this turn if able and gets \"power attacker +4000\" until the end of the turn.";
        }
    }
}
