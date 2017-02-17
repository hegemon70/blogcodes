using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace UiTableGrid.TwoColumns
{
    public class TableSourcePerson : UITableViewSource
    {
        private readonly List<Person> _results;

        private readonly PersonsViewController _owner;

        public TableSourcePerson(List<Person> results, PersonsViewController owner)
        {
            _results = results;
            _owner = owner;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var person = _results[indexPath.Row];

            _owner.Selected = person;

            tableView.DeselectRow(indexPath, true);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(TwoColumnCell.Id) as TwoColumnCell ??
                       new TwoColumnCell(tableView.Bounds);

            cell.LeftValue.Text = _results[indexPath.Row].Name;
            cell.RightValue.Text = _results[indexPath.Row].Age.ToString();

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _results.Count;
        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return 40;
        }

        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            var cell = tableView.DequeueReusableCell("HeaderCell") as TwoColumnCell;

            if (cell != null) return cell;

            return new TwoColumnCell(tableView.Bounds, isHeader: true)
            {
                LeftValue = { Text = "Nombre" },
                RightValue = { Text = "Edad" },
                BackgroundColor = UIColor.FromRGB(247, 247, 247)
            };
        }
    }
}