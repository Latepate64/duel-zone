using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class BatDoctorShadowOfUndeath : Creature
{
    public BatDoctorShadowOfUndeath() : base(
        "Bat Doctor, Shadow of Undeath", 3, 2000, Race.Ghost, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new BatDoctorShadowOfUndeathEffect()));
    }
}
