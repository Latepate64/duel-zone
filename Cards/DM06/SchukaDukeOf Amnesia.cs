using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class SchukaDukeOfAmnesia : Creature
{
    public SchukaDukeOfAmnesia() : base("Schuka, Duke of Amnesia", 6, 5000, Race.DarkLord, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new SchukaDukeOfAmnesiaEffect()));
    }
}
