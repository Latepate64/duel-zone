using Common;

namespace Cards.Cards.DM04
{
    class VolcanoSmogDeceptiveShade : Creature
    {
        public VolcanoSmogDeceptiveShade() : base("Volcano Smog, Deceptive Shade", 6, 5000, Subtype.Ghost, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.EachCivilizationCardCostsMoreAbility(Civilization.Light, 2));
        }
    }
}
