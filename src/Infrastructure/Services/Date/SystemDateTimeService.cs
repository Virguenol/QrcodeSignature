using Grs.BioRestock.Application.Interfaces.Services;
using System;

namespace Grs.BioRestock.Infrastructure.Services.Date
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}