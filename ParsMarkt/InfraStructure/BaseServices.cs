using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ParsMarkt
{
    public abstract class BaseServices : object
    {
        public BaseServices(System.Net.Http.HttpClient http) : base()
        {
            JsonOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            Http = http;
            //Client.DefaultRequestHeaders

            BaseUrl = "https://localhost:44380";
            RequestUri = $"{ BaseUrl }/{ GetApiUrl() }";
        }

        protected abstract string GetApiUrl();

        protected string BaseUrl { get; set; }

        protected string RequestUri { get; set; }

        protected System.Net.Http.HttpClient Http { get; }
        //protected System.Net.Http.HttpClient Http { get; set; }

        protected System.Text.Json.JsonSerializerOptions JsonOptions { get; set; }

        protected virtual async System.Threading.Tasks.Task<O> GetAsync<O>()
        {
            System.Net.Http.HttpResponseMessage response = null;

            try
            {
                response = await Http.GetAsync(requestUri: RequestUri);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        O result = await response.Content.ReadFromJsonAsync<O>();

                        return result;
                    }
                    // When content type is not valid
                    catch (System.NotSupportedException)
                    {
                        System.Console.WriteLine("The content type is not supported.");
                    }
                    // Invalid JSON
                    catch (System.Text.Json.JsonException)
                    {
                        System.Console.WriteLine("Invalid JSON.");
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                response.Dispose();
            }

            return default;
        }

        protected virtual async System.Threading.Tasks.Task<O> GetByIdAsync<O>(int id)
        {
            var requestUrl = $"{RequestUri}/{id}";
            System.Net.Http.HttpResponseMessage response = null;

            try
            {
                response = await Http.GetAsync(requestUri: requestUrl);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        O result = await response.Content.ReadFromJsonAsync<O>();

                        return result;
                    }
                    // When content type is not valid
                    catch (System.NotSupportedException)
                    {
                        System.Console.WriteLine("The content type is not supported.");
                    }
                    // Invalid JSON
                    catch (System.Text.Json.JsonException)
                    {
                        System.Console.WriteLine("Invalid JSON.");
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                response.Dispose();
            }

            return default;
        }
        protected virtual async System.Threading.Tasks.Task<O> PostAsync<I, O>(I viewModel)
        {
            System.Net.Http.HttpResponseMessage response = null;

            try
            {
               // var content = new StringContent(JsonSerializer.Serialize(viewModel), Encoding.UTF8, "application/json");
              // response = await Http.PostAsync(RequestUri, content);
                 response = await Http.PostAsJsonAsync(RequestUri, viewModel);

                //response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        //System.Text.Json.JsonSerializerOptions jsonSerializerOptions =
                        //	new System.Text.Json.JsonSerializerOptions
                        //	{
                        //		MaxDepth = 5,
                        //	};

                        //O result =
                        //	await response.Content.ReadFromJsonAsync<O>(options: jsonSerializerOptions);



                        // New Solution
                        O result = await response.Content.ReadFromJsonAsync<O>();

                        return result;
                        // /New Solution

                        // Old Solution
                        //string data =
                        //	await response.Content.ReadAsStringAsync();

                        //O result =
                        //	System.Text.Json.JsonSerializer.Deserialize<O>(data);
                        // /Old Solution
                    }
                    // When content type is not valid
                    catch (System.NotSupportedException)
                    {
                        System.Console.WriteLine("The content type is not supported.");
                    }
                    // Invalid JSON
                    catch (System.Text.Json.JsonException)
                    {
                        System.Console.WriteLine("Invalid JSON.");
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
             {
                response.Dispose();
                //response = null;
            }

            return default;
        }

        protected virtual async System.Threading.Tasks.Task<O> PutAsync<I, O>(I viewModel)
        {
            System.Net.Http.HttpResponseMessage response = null;

            try
            {
                //var content = new StringContent(JsonSerializer.Serialize(viewModel), Encoding.UTF8, "application/json");
                response = await Http.PutAsJsonAsync(requestUri: RequestUri, viewModel);
                // response = await Http.PutAsync(RequestUri, content);

                // response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        O result = await response.Content.ReadFromJsonAsync<O>();

                        return result;
                    }
                    // When content type is not valid
                    catch (System.NotSupportedException)
                    {
                        System.Console.WriteLine("The content type is not supported.");
                    }
                    // Invalid JSON
                    catch (System.Text.Json.JsonException)
                    {
                        System.Console.WriteLine("Invalid JSON.");
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                response.Dispose();
            }

            return default;
        }

        protected virtual async System.Threading.Tasks.Task<O> DeleteAsync<O>(int id)
        {
            string uri = $"{RequestUri}/{id}";
           
           HttpResponseMessage response = null;

            try
            {
                response = await Http.DeleteAsync(requestUri: uri);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        O result = await response.Content.ReadFromJsonAsync<O>();

                        return result;
                    }
                    // When content type is not valid
                    catch (System.NotSupportedException)
                    {
                        System.Console.WriteLine("The content type is not supported.");
                    }
                    // Invalid JSON
                    catch (System.Text.Json.JsonException)
                    {
                        System.Console.WriteLine("Invalid JSON.");
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                response.Dispose();
            }

            return default;
        }
    }
}
