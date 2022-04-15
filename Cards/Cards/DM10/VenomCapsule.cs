using Common;

namespace Cards.Cards.DM10
{
    class VenomCapsule : SilentSkillCreature
    {
        public VenomCapsule() : base("Venom Capsule", 2, 1000, Engine.Subtype.BrainJacker, Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldsEffect(1));
        }
    }
}
