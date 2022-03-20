using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.Cards.DM04
{
    class CannonShell : Creature
    {
        public CannonShell() : base("Cannon Shell", 4, 1000, Common.Subtype.ColonyBeetle, Common.Civilization.Nature)
        {
            ShieldTrigger = true;
            AddAbilities(new CannonShellAbility());
        }
    }

    class CannonShellAbility : StaticAbility
    {
        public CannonShellAbility() : base(new PowerModifyingMultiplierEffect(1000, new CardFilters.OwnersShieldZoneCardFilter()))
        {
        }

        public override string ToString()
        {
            return "This creature gets +1000 power for each shield you have.";
        }
    }
}
