namespace BotSharp.Plugin.WebDriver.Drivers.PlaywrightDriver;

public partial class PlaywrightWebDriver
{
    public async Task<BrowserActionResult> ActionOnElement(MessageInfo message, ElementLocatingArgs location, ElementActionArgs action)
    {
        await _instance.Wait(message.ContextId, waitNetworkIdle: false);
        var result = await LocateElement(message, location);
        if (result.IsSuccess)
        {
            await DoAction(message, action, result);
            result.UrlAfterAction = _instance.GetPage(message.ContextId)?.Url;
        }
        return result;
    }
}
