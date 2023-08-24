using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChifrWithDB
{
    internal class Chifr
    {
        string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public string Chifrator(string message, int bias)
        {
            string result = "";
            foreach (char letter in message)
            {
                if (alphabet.IndexOf(letter) != -1)
                {
                    if (alphabet.IndexOf(letter) < 33)
                    {
                        int biasleter = alphabet.IndexOf(letter) + bias;
                        if (biasleter > 32) { biasleter -= 33; }
                        result += alphabet[bias];
                    }
                    else
                    {
                        int biasleter = alphabet.IndexOf(letter) + bias;
                        if (biasleter > 65) { biasleter -= 33; }
                        result += alphabet[biasleter];
                    }

                }
                else
                {
                    result += letter;
                }
            }

            return result;
        }

        public string DeChifrator(string message, int bias)
        {
            return Chifrator(message, (33 - bias));

        }
    }
}
