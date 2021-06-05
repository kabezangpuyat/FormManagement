using QMS.Domain.Models.Campaign;

namespace QMS.Domain.Models.Responses.Campaign
{
    public class GetCampaignByIdResponse : ICommandQueryResponse
    {
        public CampaignViewModel Campaign { get; set; }
    }
}
