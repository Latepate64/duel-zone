using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class SteelSmasher : Creature
    {
        public SteelSmasher() : base("Steel Smasher", 2, Common.Civilization.Nature, 3000, Common.Subtype.BeastFolk)
        {
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
