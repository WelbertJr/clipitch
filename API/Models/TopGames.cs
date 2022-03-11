using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models
{
  public class TopGames
  {
    [JsonPropertyName("data")]
    public List<Game> Data { get; set; }

    [JsonPropertyName("pagination")]
    public Pagination Pagination { get; set; }
  }
}