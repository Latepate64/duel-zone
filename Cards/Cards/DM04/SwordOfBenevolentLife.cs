using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM04
{
    class SwordOfBenevolentLife : Spell
    {
        public SwordOfBenevolentLife() : base("Sword of Benevolent Life", 2, Common.Civilization.Nature)
        {
            AddSpellAbilities(new SwordOfBenevolentLifeEffect());
        }
    }

    class SwordOfBenevolentLifeEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var creatures = game.BattleZone.GetCreatures(source.Controller);
            var power = creatures.Count(x => x.HasCivilization(Common.Civilization.Light)) * 1000;
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(power, creatures.ToArray()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new SwordOfBenevolentLifeEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone gets +1000 power until the end of the turn for each light creature you have in the battle zone.";
        }
    }
}