using Interfaces;

namespace Cards.DM08;

public sealed class SeniaOrchardAvenger : TurboRushCreature
{
    public SeniaOrchardAvenger() : base("Senia, Orchard Avenger", 4, 3000, Race.TreeFolk, Civilization.Nature)
    {
        AddTurboRushAbility(new SeniaOrchardAvengerEffect());
    }
}
