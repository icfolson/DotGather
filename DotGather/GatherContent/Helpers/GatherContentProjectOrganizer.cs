using DotGather.GatherContent.Objects;
using DotGather.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotGather.GatherContent.Helpers
{
    /// <summary>
    /// A helper class used to organize a Project's Pages through the Parent/Child relationship.
    /// </summary>
    public static class GatherContentProjectOrganizer
    {
        /// <summary>
        /// Organizes the given Pages by enforcing the Parent/Child relationship contained within each Page.
        /// </summary>
        /// <param name="pages">The Pages to be organized</param>
        /// <returns>An organized Pages object</returns>
        /// <seealso cref="Pages"/>
        /// <seealso cref="IPage"/>
        public static IEnumerable<IPage> OrganizeProject(Pages pages)
        {
            var organizedPages = pages.Where(x => x.ParentId.Equals(0));

            Parallel.ForEach(organizedPages, (currentPage) => 
            {
                currentPage.Children = AddPages(currentPage, pages);
            });

            return organizedPages;
        }

        private static IEnumerable<IPage> AddPages(IPage organizedPage, Pages pages)
        {
            var childPages = pages.AsParallel().Where(x => x.ParentId.Equals(organizedPage.Id));

            Parallel.ForEach(childPages, (currentPage) => 
            {
                currentPage.Children = AddPages(currentPage, pages);
            });

            return childPages;
        }
    }
}
