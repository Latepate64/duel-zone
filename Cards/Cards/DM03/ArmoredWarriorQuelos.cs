using Common;

namespace Cards.Cards.DM03
{
    public class ArmoredWarriorQuelos : Creature
    {
        public ArmoredWarriorQuelos() : base("Armored Warrior Quelos", 5, Civilization.Fire, 2000, Subtype.Armorloid)
        {
            // Whenever this creature attacks, put a non-fire card from your mana zone into your graveyard. Then your opponent chooses a non-fire card in his mana zone and puts it into his graveyard.
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.ArmoredWarriorQuelosEffect()));
        }
    }
}
