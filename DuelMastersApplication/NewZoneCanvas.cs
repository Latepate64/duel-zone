using System.Collections.Generic;
using System.Windows.Controls;

namespace DuelMastersApplication
{
    public class NewZoneCanvas : Canvas
    {
        //List<NewAbstractCardCanvas> _cards { get; } = new List<NewAbstractCardCanvas>();

        public NewZoneCanvas()
        {
        }

        public void AddCard(NewAbstractCardCanvas cardToAdd)
        {
            //_cards.Add(card);
            Children.Add(cardToAdd);

            double centerWidth = ActualWidth / 2;
            int halfChildren = Children.Count / 2;
            var cardIndex = 0;
            for (int i = 0; i < halfChildren; ++i)
            {
                NewMethod(halfChildren, i, -1, Children[cardIndex++] as NewAbstractCardCanvas, centerWidth);
            }
            if (Children.Count % 2 == 1)
            {
                NewAbstractCardCanvas card = Children[cardIndex++] as NewAbstractCardCanvas;
                SetLeft(card, centerWidth - card.Width / 2);
            }
            for (int i = 0; i < halfChildren; ++i)
            {
                NewMethod(halfChildren, i, 1, Children[cardIndex++] as NewAbstractCardCanvas, centerWidth);
            }
        }

        private void NewMethod(int halfChildren, int i, int multiplier, NewAbstractCardCanvas card, double parentCenter)
        {
            var cardWidths = parentCenter + multiplier * halfChildren + i * card.Width;
            double cardCenter = cardWidths;
            SetLeft(card, cardCenter - card.Width / 2);
        }

        public void RemoveCard(NewAbstractCardCanvas card)
        {
            throw new System.NotImplementedException();
        }
    }
}
