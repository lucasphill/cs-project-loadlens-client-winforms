namespace LoadLens.Client.Models.DTOs;

public class CreateCPUDatalogDTO
{
    public string? HardwareName { get; set; }
    public float LoadCPUTotal { get; set; }
    public float TempCoreMax { get; set; }
    public float TempCoreAvg { get; set; }
}
