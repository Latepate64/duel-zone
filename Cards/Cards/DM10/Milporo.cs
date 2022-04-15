namespace Cards.Cards.DM10
{
    class Milporo : SilentSkillCreature
    {
        public Milporo() : base("Milporo", 4, 3000, Engine.Subtype.CyberLord, Engine.Civilization.Water)
        {
            AddSilentSkillAbility(new OneShotEffects.DrawCardsEffect(1));
        }
    }
}
