using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Common.Interfaces;
public interface IDataProtectionService
{
    string Encrypt(string plainText);
    string Decrypt(string cipherText);
}