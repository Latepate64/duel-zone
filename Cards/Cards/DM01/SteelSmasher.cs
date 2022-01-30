using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    class SteelSmasher : Creature
    {
        public SteelSmasher() : base("Steel Smasher", 2, Civilization.Nature, 3000, Subtype.BeastFolk)
        {
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
