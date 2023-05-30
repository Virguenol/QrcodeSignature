using Grs.BioRestock.Shared.Wrapper;
using Grs.BioRestock.Transfer.DataModels.Article;
using Grs.BioRestock.Transfer.DataModels.BonDeRetourDtos;
using Grs.BioRestock.Transfer.DataModels.Client;
using Grs.BioRestock.Transfer.DataModels.Demandesignature;
using System;
using System.Collections.Generic;

namespace Grs.BioRestock.Client.Infrastructure.ApiClients
{
    public partial class BooleanIResult : Result<bool>
    {
    }

    public partial class BooleanResult : Result<bool>
    {
    }

    public partial class Int32Result : Result<Int32>
    {
    }

    public partial class Int32IResult : Result<Int32>
    {
    }

    public partial class StringResult : Result<string>
    {
    }

    public partial class StringIResult : Result<string>
    {
    }

    public partial class StringListIResult : Result<List<string>>
    {
    }
    public partial class GetBonDeRetourDtoListResult : Result<List<GetBonDeRetourDto>>
    {
    }
    public partial class GetBonDeRetourDtoResult : Result<GetBonDeRetourDto>
    {
    }
    public partial class GetArticleDtoListResult : Result<GetArticleDto>
    {
    }
    public partial class CustomerListResult : Result<AddCustomerDto>
    {
    }

    public partial class DemandeSingatureDtoListResult : Result<List<DemandeSingatureDto>>
    {
    }

    public partial class DemandeSingatureDtoResult : Result<DemandeSingatureDto>
    {
    }
}