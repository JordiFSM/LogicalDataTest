﻿namespace LogicalData.Domain.Modelos.ModelosEntidades
{
    public class MJwt
    {
        public string Key { get; set; } = String.Empty;
        public string Issuer { get; set; } = String.Empty;
        public string Audience { get; set; } = String.Empty;
        public string Subject { get; set; } = String.Empty;
    }
}
