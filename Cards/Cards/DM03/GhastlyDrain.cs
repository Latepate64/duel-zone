using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class GhastlyDrain : Spell
    {
        public GhastlyDrain() : base("Ghastly Drain", 3, Common.Civilization.Darkness)
        {
            AddSpellAbilities(new GhastlyDrainEffect());
        }
    }

    class GhastlyDrainEffect : ChooseAnyNumberOfCardsEffect
    {
        public GhastlyDrainEffect() : base(new CardFilters.OwnersShieldZoneCardFilter())
        {
        }

        public GhastlyDrainEffect(GhastlyDrainEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new GhastlyDrainEffect(this);
        }

        public override string ToString()
        {
            return "Choose any number of your shields and put them into your hand. You can't use the \"shield trigger\" abilities of those shields.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.PutFromShieldZoneToHand(cards, false);
        }
    }
}
