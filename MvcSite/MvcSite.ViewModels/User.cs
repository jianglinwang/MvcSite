using MvcSite.Core.Attribute;

namespace MvcSite.ViewModels
{
    [GlobalResource(ClassKey="Website")]
    public class User
    {
        [GlobalResource(ResourceKey = "USER_NAME")]
        public string UserName { get; set; }
    }
}
