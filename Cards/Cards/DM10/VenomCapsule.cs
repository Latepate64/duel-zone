using Common;

namespace Cards.Cards.DM10
{
    class VenomCapsule : SilentSkillCreature
    {
        public VenomCapsule() : base("Venom Capsule", 2, 1000, Subtype.BrainJacker, Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldsEffect(1));
        }
    }
}
