﻿namespace ParsMarketCoreAPI
{
    public interface IPasswordHelper
    {
        string EncodePasswordMd5(string password);
    }
}
