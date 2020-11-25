using LoginWithMVVM.Model;
using System.Collections.Generic;

namespace LoginWithMVVM.ViewModel
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            this.MenuOptionList = new List<MenuOption>()
            {
                new MenuOption { Title = "Bar & Hotels", Image = "beer.png" },
                new MenuOption { Title = "Fine Dining", Image = "Waiter.png" },
                new MenuOption { Title = "Cafes", Image = "cafe.png" },
                new MenuOption { Title = "Nearby", Image = "nearby.png" },
                new MenuOption { Title = "Fast food", Image = "Food.png" },
                new MenuOption { Title = "Featured food", Image = "pizza.png" }
            };
            
        }

        public List<MenuOption> MenuOptionList { get; set; }

        
    }
}
