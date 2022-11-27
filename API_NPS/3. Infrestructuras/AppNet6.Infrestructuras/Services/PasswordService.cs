﻿using AppNet6.Core.Exceptions;
using AppNet6.Infrestructuras.Interfaces;
using AppNet6.Infrestructuras.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Infrestructuras.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordOptions _option;
        public PasswordService(IOptions<PasswordOptions> option)
        {
            _option = option.Value;
        }

        public bool check(string hash, string password)
        {
            var part = hash.Split(".", 3);
            if (part.Length != 3)
            {
                throw new BusinessException("Hash no cuenta con el formato especificado");
            }
            var _iteration = Convert.ToInt32(part[0]);
            var _Salt = Convert.FromBase64String(part[1]);
            var _key = Convert.FromBase64String(part[2]);


            using (var algorithm = new Rfc2898DeriveBytes(password, _Salt, _iteration))
            {
                var keyToCheck = algorithm.GetBytes(_option.keySize);
                return keyToCheck.SequenceEqual(_key);
            }
        }

        public string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                _option.SaltSize,
                _option.Iterations
                ))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(_option.keySize));
                var salt = Convert.ToBase64String(algorithm.Salt);
                return $"{_option.Iterations}.{salt}.{key}";
            }
        }
    }
}
