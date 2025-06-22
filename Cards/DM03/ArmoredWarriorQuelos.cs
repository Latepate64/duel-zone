using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM03;

public class ArmoredWarriorQuelos : Creature
{
    public ArmoredWarriorQuelos() : base("Armored Warrior Quelos", 5, 2000, Race.Armorloid, Civilization.Fire)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new ArmoredWarriorQuelosEffect()));
    }
}
