using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using UiTableGrid.TwoColumns;
using UIKit;

namespace UiTableGrid
{
    public class PersonsViewController : UIViewController
    {
        public Person Selected { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var searchBar = new UISearchBar
            {
                Placeholder = "enter search text"
            };

            searchBar.SizeToFit();
            searchBar.AutocorrectionType = UITextAutocorrectionType.No;
            searchBar.AutocapitalizationType = UITextAutocapitalizationType.None;

            var results = Person.GetPersons();

            var table = new UITableView(View.Bounds, UITableViewStyle.Grouped)
            {
                AutoresizingMask = UIViewAutoresizing.All,
                Source = new TableSourcePerson(results, this),
                TableHeaderView = searchBar
            };

            Observable.FromEventPattern<UISearchBarTextChangedEventArgs>(searchBar, "TextChanged")
                .Throttle(TimeSpan.FromSeconds(0.750))
                .Select(x => x.EventArgs.SearchText.ToLowerInvariant())
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(text =>
                {
                    results =
                        results
                            .Where(t =>
                                t.Name.ToLowerInvariant().Contains(text)
                                || t.Age.ToString().Contains(text))
                            .ToList();
                    table.Source = new TableSourcePerson(results, this);
                    table.ReloadData();
                });

            Add(table);
        }
    }
}