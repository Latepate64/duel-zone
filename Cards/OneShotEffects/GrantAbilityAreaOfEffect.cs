using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class GrantAbilityAreaOfEffect : OneShotAreaOfEffect
    {
        private readonly IDuration _duration;

        public List<IAbility> Abilities { get; } = new List<IAbility>();

        public GrantAbilityAreaOfEffect(IDuration duration, params IAbility[] abilities) : base(new OwnersBattleZoneCreatureFilter())
        {
            Abilities.AddRange(abilities);
            _duration = duration;
        }

        public GrantAbilityAreaOfEffect(GrantAbilityAreaOfEffect effect) : base(effect)
        {
            Abilities = effect.Abilities.Select(x => x.Copy()).ToList();
            _duration = effect._duration.Copy();
        }

        public override object Apply(IGame game, IAbility source)
        {
            foreach (var creature in GetAffectedCards(game, source))
            {
                game.AddContinuousEffects(source, new AbilityGrantingEffect(new TargetsFilter(creature.Id), _duration, Abilities.Select(x => x.Copy()).ToArray()));
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new GrantAbilityAreaOfEffect(this);
        }

        public override string ToString()
        {
            return $"Each of your creatures in the battle zone gets {Abilities} {_duration}.";
        }
    }
}
