using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class LurkingEel : Creature
    {
        public LurkingEel() : base("Lurking Eel", 6, 4000, Engine.Subtype.GelFish, Engine.Civilization.Water)
        {
            AddStaticAbilities(new CivilizationBlockerEffect(Engine.Civilization.Fire, Engine.Civilization.Nature));
        }
    }
}
