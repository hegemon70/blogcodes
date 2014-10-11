using Microsoft.WindowsAzure.MobileServices;

namespace Client
{
    public class TodoItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool Complete { get; set; }

        [Version]
        public string Version { get; set; }
    }
}