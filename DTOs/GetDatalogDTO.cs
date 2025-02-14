namespace LoadLens.API.DTOs.DatalogDTO;

public class GetDatalogDTO
{
    public Guid Id { get; set; }

    public Dictionary<string, object>? CpuJson { get; set; }

    public Guid ComputerId { get; set; }

    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
}
