using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upr1.Others;
internal static class Encryption
{
    public static string Encrypt(string pass)
    {
        string encrypted = "";
        foreach (var ch in pass)
        {
            encrypted += (char)(ch + 1);
        }
        return encrypted;
    }
    public static string Decrypt(string enpass)
    {
        string decrypted = "";
        foreach (var ch in enpass)
        {
            decrypted += (char)(ch - 1);
        }
        return decrypted;
    }
}
