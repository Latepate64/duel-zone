using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class HunterFish : Creature
    {
        public HunterFish() : base("Hunter Fish", 2, Civilization.Water, 3000, Subtype.Fish)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
