using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class SphereOfWonder : Spell
    {
        public SphereOfWonder() : base("Sphere of Wonder", 4, Civilization.Light)
        {
            AddSpellAbilities(new SphereOfWonderEffect());
        }
    }

    class SphereOfWonderEffect : OneShotEffect
    {
        public SphereOfWonderEffect()
        {
        }

        public SphereOfWonderEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            if (GetOpponent(game).ShieldZone.Cards.Count > Applier.ShieldZone.Cards.Count)
            {
                Applier.PutFromTopOfDeckIntoShieldZone(1, game, Ability);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new SphereOfWonderEffect(this);
        }

        public override string ToString()
        {
            return "If your opponent has more shields than you do, add the top card of your deck to your shields face down.";
        }
    }
}
