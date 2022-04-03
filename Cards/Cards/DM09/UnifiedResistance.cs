using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class UnifiedResistance : Spell
    {
        public UnifiedResistance() : base("Unified Resistance", 2, Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new UnifiedResistanceOneShotEffect());
        }
    }

    class UnifiedResistanceOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var race = source.GetController(game).ChooseRace();
            var creatures = game.BattleZone.GetCreatures(source.Controller).Where(x => x.HasSubtype(race));
            game.AddContinuousEffects(source, new UnifiedResistanceContinuousEffect(source.Controller, creatures.ToArray()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new UnifiedResistanceOneShotEffect();
        }

        public override string ToString()
        {
            return "Choose a race. Until the start of your next turn, each of your creatures in the battle zone of that race gets \"Blocker.\"";
        }
    }

    class UnifiedResistanceContinuousEffect : AbilityAddingEffect
    {
        public UnifiedResistanceContinuousEffect(UnifiedResistanceContinuousEffect effect) : base(effect)
        {
        }

        public UnifiedResistanceContinuousEffect(System.Guid player, params Engine.ICard[] cards) : base(new CardFilters.TargetsFilter(cards), new Durations.UntilStartOfYourNextTurn(player), new StaticAbilities.BlockerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new UnifiedResistanceContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"Until the start of your next turn, {Filter} have \"Blocker\".";
        }
    }
}
