using Engine;
using Engine.Abilities;
using Interfaces;
using System.Collections.Generic;

namespace Cards.DM02
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

        protected override IEnumerable<Card> GetSelectableCards(IGame game, IAbility source)
        {
            return GetOpponent(game).ShieldZone.Cards;
        }
    }
}
