using ContinuousEffects;
using Interfaces;

namespace Cards.Promo;

public sealed class QTronicOmnistrain : EvolutionCreature
{
    public QTronicOmnistrain() : base("Q-tronic Omnistrain", 6, 3000, Race.Survivor, Civilization.Nature)
    {
        AddShieldTrigger();
        AddStaticAbilities(new QTronicOmnistrainEffect());
    }
}
