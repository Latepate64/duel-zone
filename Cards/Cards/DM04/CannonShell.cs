using Cards.ContinuousEffects;
using Engine.Abilities;

namespace Cards.Cards.DM04
{
    class CannonShell : Creature
    {
        public CannonShell() : base("Cannon Shell", 4, 1000, Common.Subtype.ColonyBeetle, Common.Civilization.Nature)
        {
            ShieldTrigger = true;

            // This creature gets +1000 power for each shield you have.
            AddAbilities(new StaticAbility(new CannonShellEffect()));
        }
    }
}
