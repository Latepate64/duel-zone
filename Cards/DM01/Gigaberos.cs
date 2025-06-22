using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM01;

public class Gigaberos : Creature
{
    public Gigaberos() : base("Gigaberos", 5, 8000, Race.Chimera, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new GigaberosEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
