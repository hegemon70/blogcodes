using System.Collections.Generic;
using UIKit;
using Foundation;
using UiTableGrid.GridTableControl;


namespace UiTableGrid
{
    [Register("PersonsCountryViewController")]
    public class PersonsCountryViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var results = Person.GetPersons();

            Person template;

            var columns = new Dictionary<string, GridTableColumn>
            {
                [nameof(template.Name)] = new GridTableColumn
                {
                    ColumnName = "Nombre",
                    WidthInPercent = 40
                },
                [nameof(template.Country)] = new GridTableColumn
                {
                    ColumnName = "País",
                    WidthInPercent = 40
                },
                [nameof(template.Age)] = new GridTableColumn
                {
                    ColumnName = "Edad",
                    WidthInPercent = 20
                }
            };

            var table = new GridTable<Person>(results, View.Bounds, columns);

            Add(table.Build());
        }
    }
}