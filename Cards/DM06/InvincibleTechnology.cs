using Engine;
using Interfaces;

namespace Cards.DM06;

public class InvincibleTechnology : Spell
{
    public InvincibleTechnology() : base("Invincible Technology", 13, Civilization.Water)
    {
        AddSpellAbilities(new InvincibleTechnologyEffect());
    }
}
