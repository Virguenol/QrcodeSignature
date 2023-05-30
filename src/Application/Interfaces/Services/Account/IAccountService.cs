﻿using Grs.BioRestock.Application.Interfaces.Common;
using Grs.BioRestock.Shared.Wrapper;
using System.Threading.Tasks;
using Grs.BioRestock.Transfer.Requests.Identity;

namespace Grs.BioRestock.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}