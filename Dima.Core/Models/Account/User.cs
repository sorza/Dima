﻿namespace Dima.Core.Models.Account
{
    public class User
    {
        public string Email { get; set; } = string.Empty;
        public bool isEmailConfirmed { get; set; }
        public Dictionary<string, string> Claims { get; set; } = [];
    }
}
