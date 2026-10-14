using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class VenomCapsule : SilentSkillCreature
{
    public VenomCapsule() : base("Venom Capsule", 2, 1000, Race.BrainJacker,
        Civilization.Darkness)
    {
        AddSilentSkillAbility(
            new ThisCreatureBreaksOpponentsShieldsEffect(1));
    }
}