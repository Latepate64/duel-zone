using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;
using System.Linq;

namespace Cards.Cards.DM04
{
    class ThreeEyedDragonfly : Creature
    {
        public ThreeEyedDragonfly() : base("Three-Eyed Dragonfly", 5, 4000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new TriggeredAbilities.AttackAbility(new ThreeEyedDragonflyOneShotEffect()));
        }
    }

    class ThreeEyedDragonflyOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var destroyed = new YouMayDestroyOneOfYourOtherCreaturesEffect().Apply(game, source);
            if (destroyed.Any())
            {
                game.AddContinuousEffects(source, new ThreeEyedDragonflyContinuousEffect());
            }
            return destroyed;
        }

        public override IOneShotEffect Copy()
        {
            return new ThreeEyedDragonflyOneShotEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your other creatures. If you do, this creature gets +2000 power and has \"double breaker\" until the end of the turn.";
        }
    }

    class ThreeEyedDragonflyContinuousEffect : CharacteristicModifyingEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        public ThreeEyedDragonflyContinuousEffect(ThreeEyedDragonflyContinuousEffect effect) : base(effect)
        {
        }

        public ThreeEyedDragonflyContinuousEffect() : base(new TargetFilter(), new UntilTheEndOfTheTurn())
        {
        }

        public void AddAbility(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.AddGrantedAbility(new StaticAbilities.DoubleBreakerAbility()));
        }

        public override IContinuousEffect Copy()
        {
            return new ThreeEyedDragonflyContinuousEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.Power += 2000);
        }

        public override string ToString()
        {
            return "This creature gets +2000 power and has \"double breaker\" until the end of the turn.";
        }
    }

    class YouMayDestroyOneOfYourOtherCreaturesEffect : DestroyEffect
    {
        public YouMayDestroyOneOfYourOtherCreaturesEffect(YouMayDestroyOneOfYourOtherCreaturesEffect effect) : base(effect)
        {
        }

        public YouMayDestroyOneOfYourOtherCreaturesEffect() : base(new CardFilters.OwnersOtherBattleZoneCreatureFilter(), 0, 1, true)
        {
        }

        public override string ToString()
        {
            return "You may destroy one of your other creatures.";
        }

        public override OneShotEffect Copy()
        {
            return new YouMayDestroyOneOfYourOtherCreaturesEffect(this);
        }
    }
}
