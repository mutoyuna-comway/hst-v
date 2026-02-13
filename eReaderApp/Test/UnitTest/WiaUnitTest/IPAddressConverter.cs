using Newtonsoft.Json;
using System;
using System.Net;

public class IPAddressConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        // IPAddress型ならこのコンバーターを使う
        return objectType == typeof(IPAddress) ;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        // 書き込むときは文字列にする ("192.168.0.1" など)
        IPAddress ip = (IPAddress)value;
        writer.WriteValue(ip?.ToString());
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        // 読み込むときは文字列からIPAddress型に戻す
        if (reader.TokenType == JsonToken.Null) return null;

        string ipString = (string)reader.Value;
        return IPAddress.Parse(ipString);
    }
}