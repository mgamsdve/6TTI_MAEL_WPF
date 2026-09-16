using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using OpenSilver.WebAssembly;

namespace App1.Browser.Pages;

[Route("/")]
public class Index : ComponentBase
{
    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await Runner.RunApplicationAsync<App1.App>();
    }
}
