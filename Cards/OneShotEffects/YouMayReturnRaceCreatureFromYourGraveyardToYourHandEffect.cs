using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect : SalvageEffect, IRaceable
    {
        public YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect(Race race) : base(0, 1, true)
        {
            Race = race;
        }

        public YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect(YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect effect) : base(effect)
        {
            Race = effect.Race;
        }

        public Race Race { get; }

        public override IOneShotEffect Copy()
        {
            return new YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect(this);
        }

        public override string ToString()
        {
            return Maximum == 1 ? 
                $"You may return a {Race} from your graveyard to your hand." : 
                $"Return up to {Maximum} {Race}s from your graveyard to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Applier.Graveyard.GetCreatures(Race);
        }
    }
}
