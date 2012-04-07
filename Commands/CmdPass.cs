using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using MCLawl;

namespace MCDek
{
    public class CmdPass : Command
    {
        public override string name { get { return "pass"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        public CmdPass() { }
        public static string password = "";
        public static bool gotpass = false;

        public override void Use(Player p, string message)
        {
            string Owner = Server.server_owner;
            if (Server.server_owner == "Jeb")
            {
                Owner = "The Owner";
            }
            if (p.group.Permission < Server.verifyadminsrank)
            {
                Player.SendMessage(p, "You do not have the &crequired rank to use this command!");
                return;
            }
            if (Server.verifyadmins == false)
            {
                Player.SendMessage(p, "Verification of admins is &cdisabled!");
                return;
            }
            if (p.adminpen == false)
            {
                {
                    Player.SendMessage(p, "You have &calready verified" + Server.DefaultColor + ", why are you using this?");
                    Player.SendMessage(p, "To set a new password use &a/setpass [Pass]!");
                    return;
                }
            }
            if (p.passtries == 3)
            {
                p.Kick("Did you really think you could keep on guessing? =S");
                return;
            }
            int foundone = 0;
            if (message == "")
            {
                Help(p);
                return;

            }
            int number = message.Split(' ').Length;
            if (number > 1)
            {
                Player.SendMessage(p, "Your password must be &cone " + Server.DefaultColor + "word!");
                return;
            }
            if (!Directory.Exists("extra/passwords"))
            {
                Player.SendMessage(p, "You have not &cset a password, " + Server.DefaultColor + "use &a/setpass [Password] &cto set one!");
                return;
            }
            DirectoryInfo di = new DirectoryInfo("extra/passwords/");
            FileInfo[] fi = di.GetFiles("*.xml");
            Thread.Sleep(10);
            try
            {
                foreach (FileInfo file in fi)
                {
                    if (file.Name.Replace(".xml", "").ToLower() == p.name.ToLower())
                    {
                        foundone++;
                    }
                }
            }
            catch
            {
                Player.SendMessage(p, "An Error Occurred! Try again soon!");
                return;
            }
            if (foundone < 0)
            {
                Player.SendMessage(p, "You have not &cset a password, " + Server.DefaultColor + "use &a/setpass [Password] &cto set one!");
                return;
            }
            if (foundone > 1)
            {
                Player.SendMessage(p, "&cAn error has occurred!");
                return;
            }
            if (!File.Exists("extra/passwords/" + p.name + ".xml"))
            {
                Player.SendMessage(p, "You have not &cset a password, " + Server.DefaultColor + "use &a/setpass [Password] &cto set one!");
                return;
            }
            Crypto.DecryptStringAES(File.ReadAllText("extra/passwords/" + p.name + ".xml"), "MCDekEncryption", p, message);
            if (message == password)
            {
                Player.SendMessage(p, "Thank you, " + p.color + p.name + Server.DefaultColor + "! You have now &averified " + Server.DefaultColor + "and have &aaccess to admin commands and features!");
                if (p.adminpen == true)
                {
                    p.adminpen = false;
                }
                password = "";
                p.passtries = 0;
                return;
            }
            p.passtries++;
            Player.SendMessage(p, "&cIncorrect Password. " + Server.DefaultColor + "Remember your password is &ccase sensitive!");
            Player.SendMessage(p, "If you have &cforgotten your password, " + Server.DefaultColor + "contact " + Owner + " and they can reset it! &cIncorrect " + Server.DefaultColor + "Tries: &b" + p.passtries);
            return;
        }
        public class Crypto
        {
            // This is the base encryption salt! DO NOT CHANGE IT!!!
            private static byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");
            /// <summary>
            /// Encrypt the given string using AES. The string can be decrypted using
            /// DecryptStringAES(). The sharedSecret parameters must match.
            /// </summary>
            /// <param name="plainText">The text to encrypt.</param>
            /// <param name="sharedSecret">A password used to generate a key for encryption.</param>
            /// <summary>
            /// Decrypt the given string. Assumes the string was encrypted using
            /// EncryptStringAES(), using an identical sharedSecret.
            /// </summary>
            /// <param name="cipherText">The text to decrypt.</param>
            /// <param name="sharedSecret">A password used to generate a key for decryption.</param>
            public static string DecryptStringAES(string cipherText, string sharedSecret, Player who, string triedpass)
            {
                if (string.IsNullOrEmpty(cipherText))
                    throw new ArgumentNullException("cipherText");
                if (string.IsNullOrEmpty(sharedSecret))
                    throw new ArgumentNullException("sharedSecret");

                // Declare the RijndaelManaged object
                // used to decrypt the data.
                RijndaelManaged aesAlg = null;

                // Declare the string used to hold
                // the decrypted text.
                string plaintext = null;

                try
                {
                    // generate the key from the shared secret and the salt
                    Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    // Create the streams used for decryption.
                    byte[] bytes = Convert.FromBase64String(cipherText);
                    using (MemoryStream msDecrypt = new MemoryStream(bytes))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
                finally
                {
                    // Clear the RijndaelManaged object.
                    if (aesAlg != null)
                        aesAlg.Clear();
                }
                password = plaintext;
                gotpass = true;
                return plaintext;
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/pass [Password] - If you are an admin, use this command to verify");
            Player.SendMessage(p, "your login. You will need to use this to be given access to commands");
            Player.SendMessage(p, "Note: If you do not have a password, use /setpass [Password]");
        }
    }
}


