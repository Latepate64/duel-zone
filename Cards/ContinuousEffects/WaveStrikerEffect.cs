using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WaveStrikerEffect : AbilityAddingEffect
    {
        public WaveStrikerEffect(WaveStrikerEffect effect) : base(effect)
        {
        }

        public WaveStrikerEffect(params IAbility[] abilities) : base(new TargetFilter(), new Durations.Indefinite(), new WaveStrikerCondition(), abilities)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new WaveStrikerEffect();
        }

        public override string ToString()
        {
            return $"Wave striker: {AbilitiesAsText}";
        }
    }

    class WaveStrikerCondition : Condition
    {
        public WaveStrikerCondition() : base(new CardFilters.BattleZoneCreatureFilter())
        {
        }

        public override bool Applies(IGame game, Guid player)
        {
            return game.BattleZone.Creatures.Count(x => x.GetAbilities<WaveStrikerAbility>().Any()) >= 3;
        }

        public override Condition Copy()
        {
            return new WaveStrikerCondition();
        }

        public override string ToString()
        {
            return "2 or more other creatures in the battle zone have \"wave striker\"";
        }
    }
}
