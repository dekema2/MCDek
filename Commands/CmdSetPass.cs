using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Security.Authentication;
using System.Text;
using MCLawl;

namespace MCDek
{
    public class CmdSetPass : Command
    {
        public override string name { get { return "setpass"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        public CmdSetPass() { }

        public override void Use(Player p, string message)
        {
            if (p.group.Permission < Server.verifyadminsrank)
            {
                Player.SendMessage(p, "You do not have the &crequired rank " + Server.DefaultColor + "to use this command!");
                return;
            }
            if (Server.verifyadmins == false)
            {
                Player.SendMessage(p, "Verification of admins is &cdisabled!");
                return;
            }
            if (p.adminpen == true)
            {
                if (File.Exists("extra/passwords/" + p.name + ".xml"))
                {
                    Player.SendMessage(p, "&cYou already have a password set. " + Server.DefaultColor + "You &ccannot change " + Server.DefaultColor + "it unless &cyou verify it with &a/pass [Password]. " + Server.DefaultColor + "If you have &cforgotten " + Server.DefaultColor + "your password, contact &c" + Server.server_owner + Server.DefaultColor + " and they can &creset it!");
                    return;
                }
            }
            if (message == "")
            {
                Help(p);
                return;

            }
            int number = message.Split(' ').Length;
            if (number > 1)
            {
                Player.SendMessage(p, "Your password must be one word!");
                return;
            }
            Crypto.EncryptStringAES(message, "MCDekEncryption", p);
            Player.SendMessage(p, "Your password has &asuccessfully &abeen set to:");
            Player.SendMessage(p, "&c" + message);
            return;
        }
        public class Crypto
        {
            private static byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");

            /// <summary>
            /// Encrypt the given string using AES. The string can be decrypted using
            /// DecryptStringAES(). The sharedSecret parameters must match.
            /// </summary>
            /// <param name="plainText">The text to encrypt.</param>
            /// <param name="sharedSecret">A password used to generate a key for encryption.</param>
            public static string EncryptStringAES(string plainText, string sharedSecret, Player who)
            {
                if (string.IsNullOrEmpty(plainText))
                    throw new ArgumentNullException("plainText");
                if (string.IsNullOrEmpty(sharedSecret))
                    throw new ArgumentNullException("sharedSecret");

                string outStr = null; // Encrypted string to return
                RijndaelManaged aesAlg = null; // RijndaelManaged object used to encrypt the data.

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
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for encryption.
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {

                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }
                        }
                        outStr = Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
                finally
                {
                    // Clear the RijndaelManaged object.
                    if (aesAlg != null)
                        aesAlg.Clear();
                }

                // Return the encrypted bytes from the memory stream.
                if (!Directory.Exists("extra/passwords"))
                {
                    Directory.CreateDirectory("extra/passwords");
                }
                try
                {
                    if (File.Exists("extra/passwords/" + who.name + ".xml"))
                    {
                        File.Delete("extra/passwords/" + who.name + ".xml");
                    }
                    StreamWriter SW = new StreamWriter(File.Create("extra/passwords/" + who.name + ".xml"));
                    SW.WriteLine(outStr);
                    SW.Flush();
                    SW.Close();
                    File.WriteAllText("extra/passwords/" + who.name + ".xml", outStr);
                }
                catch
                {
                    Player.SendMessage(who, "&cFailed to Save Password, &aTry Again Later!");
                    Server.s.Log(who.name + " failed to save password.");
                }
                return outStr;

            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/setpass [Password] - Sets your admin password to [password].");
            Player.SendMessage(p, "Note: Do NOT set this as your Minecraft password!");
        }
    }
}

