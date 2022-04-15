using Common;

namespace Cards.Cards.Promo
{
    class GiliamTheTormentor : Creature
    {
        public GiliamTheTormentor() : base("Giliam, the Tormentor", 7, 5000, Engine.Subtype.DemonCommand, Civilization.Darkness)
        {
            AddStaticAbilities(new ContinuousEffects.CivilizationBlockerEffect(Civilization.Light), new ContinuousEffects.NotDestroyedInBattleEffect(Civilization.Light));
        }
    }
}
