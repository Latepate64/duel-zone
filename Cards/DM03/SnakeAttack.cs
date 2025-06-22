using OneShotEffects;
using Engine;
using Interfaces;

namespace Cards.DM03;

public class SnakeAttack : Spell
{
    public SnakeAttack() : base("Snake Attack", 4, Civilization.Darkness)
    {
        AddSpellAbilities(new SnakeAttackEffect(), new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
    }
}
