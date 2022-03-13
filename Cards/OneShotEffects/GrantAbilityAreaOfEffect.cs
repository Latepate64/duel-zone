using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.OneShotEffects
{
    class GrantAbilityAreaOfEffect : OneShotAreaOfEffect
    {
        public Ability Ability { get; }

        public GrantAbilityAreaOfEffect(Ability ability) : base(new OwnersBattleZoneCreatureFilter())
        {
            Ability = ability;
        }

        public GrantAbilityAreaOfEffect(GrantAbilityAreaOfEffect effect) : base(effect)
        {
            Ability = effect.Ability.Copy();
        }

        public override object Apply(Game game, Ability source)
        {
            foreach (var creature in GetAffectedCards(game, source))
            {
                game.AddContinuousEffects(source, new AbilityGrantingEffect(new TargetsFilter(creature.Id), new UntilTheEndOfTheTurn(), Ability.Copy()));
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new GrantAbilityAreaOfEffect(this);
        }

        public override string ToString()
        {
            return $"Each of your creatures in the battle zone gets ${Ability} until the end of the turn.";
        }
    }
}
