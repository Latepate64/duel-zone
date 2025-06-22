using Interfaces;

namespace Cards.DM11;

public class GankloakRogueCommando : SilentSkillCreature
{
    public GankloakRogueCommando() : base("Gankloak, Rogue Commando", 3, 2000, Race.Human, Civilization.Fire)
    {
        AddSilentSkillAbility(new GankloakRogueCommandoOneShotEffect());
    }
}
