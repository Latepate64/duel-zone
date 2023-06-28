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
        public override void Apply()
        {
            var creatures = Game.BattleZone.GetCreatures(Applier);
            var power = creatures.Count(x => x.HasCivilization(Civilization.Darkness)) * 1000;
            Game.AddContinuousEffects(Ability, new SwordOfMalevolentDeathContinuousEffect(power, creatures.ToArray()));
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

    class SwordOfMalevolentDeathContinuousEffect : ContinuousEffects.AddAbilitiesUntilEndOfTurnEffect
    {
        public SwordOfMalevolentDeathContinuousEffect(SwordOfMalevolentDeathContinuousEffect effect) : base(effect)
        {
        }

        public SwordOfMalevolentDeathContinuousEffect(int power, params ICard[] cards) : base(new StaticAbilities.PowerAttackerAbility(power), cards)
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
