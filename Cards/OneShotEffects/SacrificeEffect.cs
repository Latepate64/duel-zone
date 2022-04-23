using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class SacrificeEffect : DestroyEffect
    {
        public SacrificeEffect() : base(1, 1, true)
        {
        }

        public SacrificeEffect(DestroyEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SacrificeEffect(this);
        }

        public override string ToString()
        {
            return "Destroy one of your creatures.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Ability.Controller);
        }
    }
}
