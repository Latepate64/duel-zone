using ContinuousEffects;
using Interfaces;

namespace Cards.DM08;

sealed class MegariaEmpressOfDread : Creature
{
    public MegariaEmpressOfDread() : base("Megaria, Empress of Dread", 5, 5000, Race.DarkLord, Civilization.Darkness)
    {
        AddStaticAbilities(new MegariaEmpressOfDreadEffect());
    }
}
