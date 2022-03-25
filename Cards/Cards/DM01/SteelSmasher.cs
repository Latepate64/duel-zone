using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class SteelSmasher : Creature
    {
        public SteelSmasher() : base("Steel Smasher", 2, 3000, Common.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            AddAbilities(new ThisCreatureCannotAttackPlayersAbility());
        }
    }
}
