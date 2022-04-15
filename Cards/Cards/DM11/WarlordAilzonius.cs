namespace Cards.Cards.DM11
{
    class WarlordAilzonius : EvolutionCreature
    {
        public WarlordAilzonius() : base("Warlord Ailzonius", 5, 8000, Engine.Subtype.Gladiator, Engine.Civilization.Light)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new ContinuousEffects.OpponentCannotChooseThisCreatureEffect());
        }
    }
}
