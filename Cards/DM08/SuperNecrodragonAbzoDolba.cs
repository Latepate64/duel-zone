using ContinuousEffects;
using Interfaces;

namespace Cards.DM08;

public sealed class SuperNecrodragonAbzoDolba : DragonEvolutionCreature
{
    public SuperNecrodragonAbzoDolba() : base(
        "Super Necrodragon Abzo Dolba", 6, 11000, Race.ZombieDragon, Civilization.Darkness)
    {
        AddStaticAbilities(new SuperNecrodragonAbzoDolbaEffect());
        AddStaticAbilities(new TripleBreakerEffect());
    }
}
