using Common;
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
        public override object Apply(IGame game, IAbility source)
        {
            source.GetController(game).PutFromTopOfDeckIntoManaZone(game, source.GetController(game).ManaZone.Cards.Count);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new ManaBonanzaEffect();
        }

        public override string ToString()
        {
            return "For each card in your mana zone, put a card from the top of your deck into your mana zone tapped.";
        }
    }
}
