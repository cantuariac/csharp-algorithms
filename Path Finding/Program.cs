
using PathFinding;
using System.Text.Json;



GridMap map;
using (var reader = new StreamReader("./test_map.json"))
{
    map = JsonSerializer.Deserialize<GridMap>(reader.ReadToEnd());
    reader.Close();
    map.Print();
}

//var map = new GridMap(50, 50);

//for (int i = 0; i < map.Dimensions.Length; i++)
//{
//    for (int j = 0; j < map.Dimensions.Width; j++)
//    {
//        map.Height[i * map.Dimensions.Length + j] = (short)1;
//    }
//}

//using (var writer = new StreamWriter("./test_map.json"))
//{
//    string jsonString = JsonSerializer.Serialize(map, new JsonSerializerOptions { WriteIndented = true });

//    writer.Write(jsonString);
//    writer.Close();

//}


