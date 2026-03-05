using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

public sealed class Bombersaur : Creature
{
    public Bombersaur() : base("Bombersaur", 5, 5000, Interfaces.Race.RockBeast, Interfaces.Civilization.Fire)
    {
        AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new BombersaurEffect()));
    }
}
