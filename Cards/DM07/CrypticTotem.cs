using ContinuousEffects;
using Interfaces;

namespace Cards.DM07;

sealed class CrypticTotem : Creature
{
    public CrypticTotem() : base(
        "Cryptic Totem", 6, 6000, Race.MysteryTotem, Civilization.Nature)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddStaticAbilities(new CrypticTotemEffect());
    }
}
