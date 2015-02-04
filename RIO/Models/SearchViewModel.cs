using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    public class SearchViewModel
    {

        #region Public Properties 

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Item> Items { get; set; }

        #endregion

    }
}