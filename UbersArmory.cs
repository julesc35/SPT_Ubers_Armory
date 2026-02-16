using System.Reflection;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Mod;
using WTTServerCommonLib;
using Range = SemanticVersioning.Range;

namespace UbersArmory;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.Uberpony.UbersArmory";
    public override string Name { get; init; } = "Uber's Armory";
    public override string Author { get; init; } = "Uberpony";
    public override SemanticVersioning.Version Version { get; init; } = new("1.0.0");
    public override Range SptVersion { get; init; } = new("~4.0.12");
    public override string License { get; init; } = "MIT";
    public override bool? IsBundleMod { get; init; } = false;
    public override Dictionary<string, Range>? ModDependencies { get; init; } = new()
    {
        { "com.wtt.commonlib", new Range("~2.0.0") }
    };
    public override string? Url { get; init; }
    public override List<string>? Contributors { get; init; }
    public override List<string>? Incompatibilities { get; init; }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 2)]
public class UbersArmory(
    WTTServerCommonLib.WTTServerCommonLib wttCommon
) : IOnLoad
{
    public async Task OnLoad()
    {

        // Get your current assembly
        var assembly = Assembly.GetExecutingAssembly();


        // Use WTT-CommonLib services
        await wttCommon.CustomItemServiceExtended.CreateCustomItems(assembly, Path.Join("db", "CustomItems"));
        await wttCommon.CustomBuffService.CreateCustomBuffs(assembly, Path.Join( "db", "CustomBuffs"));

        await Task.CompletedTask;
    }
}