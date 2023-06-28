using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM12
{
    class CosmicDarts : Spell
    {
        public CosmicDarts() : base("Cosmic Darts", 1, Civilization.Light)
        {
            AddSpellAbilities(new CosmicDartsEffect());
        }
    }

    class CosmicDartsEffect : OneShotEffects.CardSelectionEffect
    {
        public CosmicDartsEffect() : base(1, 1, false)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new CosmicDartsEffect();
        }

        public override string ToString()
        {
            return "Your opponent chooses one of your shields. Look at it. If it's a spell, you may cast immediately for no cost. If it's not a spell or if you don't cast it, put it back where it was.";
        }

        protected override void Apply(IAbility source, params ICard[] cards)
        {
            if (cards.Length == 1)
            {
                Applier.Look(Applier, cards);
                var card = cards.Single();
                if (card.IsSpell && Applier.ChooseToTakeAction($"You may cast {card.Name} for no cost."))
                {
                    Applier.Cast(card);
                }
                Applier.Unreveal(cards);
            }
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Applier.ShieldZone.Cards;
        }
    }
}
