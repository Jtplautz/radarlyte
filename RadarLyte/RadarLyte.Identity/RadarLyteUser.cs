using Microsoft.AspNetCore.Identity;

namespace RadarLyte.Identity;
public class RadarLyteUser : IdentityUser 
{
    public bool Enabled { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modfied { get; set; }
}

