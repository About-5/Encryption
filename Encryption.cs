using System;
using System.Text;

namespace TestingCS
{
    public class Encryption
    {
        public string encryptCaeser(string plainText, int shift)
        {
            StringBuilder cipherText = new StringBuilder("", plainText.Length);
            plainText = plainText.ToUpper();

            for (int i = 0; i < plainText.Length; i++)
            {
                int ascii = (int)plainText[i] + shift;
                if (ascii < 65)
                {
                    cipherText.Insert(i, plainText[i]);
                }
                else if (ascii < 91)
                {
                    cipherText.Insert(i, (char)ascii);
                }
                else
                {
                    ascii = ascii - 26;
                    cipherText.Insert(i, (char)ascii);
                }
            }

            return cipherText.ToString();
        }

        public string decryptCaeser(string cipherText, int shift)
        {
            StringBuilder plainText = new StringBuilder("", cipherText.Length);
            cipherText = cipherText.ToUpper();

            for (int i = 0; i < cipherText.Length; i++)
            {
                int ascii = (int)cipherText[i] - shift;
                if (ascii < 60)
                {
                    plainText.Insert(i, cipherText[i]);
                    
                }
                else if (ascii > 64)
                {
                    plainText.Insert(i, (char)ascii);
                }
                else
                {
                    ascii = ascii + 26;
                    plainText.Insert(i, (char)ascii);
                }
            }

            return plainText.ToString();
        }

        public string substitutionEncrypt(string plainText, string code)
        {
            StringBuilder cipherText = new StringBuilder("", plainText.Length);
            plainText = plainText.ToUpper();

            if (code.Length != 26)
            {
                Console.WriteLine("Bad encoding string \n");
                return null;
            }

            for (int i = 0; i < plainText.Length; i++)
            {
                int index = (int)plainText[i] - 65;

                if(index >= 0)
                {
                    int ascii = (int)code[index];
                    
                    if (ascii < 91)
                    {
                        cipherText.Insert(i, (char)ascii);
                    }
                    else 
                    {
                        ascii = ascii - 26;
                        cipherText.Insert(i, (char)ascii);
                    }
                }
                else
                {
                    cipherText.Insert(i, plainText[i]);
                }
            }

            return cipherText.ToString();
        }

        public string substitutionDecrypt(string cipherText, string code)
        {
            StringBuilder plainText = new StringBuilder("", cipherText.Length);
            cipherText = cipherText.ToUpper();

            if(code.Length != 26)
            {
                Console.WriteLine("Bad decoding string \n");
                return null;
            }

            for(int i = 0; i < cipherText.Length; i++)
            {
                int index = (int)cipherText[i] - 65;

                if (index >= 0)
                {
                    int ascii = (int)code[index];

                    if (ascii > 64)
                    {
                        plainText.Insert(i, (char)ascii);
                    }
                    else
                    {
                        ascii = ascii + 26;
                        plainText.Insert(i, (char)ascii);
                    }
                } 
                else
                {
                    plainText.Insert(i, cipherText[i]);
                }
            }

            return plainText.ToString();    
        }

        public static void Main(string[] args)
        {
            string plainText = "How is your day today";
            Encryption encrypt = new Encryption();
            int caeserShift = 5;
            string cipherText = encrypt.encryptCaeser(plainText, caeserShift);
            string decryptedText = encrypt.decryptCaeser(cipherText, caeserShift);
            Console.WriteLine("Caeser cipher: \n{0} \n{1} \n{2}", plainText, cipherText, decryptedText);
            string code = "ZXCVBNMASDFGHJKLPOIUYTREWQ";
            cipherText = encrypt.substitutionEncrypt(plainText, code);
            decryptedText = encrypt.substitutionEncrypt(cipherText, code);
            Console.WriteLine("Substitution: \n{0} \n{1} \n{2}", plainText, cipherText, decryptedText);
        }
    }
}
