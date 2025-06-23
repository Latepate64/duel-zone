using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

sealed class KyrstronLairDelver : Creature
{
    public KyrstronLairDelver() : base("Kyrstron, Lair Delver", 5, 1000, Race.Dragonoid, Civilization.Fire)
    {
        AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new KyrstronLairDelverEffect()));
    }
}
