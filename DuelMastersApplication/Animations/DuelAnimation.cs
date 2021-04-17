using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace DuelMastersApplication.Animations
{
    public abstract class DuelAnimation
    {
        protected Duration DefaultDuration => new Duration(new TimeSpan(0, 0, 0, 1, 0));

        public string Message { get; protected set; }

        public event EventHandler Completed;

        public abstract void Play();

        protected void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            Completed.Invoke(this, null);
        }
    }

    public class DrawCardAnimation : DuelAnimation
    {
        private readonly NewZoneCanvas _listView;
        private readonly NewCardCanvas _card;

        public DrawCardAnimation(NewZoneCanvas listView, NewCardCanvas card, string playerName)
        {
            _listView = listView;
            _card = card;
            Message = string.Format("{0} drew a card.", playerName);
        }

        public override void Play()
        {
            _listView.AddCard(_card);
            DoubleAnimation doubleAnimation = new DoubleAnimation(0.0, 1.0, DefaultDuration)
            {
                RepeatBehavior = new RepeatBehavior(1),
            };
            doubleAnimation.Completed += DoubleAnimation_Completed;
            _card.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
        }
    }
}
