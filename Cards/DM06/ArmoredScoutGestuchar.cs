using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class ArmoredScoutGestuchar : Creature
{
    public ArmoredScoutGestuchar() : base("Armored Scout Gestuchar", 5, 4000, Race.Armorloid, Civilization.Fire)
    {
        AddStaticAbilities(new ArmoredScoutGestucharEffect());
    }
}
