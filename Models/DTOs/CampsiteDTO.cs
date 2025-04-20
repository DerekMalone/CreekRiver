namespace CreekRiver.Models.DTOs;

public class CampsiteDTO
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    public string ImageUrl { get; set; }
    public int CampsiteTypeId { get; set; }
    public CampsiteType CampsiteType { get; set; }
    public List<Reservation> Reservations { get; set; }
}