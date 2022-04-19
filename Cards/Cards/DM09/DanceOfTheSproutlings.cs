using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

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
        public override void Apply(IGame game, IAbility source)
        {
            new DanceOfTheSproutlingsSecondEffect(source.GetController(game).ChooseRace(ToString())).Apply(game, source);
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
        private readonly Race _race;

        public DanceOfTheSproutlingsSecondEffect(Race race) : base()
        {
            _race = race;
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
            return $"You may put any number of {_race}s from your hand into your mana zone.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.Move(source, ZoneType.Hand, ZoneType.ManaZone, cards);
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return source.GetController(game).Hand.GetCreatures(_race);
        }
    }
}
