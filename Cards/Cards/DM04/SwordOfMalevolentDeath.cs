using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM04
{
    class SwordOfMalevolentDeath : Spell
    {
        public SwordOfMalevolentDeath() : base("Sword of Malevolent Death", 4, Civilization.Darkness)
        {
            AddSpellAbilities(new SwordOfMalevolentDeathEffect());
        }
    }

    class SwordOfMalevolentDeathEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var creatures = game.BattleZone.GetCreatures(source.Owner);
            var power = creatures.Where(x => x.Civilizations.Contains(Civilization.Darkness)).Count() * 1000;
            game.AddContinuousEffects(source, new Engine.ContinuousEffects.AbilityAddingEffect(new CardFilters.TargetsFilter(creatures.Select(x => x.Id).ToArray()), new Engine.Durations.UntilTheEndOfTheTurn(), new StaticAbilities.PowerAttackerAbility(power)));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new SwordOfMalevolentDeathEffect();
        }

        public override string ToString()
        {
            return "Until the end of the turn, each of your creatures in the battle zone gets \"While attacking, this creature gets +1000 power for each darkness card in your mana zone.\"";
        }
    }
}
