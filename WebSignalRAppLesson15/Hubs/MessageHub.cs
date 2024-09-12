using Microsoft.AspNetCore.SignalR;
using WebSignalRAppLesson15.Helpers;

namespace WebSignalRAppLesson15.Hubs;
public class MessageHub : Hub
{
    public async override Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("ReceiveConnectInfo","User Connected !");
    }

    public async override Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.Others.SendAsync("ReceiveDisconnectInfo", "User Disconnected !");
    }

    public async Task SendMessage(string userUsername)
    {
        // parameters after function name : 
        await Clients.All.SendAsync("ReceiveMessage",userUsername + " 's offer : ",FileHelper.Read());
    }

    public async Task ShowTimer(int seconds)
    {
        // showing timer for all users (10 second) :
        await Clients.All.SendAsync("ReceiveTimerSeconds",seconds);

        // disabling button for caller : 
        await Clients.Caller.SendAsync("DisableButton",seconds);
    }

    public async Task ShowWinner(string winnerUsername)
    {
        // showing winner in hub : 
        await Clients.All.SendAsync("ShowWinnerForOthers", winnerUsername );
        // await Clients.Caller.SendAsync("ShowWinnerForCaller");
    }
}
