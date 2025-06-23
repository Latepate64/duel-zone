using ContinuousEffects;
using Interfaces;

namespace Cards.DM09;

public sealed class NecrodragonIzoristVhal : Creature
{
    public NecrodragonIzoristVhal() : base("Necrodragon Izorist Vhal", 6, 0, Race.ZombieDragon, Civilization.Darkness)
    {
        AddStaticAbilities(new NecrodragonIzoristVhalEffect(), new PoweredDoubleBreaker());
    }
}
