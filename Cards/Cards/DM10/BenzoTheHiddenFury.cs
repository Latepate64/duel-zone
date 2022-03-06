using Common;

namespace Cards.Cards.DM10
{
    class BenzoTheHiddenFury : Creature
    {
        public BenzoTheHiddenFury() : base("Benzo, the Hidden Fury", 4, 2000, Subtype.PandorasBox, Civilization.Darkness)
        {
            Abilities.Add(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.ShieldRecoveryEffect(true)));
        }
    }
}
