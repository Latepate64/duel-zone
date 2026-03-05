using ContinuousEffects;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM12;

public sealed class NemonexBajulasRobomantis : EvolutionCreature
{
    public NemonexBajulasRobomantis() : base("Nemonex, Bajula's Robomantis", 6, 5000, Race.Xenoparts, Race.GiantInsect,
        Civilization.Fire, Civilization.Nature)
    {
        AddStaticAbilities(new EachOfYourOtherRacesGetsPowerEffect(Race.Xenoparts, Race.GiantInsect));
        AddTriggeredAbility(new NemonexAbility(
            new YourOpponentChoosesCardInHisManaZoneAndPutsItIntoHisGraveyardEffect()));
    }
}
