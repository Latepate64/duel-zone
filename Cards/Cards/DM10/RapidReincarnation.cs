using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class RapidReincarnation : Spell
    {
        public RapidReincarnation() : base("Rapid Reincarnation", 3, Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new RapidReincarnationEffect());
        }
    }

    class RapidReincarnationEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            ICard creature = Controller.DestroyOwnCreatureOptionally(ToString(), game, Ability);
            if (creature != null)
            {
                ICard card = Controller.ChooseCard(Controller.Hand.Creatures.Where(x => x.ManaCost <= Controller.ManaZone.Cards.Count), ToString());
                game.Move(Ability, ZoneType.Hand, ZoneType.BattleZone, card);
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
}
