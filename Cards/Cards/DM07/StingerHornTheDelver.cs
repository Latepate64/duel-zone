using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM07
{
    class StingerHornTheDelver : Creature
    {
        public StingerHornTheDelver() : base("Stinger Horn, the Delver", 4, 3000, Engine.Subtype.HornedBeast, Civilization.Nature)
        {
            AddPowerAttackerAbility(1000);
            AddStaticAbilities(new StealthEffect(Civilization.Water));
        }
    }
}
