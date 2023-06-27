using Engine;
using Engine.Abilities;
using System.Linq;

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
        public DanceOfTheSproutlingsEffect()
        {
        }

        public DanceOfTheSproutlingsEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var controller = Applier;
            var race = controller.ChooseRace(ToString());
            var creatures = controller.ChooseAnyNumberOfCards(controller.Hand.GetCreatures(race), ToString());
            game.Move(Ability, ZoneType.Hand, ZoneType.ManaZone, creatures.ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new DanceOfTheSproutlingsEffect(this);
        }

        public override string ToString()
        {
            return "Choose a race. You may put any number of creatures of that race from your hand into your mana zone.";
        }
    }
}
