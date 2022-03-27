using Common;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class SchukaDukeOfAmnesia : Creature
    {
        public SchukaDukeOfAmnesia() : base("Schuka, Duke of Amnesia", 6, 5000, Subtype.DarkLord, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsDestroyedAbility(new SchukaDukeOfAmnesiaEffect()));
        }
    }

    class SchukaDukeOfAmnesiaEffect : OneShotEffects.CardMovingAreaOfEffect
    {
        public SchukaDukeOfAmnesiaEffect() : base(ZoneType.Hand, ZoneType.Graveyard, new CardFilters.HandCardFilter())
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
    }
}
