using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grs.BioRestock.Transfer.Requests.Identity;
using Grs.BioRestock.Transfer.Responses.Identity;

namespace Grs.BioRestock.Client.Pages.Identity
{
    public partial class EditUserModal
    {
        //private FluentValidationValidator _fluentValidationValidator;

        //private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
        private readonly UpdateUserRequest _editUserModel = new();

        private UserResponse user = new();

        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        [Parameter] public string userId { get; set; }
        private string UserName { get; set; }
        private string Email { get; set; }


        private void Cancel()
        {
            MudDialog.Cancel();
        }

        protected override async Task OnInitializedAsync()
        {
            await GetUser();
        }

        private async Task GetUser()
        {
            var response = await _userManager.GetAsync(userId);
            if (response.Succeeded)
            {
                user = response.Data;
                _editUserModel.Id = user.Id;
                UserName = user.UserName;
                Email = user.Email;
            }
            else
            {
                foreach (var m in response.Messages)
                {
                    _snackBar.Add(m, Severity.Error);
                }
            }
        }


        private async Task SubmitAsync()
        {
            //_registerUserModel.EmployeeID = employee.EmployeeID;
            //_registerUserModel.SiteID = site.SiteID;
            var response = await _userManager.UpdateUserAsync(_editUserModel);
            if (response.Succeeded)
            {
                _snackBar.Add("Utilisateur Mis a jour !", Severity.Success);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }
    }
}