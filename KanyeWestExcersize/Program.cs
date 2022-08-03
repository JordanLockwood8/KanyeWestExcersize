using Newtonsoft.Json.Linq;

//Kanye
var client = new HttpClient();
var kanyeUrl = "https://api.kanye.rest";
var response = client.GetStringAsync(kanyeUrl).Result;
var kanyeQuote = JObject.Parse(response).GetValue("quote").ToString();
//Console.WriteLine(kanyeQuote);
//Ron
var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
var response2 = client.GetStringAsync(ronUrl).Result;
var ronQuote = JArray.Parse(response2).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
//Console.WriteLine(ronQuote);
for (int i = 0; i < 6; i++)
{
    response = client.GetStringAsync(kanyeUrl).Result;
    kanyeQuote = JObject.Parse(response).GetValue("quote").ToString();
    Console.WriteLine($"Kanye: {kanyeQuote}");
    
    Thread.Sleep(1000);
    response2 = client.GetStringAsync(ronUrl).Result;
    ronQuote = JArray.Parse(response2).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
    Console.WriteLine($"Ron: {ronQuote}");
    Thread.Sleep(2000);
    Console.WriteLine();
}