using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;


public abstract class HasherBase
{
    // Abstract method for hash calculation.
    public abstract byte[] CalculateHash(byte[] data);
    public abstract bool VerifyHash(byte[] data, byte[] hash);
}


public class MD5Hash : HasherBase
{
    public override byte[] CalculateHash(byte[] data)
    {
        using (MD5 md5 = new MD5CryptoServiceProvider())
        {
            return md5.ComputeHash(data);
        }
    }

    public override bool VerifyHash(byte[] data, byte[] hash)
    {
        // Calculate the hash of the data.
        byte[] computedHash = CalculateHash(data);

        // Compare the computed hash with the provided hash for equality.
        return StructuralComparisons.StructuralEqualityComparer.Equals(computedHash, hash);
    }

}

public class SHA256Hash : HasherBase
{
    public override byte[] CalculateHash(byte[] data)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(data);
        }
    }

    public override bool VerifyHash(byte[] data, byte[] hash)
    {
        // Calculate the SHA-256 hash of the data.
        byte[] computedHash = CalculateHash(data);

        // Compare the computed hash with the provided hash for equality.
        return StructuralComparisons.StructuralEqualityComparer.Equals(computedHash, hash);
    }
}
