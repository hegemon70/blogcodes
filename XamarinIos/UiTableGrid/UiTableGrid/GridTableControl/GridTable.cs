using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using CoreGraphics;
using Foundation;
using UIKit;

namespace UiTableGrid.GridTableControl
{
    public struct GridTableColumn
    {
        public string ColumnName { get; set; }

        public int WidthInPercent { get; set; }
    }

    public class GridTable<T> where T : class
    {
        public delegate void ValueSelectedHandler(object sender, SelectedFilterEventArgs<T> args);

        public event ValueSelectedHandler ValueSelected;

        private readonly CGRect _bounds;

        private List<T> _results;

        private readonly Dictionary<string, GridTableColumn> _propertyColumn;

        public GridTable(List<T> results, CGRect bounds, Dictionary<string, GridTableColumn> propertyColumn)
        {
            _results = results;
            _bounds = bounds;
            _propertyColumn = propertyColumn;
        }

        public UITableView Build()
        {
            var searchBar = new UISearchBar
            {
                Placeholder = "Enter Search Text"
            };

            searchBar.SizeToFit();
            searchBar.AutocorrectionType = UITextAutocorrectionType.No;
            searchBar.AutocapitalizationType = UITextAutocapitalizationType.None;

            var table = new UITableView(_bounds, UITableViewStyle.Grouped)
            {
                AutoresizingMask = UIViewAutoresizing.All,
                Source = new GridTableSource<T>(_results, this, _propertyColumn),
                TableHeaderView = searchBar,
                //AllowsSelection = true
                //TODO: Margin-Padding
                //ContentInset = new UIEdgeInsets(0, 16, 0, 16);
            };

            Observable.FromEventPattern<UISearchBarTextChangedEventArgs>(searchBar, "TextChanged")
            .Throttle(TimeSpan.FromSeconds(0.750))
            .Select(x => x.EventArgs.SearchText.ToLowerInvariant())
            .ObserveOn(SynchronizationContext.Current)
            .Subscribe(text =>
            {
                _results =
                    _results
                        .Where(t =>
                        {
                            return _propertyColumn
                                .Select(columnProperty =>
                                    ControlHelpers.GetPropValue(t, columnProperty.Key)?.ToString().ToLowerInvariant() ?? string.Empty)
                                .Any(v => v.Contains(text));
                        }).ToList();

                table.Source = new GridTableSource<T>(_results, this, _propertyColumn);
                table.ReloadData();
            });

            return table;
        }

        protected internal virtual void OnValueSelected(SelectedFilterEventArgs<T> args)
        {
            ValueSelected?.Invoke(this, args);
        }
    }

    public class SelectedFilterEventArgs<T> : EventArgs
    {
        public T SelectedValue { get; set; }
    }

    public class GridTableSource<TResult> : UITableViewSource where TResult : class
    {
        private readonly List<TResult> _results;

        private readonly GridTable<TResult> _owner;

        private readonly Dictionary<string, GridTableColumn> _propertyColumn;

        public GridTableSource(List<TResult> results, GridTable<TResult> owner, Dictionary<string, GridTableColumn> propertyColumn)
        {
            _results = results;
            _owner = owner;
            _propertyColumn = propertyColumn;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var parameter = _results[indexPath.Row];

            _owner.OnValueSelected(new SelectedFilterEventArgs<TResult>
            {
                SelectedValue = parameter
            });

            tableView.DeselectRow(indexPath, true);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var labels = (from column in _propertyColumn
                          let txt = ControlHelpers.GetPropValue(_results[indexPath.Row], column.Key)?.ToString() ?? string.Empty
                          select new Tuple<string, int>(txt, column.Value.WidthInPercent))
               .ToList();

            var cell = tableView.DequeueReusableCell(MultiColumnCell.Id) as MultiColumnCell ??
                       new MultiColumnCell(tableView.Bounds, labels.ToArray());

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
            var cell = tableView.DequeueReusableCell("HeaderCell") as MultiColumnCell;

            if (cell != null) return cell;

            var labels =
                _propertyColumn
                    .Select(
                        gridTableColumn =>
                            new Tuple<string, int>(gridTableColumn.Value.ColumnName,
                                gridTableColumn.Value.WidthInPercent))
                    .ToList();


            return new MultiColumnCell(tableView.Bounds, labels.ToArray(), isHeader: true)
            {
                BackgroundColor = UIColor.FromRGB(247, 247, 247)
            };
        }
    }
}
