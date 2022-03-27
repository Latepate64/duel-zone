using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class HunterFish : Creature
    {
        public HunterFish() : base("Hunter Fish", 2, 3000, Common.Subtype.Fish, Common.Civilization.Water)
        {
            AddAbilities(new BlockerAbility(), new ThisCreatureCannotAttackAbility());
        }
    }
}
