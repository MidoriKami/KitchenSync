﻿using Dalamud.Plugin;
using KitchenSync.Data;
using KitchenSync.System;

namespace KitchenSync;

public sealed class KitchenSyncPlugin : IDalamudPlugin
{
    public string Name => "KitchenSync";

    public KitchenSyncPlugin(DalamudPluginInterface pluginInterface)
    {
        pluginInterface.Create<Service>();
        
        Service.Configuration = pluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Service.Configuration.Initialize(pluginInterface);

        Service.DutyEventManager = new DutyEventManager();
        Service.FateEventManager = new FateEventManager();
        Service.IconManager = new IconManager();
        Service.WindowManager = new WindowManager();
        Service.CommandSystem = new CommandManager();
        Service.HotbarManager = new HotbarManager();
    }

    public void Dispose()
    {
        Service.DutyEventManager.Dispose();
        Service.FateEventManager.Dispose();
        Service.IconManager.Dispose();
        Service.PlayerEventManager.Dispose();

        Service.WindowManager.Dispose();
        Service.CommandSystem.Dispose();
        Service.HotbarManager.Dispose();
    }
}