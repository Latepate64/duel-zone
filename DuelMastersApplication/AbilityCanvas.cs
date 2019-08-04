using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Trigger;
using DuelMastersModels.Factories;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DuelMastersApplication
{
    public class AbilityCanvas : Canvas
    {
        public static readonly DependencyProperty SetAndIdProperty = DependencyProperty.Register("SetAndId", typeof(SetAndId), typeof(AbilityCanvas), new PropertyMetadata(OnSetAndIdChanged));
        public static readonly DependencyProperty AbilityProperty = DependencyProperty.Register("Ability", typeof(NonStaticAbility), typeof(AbilityCanvas), new PropertyMetadata(OnAbilityChanged));

        public NonStaticAbility Ability
        {
            get { return (NonStaticAbility)GetValue(AbilityProperty); }
            set { SetValue(AbilityProperty, value); }
        }

        private Image _artwork = new Image() { Stretch = Stretch.Fill };
        private TextBox _textBox = new TextBox() { TextWrapping = TextWrapping.Wrap, VerticalScrollBarVisibility = ScrollBarVisibility.Hidden, FontFamily = new FontFamily("Microsoft Sans Serif"), Cursor = System.Windows.Input.Cursors.Arrow, Focusable = false };

        public AbilityCanvas()
        {
            Background = new SolidColorBrush(Colors.Black);
            SizeChanged += AbilityCanvas_SizeChanged;

            Children.Add(_artwork);
            Children.Add(_textBox);
        }

        private void AbilityCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double width = e.NewSize.Width;
            double height = e.NewSize.Height;

            _artwork.Width = (1 - 2 * AbstractCardCanvas.FrameOffset) * width;
            _artwork.Height = 0.5 * Height;
            SetLeft(_artwork, (width - _artwork.Width) / 2);
            SetTop(_artwork, AbstractCardCanvas.FrameOffset * height);

            _textBox.Width = _artwork.Width;
            _textBox.Height = 0.3 * Height;
            SetLeft(_textBox, (width - _textBox.Width) / 2);
            SetTop(_textBox, (1 - AbstractCardCanvas.FrameOffset) * height - _textBox.Height);
        }

        private static void OnSetAndIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as AbilityCanvas)._artwork.Source = AbstractCardCanvas.GetArtwork((SetAndId)e.NewValue);
        }

        private static void OnAbilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NonStaticAbility nonStaticAbility = e.NewValue as NonStaticAbility;
            if (nonStaticAbility is TriggerAbility triggerAbility)
            {
                (d as AbilityCanvas)._textBox.Text = string.Format("{0} {1}", TriggerConditionFactory.GetTextForTriggerCondition(triggerAbility.TriggerCondition), LowerCaseFirstLetter(EffectFactory.GetTextForEffects(triggerAbility.Effects)));
            }
            else
            {
                throw new InvalidOperationException("Unknown nonStaticAbility.");
            }
        }

        private static string LowerCaseFirstLetter(string text)
        {
            return char.ToLowerInvariant(text[0]) + text.Substring(1);
        }
    }
}
