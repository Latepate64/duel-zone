using Abilities.Triggered;
using OneShotEffects;
using Engine;

namespace Cards.Cards.DM05;

public class KulusSoulshineEnforcer : Creature
{
    public KulusSoulshineEnforcer() : base("Kulus, Soulshine Enforcer", 4, 3500, Race.Berserker, Civilization.Light)
    {
        AddTriggeredAbility(new KulusSoulshineEnforcerAbility(new PutTopCardOfDeckIntoManaZoneEffect()));
    }
}
