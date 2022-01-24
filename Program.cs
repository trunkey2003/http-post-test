using System.Net.Http;

namespace JSONEx
{
    class Program
    {
        public static async Task<string> GetWebContent(string url)
        {
            try{
            var httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.GetAsync(url);
            var html = await res.Content.ReadAsStringAsync();
            return html;
            } catch (Exception e){
                Console.WriteLine(e);
                return "Loi";
            }
        }
        static async Task Main()
        {
            var url = "http://localhost:5000/api/QuanLyNguoiDung/DangNhap";
            var httpClient = new HttpClient(); 
            var httpResquestMessage = new HttpRequestMessage();
            httpResquestMessage.Method = HttpMethod.Post;
            httpResquestMessage.RequestUri = new Uri(url);
            httpResquestMessage.Headers.Add("User-Agent", "Mozilla/5.0");
            var parameters = new List<KeyValuePair<string,string>>();
            parameters.Add(new KeyValuePair<string,string>("taiKhoan", ""));
            parameters.Add(new KeyValuePair<string,string>("matKhau", ""));
            httpResquestMessage.Content = new FormUrlEncodedContent(parameters);
            var res = await httpClient.SendAsync(httpResquestMessage);
            var html = await res.Content.ReadAsStringAsync();
            Console.WriteLine(html);
        }
    }
}