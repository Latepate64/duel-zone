using Abilities.Static;
using ContinuousEffects.CannotUseShieldTrigger;
using Interfaces;

namespace Cards.DM07;

sealed class CrypticTotem : Creature
{
    public CrypticTotem() : base(
        "Cryptic Totem", 6, 6000, Race.MysteryTotem, Civilization.Nature)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddStaticAbilities(new CrypticTotemEffect());
    }
}
