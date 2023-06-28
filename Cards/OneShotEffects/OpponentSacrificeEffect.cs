using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class OpponentSacrificeEffect : DestroyEffect
    {
        public OpponentSacrificeEffect() : base(1, 1, false)
        {
        }

        public OpponentSacrificeEffect(DestroyEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new OpponentSacrificeEffect(this);
        }

        public override string ToString()
        {
            return "Your opponent chooses one of his creatures and destroys it.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Applier.Opponent);
        }
    }
}
