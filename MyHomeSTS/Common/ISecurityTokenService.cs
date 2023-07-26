using System.ServiceModel.Channels;
using System.ServiceModel;

namespace My_STS
{
    [ServiceContract(Name = "SecurityTokenService", Namespace = "http://tempuri.org")]
    public interface ISecurityTokenService
    {
        [OperationContract(Action = Constants.Trust.Actions.Issue,
                           ReplyAction = Constants.Trust.Actions.IssueReply)]
        Message ProcessRequestSecurityToken(Message message);
    }
}
