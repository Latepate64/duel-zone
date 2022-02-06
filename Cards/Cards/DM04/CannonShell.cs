using Cards.CardFilters;
using Cards.ContinuousEffects;
using Engine.Abilities;
using Engine.Durations;

namespace Cards.Cards.DM04
{
    class CannonShell : Creature
    {
        public CannonShell() : base("Cannon Shell", 4, Common.Civilization.Nature, 1000, Common.Subtype.ColonyBeetle)
        {
            ShieldTrigger = true;

            // This creature gets +1000 power for each shield you have.
            Abilities.Add(new StaticAbility(new CannonShellEffect()));
        }
    }
}
