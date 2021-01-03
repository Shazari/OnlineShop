using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParsMarkt
{
    public static class JsRuntimeExtensionMethod
    {
        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content) =>
            js.InvokeAsync<object>("localStorage.setItem", key, content);

        public static ValueTask<object> SetInLocalStorage<T>(this IJSRuntime js, string key, T content) =>
            js.InvokeAsync<object>("localStorage.setItem", key, content);

        public static ValueTask<object> GetInLocalStorage(this IJSRuntime js, string key) =>
            js.InvokeAsync<object>("localStorage.getItem", key);

        public static ValueTask<object> RemoveInLocalStorage(this IJSRuntime js, string key) =>
            js.InvokeAsync<object>("localStorage.removeItem", key);

    }
}
