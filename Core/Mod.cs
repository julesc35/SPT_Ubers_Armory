using ModName.Models;
using ModName.Utils;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Match;
using SPTarkov.Server.Core.Models.Logging;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Models.Utils;

namespace ModName.Core;

[Injectable(TypePriority = OnLoadOrder.PreSptModLoader + 1)]
public class Mod(
    ISptLogger<Mod> logger,
    ModUtils modUtils)
    : IOnLoad
{
    public Task OnLoad()
    {
        ModConfig config = modUtils.ModConfig;

        return Task.CompletedTask;
    }
}
