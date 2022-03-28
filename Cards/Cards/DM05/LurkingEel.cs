using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class LurkingEel : Creature
    {
        public LurkingEel() : base("Lurking Eel", 6, 4000, Subtype.GelFish, Civilization.Water)
        {
            AddStaticAbilities(new CivilizationBlockerEffect(Civilization.Fire, Civilization.Nature));
        }
    }
}
