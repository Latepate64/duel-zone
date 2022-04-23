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

        public override void Apply(IGame game)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (Controller.ChooseToTakeAction("You may add the top card of your deck to your shields face down."))
                {
                    Controller.PutFromTopOfDeckIntoShieldZone(1, game, Ability);
                }
                else
                {
                    break;
                }
            }
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
