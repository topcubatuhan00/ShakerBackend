﻿using Shaker.Domain.Core;

namespace Shaker.Domain.Entities;

public class User : EntityBase
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
