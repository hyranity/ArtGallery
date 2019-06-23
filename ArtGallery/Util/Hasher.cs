using System.Security.Cryptography;
using System;

// This code is possible thanks to: 
// https://medium.com/@mehanix/lets-talk-security-salted-password-hashing-in-c-5460be5c3aae

public class Hasher
{
	byte[] Salt { get; set; }
	string HashedPassword { get; set; }

	public Hasher(string password)
	{
		// Randomly generate salt
		new RNGCryptoServiceProvider().GetBytes(Salt = new byte[16]);

		var pbkdf2 = new Rfc2898DeriveBytes(password, Salt, 10000);

		byte[] hash = pbkdf2.GetBytes(20);
		byte[] hashBytes = new byte[36];
		Array.Copy(Salt, 0, hashBytes, 0, 16);
		Array.Copy(hash, 0, hashBytes, 16, 20);

		HashedPassword = Convert.ToBase64String(hashBytes);
	}

	public Hasher(string password, byte[] Salt)
	{
		// Use existing salt to generate 
		var pbkdf2 = new Rfc2898DeriveBytes(password, Salt, 10000);

		byte[] hash = pbkdf2.GetBytes(20);
		byte[] hashBytes = new byte[36];
		Array.Copy(Salt, 0, hashBytes, 0, 16);
		Array.Copy(hash, 0, hashBytes, 16, 20);

		HashedPassword = Convert.ToBase64String(hashBytes);
	}

	public string GetHashedPassword()
	{
		return this.HashedPassword;
	}

	public byte[] GetSalt()
	{
		return Salt;
	}

	public static bool ComparePassword(string hashedPass, string enteredPass, byte[] hashedPassSalt)
	{
		Hasher hash = new Hasher(enteredPass, hashedPassSalt);
		string hashedSecondPass = hash.GetHashedPassword();
		if (hashedSecondPass == hashedPass)
			return true;
		else
			return false;
	}


}
