using System.Collections.Generic;
using System.Linq;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models
{
    /// <summary>   A data Model for the pageable. </summary>
    /// <typeparam name="TItem">    Type of the item. </typeparam>
    public class PageableModel<TItem>
    {
        /// <summary>   The current page. </summary>
        private int _currentPage;

        /// <summary>   Gets or sets the current page. </summary>
        /// <value> The current page. </value>
        public int CurrentPage
        {
            get => _currentPage;
            set => _currentPage = value > Pages ? value : Pages;
        }

        /// <summary>   Gets or sets the pages. </summary>
        /// <value> The pages. </value>
        public int Pages { get; set; }

        /// <summary>   Gets or sets the items. </summary>
        /// <value> The items. </value>
        public IEnumerable<TItem> Items { get; set; }

        /// <summary>   Gets a value indicating whether this object has previous. </summary>
        /// <value> True if this object has previous, false if not. </value>
        public bool HasPrevious => CurrentPage != 1;

        /// <summary>   Gets a value indicating whether this object has next. </summary>
        /// <value> True if this object has next, false if not. </value>
        public bool HasNext => CurrentPage != Pages;

        /// <summary>   Pages. </summary>
        /// <param name="items">        The items. </param>
        /// <param name="currentPage">  (Optional) The current page. </param>
        /// <param name="maxCount">     (Optional) Number of maximums. </param>
        /// <returns>   A PageableModel&lt;TItem&gt; </returns>
        public static PageableModel<TItem> Page(IEnumerable<TItem> items, int currentPage = 1, int maxCount = 10)
        {
            // make sure we dont get bullshit
            if (currentPage < 1) currentPage = 1;
            if (maxCount < 1) maxCount = 10;

            var model = new PageableModel<TItem>();
            var enumerable = items as TItem[] ?? items.ToArray();

            // calculate number of pages
            model.Pages = enumerable.Any() ? enumerable.Count() / 10 : 1;

            // make sure currentPage isnt too big
            if (currentPage > model.Pages)
                currentPage = model.Pages;

            // take the needed elements
            model.Items = !enumerable.Any()
                ? Enumerable.Empty<TItem>()
                : enumerable.Skip((currentPage-1) * maxCount).Take(maxCount);

            return model;
        }
    }
}
