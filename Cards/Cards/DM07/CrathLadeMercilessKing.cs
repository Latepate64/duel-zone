using Common;

namespace Cards.Cards.DM07
{
    class CrathLadeMercilessKing : Creature
    {
        public CrathLadeMercilessKing() : base("Crath Lade, Merciless King", 8, 4000, Subtype.DarkLord, Civilization.Darkness)
        {
            AddAbilities(new Engine.Abilities.TapAbility(new OneShotEffects.OpponentRandomDiscardEffect(2)));
        }
    }
}
