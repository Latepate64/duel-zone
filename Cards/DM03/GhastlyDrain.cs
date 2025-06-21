using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM03
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

        protected override void Apply(IGame game, IAbility source, params Card[] cards)
        {
            game.PutFromShieldZoneToHand(cards, false, Ability);
        }

        protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
        {
            return Controller.ShieldZone.Cards;
        }
    }
}
