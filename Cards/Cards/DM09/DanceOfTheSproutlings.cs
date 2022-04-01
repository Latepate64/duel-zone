using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM09
{
    class DanceOfTheSproutlings : Spell
    {
        public DanceOfTheSproutlings() : base("Dance of the Sproutlings", 3, Civilization.Nature)
        {
            AddSpellAbilities(new DanceOfTheSproutlingsEffect());
        }
    }

    class DanceOfTheSproutlingsEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            return new DanceOfTheSproutlingsSecondEffect(source.GetController(game).ChooseRace()).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new DanceOfTheSproutlingsEffect();
        }

        public override string ToString()
        {
            return "Choose a race. You may put any number of creatures of that race from your hand into your mana zone.";
        }
    }

    class DanceOfTheSproutlingsSecondEffect : ChooseAnyNumberOfCardsEffect
    {
        private readonly Subtype _subtype;

        public DanceOfTheSproutlingsSecondEffect(Subtype subtype) : base(new CardFilters.OwnersHandSubtypeCreatureFilter(subtype))
        {
            _subtype = subtype;
        }

        public DanceOfTheSproutlingsSecondEffect(DanceOfTheSproutlingsSecondEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DanceOfTheSproutlingsSecondEffect(this);
        }

        public override string ToString()
        {
            return $"You may put any number of {_subtype}s from your hand into your mana zone.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            game.Move(ZoneType.Hand, ZoneType.ManaZone, cards);
        }
    }
}
