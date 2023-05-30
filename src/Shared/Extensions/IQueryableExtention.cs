using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grs.BioRestock.Shared.Wrapper;

namespace Grs.BioRestock.Shared.Extensions
{
	public static class IQueryableExtention
	{
		public static List<T> ToPageListe<T>(IQueryable<T> query, int page, int pageSize)
		{
			var TotalCount = query.Count();


			var pageCount = (double)TotalCount / pageSize;
			var TotalPages = (int)Math.Ceiling(pageCount);

			var skip = (page - 1) * pageSize;
			return query.Skip(skip).Take(pageSize).ToList();
		}
	}
}