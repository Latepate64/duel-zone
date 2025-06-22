using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM07;

public sealed class ArmoredTransportGaliacruse : Creature
{
    public ArmoredTransportGaliacruse() : base(
        "Armored Transport Galiacruse", 6, 5000, Race.Armorloid, Civilization.Fire)
    {
        AddAbilities(new TapAbility(new ArmoredTransportGaliacruseEffect()));
    }
}
