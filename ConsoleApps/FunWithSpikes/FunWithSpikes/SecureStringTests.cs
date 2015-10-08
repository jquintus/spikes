using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace FunWithSpikes
{
    public static class SecureStringExtensions
    {
        /// <summary>
        /// http://blogs.msdn.com/b/fpintos/archive/2009/06/12/how-to-properly-convert-securestring-to-string.aspx
        /// </summary>
        /// <param name="securePassword"></param>
        /// <returns></returns>
        public static string ConvertToUnsecureString(this SecureString securePassword)
        {
            if (securePassword == null) throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }

    [TestFixture]
    public class SecureStringTests
    {
        [Test]
        public void ConvertToUnsecureString_ReturnsString()
        {
            // Assemble
            var secureString = new SecureString();
            var insecureString = "teenagers";
            foreach (var c in insecureString)
            {
                secureString.AppendChar(c);
            }

            // Act
            var actual = secureString.ConvertToUnsecureString();

            // Assert
            Assert.AreEqual(insecureString, actual);
        }
    }
}