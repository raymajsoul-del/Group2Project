using RoleMenuDemo.Models;

namespace RoleMenuDemo.Services
{
    public class MenuService
    {
        private readonly List<MenuItem> _items = new()
        {
            new MenuItem{ Title = "Home", Url = "/", Icon = "home", AllowedRoles = new[]{ "Admin", "Accountant", "Inventory", "Purchase" } },
            new MenuItem{ Title = "POS", Url = "/POS", Icon = "cart", AllowedRoles = new[]{ "Admin" } },
            new MenuItem{ Title = "Inventory", Url = "/Inventory", Icon = "box", AllowedRoles = new[]{ "Admin", "Inventory", "Accountant" } },
            new MenuItem{ Title = "Purchase", Url = "/Purchase", Icon = "briefcase", AllowedRoles = new[]{ "Admin", "Purchase", "Accountant" } },
            new MenuItem{ Title = "Shipping", Url = "/Shipping", Icon = "truck", AllowedRoles = new[]{ "Admin" , "Inventory" } },
            new MenuItem{ Title = "Accounting", Url = "/Accounting", Icon = "chart", AllowedRoles = new[]{ "Admin", "Accountant" } },
            new MenuItem{ Title = "User", Url = "/User", Icon = "users", AllowedRoles = new[]{ "Admin" } }
        };

        public IEnumerable<MenuItem> GetMenuForRoles(IEnumerable<string> roles)
        {
            var roleSet = new HashSet<string>(roles);
            return _items.Where(i => i.AllowedRoles.Any(r => roleSet.Contains(r)));
        }
    }
}
