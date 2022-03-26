using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM04
{
    class SwordOfMalevolentDeath : Spell
    {
        public SwordOfMalevolentDeath() : base("Sword of Malevolent Death", 4, Civilization.Darkness)
        {
            AddSpellAbilities(new SwordOfMalevolentDeathOneShotEffect());
        }
    }

    class SwordOfMalevolentDeathOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var creatures = game.BattleZone.GetCreatures(source.Owner);
            var power = creatures.Where(x => x.Civilizations.Contains(Civilization.Darkness)).Count() * 1000;
            game.AddContinuousEffects(source, new SwordOfMalevolentDeathContinuousEffect(new CardFilters.TargetsFilter(creatures.ToArray()), power));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new SwordOfMalevolentDeathOneShotEffect();
        }

        public override string ToString()
        {
            return "Until the end of the turn, each of your creatures in the battle zone gets \"While attacking, this creature gets +1000 power for each darkness card in your mana zone.\"";
        }
    }

    class SwordOfMalevolentDeathContinuousEffect : AbilityAddingEffect
    {
        public SwordOfMalevolentDeathContinuousEffect(SwordOfMalevolentDeathContinuousEffect effect) : base(effect)
        {
        }

        public SwordOfMalevolentDeathContinuousEffect(ICardFilter filter, int power) : base(filter, new Engine.Durations.UntilTheEndOfTheTurn(), new StaticAbilities.PowerAttackerAbility(power))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SwordOfMalevolentDeathContinuousEffect(this);
        }

        public override string ToString()
        {
            return "Until the end of the turn, this creature has \"While attacking, this creature gets +1000 power for each darkness card in your mana zone.\"";
        }
    }
}
