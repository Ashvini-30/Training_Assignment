
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication3.EncryptedPassword
{
    public class EncryptedPassword
    {
        public static string Encode(string Password)
        {
            try
            {
                byte[] PasswordBytes = Encoding.UTF8.GetBytes(Password);
                string EncryptedData =Convert.ToBase64String(PasswordBytes);
                return EncryptedData;

            }
            catch(Exception ex)
            {
                throw new Exception("Error while decrypting" +ex.Message);
            }
        }
    }
}