using Microsoft.JSInterop;

namespace RedSocial.Client.Auth
{
    public static class IJSRuntimeExtensionMethods
    {

        public static ValueTask<object> GuardarEnLocalStorage(this IJSRuntime js,
            string llave, string contenido)
        {
            return js.InvokeAsync<object>("localStorage.setItem", llave, contenido);
        }

        public static ValueTask<object> ObtenerDeLocalStorage(this IJSRuntime js,
            string llave)
        {
            return js.InvokeAsync<object>("localStorage.getItem", llave);
        }

        public static ValueTask<object> RemoverDelLocalStorage(this IJSRuntime js,
            string llave)
        {
            return js.InvokeAsync<object>("localStorage.removeItem", llave);
        }
    }
}
