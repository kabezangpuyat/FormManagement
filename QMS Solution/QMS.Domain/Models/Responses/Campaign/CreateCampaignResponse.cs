using QMS.Domain.Models.Campaign;

namespace QMS.Domain.Models.Responses.Campaign
{
    public class CreateCampaignResponse : ICommandQueryResponse
    {
        public CreateCampaignResponse(CampaignViewModel campaign)
        {
            Campaign = campaign;
        }
        public CreateCampaignResponse(CampaignViewModel campaign, string message, bool? success)
        {
            Campaign = campaign;
            Message = message;
            Success = success;
        }
        public CampaignViewModel Campaign { get; set; }
        public bool? Success { get; set; }
        public string Message { get; set; }
    }
}
