using Engine;
using Engine.Abilities;

namespace Cards.Cards.Promo
{
    class BrigadeShellQ : Creature
    {
        public BrigadeShellQ() : base("Brigade Shell Q", 3, 1000, Race.Survivor, Race.ColonyBeetle, Civilization.Nature)
        {
            AddSurvivorAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new BrigadeShellQEffect()));
        }
    }

    class BrigadeShellQEffect : OneShotEffect
    {
        public override void Apply()
        {
            ICard card = Applier.RevealTopCardOfOwnDeck();
            if (card != null)
            {
                if (card.HasRace(Race.Survivor))
                {
                    Applier.PutTopCardOfOwnDeckIntoOwnHand(Ability);
                }
                else
                {
                    Applier.PutTopCardOfOwnDeckIntoOwnGraveyard(Ability);
                }
            }
        }

        public override IOneShotEffect Copy()
        {
            return new BrigadeShellQEffect();
        }

        public override string ToString()
        {
            return "Reveal the top card of your deck. If it's a Survivor, put it into your hand. Otherwise, put it into your graveyard.";
        }
    }
}
