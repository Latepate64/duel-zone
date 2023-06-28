using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class GlorySnow : Spell
    {
        public GlorySnow() : base("Glory Snow", 4, Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new GlorySnowEffect());
        }
    }

    class GlorySnowEffect : OneShotEffect
    {
        public override void Apply()
        {
            if (Applier.Opponent.ManaZone.Cards.Count > Applier.ManaZone.Cards.Count)
            {
                Applier.PutFromTopOfDeckIntoManaZone(2, Ability);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new GlorySnowEffect();
        }

        public override string ToString()
        {
            return "If your opponent has more cards in his mana zone than you have in yours, put the top 2 cards of your deck into your mana zone.";
        }
    }
}
