using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class DestroyOneOfYourOpponentsCreaturesEffect : DestroyEffect
    {
        public DestroyOneOfYourOpponentsCreaturesEffect() : base(1, 1, true)
        {
        }

        public DestroyOneOfYourOpponentsCreaturesEffect(DestroyEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyOneOfYourOpponentsCreaturesEffect(this);
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(Applier);
        }
    }
}
