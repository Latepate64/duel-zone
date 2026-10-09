using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM06;

public sealed class QTronicHypermind : EvolutionCreature
{
    public QTronicHypermind() : base("Q-tronic Hypermind", 8, 8000, Race.Survivor, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new QTronicHypermindEffect()));
        AddAbilities(new DoubleBreakerAbility());
    }
}
