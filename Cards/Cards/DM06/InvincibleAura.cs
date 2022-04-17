using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class InvincibleAura : Spell
    {
        public InvincibleAura() : base("Invincible Aura", 13, Civilization.Light)
        {
            AddSpellAbilities(new InvincibleAuraEffect());
        }
    }

    class InvincibleAuraEffect : OneShotEffect
    {
        public InvincibleAuraEffect()
        {
        }

        public InvincibleAuraEffect(InvincibleAuraEffect effect) : base(effect)
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (source.GetController(game).ChooseToTakeAction("You may add the top card of your deck to your shields face down."))
                {
                    source.GetController(game).PutFromTopOfDeckIntoShieldZone(1, game, source);
                }
                else
                {
                    break;
                }
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new InvincibleAuraEffect(this);
        }

        public override string ToString()
        {
            return "Add up to 3 cards from the top of your deck to your shields face down.";
        }
    }
}
