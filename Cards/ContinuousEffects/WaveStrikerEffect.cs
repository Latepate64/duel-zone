using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WaveStrikerEffect : ContinuousEffect, IAbilityAddingEffect
    {
        private readonly IAbility[] _abilities;

        public WaveStrikerEffect(WaveStrikerEffect effect) : base(effect)
        {
            _abilities = effect._abilities;
        }

        public WaveStrikerEffect(params IAbility[] abilities) : base()
        {
            _abilities = abilities;
        }

        public void AddAbility()
        {
            if (Game.BattleZone.Creatures.Count(x => x.GetAbilities<WaveStrikerAbility>().Any()) >= 3)
            {
                _abilities.ToList().ForEach(x => Game.AddAbility(Source, x.Copy()));
            }
        }

        public override IContinuousEffect Copy()
        {
            return new WaveStrikerEffect();
        }

        public override string ToString()
        {
            return $"Wave striker: {string.Join(", ", _abilities.Select(x => x.ToString()))}";
        }
    }
}
