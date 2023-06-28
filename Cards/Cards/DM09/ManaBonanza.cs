using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM09
{
    class ManaBonanza : Spell
    {
        public ManaBonanza() : base("Mana Bonanza", 8, Civilization.Nature)
        {
            AddSpellAbilities(new ManaBonanzaEffect());
        }
    }

    class ManaBonanzaEffect : OneShotEffect
    {
        public ManaBonanzaEffect()
        {
        }

        public ManaBonanzaEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            Applier.PutFromTopOfDeckIntoManaZone(Applier.ManaZone.Cards.Count, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new ManaBonanzaEffect(this);
        }

        public override string ToString()
        {
            return "For each card in your mana zone, put a card from the top of your deck into your mana zone tapped.";
        }
    }
}
