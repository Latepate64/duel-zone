using Interfaces;

namespace Cards.DM02;

public class ArmoredCannonBalbaro : EvolutionCreature
{
    public ArmoredCannonBalbaro() : base("Armored Cannon Balbaro", 3, 3000, Race.Human, Civilization.Fire)
    {
        AddStaticAbilities(new ArmoredCannonBalbaroEffect());
    }
}
