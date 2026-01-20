using System;
using System.Collections.Generic;

namespace Champ2026Client.Models;

public partial class UserLogin
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
