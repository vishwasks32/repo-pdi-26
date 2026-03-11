using System;
using System.Linq;

namespace IPvalidatorApp
{
    public class IPv4Address
    {
        public string RawInput {get;}
        public byte[] Octets { get; private set;}
        public bool IsValid{ get; private set;}

        public IPv4Address(string input)
        {
            RawInput = input;
            Validate();
        }

        private void Validate()
        {
            string[] parts = RawInput.Split('.');

            if(parts.Length != 4)
            {
                IsValid = false;
                return;
            }

            byte[] tempOctets = new byte[4];
            for(int i = 0; i < 4; i++)
            {
                if(!byte.TryParse(parts[i], out byte value) ||
                (parts[i].Length > 1 && parts[i].StartsWith("0")))
                {
                    IsValid = false;
                    return;
                }

                tempOctets[i] = value;

            }

            Octets = tempOctets;
            IsValid = true;
        }
    }
    
}