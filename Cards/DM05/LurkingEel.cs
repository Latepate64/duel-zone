using ContinuousEffects;

namespace Cards.DM05
{
    sealed class LurkingEel : Engine.Creature
    {
        public LurkingEel() : base("Lurking Eel", 6, 4000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new CivilizationBlockerEffect(Interfaces.Civilization.Fire, Interfaces.Civilization.Nature));
        }
    }
}
