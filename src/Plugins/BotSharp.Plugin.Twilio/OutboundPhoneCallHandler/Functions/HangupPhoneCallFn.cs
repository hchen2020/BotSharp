using BotSharp.Plugin.Twilio.OutboundPhoneCallHandler.LlmContexts;
using Twilio.Rest.Api.V2010.Account;

namespace BotSharp.Plugin.Twilio.OutboundPhoneCallHandler.Functions;

public class HangupPhoneCallFn : IFunctionCallback
{
    private readonly IServiceProvider _services;
    private readonly ILogger<HangupPhoneCallFn> _logger;

    public string Name => "util-twilio-hangup_phone_call";
    public string Indication => "Hangup";

    public HangupPhoneCallFn(
        IServiceProvider services,
        ILogger<HangupPhoneCallFn> logger)
    {
        _services = services;
        _logger = logger;
    }

    public async Task<bool> Execute(RoleDialogModel message)
    {
        var args = JsonSerializer.Deserialize<LlmContextIn>(message.FunctionArgs);
        // Have to find the SID by the phone number
        var call = CallResource.Update(
            status: CallResource.UpdateStatusEnum.Completed,
            pathSid: args.CallSid
        );

        message.Content = "The call has ended.";

        return true;
    }
}
