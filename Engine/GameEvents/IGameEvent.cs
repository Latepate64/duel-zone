namespace Engine.GameEvents
{
    public interface IGameEvent
    {
        System.Guid Id { get; }

        void Happen(IGame game);

        /// <summary>
        /// 616.1. If two or more replacement and/or prevention effects are attempting to modify the way an event
        /// affects an object or player, the affected object’s controller (or its owner if it has no controller) or the
        /// affected player chooses one to apply, following the steps listed below. If two or more players have
        /// to make these choices at the same time, choices are made in APNAP order (see rule 101.4).
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        IPlayer GetApplier(IGame game);
    }
}
