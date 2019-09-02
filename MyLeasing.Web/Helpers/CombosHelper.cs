using Microsoft.AspNetCore.Mvc.Rendering;
using MyLeasing.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboLessees()
        {
            var list = _dataContext.Lessees.Select(l => new SelectListItem
            {
                Text = l.User.FullNameWithDocument,
                Value = $"{l.Id}"

            })
             .OrderBy(l => l.Text)
             .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(seleccione un incquilino)",
                Value = "0"

            });

            return list;
        }



        public IEnumerable<SelectListItem> GetComboPropertyTypes()
        {
            var list = _dataContext.PropertyTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"

            })
            .OrderBy(pt => pt.Text)
            .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(seleccione un tipo de propiedad)",
                Value = "0"

            });

            return list;
        }
    }
}
