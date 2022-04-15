using Common;

namespace Cards.Cards.DM07
{
    class CuriousEye : Creature
    {
        public CuriousEye() : base("Curious Eye", 3, 1000, Engine.Subtype.CyberVirus, Civilization.Water)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayLookAtOneOfYourOpponentsShieldsEffect());
        }
    }
}
