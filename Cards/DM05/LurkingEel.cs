using ContinuousEffects;

namespace Cards.DM05
{
    class LurkingEel : Engine.Creature
    {
        public LurkingEel() : base("Lurking Eel", 6, 4000, Engine.Race.GelFish, Engine.Civilization.Water)
        {
            AddStaticAbilities(new CivilizationBlockerEffect(Engine.Civilization.Fire, Engine.Civilization.Nature));
        }
    }
}
