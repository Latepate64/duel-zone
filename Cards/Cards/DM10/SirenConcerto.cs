using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class SirenConcerto : Spell
    {
        public SirenConcerto() : base("Siren Concerto", 1, Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new SirenConcertoEffect());
        }
    }

    class SirenConcertoEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var controller = Applier;
            controller.ReturnOwnMana(Ability);
            controller.PutOwnHandCardIntoMana(Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new SirenConcertoEffect();
        }

        public override string ToString()
        {
            return "Put a card from your mana zone into your hand. Then put a card from your hand into your mana zone.";
        }
    }
}
