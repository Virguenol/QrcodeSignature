using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;

namespace Grs.BioRestock.Shared.Wrapper
{
    public class PaginatedResult<T> : IResult
    {
        public List<T> Data { get; set; }

        internal PaginatedResult(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10)
        {
            Data = data;
            CurrentPage = page;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }

        public PaginatedResult()
        {
            Data = default;
        }

        public static PaginatedResult<T> Fail(List<string> messages)
        {
            return new PaginatedResult<T>(false, default, messages);
        }

        public static PaginatedResult<T> Fail(string eMessage)
        {
            return new PaginatedResult<T>(false, default, new List<string> { eMessage });
        }

        public static Task<PaginatedResult<T>> FailAsync(string message) => Task.FromResult(Fail(message));

        public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new PaginatedResult<T>(true, data, null, count, page, pageSize);
        }

        public static PaginatedResult<T> GetPaginatedResult(IQueryable<object> query, int page, int pageSize)
        {
            var result = new PaginatedResult<T>
            {
                Succeeded = true,
                CurrentPage = page,
                PageSize = pageSize,
                TotalCount = query.Count()
            };


            var pageCount = (double)result.TotalCount / pageSize;
            result.TotalPages = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            if (skip > result.TotalCount)
            {
                skip = 0;
                result.CurrentPage = 1;
            }

            result.Data = query.Skip(skip).Take(pageSize).ToList().Adapt<List<T>>();

            return result;
        }


        public static Task<PaginatedResult<T>> SuccessAsync(List<T> data, int count, int page, int pageSize) => Task.FromResult(Success(data, count, page, pageSize));

        public List<string> Messages { get; set; }
        public bool Succeeded { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;
    }
}