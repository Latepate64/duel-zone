﻿namespace Cards.Cards.DM10
{
    class VenomCapsule : SilentSkillCreature
    {
        public VenomCapsule() : base("Venom Capsule", 2, 1000, Engine.Race.BrainJacker, Engine.Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldEffect());
        }
    }
}
