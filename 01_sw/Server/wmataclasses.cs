using System.Net.Sockets;

namespace wmata
{
public enum LineCd { RD, GR, YL, BL, OR, SV }
public enum Service { Normal, NoPassengers, Special, Unknown }

public class Train
{
    public int TrainId { get; set; }
    public int TrainNumber { get; set; }
    public int CarCount { get; set; }
    public int DirectionNum { get; set; }
    public int CircuitId { get; set; }
    public string DestinationStationCode { get; set; }
    public LineCd LineCode { get; set; }
    public int SecondsAtLocation { get; set; }
    public Service Service { get; set; }
}

public class StandardRoute
{
    public LineCd LineCode { get; set; }
    public int TrackNum { get; set; }
    public TrackCircuit[] TrackCircuits { get; set; }
}

public class TrackCircuit
{
    public int SeqNum { get; set; }
    public int CircuitId { get; set; }
    public string? StationCode { get; set; }
}
public class RawStation
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string? StationTogether1 { get; set; }
    public string? StationTogether2 { get; set; }
    public LineCd? LineCode1 { get; set; }
    public LineCd? LineCode2 { get; set; }
    public LineCd? LineCode3 { get; set; }
    public LineCd? LineCode4 { get; set; }
    public double Lat { get; set; }
    public double Long {get; set; }
    public Address Address {get; set; }
}

public class Address
{
    public String Street { get; set; }
    public String City { get; set; }
    public String State { get; set; }
    public String Zip { get; set; }
}
}