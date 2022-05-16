namespace DevTrackR.API.Entities;

public class Package
{
  public Package(string title, decimal weight)
  {
    this.Code = Guid.NewGuid().ToString();
    this.Title = title;
    this.Weight = weight;
    this.Delivered = false;
    this.PostedAt = DateTime.Now;
    this.Updates = new List<PackageUpdate>();
  }

  public int Id { get; private set; }
  public string Code { get; private set; }
  public string Title { get; private set; }
  public decimal Weight { get; private set; }
  public bool Delivered { get; private set; }
  public DateTime PostedAt { get; private set; }
  public List<PackageUpdate> Updates { get; private set; }
}