using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM06
{
    class SchukaDukeOfAmnesia : Creature
    {
        public SchukaDukeOfAmnesia() : base("Schuka, Duke of Amnesia", 6, 5000, Race.DarkLord, Civilization.Darkness)
        {
            AddWhenThisCreatureIsDestroyedAbility(new SchukaDukeOfAmnesiaEffect());
        }
    }

    class SchukaDukeOfAmnesiaEffect : OneShotEffects.CardMovingAreaOfEffect
    {
        public SchukaDukeOfAmnesiaEffect() : base(ZoneType.Hand, ZoneType.Graveyard)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SchukaDukeOfAmnesiaEffect();
        }

        public override string ToString()
        {
            return "Each player discards his hand.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IAbility source)
        {
            return Game.Players.SelectMany(x => x.Hand.Cards);
        }
    }
}
