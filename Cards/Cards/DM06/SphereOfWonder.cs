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
        public override object Apply(IGame game, IAbility source)
        {
            if (source.GetOpponent(game).ShieldZone.Cards.Count > source.GetController(game).ShieldZone.Cards.Count)
            {
                source.GetController(game).PutFromTopOfDeckIntoShieldZone(1, game);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new SphereOfWonderEffect();
        }

        public override string ToString()
        {
            return "If your opponent has more shields than you do, add the top card of your deck to your shields face down.";
        }
    }
}
