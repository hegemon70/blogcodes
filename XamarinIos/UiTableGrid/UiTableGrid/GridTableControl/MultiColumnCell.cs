using System;
using CoreGraphics;
using UIKit;

namespace UiTableGrid.GridTableControl
{
    public class MultiColumnCell : UITableViewCell
    {
        public static string Id = "MultiColumnCell";

        private const float CellHeight = 60;

        private const float Y = 0;

        public MultiColumnCell(CGRect tableViewBounds, Tuple<string, int>[] labelsWidth, bool isHeader = false)
        {
            if (isHeader) Id = "HeaderCell";

            var w = tableViewBounds.Width;

            var previous = 0.0;

            var sepxpos = 0.0;

            var limit = labelsWidth.Length - 1;

            var separators = new UIView[limit];

            var views = new UIView[labelsWidth.Length];

            for (int i = 0; i < labelsWidth.Length; i++)
            {
                var lw = labelsWidth[i];

                var cw = w*lw.Item2/100;

                var x = previous < 1 ? 15 : previous + 3;

                previous += cw;

                var label = new UILabel(new CGRect(x, Y, cw, CellHeight))
                {
                    LineBreakMode = UILineBreakMode.TailTruncation,
                    Text = lw.Item1
                };

                views[i] = label;

                if (!isHeader && i < limit)
                {
                    sepxpos += cw;
                    separators[i] = GetVerticalSep(sepxpos, CellHeight - 16);
                }
            }


            var cell = new UITableViewCell(UITableViewCellStyle.Default, Id)
            {
                Frame = new CGRect(0, 0, w, CellHeight),
                SelectionStyle = UITableViewCellSelectionStyle.Gray,
                UserInteractionEnabled = false
            };

            if (!isHeader) cell.AddSubviews(separators);

            cell.AddSubviews(views);

            Add(cell);
        }

        private static UIImageView GetVerticalSep(double x, nfloat height)
        {
            var verticalLine = UIImage.FromBundle("vertical-line");
            var imageView = new UIImageView(new CGRect(x, 0, 1, height)) {Image = verticalLine};
            return imageView;
        }
    }
}
