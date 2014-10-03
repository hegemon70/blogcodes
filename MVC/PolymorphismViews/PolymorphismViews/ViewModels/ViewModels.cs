using System;

namespace PolymorphismViews.ViewModels
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }
    }

    public class FooViewModel : BaseViewModel
    {
        public string Foo { get; set; }
    }
}