using NotenManager.Model;
using System.Collections.Generic;

namespace NotenManager.Repository
{
    public class BreadcrumbRepository
    {
        public List<BreadcrumbModel> Breadcrumbs { get; private set; } = new List<BreadcrumbModel>();

        public void SetBreadcrumb(List<BreadcrumbModel> breadcrumbs)
        {
            Breadcrumbs = breadcrumbs;
        }
    }
}
