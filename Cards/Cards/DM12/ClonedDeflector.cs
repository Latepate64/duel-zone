using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class ClonedDeflector : Spell
    {
        public ClonedDeflector() : base("Cloned Deflector", 3, Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new ClonedDeflectorEffect(Name));
        }
    }

    class ClonedDeflectorEffect : ClonedEffect
    {
        public ClonedDeflectorEffect(string name) : base(name)
        {
        }

        public ClonedDeflectorEffect(ClonedDeflectorEffect effect) : base(effect)
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            return new ClonedDeflectorTapEffect(GetAmount(game)).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new ClonedDeflectorEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone. Then, for each Cloned Deflector in each graveyard, you may choose another of your opponent's creatures in the battle zone. Tap all those creatures.";
        }
    }

    class ClonedDeflectorTapEffect : TapChoiceEffect
    {
        public ClonedDeflectorTapEffect(int maximum) : base(1, maximum, true)
        {
        }

        public ClonedDeflectorTapEffect(ClonedDeflectorTapEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ClonedDeflectorTapEffect(this);
        }

        public override string ToString()
        {
            var amount = Maximum == 1 ? "one" : $"1-{Maximum}";
            return $"Tap {amount} of your opponent's creatures in the battle zone.";
        }
    }
}
