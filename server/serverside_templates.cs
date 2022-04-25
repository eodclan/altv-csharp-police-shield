// 1. added this usings:

using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;


// 2. Serverside events

[AsyncClientEvent("Server:Shield:giveShield")]
public static async Task GiveShield_Event(IPlayer player)
{
    try
    {
        if (player == null || !player.Exists) return;
        bool shieldstate = true;
        int istate = shieldstate ? 1 : 0;
        player.SetStreamSyncedMetaData("shield", istate);
        player.SetStreamSyncedMetaData("shieldstatus", istate);
    }
    catch (Exception e)
    {

        Console.WriteLine($"{e}");
    }
}

[AsyncClientEvent("Server:Shield:shieldUp")]
public static async Task GiveShieldCheckUp_Event(IPlayer player)
{
    try
    {
        if (player == null || !player.Exists) return;
        if (!player.HasData("shield"))
        {
            player.SetStreamSyncedMetaData("shieldStatus", true);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"{e}");
    }
}

[AsyncClientEvent("Server:Shield:shieldDown")]
public static async Task GiveShieldCheckDown_Event(IPlayer player)
{
    try
    {
        if (player == null || !player.Exists) return;
        if (!player.HasData("shield"))
        {
            player.SetStreamSyncedMetaData("shieldStatus", false);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"{e}");
    }
}

[AsyncClientEvent("Server:Shield:removeShield")]
public async Task RemoveShield_Event(IPlayer player)
{
    try
    {
        if (player == null || !player.Exists) return;
        player.DeleteStreamSyncedMetaData("shield");
        player.DeleteStreamSyncedMetaData("shieldstatus");
    }
    catch (Exception e)
    {
        Console.WriteLine($"{e}");
    }
}	