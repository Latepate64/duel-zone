using Common;

namespace Cards.Cards.DM03
{
    class ArmoredWarriorQuelos : Creature
    {
        public ArmoredWarriorQuelos() : base("Armored Warrior Quelos", 5, 2000, Subtype.Armorloid, Civilization.Fire)
        {
            // Whenever this creature attacks, put a non-fire card from your mana zone into your graveyard. Then your opponent chooses a non-fire card in his mana zone and puts it into his graveyard.
            Abilities.Add(new TriggeredAbilities.AttackAbility(new OneShotEffects.ArmoredWarriorQuelosEffect()));
        }
    }
}
