using TriggeredAbilities;
using OneShotEffects;
using Interfaces;

namespace Cards.DM05;

public sealed class KulusSoulshineEnforcer : Creature
{
    public KulusSoulshineEnforcer() : base("Kulus, Soulshine Enforcer", 4, 3500, Race.Berserker, Civilization.Light)
    {
        AddTriggeredAbility(new KulusSoulshineEnforcerAbility(new PutTopCardOfDeckIntoManaZoneEffect()));
    }
}
