using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class ProtectiveForce : Spell
    {
        public ProtectiveForce() : base("Protective Force", 1, Civilization.Light)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new ProtectiveForceEffect());
        }
    }

    class ProtectiveForceEffect : OneShotEffects.GrantChoiceEffect
    {
        public ProtectiveForceEffect() : base(new CardFilters.OwnersBattleZoneBlockerCreatureFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ProtectiveForceEffect();
        }

        public override string ToString()
        {
            return "One of your creatures in the battle zone that has \"blocker\" gets +4000 power until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(4000, cards));
        }
    }
}
