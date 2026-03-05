using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class ScarletSkyterror : Creature
{
    public ScarletSkyterror() : base("Scarlet Skyterror", 8, 3000, Race.ArmoredWyvern, Civilization.Fire)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ScarletSkyterrorEffect()));
    }
}
