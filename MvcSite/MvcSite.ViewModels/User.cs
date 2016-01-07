using MvcSite.Core.Attribute;

namespace MvcSite.ViewModels
{
    [GlobalResource(ClassKey="Website")]
    public class User
    {
        [GlobalResource(ResourceKey="UserName")]
        public string UserName { get; set; }
    }
}
