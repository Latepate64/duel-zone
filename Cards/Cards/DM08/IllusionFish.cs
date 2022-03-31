using Common;

namespace Cards.Cards.DM08
{
    class IllusionFish : TurboRushCreature
    {
        public IllusionFish() : base("Illusion Fish", 4, 3000, Subtype.GelFish, Civilization.Water)
        {
            AddTurboRushAbility(new ContinuousEffects.ThisCreatureCannotBeBlockedEffect());
        }
    }
}
