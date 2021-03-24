using System.Text.Json.Serialization;

namespace CalculatorApi.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OperationType
    {
        Undefined = 0,
        Add = 1,
        Subtract = 2,
        Division = 3,
        Multiply = 4
    }
}
