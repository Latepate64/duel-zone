using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM09;

public class VreemahFreakyMojoTotem : Creature
{
    public VreemahFreakyMojoTotem() : base(
        "Vreemah, Freaky Mojo Totem", 5, 4000, Race.MysteryTotem, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(
            new VreemahFreakyMojoTotemOneShotEffect()));
    }
}
