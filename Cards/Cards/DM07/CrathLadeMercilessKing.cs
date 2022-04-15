namespace Cards.Cards.DM07
{
    class CrathLadeMercilessKing : Creature
    {
        public CrathLadeMercilessKing() : base("Crath Lade, Merciless King", 8, 4000, Engine.Subtype.DarkLord, Engine.Civilization.Darkness)
        {
            AddTapAbility(new OneShotEffects.OpponentRandomDiscardEffect(2));
        }
    }
}
