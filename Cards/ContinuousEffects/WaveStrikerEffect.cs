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

        public WaveStrikerEffect(params IAbility[] abilities) : base(new TargetFilter())
        {
            _abilities = abilities;
        }

        public void AddAbility(IGame game)
        {
            if (game.BattleZone.Creatures.Count(x => x.GetAbilities<WaveStrikerAbility>().Any()) >= 3)
            {
                foreach (var card in game.GetAllCards(Filter, GetSourceAbility(game).Controller))
                {
                    _abilities.ToList().ForEach(x => game.AddAbility(card, x.Copy()));
                }
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
