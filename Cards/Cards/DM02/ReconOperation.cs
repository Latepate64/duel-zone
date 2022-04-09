using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM02
{
    class ReconOperation : Spell
    {
        public ReconOperation() : base("Recon Operation", 2, Civilization.Water)
        {
            AddSpellAbilities(new ReconOperationEffect());
        }
    }

    class ReconOperationEffect : OneShotEffects.LookEffect
    {
        public ReconOperationEffect() : base(0, 3)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ReconOperationEffect();
        }

        public override string ToString()
        {
            return "Look at up to 3 of your opponent's shields.";
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetOpponent(game).ShieldZone.Cards;
        }
    }
}
