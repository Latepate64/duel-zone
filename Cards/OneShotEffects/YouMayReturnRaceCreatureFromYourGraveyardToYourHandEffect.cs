using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect : SalvageEffect
    {
        private readonly Race _race;

        public YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect(Race race, int maximum = 1) : base(0, maximum, true)
        {
            _race = race;
        }

        public YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect(YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect effect) : base(effect)
        {
            _race = effect._race;
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect(this);
        }

        public override string ToString()
        {
            return Maximum == 1 ? 
                $"You may return a {_race} from your graveyard to your hand." : 
                $"Return up to {Maximum} {_race}s from your graveyard to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.Graveyard.GetCreatures(_race);
        }
    }
}
