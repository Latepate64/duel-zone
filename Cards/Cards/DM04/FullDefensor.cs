using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM04
{
    class FullDefensor : Spell
    {
        public FullDefensor() : base("Full Defensor", 2, Civilization.Light)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new FullDefensorEffect());
        }
    }

    class FullDefensorEffect : GrantAbilityAreaOfEffect
    {
        public FullDefensorEffect() : base(new Engine.Durations.UntilStartOfYourNextTurn(), new StaticAbilities.BlockerAbility())
        {
        }

        public FullDefensorEffect(FullDefensorEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new FullDefensorEffect(this);
        }

        public override string ToString()
        {
            return "Until the start of your next turn, each of your creatures in the battle zone gets \"Blocker\".";
        }
    }
}
