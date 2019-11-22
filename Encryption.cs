using System;
using System.Text;
using System.Collections.Generic;

namespace TestingCS
{
    public class Encryption
    {
        public string encryptCaeser(string plainText, int shift) {
            StringBuilder cipherText = new StringBuilder("", plainText.Length);
            plainText = plainText.ToUpper();

            for (int i = 0; i < plainText.Length; i++) {
                int ascii = (int)plainText[i] + shift;
                if (ascii < 65) {
                    cipherText.Insert(i, plainText[i]);
                } else if (ascii < 91) {
                    cipherText.Insert(i, (char)ascii);
                }
                else {
                    ascii = ascii - 26;
                    cipherText.Insert(i, (char)ascii);
                }
            }

            return cipherText.ToString();
        }

        public string decryptCaeser(string cipherText, int shift) {
            StringBuilder plainText = new StringBuilder("", cipherText.Length);
            cipherText = cipherText.ToUpper();

            for (int i = 0; i < cipherText.Length; i++) {
                int ascii = (int)cipherText[i] - shift;
                if (ascii < 39) {
                    plainText.Insert(i, cipherText[i]);
                    
                } else if (ascii > 64) {
                    plainText.Insert(i, (char)ascii);
                } else {
                    ascii = ascii + 26;
                    plainText.Insert(i, (char)ascii);
                }
            }

            return plainText.ToString();
        }

        public string substitutionEncrypt(string plainText, string code) {
            StringBuilder cipherText = new StringBuilder("", plainText.Length);
            plainText = plainText.ToUpper();

            if (code.Length != 26) {
                Console.WriteLine("Bad encoding string \n");
                return null;
            }

            for (int i = 0; i < plainText.Length; i++) {
                int index = (int)plainText[i] - 65;

                if(index >= 0) {
                    int ascii = (int)code[index];
                    
                    if (ascii < 91) {
                        cipherText.Insert(i, (char)ascii);
                    } else {
                        ascii = ascii - 26;
                        cipherText.Insert(i, (char)ascii);
                    }
                } else {
                    cipherText.Insert(i, plainText[i]);
                }
            }

            return cipherText.ToString();
        }

        public string substitutionDecrypt(string cipherText, string code) {
            StringBuilder plainText = new StringBuilder("", cipherText.Length);
            cipherText = cipherText.ToUpper();
            code = code.ToUpper();
            if (code.Length != 26) {
                Console.WriteLine("Bad encoding string \n");
                return null;
            }

            Dictionary<int, int> list = new Dictionary<int, int>()
            {
                {32, -33}
            };
            for(int i = 0; i < code.Length; i++) {
                list.Add(code[i], i);
            } 

            if(code.Length != 26) {
                Console.WriteLine("Bad decoding string \n");
                return null;
            }

            for(int i = 0; i < cipherText.Length; i++) {
                plainText.Insert(i, (char)(list[cipherText[i]] + 65));
            }

            return plainText.ToString();    
        }

        public string vigenereEncrypt(string plainText, string keyword) {
            StringBuilder cipherText = new StringBuilder("", plainText.Length);
            plainText = plainText.ToUpper();
            int count = 0;
            if(keyword.Length < 1) {
                Console.WriteLine("Bad keyword string \n");
                return null;
            }

            for(int i = 0; i < plainText.Length; i++) {
                int index = count % keyword.Length;
                int ascii = (int)plainText[i] + ((int)keyword[index] - 64);
                if(ascii < 65) {
                    cipherText.Insert(i, plainText[i]);
                } else if(ascii > 90) {
                    ascii = ascii - 26;
                    cipherText.Insert(i, (char)ascii);
                } else {
                    cipherText.Insert(i, (char)ascii);
                }
                count++;
            }
            return cipherText.ToString();
        }

        public string vigenereDecrypt(string CipherText, string keyword) {
            StringBuilder plainText = new StringBuilder("", CipherText.Length);
            CipherText = CipherText.ToUpper();
            int count = 0;
            if(keyword.Length < 1) {
                Console.WriteLine("Bad keyword string \n");
                return null;
            }

            for(int i = 0; i < CipherText.Length; i++) {
                int index = count % keyword.Length;
                int ascii = (int)CipherText[i] - ((int)keyword[index] - 64);
                if(ascii < 39) {
                    plainText.Insert(i, CipherText[i]);
                } else if(ascii > 64) {
                    plainText.Insert(i, (char)ascii);
                } else {
                    ascii = ascii + 26;
                    plainText.Insert(i, (char)ascii);
                }
                count++;
            }
            return plainText.ToString();
        }

        public static void Main(string[] args) {
            string plainText = "How is your day today";
            Encryption encrypt = new Encryption();
            int caeserShift = 10;
            string cipherText = encrypt.encryptCaeser(plainText, caeserShift);
            string decryptedText = encrypt.decryptCaeser(cipherText, caeserShift);
            Console.WriteLine("Caeser cipher: \n{0} \n{1} \n{2}", plainText, cipherText, decryptedText);
            string code = "ZXCVBNMASDFGHJKLPOIUYTREWQ";
            cipherText = encrypt.substitutionEncrypt(plainText, code);
            decryptedText = encrypt.substitutionDecrypt(cipherText, code);
            Console.WriteLine("Substitution: \n{0} \n{1} \n{2}", plainText, cipherText, decryptedText);
            string keyword = "DOG";
            cipherText = encrypt.vigenereEncrypt(plainText, keyword);
            decryptedText = encrypt.vigenereDecrypt(cipherText, keyword);
            Console.WriteLine("Vigenere cipher: \n{0} \n{1} \n{2}", plainText, cipherText, decryptedText);
        }
    }
}
