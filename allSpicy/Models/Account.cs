namespace allSpicy.Models;

public class Profile
{
  public string Name { get; set; }
  public string Id { get; set; }
  public string Picture { get; set; }
}

public class Account : Profile
{
  public string Email { get; set; }

}
