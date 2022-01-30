using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.Choices;
using Engine.ContinuousEffects;
using Engine.Durations;
using Engine.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.StaticAbilities
{
    internal class PetrovaAbility : StaticAbility
    {
        public PetrovaAbility()
        {
            //ContinuousEffects.Add(new PowerModifyingEffect(new NoneFilter(), 4000, new Indefinite()));
            ContinuousEffects.Add(new PetrovaChannelerOfSunsEffect(new TargetFilter(), new Indefinite(), new CardMovedEvent(Guid.Empty, Guid.Empty, Engine.Zones.ZoneType.Anywhere, Engine.Zones.ZoneType.BattleZone, null)));
        }

        public PetrovaAbility(PetrovaAbility ability) : base(ability)
        {
        }

        //public override Choice Apply(Game game, Decision decision)
        //{
        //    if (decision == null)
        //    {
        //        return new EnumChoice(Owner, new List<Enum> { Subtype.MechaDelSol });
        //    }
        //    else
        //    {
        //        ContinuousEffects.Single().Filters.Clear();
        //        ContinuousEffects.Single().Filters.Add(new SubtypeFilter((Subtype)(decision as EnumDecision).Decision) { Owner = Owner, Target = Source });
        //        return null;
        //    }
        //}

        public override Ability Copy()
        {
            return new PetrovaAbility(this);
        }

        //public override void Revoke()
        //{
        //    ContinuousEffects.Single().Filters.Clear();
        //    ContinuousEffects.Single().Filters.Add(new NoneFilter { Owner = Owner, Target = Source });
        //}
    }

    internal class PetrovaChannelerOfSunsEffect : ReplacementEffect
    {
        public PetrovaChannelerOfSunsEffect(CardFilter filter, Duration duration, GameEvent gameEvent) : base(filter, duration, gameEvent)
        {
        }

        public PetrovaChannelerOfSunsEffect(PetrovaChannelerOfSunsEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new PetrovaChannelerOfSunsEffect(this);
        }

        public override GameEvent Apply(Game game, Player player)
        {
            throw new NotImplementedException();
        }

        public override bool Replaceable(GameEvent gameEvent, Game game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Destination == Engine.Zones.ZoneType.BattleZone && Filter.Applies(game.GetCard(e.CardInSourceZone), game, game.GetPlayer(e.Player));
            }
            return false;
        }
    }
}
