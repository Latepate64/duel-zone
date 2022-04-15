namespace Cards.Cards.DM08
{
    class SlaphappySoldierGalback : TurboRushCreature
    {
        public SlaphappySoldierGalback() : base("Slaphappy Soldier Galback", 4, 3000, Engine.Subtype.Dragonoid, Engine.Civilization.Fire)
        {
            AddTurboRushAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(4000)));
        }
    }
}
