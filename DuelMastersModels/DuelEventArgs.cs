using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels
{
	/// <summary>
	/// Anything that happens in a game is an event. Multiple events may take place during the resolution of a spell or ability. The text of triggered abilities and replacement effects defines the event they’re looking for. One “happening” may be treated as a single event by one ability and as multiple events by another.
	/// </summary>
	public class DuelEventArgs : EventArgs
	{
		/// <summary>
		/// Anything that happens in a game is an event. Multiple events may take place during the resolution of a spell or ability. The text of triggered abilities and replacement effects defines the event they’re looking for. One “happening” may be treated as a single event by one ability and as multiple events by another.
		/// </summary>
		public DuelEvent DuelEvent { get; private set; }

		/// <summary>
		/// Creates duel event arguments.
		/// </summary>
		/// <param name="duelEvent">Event that occurred during duel.</param>
		public DuelEventArgs(DuelEvent duelEvent)
		{
			DuelEvent = duelEvent;
		}
	}

	/// <summary>
	/// Anything that happens in a game is an event. Multiple events may take place during the resolution of a spell or ability. The text of triggered abilities and replacement effects defines the event they’re looking for. One “happening” may be treated as a single event by one ability and as multiple events by another.
	/// </summary>
	public abstract class DuelEvent
	{
	}

	/// <summary>
	/// Player drew a card.
	/// </summary>
	public class DrawCardEvent : DuelEvent
	{
		/// <summary>
		/// Player who drew a card.
		/// </summary>
		public Player Player { get; private set; }

		/// <summary>
		/// Card that the player drew.
		/// </summary>
		public IZoneCard Card { get; private set; }

		internal DrawCardEvent(Player player, IZoneCard card)
		{
			Player = player;
			Card = card;
		}
	}
}
