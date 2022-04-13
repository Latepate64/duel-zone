using Common;

namespace Cards.Cards.DM05
{
    class GalliaZohlIronGuardianQ : Creature
    {
        public GalliaZohlIronGuardianQ() : base("Gallia Zohl, Iron Guardian Q", 5, 2000, Subtype.Survivor, Subtype.Guardian, Civilization.Light)
        {
            AddSurvivorAbility(new ContinuousEffects.ThisCreatureHasBlockerEffect());
        }
    }
}
