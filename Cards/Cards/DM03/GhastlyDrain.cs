using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM03
{
    class GhastlyDrain : Spell
    {
        public GhastlyDrain() : base("Ghastly Drain", 3, Civilization.Darkness)
        {
            AddSpellAbilities(new GhastlyDrainEffect());
        }
    }

    class GhastlyDrainEffect : ChooseAnyNumberOfCardsEffect
    {
        public GhastlyDrainEffect() : base()
        {
        }

        public GhastlyDrainEffect(GhastlyDrainEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new GhastlyDrainEffect(this);
        }

        public override string ToString()
        {
            return "Choose any number of your shields and put them into your hand. You can't use the \"shield trigger\" abilities of those shields.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.PutFromShieldZoneToHand(cards, false, Ability);
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return Applier.ShieldZone.Cards;
        }
    }
}
