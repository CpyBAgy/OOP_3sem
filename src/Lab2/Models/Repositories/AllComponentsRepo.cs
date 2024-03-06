namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public record AllComponentsRepo
{
    public static BiosRepo Bioses { get; } = new BiosRepo();
    public static CoolerRepo Coolers { get; } = new CoolerRepo();
    public static CpuRepo Cpus { get; } = new CpuRepo();
    public static GpuRepo Gpus { get; } = new GpuRepo();
    public static HddRepo Hdds { get; } = new HddRepo();
    public static MotherboardRepo Motherboards { get; } = new MotherboardRepo();
    public static PcCaseRepo PcCases { get; } = new PcCaseRepo();
    public static PowerSupplyRepo PowerSupplies { get; } = new PowerSupplyRepo();
    public static RamRepo Rams { get; } = new RamRepo();
    public static SsdRepo Ssds { get; } = new SsdRepo();
}