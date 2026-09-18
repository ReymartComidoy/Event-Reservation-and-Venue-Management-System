using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_Reservation_and_Venue_Management_System.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Panel _container;
        private readonly Dictionary<ViewModule, UserControl> _views;

        public NavigationService(Panel container, Dictionary<ViewModule, UserControl> views)
        {
            _container = container;
            _views = views;
        }

        public void NavigateTo(ViewModule module)
        {
            if (!_views.ContainsKey(module)) return;

            _container.Controls.Clear();
            UserControl selectedView = _views[module];
            selectedView.Dock = DockStyle.Fill;
            _container.Controls.Add(selectedView);
            selectedView.BringToFront();
        }
    }
}
