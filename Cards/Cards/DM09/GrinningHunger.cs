using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM09
{
    class GrinningHunger : Spell
    {
        public GrinningHunger() : base("Grinning Hunger", 4, Civilization.Darkness)
        {
            AddSpellAbilities(new GrinningHungerEffect());
        }
    }

    class GrinningHungerEffect : OneShotEffect
    {
        public GrinningHungerEffect()
        {
        }

        public GrinningHungerEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            var card = Applier.Opponent.ChooseCard(Game.BattleZone.GetCreatures(Applier.Opponent).Union(Applier.Opponent.ShieldZone.Cards), ToString());
            if (card != null)
            {
                Game.Move(Ability, Game.GetZone(card).Type, ZoneType.Graveyard, card);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new GrinningHungerEffect(this);
        }

        public override string ToString()
        {
            return "Your opponent chooses one of his creatures in the battle zone or one of his shields and puts it into his graveyard.";
        }
    }
}
