using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class Gigarayze : Creature
{
    public Gigarayze() : base("Gigarayze", 4, 2000, Race.Chimera, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new GigarayzeEffect(
            Civilization.Water, Civilization.Fire)));
    }
}
