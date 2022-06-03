using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorTextarea
{
    public class JsInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JsInterop(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/BlazorTextarea/jsInteropBlazorTextarea.js").AsTask());
        }

        internal async Task Init<T>(T objRef, ElementReference elementReference, int updateBatchCount, string eventName)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("init", objRef, elementReference, updateBatchCount, eventName);
        }

        internal async Task SetText(ElementReference elementReference, string text)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("setText", elementReference, text);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}