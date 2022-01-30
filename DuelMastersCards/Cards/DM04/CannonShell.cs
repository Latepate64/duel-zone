using Cards.CardFilters;
using Cards.ContinuousEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Durations;

namespace Cards.Cards.DM04
{
    class CannonShell : Creature
    {
        public CannonShell() : base("Cannon Shell", 4, Civilization.Nature, 1000, Subtype.ColonyBeetle)
        {
            ShieldTrigger = true;

            // This creature gets +1000 power for each shield you have.
            Abilities.Add(new StaticAbility(new CannonShellEffect(new TargetFilter(), new Indefinite())));
        }
    }
}
