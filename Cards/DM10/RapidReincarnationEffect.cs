using Engine.Abilities;
using Interfaces;
using System.Linq;

namespace Cards.DM10;

public sealed class RapidReincarnationEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        if (Controller.DestroyOwnCreatureOptionally(ToString(), game, Ability) != null)
        {
            var card = Controller.ChooseCard(Controller.Hand.Creatures.Where(
                x => x.ManaCost <= Controller.ManaZone.Size), ToString()) as ICreature;
            Controller.PutCreatureFromOwnHandIntoBattleZone(card, game, Ability);
        }
    }

    public override IOneShotEffect Copy()
    {
        return new RapidReincarnationEffect();
    }

    public override string ToString()
    {
        return "You may destroy one of your creatures. If you do, choose a creature in your hand that costs the same as or less than the number of cards in your mana zone and put it into the battle zone.";
    }
}
