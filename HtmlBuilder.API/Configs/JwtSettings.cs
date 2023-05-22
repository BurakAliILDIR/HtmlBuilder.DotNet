﻿namespace HtmlBuilder.API.Configs
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience{ get; set; }
        public string Key{ get; set; }
        public long AccessTokenMinute { get; set; }
        public long RefreshTokenMinute { get; set; }
    }
}
