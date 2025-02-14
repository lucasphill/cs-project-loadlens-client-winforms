using System.Text.Json;

namespace LoadLens.Client.Services;

internal class FilesService
{
    private string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LoadLens");

    public void SaveLocalFile(string value, string fileName)
    {
        string filePath = Path.Combine(folderPath, fileName);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        File.WriteAllText(filePath, value);
    }

    public void AppendLocalFile(string value, string fileName)
    {
        string filePath = Path.Combine(folderPath, fileName);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        File.AppendAllText(filePath, value);
    }

    public string GetLocalFileData(string fileName)
    {
        string filePath = Path.Combine(folderPath, fileName);

        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            return data;
        }
        else
        {
            return "";
        }
    }

    public bool DeleteLocalFile(string fileName)
    {
        string filePath = Path.Combine(folderPath, fileName);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AppendToJsonFile(string value, string fileName)
    {
        string filePath = Path.Combine(folderPath, fileName);

        List<object> dataList;

        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            dataList = JsonSerializer.Deserialize<List<object>>(jsonContent);
        }
        else
        {
            dataList = new List<object>();
        }

        // Adicionar o novo objeto à lista
        dataList.Add(value);

        // Serializar a lista atualizada para JSON com indentação
        //var options = new JsonSerializerOptions
        //{
        //    WriteIndented = true // Ativa a indentação
        //};
        string updatedJson = JsonSerializer.Serialize(dataList);

        // Escrever o JSON atualizado de volta no arquivo
        //File.AppendAllText(filePath, value);
        File.WriteAllText(filePath, updatedJson);
    }
}
