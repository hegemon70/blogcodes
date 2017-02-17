using System;
using CoreGraphics;
using UIKit;

namespace UiTableGrid.TwoColumns
{
    public class TwoColumnCell : UITableViewCell
    {
        public static string Id = "MultiColumnCell";

        public UILabel LeftValue { get; set; }

        public UILabel RightValue { get; set; }

        public TwoColumnCell(CGRect tableViewBounds, bool isHeader = false)
        {
            if (isHeader) Id = "HeaderCell";

            var w = tableViewBounds.Width;

            var left = w * 70 / 100 + 5;
            var right = w * 30 / 100;

            const float cellHeight = 60;

            const float y = 0;
            
            var cell = new UITableViewCell(UITableViewCellStyle.Default, Id)
            {
                Frame = new CGRect(0, 0, w, cellHeight),
                SelectionStyle = UITableViewCellSelectionStyle.Gray,
                //if you want the selected row effect :S
                UserInteractionEnabled = false
            };

            // I couldn't set the padding, so, x = 15, and so on
            LeftValue = new UILabel(new CGRect(15, y, left, cellHeight))
            {
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            RightValue = new UILabel(new CGRect(left + 5, y, right - 5, cellHeight))
            {
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            if (isHeader)
                cell.AddSubviews(LeftValue, RightValue);
            else
                cell.AddSubviews(LeftValue, GetVerticalSep(left, cellHeight-19), RightValue);

            Add(cell);
        }

        private static UIImageView GetVerticalSep(nfloat left, nfloat height)
        {
            var verticalLine = UIImage.FromBundle("vertical-line");
            UIImageView imageView = new UIImageView(new CGRect(left, 0, 1, height)) { Image = verticalLine };
            return imageView;
        }
    }
}
