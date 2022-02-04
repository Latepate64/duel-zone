using Cards.CardFilters;
using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;
using System;

namespace Cards.StaticAbilities
{
    internal class PetrovaAbility : StaticAbility
    {
        public PetrovaAbility()
        {
            //ContinuousEffects.Add(new PowerModifyingEffect(new NoneFilter(), 4000, new Indefinite()));
            ContinuousEffects.Add(new PetrovaChannelerOfSunsEffect(new TargetFilter(), new Indefinite(), new CardMovedEvent { Source = ZoneType.Anywhere, Destination = ZoneType.BattleZone }));
        }

        public PetrovaAbility(PetrovaAbility ability) : base(ability)
        {
        }

        //public override Choice Apply(Game game, Decision decision)
        //{
        //    if (decision == null)
        //    {
        //        return new EnumChoice(Owner, new List<Enum> { Common.Subtype.MechaDelSol });
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

        public override GameEvent Apply(Game game, Engine.Player player)
        {
            throw new NotImplementedException();
        }

        public override bool Replaceable(GameEvent gameEvent, Game game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Destination == ZoneType.BattleZone && Filter.Applies(game.GetCard(e.CardInSourceZone), game, game.GetPlayer(e.Player));
            }
            return false;
        }
    }
}
