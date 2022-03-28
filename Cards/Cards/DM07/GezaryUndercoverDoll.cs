using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM07
{
    class GezaryUndercoverDoll : Creature
    {
        public GezaryUndercoverDoll() : base("Gezary, Undercover Doll", 3, 2000, Subtype.DeathPuppet, Civilization.Darkness)
        {
            AddStaticAbilities(new StealthEffect(Civilization.Nature));
        }
    }
}
